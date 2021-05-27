package geometria;

public class Comparacao 
{
    public static <T extends Comparable<T>> T maiorElemento(T[] v) 
    {
        int indiceMaior = 0;
        for(int i = 0; i < v.length; i++)
        {
            if(v[indiceMaior].compareTo(v[i]) < 0)
            {
                indiceMaior = n;
            }
        }
        return v[indiceMaior];
    }

    public static <T extends Comparable<T>> T menorElemento(T[] v) 
    {
        int indiceMenor = 0;
        for(int i = 0; i < v.length; i++)
        {
            if(v[indiceMenor].compareTo(v[i]) > 0)
            {
                indiceMenor = n;
            }
        }
        return v[indiceMenor];
    }
}
