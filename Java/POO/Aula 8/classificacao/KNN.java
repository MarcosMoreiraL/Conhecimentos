package classificacao;

public class KNN 
{
    int k;
    ExemploComRotulo[] dados = null;

    class Info
    {
        double distance;
        int rotulo;
    }

    public KNN(int k)
    {
        this.k = k;
    }    

    public void setDadosTreinamento(ExemploComRotulo[] dados) throws Exception
    {
        if(dados.length > k)
        {
            this.dados = dados;
        }else
        {
            throw new Exception("Poucos dados de treinamento");
        }
    }

    int predizer(Exemplo teste) throws Exception
    {
        if(this.dados == null)
        {
            throw new Exception("Dados de treinamento - nao inicializado");
        }

        if(teste.atributos.length != dados[0].atributos.length)
        {
            throw new ExcecaoExemploInvalido(dados[0].atributos.length, teste.atributos.length);
        }

        //CALCULANDO A DISTÂNCIA PARA TODOS
        Info[] vetor = new Info[dados.length];
        for(int i = 0; i < dados.length; i++)
        {
            double soma = 0.0;
            for(int j = 0; j < dados[i].atributos.length; j++)
            {
                soma+= Math.pow(dados[i].atributos[j] - teste.atributos[j], 2);
            }
            vetor[i] = new Info();
            vetor[i].distance = Math.sqrt(soma);
            vetor[i].rotulo = dados[i].getRotulo();
        }

        vetor = ordenar(vetor, k);

        //VERIFICAR QUAL RÓTULO APARECE MAIS
        Info[] vetorTemp = vetor;
        int rotulo = 0, freq = 0;
        for(int i = 0; i <= k; i++)
        {
            int freqTemp = 0 , rotuloTemp = vetorTemp[i].rotulo;
            for(int j = 0; j < vetorTemp.length; j++)
            {
                    if(vetorTemp[j].rotulo == rotulo)
                    {
                        freqTemp++;
                    }
            }
            if(freqTemp > freq)
            {
                freq = freqTemp;
                rotulo = rotuloTemp;
            }
            freqTemp = 0;
        }
        return rotulo;
    }

    Info[] ordenar(Info[] vetor, int k)
    {
        Info[] vetorTemp = new Info[dados.length];

        for(int i = 0; i < vetor.length; i++)
        {
            for(int j = 0; j < vetorTemp.length; j++)
            {
                if(vetorTemp[j] == null)
                {
                    vetorTemp[j] = vetor[i];
                    break;
                }else
                {
                    if(vetor[i].distance <= vetorTemp[j].distance)
                    {
                        for(int l = vetorTemp.length - 1; l > j; l--)
                        {
                            vetorTemp[l] = vetorTemp[l - 1];
                        }
                        vetorTemp[j] = vetor[i];
                        break;
                    }
                }
            }
        }
        return vetorTemp;
    }
}

 class Exemplo
{
    double atributos[];

    public Exemplo(double[] atributos)
    {
        this.atributos = atributos;
    }

    public double[] getAtributos()
    {
        return this.atributos;
    }
}

class ExemploComRotulo extends Exemplo
{
    int rotulo;

    public ExemploComRotulo(double[] atributos, int rotulo) 
    {
        super(atributos);
        this.rotulo = rotulo;
    }

    public int getRotulo()
    {
        return this.rotulo;
    }
}
