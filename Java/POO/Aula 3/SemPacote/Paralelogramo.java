public class Paralelogramo 
{
    int tamanhoLadoA, tamanhoLadoB;

    public Paralelogramo(int tamanhoLadoA)
    {
        this.tamanhoLadoA = tamanhoLadoA;
        this.tamanhoLadoB = -1;
    }

    public Paralelogramo(int tamanhoLadoA, int tamanhoLadoB)
    {
        this.tamanhoLadoA = tamanhoLadoA;
        this.tamanhoLadoB = tamanhoLadoB;
    }

    int getArea()
    {
        if(tamanhoLadoB == -1)
        {
            return tamanhoLadoA * tamanhoLadoA;
        }else
        {
            return tamanhoLadoA *tamanhoLadoB;
        }
    }

    String getTipo()
    {
        if(tamanhoLadoB == -1 || tamanhoLadoA == tamanhoLadoB)
        {
            return "Paralelogramo quadrado";
        }else
        {
            return "Paralelogramo retangulo";
        }
    }
}
