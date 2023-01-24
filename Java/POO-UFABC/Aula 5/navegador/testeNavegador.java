package navegador;

public class testeNavegador 
{
    public static void main(String[] args)
    {
        final int n = 5;
        final Navegador navegador = new Navegador(n);
        AbaNavegador aba1 = navegador.abrirAba(1, "Buscador");
        AbaNavegador aba2 = navegador.abrirAba(1, "Rede Social");
        navegador.fecharAba(aba1);
        //AbaNavegador aba3 = navegador.abrirAba(1, "Buscador");
        String[] abas = navegador.getAbas();
        for(int i = 0; i < abas.length; i++)
        {
            System.out.println(abas[i]);
        }
    }
}
