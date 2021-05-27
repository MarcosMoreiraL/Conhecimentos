package quadrilateros;

public class Quadrado extends Retangulo
{
    public Quadrado()
    {

    }

    
    public void setLados(double lado)
    {
        super.setLados(lado, lado);

        /* this.ladoAB = lado;
        this.ladoBC = lado;
        this.ladoCD = lado;
        this.ladoDA = lado;*/
    }

    @Override
    public String getPropriedades()
    {
        return super.getPropriedades() + " Todos os lados tem mesmo tamanho.";
    }
}
