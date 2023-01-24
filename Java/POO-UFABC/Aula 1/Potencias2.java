import java.util.*;

public class Potencias2
{
    public static void main(String[] args)
    {
        int qtd = 0;
        Scanner sc = new Scanner(System.in);

        qtd = sc.nextInt();
        int[] vetor = new int[qtd];
        for(int i = 0; i < qtd; i++)
        {
            vetor[i] = sc.nextInt();
        }

        System.out.printf("%d\n", Resultado(vetor));
        sc.close();
    }

    public static int Resultado(int[] vetor) 
    {
        int qtdPotencias = 0;
        for(int numero : vetor)
        {
            if(PotenciaDeDois(numero))
            {
                //System.out.printf("numero: %d true\n", numero);
                qtdPotencias++;
            }
        }

        return qtdPotencias;
    }

    public static boolean PotenciaDeDois(int numero)
    {
        if(numero%2 != 0)
        {
            return false;
        }else
        {
            while(numero != 2)
            {
                if(numero%2 != 0)
                {
                    //System.out.printf("Situação False: %d\n", numero);
                    return false;
                }else
                {
                    //System.out.printf("Situação True: %d\n", numero);
                    numero/=2;
                    //System.out.printf("Situação True: %d\n", numero);
                }
            }
            return true;
        }
    }
}