package texto;

public class RemovePontuacao implements PluginFormatacao
{
    @Override
    public String aplicar(String texto) 
    {
        char[] vetorPalavra = texto.toCharArray();
        String temp = "";
        for(int i = 0; i < vetorPalavra.length; i++)
        {
            if(!isPontuacao(vetorPalavra[i]))
            {
                temp+= vetorPalavra[i];
            }
        }
        return temp;
    }

    boolean isPontuacao(char c)
    {
        char[] pontuacoes = {'.',',','/','?','!',';',':'};

        for(int i = 0; i < pontuacoes.length; i++)
        {
            if(c == pontuacoes[i])
            {
                return true;
            }
        }
        return false;
    }
}
