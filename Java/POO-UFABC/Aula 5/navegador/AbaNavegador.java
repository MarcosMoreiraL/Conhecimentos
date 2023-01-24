package navegador;

public abstract class AbaNavegador 
{
    protected String titulo;

    public String getTitulo()
    {
        return this.titulo;
    }

    public abstract String getTipo();
}
