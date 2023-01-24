package texto;

public class testePlugin 
{
    public static void main(String[] args)
    {
        TextoABC textoAbc = new TextoABC("Neste exercicio, sao usados plugins.");

        textoAbc.imprimirTexto(new ImpressaoLimiteLargura(12));
    }    
}
