import java.util.*;

public class Pedido 
{
    Mesa mesa;
    Garcom garcom;
    List<Prato> prato = new ArrayList<Prato>();
    double total;

    public Pedido(Mesa mesa, Garcom garcom)
    {
        this.mesa = mesa;
        this.garcom = garcom;
    }

    void incluirPrato(Prato prato)
    {
        this.prato.add(prato);
        total+=prato.preco;
    }

    void fechar()
    {
        /*total = 0;
        for(int i = 0; i < prato.size(); i++)
        {
            total+=prato.get(i).preco;
        }*/
    }

    void imprimirPedido()
    {
        System.out.printf("%d\n%s\n", mesa.numero, garcom.nome);
        for(int i = 0; i < prato.size(); i++)
        {
            System.out.printf("%s\n", prato.get(i).nome);
        }
        System.out.printf("%.1f", total);
    }
}
