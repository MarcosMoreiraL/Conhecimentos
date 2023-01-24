package criptografia;

public class CifraCesar implements Cifra
{
    private int nShifts;

    public CifraCesar(int nShifts)
    {
        this.nShifts = nShifts;
    }   

    public String cifrar(String mensagem)
    {
        char[] vetorPalavra = mensagem.toCharArray();
        for(int i = 0; i < vetorPalavra.length; i++)
        {
            if(vetorPalavra[i] == ' ')
            {
                continue;   
            }else
            {
                if(vetorPalavra[i] + nShifts <= 'z')
                {
                    vetorPalavra[i] = (char) (vetorPalavra[i] + nShifts);
                }else
                {
                    int diferenca = 123 - vetorPalavra[i], restante = 0;
                    restante = nShifts - diferenca;
                    vetorPalavra[i] = (char) ('a' + restante);
                }
            }
        }
        return String.valueOf(vetorPalavra);
    }

    public  String decifrar(String mensagem)
    {
        char[] vetorPalavra = mensagem.toCharArray();
        for(int i = 0; i < vetorPalavra.length; i++)
        {
            if(vetorPalavra[i] == ' ')
            {
                continue;   
            }else
            {
                if(vetorPalavra[i] - nShifts >= 'a')
                {
                    vetorPalavra[i] = (char) (vetorPalavra[i] - nShifts);
                }else
                {
                    int diferenca = vetorPalavra[i] - 96, restante = 0;
                    restante = nShifts - diferenca;
                    vetorPalavra[i] = (char) ('z' - restante);
                }   
            }
        }
        return String.valueOf(vetorPalavra);
    }
}