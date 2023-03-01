package lambdas;

public class CalculoTeste {
    public static void main(String[] args) {
        Calculo soma = new Soma();
        Calculo multiplicacao = new Multiplicacao();

        System.out.printf("SOMA: %.2f\n", soma.Executar(5, 2));
        System.out.printf("MULTIPLICAÇÃO: %.2f", multiplicacao.Executar(5, 2));
    }
}
