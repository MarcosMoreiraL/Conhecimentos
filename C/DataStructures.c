#include<stdio.h>
#include<stdlib.h>
#include<stdbool.h>

#pragma region Stack // PILHA SIMPLES
typedef struct stackNode_S
{
    int value;
    struct stackNode_S *ant;
}stackNode;

typedef struct stack_S
{ 
    int lenght;
    stackNode *last;
}stack;

stack* CreateStack()
{
    stack *newStack = malloc(sizeof(stack)); 

    newStack->last = NULL;
    newStack->lenght = -1;

    return newStack;
}

bool IsStackEmpty(stack *stack)
{
    return(stack->lenght == -1);
}

stackNode* CreateStackNode(int value)
{
    stackNode *newNode = malloc(sizeof(stackNode));

    newNode->ant = NULL;
    newNode->value = value;

    return newNode;
}

void Push(stack *stack, stackNode *node)
{
    if(node != NULL)
    {
        node->ant = stack->last;
        stack->lenght++;
        stack->last = node;
    }
}

void Pop(stack *stack)
{
    if(!IsStackEmpty(stack))
    {
        stack->last = stack->last->ant;
        stack->lenght--;
    }
}

void PrintStack(stack *stack)
{
    stackNode *temp = stack->last;

    if(IsStackEmpty(stack))
    {
        printf("Pilha vazia");
        return;
    }else
    {
        for(temp; temp != NULL; temp = temp->ant)
        {
            printf("Valor: %d\n", temp->value);
        }
    }
}
#pragma endregion Stack

#pragma region Queue //FILA SIMPLES
typedef struct queueNode_S
{
    int value;
    struct queueNode_S *next;
}queueNode;

typedef struct queue_S
{
    int count;
    queueNode *first;
    queueNode *last;
}queue;

queue* CreateQueue()
{
    queue *newQueue = malloc(sizeof(queue));
    newQueue->first = NULL;
    newQueue->last = NULL;
    newQueue->count = 0;

    return newQueue;
}

queueNode* CreateQueueNode(int value)
{
    queueNode *newNode = malloc(sizeof(queueNode));
    newNode->next = NULL;
    newNode->value = value;

    return newNode;
}

bool IsQueueEmpty(queue *queue)
{
    return(queue->count == 0);
}

void Enqueue(queue *queue, queueNode *node)
{
    if(IsQueueEmpty(queue))
    {
        queue->first = node;
        queue->last = node;
        queue->count++;
    }else
    {
        queue->last->next = node;
        queue->last = node;
        queue->count++;
    }
}

void Dequeue(queue *queue)
{
    if(!IsQueueEmpty(queue))
    {
        queue->first = queue->first->next;
        queue->count--;
    }
/*     if(queue->count == 0)
    {
        queue->first = NULL;
        queue->last = NULL;
    } */
}

void PrintQueue(queue *queue)
{
    queueNode *temp = queue->first;
    if(!IsQueueEmpty(queue))
    {
        for(temp; temp != NULL; temp = temp->next)
        {
            printf("Valor: %d\n", temp->value);
        }
    }
}
#pragma endregion Queue

#pragma region List //LISTA ENCADEADA SIMPLES

typedef struct listNode_S
{
    int value, index;
    struct listNode_S *next;
}listNode;

typedef struct list_S
{
    listNode *first;
    int count;
}list;

list* CreateList()
{
    list *newList = malloc(sizeof(list));
    newList->first = NULL;
    newList->count = 0;
    return newList;
}

listNode* CreateListNode(int value)
{
    listNode *newNode = malloc(sizeof(listNode));
    newNode->value = value;
    newNode->index = 0;
    newNode->next = NULL;

    return newNode;
}

bool isListEmpty(list *list)
{
    return (list->first == NULL);
}

void UpdateIndex(list *list)
{
    int index = 0;
    listNode *temp = list->first;

    if(!isListEmpty(list))
    {
        while(temp != NULL)
        {
            temp->index = index;
            temp = temp->next;
            index++;
        }
    }   
}

void ListAdd(list *list, listNode *node)
{
    if(isListEmpty(list))
    {
        list->first = node;
        node->index = 0;
    }else
    {
        listNode *temp = list->first;
        while (temp->next != NULL)
        {
            temp = temp->next;
        }
        temp->next = node;
        node->index = temp->index + 1;
        list->count++;
    }
}

void ListAddAtIndex(list *list, listNode *node, int index)
{
    if(isListEmpty(list))
    {
        list->first = node;
        node->index = 0;
    }else if(index <= list->count)
    {
        listNode *temp = list->first, *ant = NULL;
        while(temp != NULL && index > temp->index)
        {
            ant = temp;
            temp = temp->next;
        }
        if(index == 0)
        {
            node->next = list->first;
            list->first = node;
        }else
        {
            ant->next = node;
            node->next = temp;              
        }
        list->count++;
        UpdateIndex(list); 
    }else
    {
        printf("Indice nao existe na lista\n");
    }
}

void ListRemove(list *list, int value)
{
    if(!isListEmpty(list))
    {
        listNode *temp = list->first, *ant = NULL;
        while (temp != NULL && temp->value != value)
        {
            ant = temp;
            temp = temp->next;
        }
        if(temp != NULL)
        {
            if(ant == NULL) //REMOVENDO DO INÍCIO
            {
                list->first = temp->next;
                list->count--;
                free(temp);
                UpdateIndex(list);
            }else if(value == temp->value) //REMOVENDO DO MEIO/FIM
            {
                ant->next = temp->next;
                list->count--;
                free(temp);
                UpdateIndex(list);
            }
        }else
        {
            printf("O elemento nao esta na lista\n");
        }
    }
}

void ListRemoveAtIndex(list *list, int index)
{
    if(index >= list->count)
    {
        printf("Indice nao esta na lista\n");
        return;
    }
    if(!isListEmpty(list))
    {
        listNode *temp = list->first, *ant = NULL;
        while (temp != NULL && index > temp->index)
        {
            ant = temp;
            temp = temp->next;
        }
        if(temp != NULL)
        {
            if(ant == NULL) //REMOVENDO DO INÍCIO
            {
                list->first = temp->next;
                list->count--;
                free(temp);
                UpdateIndex(list);
            }else if(index == temp->index) //REMOVENDO DO MEIO/FIM
            {
                ant->next = temp->next;
                list->count--;
                free(temp);
                UpdateIndex(list);
            }
        }else
        {
            printf("O elemento nao esta na lista\n");
        }
    }
}

void PrintList(list *list)
{
    listNode *temp = list->first;
    if(!isListEmpty(list))
    {
        for(temp; temp != NULL; temp = temp->next)
        {
            printf("Valor: %d\n", temp->value);
        }
        printf("Tamanho da lista: %d\n", list->count);
    }else
    {
        printf("Lista vazia\n");
    }
}
#pragma endregion List

#pragma region DoubleList //LISTA CIRCULAR DUPLAMENTE ENCADEADA
typedef struct DListNode_S
{
    int value, index;
    struct DListNode_S *next, *ant;
}DListNode;

typedef struct DList_S
{
    DListNode *first;
    int count;
}DList;

bool isDListEmpty(DList *list)
{
    return (list->first == NULL);
}

DList* CreateDList()
{
    DList *newList = malloc(sizeof(DList));
    newList->count = 0;
    newList->first = NULL;
    return newList; 
}

DListNode* CreateDListNode(int value)
{
    DListNode *newNode = malloc(sizeof(DListNode));
    newNode->value = value;
    newNode->index = -1;
    newNode->ant = NULL;
    newNode->next = NULL;

    return newNode;
}

void DListUpdateIndex(DList *list)
{
    int index = 0;
    DListNode *temp = list->first;
    do
    {
        temp->index = index;
        temp = temp->next;
        index++;
    } while (temp != list->first);
}

void DListInsert(DList *list, DListNode *node)
{
    if(isDListEmpty(list))
    {
        list->first = node;
        node->ant = node;
        node->next = node;
        list->count++;
    }else
    {
        DListNode *temp = list->first;
        while (temp->next != list->first)
        {
            temp = temp->next;
        }
        temp->next = node;
        node->ant = temp;
        node->next = list->first;
        list->first->ant = node;
        list->count++;  
    }
    DListUpdateIndex(list);
}

void DListRemove(DList *list, int value)
{
    if(!isDListEmpty(list))
    {
        if(list->first->value == value)
        {
            if(list->count == 1)
            {
                free(list->first);
                list->first = NULL;
                list->count--;
            }else
            {
                DListNode *at = list->first, *ant = list->first->ant;
                list->first = at->next;
                ant->next = at->next;
                list->first->ant = ant;
                list->count--;
            }
        }else
        {
            DListNode *temp = list->first->next, *ant = temp->ant;
            while(temp != list->first && temp->value != value)
            {
                temp = temp->next;
                ant = temp->ant;
            }

            if(temp == list->first)
            {
                printf("Elemento nao encontrado\n");
                return;
            }else
            {
                ant->next = temp->next;
                temp->next->ant = ant;
                list->count--;
            }
        }
        DListUpdateIndex(list);
    }else
    {
        printf("Lista vazia\n");
    }
}

void DListPrint(DList *list)
{
    if(!isDListEmpty(list))
    {
        DListNode *temp = list->first;
        do
        {
            printf("Elemento %d: %d\n", temp->index, temp->value);
            temp = temp->next;
        } while (temp != list->first);
    }else
    {
        printf("Lista vazia\n");
    }
}
#pragma endregion DoubleList


int main()
{
    #pragma region StackExec
/*     stack *stack = CreateStack();
    int n = 0, value = 0;
    printf("Digitar o Numero de Elementos\n");
    scanf("%d", &n);
    for(int i = 0; i < n; i++)
    {
        scanf("%d", &value);
        Push(stack, CreateStackNode(value));
    }
    for(int i = 0; i < 2; i++)
    {
        Pop(stack);
    }
    PrintStack(stack); */
    #pragma endregion Stack

    #pragma region QueueExec
/*     queue *queue = CreateQueue(queue);
    int n = 0;
    scanf("%d", &n);

    for(int i = 0; i < n; i++)
    {
        int value = 0;
        scanf("%d", &value);
        Enqueue(queue, CreateQueueNode(value));
    }
    Dequeue(queue);
    Dequeue(queue);
    Dequeue(queue);
    Enqueue(queue, CreateQueueNode(55));
    Enqueue(queue, CreateQueueNode(56));
    Enqueue(queue, CreateQueueNode(57));
    PrintQueue(queue); */
    #pragma endregion QueueExec

    #pragma region ExecList
/*     list *list = CreateList();
    int n = 0;
    scanf("%d", &n);

    for(int i = 0; i < n; i++)
    {
        int value = 0;
        scanf("%d", &value);
        ListAdd(list, CreateListNode(value));
    }

    ListRemove(list, 1);
    ListRemove(list, 2);
    ListRemove(list, 3);

    ListAddAtIndex(list, CreateListNode(99), 3);
    ListRemoveAtIndex(list, 2);
    ListRemoveAtIndex(list, 8);

    PrintList(list); */
    #pragma endregion ExecList

    #pragma region ExecDoubleList
    // DList *list = CreateDList();
    // int n = 0;
    // scanf("%d", &n);

    //  for(int i = 0; i < n; i++)
    // {
    //     int value = 0;
    //     scanf("%d", &value);
    //     DListInsert(list, CreateDListNode(value));
    // }

    // DListRemove(list, 1);
    // DListRemove(list, 5);
    // DListRemove(list, 1);
    // DListRemove(list, 3);
    
    // DListPrint(list); 
    #pragma endregion ExecDoubleList

    return 0;
}