package raiz;

public class RaizQuadrada 
{
    static double calcular(double n) throws ExcecaoRaizNegativa
    {
        if(n < 0)
        {
            throw new ExcecaoRaizNegativa(n);
        }else
        {
            return Math.sqrt(n);
        }
    }   
}
