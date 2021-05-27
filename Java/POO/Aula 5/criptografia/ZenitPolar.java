package criptografia;

public class ZenitPolar implements Cifra
{
    @Override
    public String cifrar(String mensagem) 
    {
        char[] vetorPalavra = mensagem.toCharArray();
        for(int i = 0; i < vetorPalavra.length; i++)
        {
            switch(vetorPalavra[i])
            {
                case 'z':
                vetorPalavra[i] = 'p';
                break;
                case 'e':
                vetorPalavra[i] = 'o';
                break;
                case 'n':
                vetorPalavra[i] = 'l';
                break;
                case 'i':
                vetorPalavra[i] = 'a';
                break;
                case 't':
                vetorPalavra[i] = 'r';
                break;
                case 'p':
                vetorPalavra[i] = 'z';
                break;
                case 'o':
                vetorPalavra[i] = 'e';
                break;
                case 'l':
                vetorPalavra[i] = 'n';
                break;
                case 'a':
                vetorPalavra[i] = 'i';
                break;
                case 'r':
                vetorPalavra[i] = 't';
                break;
                default:
                break;
            }
        }
        return String.valueOf(vetorPalavra);
    }

    @Override
    public String decifrar(String mensagem) 
    {
        return cifrar(mensagem);
    }
    
}
