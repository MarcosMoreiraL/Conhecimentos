package texto;

public class ImpressaoLimiteLargura implements PluginImpressao
{
    int largura;

    public ImpressaoLimiteLargura(int largura)
    {
        this.largura = largura;
    }

    @Override
    public void imprimir(String texto) 
    {
        String temp = "";
        String imprimir = "";
        for(int i = 0; i < texto.length(); i++)
        {
            if(texto.charAt(i) != ' ')
            {
                temp+=texto.charAt(i);
            } 
            if(texto.charAt(i) == ' ' || i + 1 == texto.length())
            {
                if(i + 1 == texto.length())
                {
                    if(temp.length() + imprimir.length() < this.largura)
                    {
                        imprimir += ' ' + temp;
                        temp = "";
                        //Impressao.imprimirLinha(imprimir);
                        System.out.println(imprimir);
                    }else
                    {
                        //Impressao.imprimirLinha(imprimir);
                        System.out.println(imprimir);
                        imprimir = "";
                        imprimir += temp;
                        System.out.println(imprimir);
                        //Impressao.imprimirLinha(imprimir);
                        temp = "";
                    }
                }else
                {
                    if(temp != "")
                    {
                        if(temp.length() + imprimir.length() < this.largura)
                        {
                            if(imprimir.length() > 0)
                            {
                                imprimir += ' ' + temp;
                                temp = "";
                            }else
                            {
                                imprimir += temp;
                                temp = "";
                            }
                        }else
                        {
                            //Impressao.imprimirLinha(imprimir);
                            System.out.println(imprimir);
                            imprimir = "";
                            imprimir += temp;
                            temp = "";
                        }
                    }
                }
            }
        }
    }   
}
