package raiz;

public class ExcecaoRaizNegativa extends Exception
{
    double parteComplexa;

    public ExcecaoRaizNegativa(double parteComplexa)
    {
        this.parteComplexa = parteComplexa;
    }

    public String dominioComplexos()
    {
        return String.format("0 + %fi", Math.sqrt(parteComplexa));
    }

    public String toString()
    {
        return("Raiz quadrada de numero negativo nao existe no dominio dos reais");
    }
}
