package texto;

public class PrimeiraLetraMaiuscula implements PluginFormatacao
{

    @Override
    public String aplicar(String texto) 
    {
        char[] vetorPalavra = toUpper(texto.toCharArray());

        return String.valueOf(vetorPalavra);
    }  
    
    public char[] toUpper(char[] vetor)
    {
        for(int i = 0; i < vetor.length; i++)
        {
            if(!isPontuacao(vetor[i]))
            {
                if(vetor[i] > 96)    //SE A LETRA É MINÚSCULA
                {
                    try
                    {
                        if(vetor[i] != ' ' && vetor[i - 1] == ' ')
                        {
                            vetor[i] -= 32;
                        }
                    }catch(Exception e)
                    {
                        vetor[i] -= 32;
                    }
                }else if(i > 0)
                {
                    if(vetor[i - 1] != ' ')
                    {
                        vetor[i] += 32;
                    }
                }
            }
        }
        return vetor;
    }

    boolean isPontuacao(char c)
    {
        char[] pontuacoes = {' ','.',',','/','?','!',';',':', '[', ']'};

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
