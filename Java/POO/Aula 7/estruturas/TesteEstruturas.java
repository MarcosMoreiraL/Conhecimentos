package estruturas;

public class TesteEstruturas 
{
    public static void main(String[] args)
    {
        Conjunto conjunto = new Conjunto();

        conjunto.adicionar(1);
        conjunto.adicionar(2);
        conjunto.adicionar(3);
        System.out.println(conjunto.buscar(2));
        System.out.println("Quantidade: " + conjunto.getQtd());
        conjunto.remover(2);
        System.out.println(conjunto.buscar(2));
        System.out.println("Quantidade: " + conjunto.getQtd());
    }   
}
