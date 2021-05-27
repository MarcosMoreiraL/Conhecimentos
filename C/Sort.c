#include<stdio.h>
#include<stdlib.h>

#pragma region BubbleSort
void BubbleSort(int *vetor, int length)
{
    int it = 0, pos = 0, temp = 0; //número de iterações, posição atual, temp pra troca

    for(it; it < length - 1; it++)
    {
        for(pos = 0; pos < length - it - 1; pos++)
        {
            //Comparar o elemento da iteração com o próximo
            if(vetor[pos] > vetor[pos + 1])
            {
                temp = vetor[pos];
                vetor[pos] = vetor[pos + 1];
                vetor[pos + 1] = temp;
            }
        }
    }
}
#pragma endregion BubbleSort

#pragma region SelectionSort
void SelectionSort(int *vetor, int length)
{
    int it = 0, posMenorInicial = 0, posMenorGeral = 0, temp = 0;

    for(it = 0; it < length - 1; it++)
    {
        posMenorInicial = it;
        posMenorGeral = it + 1; 
        for(int i = posMenorInicial + 1; i < length; i++)
        {
            if(vetor[i] < vetor[posMenorGeral])
            {
                posMenorGeral = i; 
            }
        }
        if(vetor[posMenorGeral] < vetor[posMenorInicial])
        {
            temp = vetor[posMenorInicial];
            vetor[posMenorInicial] = vetor[posMenorGeral];
            vetor[posMenorGeral] = temp;
        }
    }
}
#pragma endregion SelectionSort

#pragma region InsertionSort
void InsertionSort(int *vetor, int length)
{
    int carta = 0, it = 0, j = 0;

    for(it = 1; it < length; it++)
    {
        carta = vetor[it];
        for(j = it - 1; (j >= 0) && vetor[j] > carta; j--)
        {
            vetor[j + 1] = vetor[j];
        }
        vetor[j + 1] = carta;
    }
}
#pragma endregion InsertionSort

#pragma region QuickSort
int Partition(int *vetor, int length, int inicio, int fim)
{
    int ref = vetor[inicio], up = fim, down = inicio, temp = 0;

    while(down < up)
    {
        //encontrando um número maior que o ref (pivô)
        while (vetor[down] <= ref && down < fim)
        {
            down++;
        }
        //também quero fazer o mesmo a partir do fim
        while (vetor[up] > ref)
        {
            up--;
        }
        if(down < up) //eles não se cruzaram nos índices
        {
            temp = vetor[down];
            vetor[down] = vetor[up];
            vetor[up] = temp;
        }
    }
    vetor[inicio] = vetor[up];
    vetor[up] = ref;

    return up; //no final das contas é a posição d up que denota onde está o pivô
}

void QuickSort(int *vetor, int length, int inicio, int fim)
{
    int pivo = 0;

    if(inicio > fim)
    {
        return;
    }

    pivo = Partition(vetor, length, inicio, fim);
    QuickSort(vetor, length, inicio, pivo-1);
    QuickSort(vetor, length, pivo+1, fim);
}
#pragma endregion QuickSort

void Print(int *vetor, int length)
{
    for(int i = 0; i < length; i++)
    {
        printf("Elemento %d: %d\n", i, vetor[i]);
    }
}

int main()
{
    int vetor[7] = {25, 57, 48, 37, 12, 92, 33};
    // BubbleSort(vetor, 7);
    // SelectionSort(vetor, 7);
    // InsertionSort(vetor, 7);
    QuickSort(vetor, 7, 0, 7);
    Print(vetor, 7);

    return 0;
}