public class ArquivoTexto implements Cloneable
{
    String[] array;
    public ArquivoTexto(int nLinhas)
    {
        String[] array = new String[nLinhas];
        for(int i = 0; i < array.length; i++)
        {
            array[i] = "";
        }
        this.array = array;
    }

    @Override
    public ArquivoTexto clone() throws CloneNotSupportedException
    {
        return (ArquivoTexto) super.clone();
    }

    ArquivoTexto criarAtalho() throws CloneNotSupportedException
    {
        ArquivoTexto retornar = (ArquivoTexto)super.clone();
        return retornar;
    }

    ArquivoTexto criarBackup() throws CloneNotSupportedException
    {
        ArquivoTexto retornar = (ArquivoTexto)super.clone();
        retornar.array = this.array.clone();
        return retornar;
    }

    String ler()
    {
        String retornar = "";
        for(int i = 0; i < array.length; i++)
        {
            if(i + 1 < array.length)
            {
                retornar+= array[i] + '\n';
            }else
            {
                retornar+= array[i];
            }
        }
        return retornar;
    }

    void modificarLinha(int indiceLinha, String novaString)
    {
        array[indiceLinha] = novaString;
    }
}
