#include<stdio.h>
#include<stdlib.h>

#pragma region BuscaSequencial
int BuscaSequencial(int value, int *vetor, int length)
{
    for(int i = 0; i < length; i++)
    {
        if(value == vetor[i])
        {
            return i;
        }
    }
    return -1;
}
#pragma endregion BuscaSequencial

#pragma region BuscaBinária

int BuscaBinaria(int valor, int *vetor, int length)
{
    int meio = 0, inicio = 0, fim = length;

    while(inicio <= fim)
    {
        meio = (inicio + fim) /2;
        if(valor == vetor[meio])
        {
            return meio;
        }else
        {
            if(valor > vetor[meio])
            {
                inicio = meio + 1;
            }else
            {
                fim = meio - 1;
            }
        }
    }return -1;
}

#pragma endregion BuscaBinária

int main()
{
    int n, *vetor;

    scanf("%d", &n);
    vetor = malloc(n*sizeof(int));

    for(int i = 0; i < n; i++)
    {
        scanf("%d", &vetor[i]);
    }

    int index = BuscaBinaria(10, vetor, n);
    
    if(index != -1)
    {
        printf("Encontrado na posicao: %d\n", index);
    }else
    {
        printf("Valor nao encontrado\n");
    }
    return 0;
}