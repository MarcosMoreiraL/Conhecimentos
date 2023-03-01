package lambdas;

public class CalculoTeste2 {
    public static void main(String[] args) {
        Calculo soma = (x, y) -> x / y;

        System.out.println(soma.Executar(6, 3));
    }
} 
