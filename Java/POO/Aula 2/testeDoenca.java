import java.util.*;

public class testeDoenca 
{
    public static void main(String[] args)
    {
        boolean tosse = false, febre = false, faltaDeAr = false;
        Doenca doenca = new Doenca();
        Scanner sc = new Scanner(System.in);

        tosse = sc.nextBoolean();
        febre = sc.nextBoolean();
        faltaDeAr = sc.nextBoolean();

        doenca.setSintomas(tosse, febre, faltaDeAr);

        System.out.println(doenca.getDoenca());
        System.out.println(doenca.getRecomendacoes());
        
        sc.close();
    }
}
