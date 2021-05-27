package navegador;

public class AbaBuscador extends AbaNavegador
{
    public AbaBuscador(String titulo)
    {
        this.titulo = titulo;
    }

    public void buscar(String expressao)
    {
        /* for(int i = 0; i < Navegador.listaHistorico.length; i++)
        {
            if(Navegador.listaHistorico[i].equals(null))
            {
                Navegador.listaHistorico[i] = "Busca: " + expressao;
            }
        } */

        Navegador.listaHistorico[navegador.Navegador.lastRegister] = "Busca: " + expressao;
        Navegador.lastRegister++;
    }

    @Override
    public String getTipo() 
    {
        return "Buscador";
    }
}
