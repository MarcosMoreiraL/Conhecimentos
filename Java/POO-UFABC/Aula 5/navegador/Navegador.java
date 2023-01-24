package navegador;

public class Navegador 
{
    public int limiteAbas, nAbasAbertas = 0;
    public static int lastRegister = 0;

    public static String[] listaHistorico = new String[100];
    public AbaNavegador[] abasAbertas;


    public Navegador(int limiteAbas)
    {
        this.limiteAbas = limiteAbas;
        this.abasAbertas = new AbaNavegador[limiteAbas];
    } 

    public AbaNavegador abrirAba(int tipo, String titulo)
    {
       if(nAbasAbertas + 1 > limiteAbas)
       {
           return null;
       }else
       {
           switch(tipo)
           {
               case 1:
                    AbaBuscador newAbaBuscador = new AbaBuscador(titulo);
                    abasAbertas[nAbasAbertas] = newAbaBuscador;
                    nAbasAbertas++;
                    return newAbaBuscador;
                case 2:
                    AbaRedeSocial newAbaRedeSocial = new AbaRedeSocial(titulo);
                    abasAbertas[nAbasAbertas] = newAbaRedeSocial;
                    nAbasAbertas++;
                    return newAbaRedeSocial;
                default:
                    return null;
           }
       }
    }

    public void fecharAba(AbaNavegador aba)
    {
        AbaNavegador[] vetorTemp = new AbaNavegador[limiteAbas];
        int indice = 0;

        for(int i = 0; i < abasAbertas.length; i++)
        {
            if(abasAbertas[i] != aba)
            {
                vetorTemp[indice] = abasAbertas[i];
                indice++;
            }
        }
        nAbasAbertas--;
        abasAbertas = vetorTemp;
    }

    public String[] getAbas()
    {

        String[] listaAbas = new String[nAbasAbertas];
        for(int i = 0; i < listaAbas.length; i++)
        {
            listaAbas[i] = abasAbertas[i].getTipo() + ' ' + abasAbertas[i].getTitulo();
        }
        return listaAbas; 
    }

    public String[] getHistorico()
    {
        String[] vetorTemp = new String[lastRegister];

        for(int i = 0; i < vetorTemp.length; i++)
        {
            vetorTemp[i] = listaHistorico[i];
        }

        return vetorTemp;
    }
}