package quadrilateros;

public class Quadrilatero
{
    public double ladoAB, ladoBC, ladoCD, ladoDA;

    public Quadrilatero()
    {

    }

    public void setLados(double ladoAB, double ladoBC, double ladoCD, double ladoDA)
    {
        this.ladoAB = ladoAB;
        this.ladoBC = ladoBC;
        this.ladoCD = ladoCD;
        this.ladoDA = ladoDA;
    }

    public double getPerimetro()
    {
        return ladoAB + ladoBC + ladoCD + ladoDA;
    }

    public String getPropriedades()
    {
        return "Figura de quatro lados.";
    }
}