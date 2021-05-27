

public class OperacaoMatematica 
{
    int valor1, valor2, resultado;

     void SetValor1(int valor1)
     {
        this.valor1 = valor1;
     }
     
     void SetValor2(int valor2)
     {
        this.valor2 = valor2;
     }

     void ExecutaOperacao(int operacao)
     {
        switch(operacao)
        {
            case 1:
            resultado = valor1 + valor2;
            break;
            case 2:
            resultado = valor1 - valor2;
            break;
            case 3:
            resultado = valor1 * valor2;
            break;
            case 4:
            resultado = valor1 / valor2;
            break;    
        }
     }

     int GetResultado()
     {
         return resultado;
     }
}
