package texto;

public class TextoABC 
{
    String texto;

    public TextoABC(String texto)
    {
        this.texto = texto;
    }

    public void aplicarFormatacao(PluginFormatacao plugin)
    {
        plugin.aplicar(this.texto);
    }

    public void imprimirTexto(PluginImpressao plugin)
    {
        plugin.imprimir(texto);
    }
}
