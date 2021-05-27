package automotores;

public class Motocicleta extends Veiculo
{
    public boolean temCarroLateral;

    public Motocicleta()
    {

    }

    public void setTemCarroLateral(boolean temCarroLateral)
    {
        this.temCarroLateral = temCarroLateral;
    }

    @Override
    public String getTipo()
    {
        return "Motocicleta modelo " + this.modelo;
    }

    public boolean getTemCarroLateral()
    {
        return this.temCarroLateral;
    }
}
