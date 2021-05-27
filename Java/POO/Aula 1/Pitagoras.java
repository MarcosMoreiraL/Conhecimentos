import java.util.*;

public class Pitagoras
{
    public static class TriangleInfo
    {
        double a = 0.0, b = 0.0, c = 0.0;
    }

    public static void main(String[] args)
    {
        TriangleInfo info = new TriangleInfo();
        Scanner sc = new Scanner(System.in);

        info.a = sc.nextDouble();
        info.b = sc.nextDouble();
        info.c = sc.nextDouble();
        
        System.out.printf("%.1f", Result(info));
        sc.close();
    }  

    public static double Result(TriangleInfo info)
    {
        double result = 0.0;
        if(info.a == 0)
        {
            result = Math.sqrt(Math.pow(info.b, 2) + Math.pow(info.c, 2));
        }else if(info.b == 0)
        {
            result = Math.sqrt(Math.pow(info.a, 2) - Math.pow(info.c, 2));
        }else if(info.c == 0)
        {
            result = Math.sqrt(Math.pow(info.a, 2) - Math.pow(info.b, 2));
        }
        return result;
    }
}