package palavras;

public class PalavraEncontrada 
{
    public String palavra = "";
    public int[] posicao = new int[2];
    public int tipo = 0;
    public int direcao = 0;

    public PalavraEncontrada()
    {

    }

    public String getPalavra()
    {
        return this.palavra;
    }

    public int[] getPosicao()
    {
        return this.posicao;
    } 

    public int getTipo()
    {
        return this.tipo;
    }

    public int getDirecao()
    {
        return this.direcao;
    }
}
