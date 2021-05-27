#include<stdio.h>
#include<stdlib.h>
#include<stdbool.h>

typedef struct Node_S
{
    int value;
}node;

typedef struct Tree_S
{
    int balance;
    node *element;
    struct Tree_S *left;
    struct Tree_S *right;
}tree;

bool IsEmpty(tree *tree)
{
    if(tree == NULL || tree->element == NULL)
    {
        return true;
    }else
    {
        return false;
    }
    //return (tree->element == NULL);
}

node* CreateNode(int value)
{
    node *newNode = malloc(sizeof(node));
    newNode->value = value; 
    return newNode;
}

tree* CreateTree()
{
    tree *newTree = malloc(sizeof(tree));
    newTree->element = NULL;
    newTree->left = NULL;
    newTree->right = NULL;
    newTree->balance = 0;
    return newTree;
}

int CalcHeight(tree *curTree)
{
    if(!IsEmpty(curTree))
    {
        if(curTree->left == NULL && curTree->right == NULL) //NÃO TENHO NENHUM FILHO
        {
            return 1;
        }else if(curTree->left != NULL && curTree->right == NULL)
        {
            return 1 + CalcHeight(curTree->left);
        }else if(curTree->left == NULL && curTree->right != NULL)
        {
            return 1 + CalcHeight(curTree->right);
        }else
        {
            int leftHeight = CalcHeight(curTree->left), rightHeight = CalcHeight(curTree->right);
            if(leftHeight >= rightHeight)
            {
                return 1 + leftHeight;
            }else
            {
                return 1 + rightHeight;
            }
        }
    }
}

void CalcBalance(tree *curTree)
{
    if(curTree->left == NULL && curTree->right == NULL)
    {
        curTree->balance = 0;
    }else if(curTree->left == NULL && curTree->right != NULL)
    {        curTree->balance = CalcHeight(curTree->right) - 0;
    }else if(curTree->right == NULL && curTree->left != NULL)
    {
        curTree->balance =  0 - CalcHeight(curTree->left);
    }else
    {
        curTree->balance = CalcHeight(curTree->right) - CalcHeight(curTree->left);
    }
    if(curTree->right != NULL)
    {
        CalcBalance(curTree->right);
    }
    if(curTree->left != NULL)
    {
        CalcBalance(curTree->left);
    }
}

#pragma region RotationMethods

tree* SimpleRightRotation(tree *curTree)
{
    tree *rightChild = curTree->right, *childOfChild = NULL;

    if(curTree->right != NULL)
    {
        if(curTree->right->left != NULL)
        {
            childOfChild = rightChild->left;
        }
    }
    rightChild->left = curTree;
    curTree->right = childOfChild;

    return rightChild;
}

tree* DoubleRightRotation(tree *curTree)
{
    tree *thisTree = curTree;
    tree *rightChild = curTree->right, *childOfChild = rightChild->left;
    tree *insertedNode = childOfChild->right;

    rightChild->left = insertedNode;
    childOfChild->right = rightChild;
    thisTree->right = childOfChild;

    tree *newRightChild = curTree->right;
    thisTree->right = NULL;
    newRightChild->left = thisTree;

    return newRightChild;
}

tree* SimpleLeftRotation(tree *curTree)
{
    tree *leftChild = curTree->right, *childOfChild = NULL;

    if(curTree->left != NULL)
    {
        if(curTree->left->right != NULL)
        {
            childOfChild = leftChild->right;
        }
    }
    leftChild->right = curTree;
    curTree->left = childOfChild;

    return leftChild;
}

tree* DoubleLeftRotation(tree *curTree)
{
    tree *thisTree = curTree;
    tree *leftChild = curTree->left, *childOfChild = leftChild->right;
    tree *insertedNode = childOfChild->left;

    leftChild->right = insertedNode;
    childOfChild->left = leftChild;
    thisTree->left = childOfChild;

    tree *newLeftChild = curTree->left;
    thisTree->left = NULL;
    newLeftChild->right = thisTree;

    return newLeftChild;
}

tree* VerifyBalance(tree *curTree)
{
    if(curTree->balance >= 2 || curTree->balance <= -2) 
    {
        if(curTree->balance >= 2) //RODANDO PRA DIREITA
        {
            if(curTree->balance * curTree->right->balance > 0)
            {
                return SimpleRightRotation(curTree);
            }else
            {
                return DoubleRightRotation(curTree);
            }
        }else //RODANDO PRA ESQUERDA
        {
            if(curTree->balance * curTree->left->balance > 0)
            {
                return SimpleLeftRotation(curTree);
            }else
            {
                return DoubleLeftRotation(curTree);
            }
        }
    }
    CalcBalance(curTree);
    if(curTree->left != NULL) curTree->left = VerifyBalance(curTree->left);

    if(curTree->right != NULL) curTree->right = VerifyBalance(curTree->right);
    return curTree;
}
#pragma endregion RotationMethods

tree* Insert(tree *curTree, node *newNode)
{
    //printf("Inserindo o valor: %d\n", newNode->value);
    if(IsEmpty(curTree))
    {
        curTree->element = newNode;
        printf("Inseri o valor: %d na arvore vazia\n", curTree->element->value);
    }else
    {
        //printf("Nao vazia\n");
        tree *newTree = CreateTree();
        newTree->element = newNode;
        if(newNode->value < curTree->element->value) //INSERINDO NA ESQUERDA
        {
            if(curTree->left == NULL)
            {
                curTree->left = newTree;
                printf("Inseri o valor: %d a esquerda do valor: %d\n", curTree->left->element->value, curTree->element->value);
            }else
            {
                curTree->left = Insert(curTree->left, newNode);
            }
        }else if(newNode->value > curTree->element->value) //INSERINDO NA DIREITA
        {
            //printf("Tentando inserir o valor: %d a direita\n", newNode->value);
            if(curTree->right == NULL)
            {
                curTree->right = newTree;
                printf("Inseri o valor: %d a direita do valor: %d\n", curTree->right->element->value, curTree->element->value);
            }else
            {
                curTree->right = Insert(curTree->right, newNode);
            }
        }
    }
    CalcBalance(curTree);
    return curTree;
}

tree* Remove(tree *curTree, int value)
{
    if(!IsEmpty(curTree))
    {
        //Achei o elemento
        if(curTree->element->value == value)
        {
            //O Elemento está em um nó folha
            if(curTree->left == NULL && curTree->right == NULL)
            {
                free(curTree);
                return NULL;
            }else 
            {
                if(curTree->left != NULL && curTree->right == NULL) //TENHO FILHOS SÓ NA ESQUERDA
                {
                    return curTree->left;
                }else if(curTree->right != NULL && curTree->left == NULL) //TENHO FILHOS SÓ NA DIREITA
                {
                    return curTree->right;
                }else //TENHO FILHOS NOS DOIS LADOS
                {
                    //ADOTANDO A ESTRATÉGIA DO MAIOR DENTRE OS MENORES
                    tree *temp = curTree->left;
                    while(temp->right != NULL) //PERCORRENDO A ÁRVORE ATÉ O ÚLTIMO NÓ DA DIREITA DA SUB-ÁRVORE DA ESQUERDA
                    {
                        temp = temp->right;
                    }

                    curTree->element = temp->element; //TROQUEI OS ELEMENTOS DA ÁRVORE
                    temp->element = CreateNode(value); 

                    curTree->left = Remove(curTree->left, value);
                    free(temp);
                }
            }
        }else if(value < curTree->element->value) //NÃO ACHEI O ELEMENTO E O VALOR É MENOR, DELEGO PARA A SUB-ÁRVORE ESQUERDA
        {
            curTree->left = Remove(curTree->left, value);
        }else if(value > curTree->element->value) //NÃO ACHEI O ELEMENTO E O VALOR É MAIOR, DELEGO PARA A SUB-ÁRVORE DIREITA
        {
            curTree->right = Remove(curTree->right, value);
        }
        //printf("nao achei\n");
        return curTree; 
    }else
    {
        return curTree;
    } 
}

bool Search(tree *curTree, int value)
{
    //printf("Buscando...\n\n");
    if(IsEmpty(curTree))
    {
        return false;
        printf("Arvore Vazia\n");
    }
    if(curTree->element->value == value)
    {
        return true;
        //printf("Achei o %d\n", tree->node->value);
    }else
    {
        if(value < curTree->element->value) //PROCURANDO NA ESQUERDA
        {
            if(curTree->left == NULL)
            {
                return false;
            }else
            {
               return Search(curTree->left, value); 
            }
        }else if(value > curTree->element->value) //PROCURANDO NA DIREITA
        {
            if(curTree->right == NULL)
            {
                return false;
            }else
            {
               return Search(curTree->right, value); 
            }
        }
    }
}

void PrintPreOrder(tree *tree)
{
    if(IsEmpty(tree))
    {
        printf("Arvore Vazia\n");
        return;
    }else
    {
        printf("%d balanceamento: %d\n", tree->element->value, tree->balance);
        if(tree->left != NULL)
        {
            PrintPreOrder(tree->left);
        }
        if(tree->right != NULL)
        {
            PrintPreOrder(tree->right);
        }
    }
}

void PrintInOrder(tree *tree)
{
    if(IsEmpty(tree))
    {
        printf("Arvore Vazia\n");
    }else
    {
        if(tree->left != NULL)
        {
            PrintInOrder(tree->left);
        }
        printf("%d\n", tree->element->value);
        if(tree->right != NULL)
        {
            PrintInOrder(tree->right);
        }
    }
}

void PrintInOrderReverse(tree *tree)
{
    if(IsEmpty(tree))
    {
        printf("Arvore Vazia\n");
    }else
    {
        if(tree->right != NULL)
        {
            PrintInOrderReverse(tree->right);
        }
        printf("%d\n", tree->element->value);
        if(tree->left != NULL)
        {
            PrintInOrderReverse(tree->left);
        }
    }
}

void PrintPostOrder(tree *tree)
{
    if(IsEmpty(tree)) 
    {
        printf("Arvore vazia\n");
    }else
    {
        if(tree->right != NULL)
        {
            PrintPostOrder(tree->right);
        }
        if(tree->left != NULL)
        {
            PrintPostOrder(tree->left);
        }
        printf("%d\n", tree->element->value);
    }
}

tree* DeleteTree(tree *curTree)
{
    if(!IsEmpty(curTree))
    {
        if(curTree->right != NULL)
        {
            curTree->right = DeleteTree(curTree->right);
        }
        if(curTree->left != NULL)
        {
            curTree->left = DeleteTree(curTree->left);
        }
        return NULL;
    }
}

int main()
{
    tree *tree = CreateTree();
    int n = 0;
    bool search = false;
    scanf("%d", &n);

    for(int i = 0; i < n; i++)
    {
        int value = 0;
        scanf("%d", &value);
        tree = Insert(tree, CreateNode(value));
        CalcBalance(tree);
    }

    // for(int j = 0; j < n; j++)
    // {
    //     int value = 0;
    //     scanf("%d", &value);
    //     if(Search(tree, value))
    //     {
    //         printf("Achei o %d\n", value);
    //     }else
    //     {
    //         printf("Nao Achei\n");
    //     }
    // }

    printf("Antes de Rotacionar\n");
    PrintPreOrder(tree);
    printf("Apagando\n");
    tree = DeleteTree(tree);
    PrintPreOrder(tree);
    // CalcBalance(tree);
    // tree = VerifyBalance(tree);
    // CalcBalance(tree);
    // printf("Depois de Rotacionar\n");
    // PrintPreOrder(tree);
    //PrintInOrder(tree);
    //printf("In-OrderReverso\n");
    //PrintInOrderReverse(tree);
    // PrintPostOrder(tree);
    return 0;
}
