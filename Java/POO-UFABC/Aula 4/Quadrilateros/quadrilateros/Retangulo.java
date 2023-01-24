package quadrilateros;

public class Retangulo extends Paralelogramo
{
    public Retangulo()
    {

    }   

    @Override
    public String getPropriedades()
    {
        return super.getPropriedades() + " Angulo de 90 graus em todos os vertices.";
    }
}
