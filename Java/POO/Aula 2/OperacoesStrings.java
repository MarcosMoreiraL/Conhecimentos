public class OperacoesStrings
{
    public String texto;

    void setTexto(String texto)
    {
        this.texto = texto;
    }

    String getTexto()
    {
        return texto;
    }

    int contaPalavras()
    {
        int nPalavras = 0;
        boolean contando = false;
        for(int i = 0; i < texto.length(); i++)
        {
            if(texto.charAt(i) != ' ' && texto.charAt(i) != ',' && texto.charAt(i) != '.' && texto.charAt(i) != '!' 
            && texto.charAt(i) != '?')
            {
                contando = true;
            }else
            {
                if(contando)
                {
                    nPalavras++;
                    contando = false;
                }
            }

            if(i+1 == texto.length())
            {
                if(contando)
                {
                    nPalavras++;
                    contando = false;
                }
            }
        }
        return nPalavras;
    }

    double comprimentoMedioPalavras()
    {
        int nPalavras = contaPalavras(), tamanho = 0, somatorio = 0;
        boolean contando = false;
        double nPalavrasDouble = nPalavras;
        for(int i = 0; i < texto.length(); i++)
        {
            if(texto.charAt(i) != ' ' && texto.charAt(i) != ',' && texto.charAt(i) != '.' && texto.charAt(i) != '!' 
            && texto.charAt(i) != '?')
            {
                contando = true;
                tamanho++;
            }else
            {
                if(contando)
                {
                    somatorio+=tamanho;
                    tamanho = 0;
                    contando = false;
                }
            }
            if(i+1 == texto.length())
            {
                if(contando)
                {
                    somatorio+=tamanho;
                    tamanho = 0;
                    contando = false;
                }
            }
        }

        return somatorio/nPalavrasDouble;
    }

    String maiorPalavra()
    {
        int inicio = 0, fim = 0, inicioTemp = 0, tamanhoTemp = 0, maiorTamanho = 0;
        String palavra = "";
        boolean contando = false;

        for(int i = 0; i < texto.length(); i++)
        {
            if(texto.charAt(i) != ' ' && texto.charAt(i) != ',' && texto.charAt(i) != '.' && texto.charAt(i) != '!' 
            && texto.charAt(i) != '?')
            {
                if(!contando)
                {
                    inicioTemp = i;
                }
                contando = true;
                tamanhoTemp++;
            }else
            {
                if(contando)
                {
                    if(tamanhoTemp > maiorTamanho)
                    {
                        maiorTamanho = tamanhoTemp;
                        inicio = inicioTemp;
                        fim = i - 1;
                    }
                    tamanhoTemp = 0;
                    contando = false;
                }
            }
            if(i+1 == texto.length())
            {
                if(contando)
                {
                    if(tamanhoTemp > maiorTamanho)
                    {
                        maiorTamanho = tamanhoTemp;
                        inicio = inicioTemp;
                        fim = i;
                    }
                    tamanhoTemp = 0;
                    contando = false;
                }
            }
        }
        //MONTANDO A STRING FINAL
        for(int i = inicio; i <= fim; i++)
        {
            palavra+=texto.charAt(i);
        }
        return palavra;
    }

    int comprimentoMaiorPalavra()
    {
        String palavra = maiorPalavra();
        int comprimento = 0;
        for(int i = 0; i < palavra.length(); i++)
        {
            comprimento++;
        }
        return comprimento;
    }
}