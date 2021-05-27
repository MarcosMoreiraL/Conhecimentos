package classificacao;

public class ExcecaoExemploInvalido extends Exception
{
    int qtdTreinamento, qtdPredizer;

    public ExcecaoExemploInvalido(int qtdTreinamento, int qtdPredizer)
    {
        this.qtdTreinamento = qtdTreinamento;
        this.qtdPredizer = qtdPredizer;
    }

    public int getQtdAtributosTreinamento()
    {
        return this.qtdTreinamento;
    }

    public int getQtdAtributosPredizer()
    {
        return this.qtdPredizer;
    }
}
