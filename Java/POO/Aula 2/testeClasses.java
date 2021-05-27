import java.util.*;

public class testeClasses 
{
    public static void main(String args[])
    {
        Scanner sc = new Scanner(System.in);
        String texto = " ";
        OperacoesStrings opStrings = new OperacoesStrings();

        texto = sc.nextLine();

        opStrings.setTexto(texto);
        System.out.println(opStrings.getTexto());
        System.out.println(opStrings.contaPalavras());
        System.out.println(opStrings.comprimentoMedioPalavras());
        System.out.println(opStrings.maiorPalavra());
        System.out.println(opStrings.comprimentoMaiorPalavra());

        sc.close();
    }   
}
