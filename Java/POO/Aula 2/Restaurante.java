import java.util.*;

public class Restaurante 
{
    public static void main(String[] args)
    {
        int nPedidos = 0;
        Scanner sc = new Scanner(System.in);
        Mesa mesa = new Mesa(sc.nextInt(), true);
        Garcom garcom = new Garcom(sc.next());
        Pedido pedido = new Pedido(mesa, garcom);

        nPedidos = sc.nextInt();

        for(int i = 0; i < nPedidos; i++)
        {
            pedido.incluirPrato(new Prato(sc.next(), sc.nextDouble()));
        }
        pedido.fechar();
        pedido.imprimirPedido();

        sc.close();
    }
}
