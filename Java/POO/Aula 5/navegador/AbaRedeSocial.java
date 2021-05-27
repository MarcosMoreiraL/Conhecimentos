package navegador;

public class AbaRedeSocial extends AbaNavegador
{
    
    public AbaRedeSocial(String titulo)
    {
        this.titulo = titulo;
    }

    public void postar(String texto)
    {
        /* for(int i = 0; i < Navegador.listaHistorico.length; i++)
        {
            if(Navegador.listaHistorico[i].equals(null))
            {
                Navegador.listaHistorico[i] = "Post: " + texto;
            }
        } */

        Navegador.listaHistorico[navegador.Navegador.lastRegister] = "Post: " + texto;
        Navegador.lastRegister++;
    }

    @Override
    public String getTipo() 
    {
        return "RedeSocial";
    }
}
