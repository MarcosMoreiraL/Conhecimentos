import java.util.*;

public class Triangular 
{
    public static void main(String[] args) 
    {
        int n = 0;
        Scanner sc = new Scanner(System.in);
        n = sc.nextInt();
        boolean triangular = VerificaNumero(n);

        if(triangular)
        {
            System.out.println("SIM");
        }else
        {
            System.out.println("NAO");
        }
        sc.close();
    }

    public static boolean VerificaNumero(int n)
    {
        for(int i = 1; i < n; i++)
        {
            if((i * (i + 1) * (i + 2)) == n)
            {
                return true;
            }
        }
        return false;
    }
}
