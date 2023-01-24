package automotores;

public class Veiculo
{
    public String modelo;

    public Veiculo()
    {

    }

    public void setModelo(String modelo)
    {
        this.modelo = modelo;
    }

    public String getTipo()
    {
        return "Veiculo generico modelo " + this.modelo;
    }
}