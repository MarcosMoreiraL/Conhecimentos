package automotores;

public class Carro extends Veiculo
{
    public int nPortas;

    public Carro()
    {

    }   

    public void setNumeroPortas(int nPortas)
    {
        this.nPortas = nPortas;
    }

    @Override
    public String getTipo()
    {
        return "Carro modelo " + this.modelo;
    }

    public int getNumeroPortas()
    {
        return this.nPortas;
    }
}
