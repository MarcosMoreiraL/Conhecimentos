package cartoes;

public class CartaoCredito extends CartaoDebito
{
    public double valorDevido = 0.0;

    public CartaoCredito()
    {

    }

    public boolean pagarComCredito(double valor)
    {
        this.valorDevido += valor;
        return true;
    }

    public void quitarCredito(double valor)
    {
        this.valorDevido-=valor;
    }

    public double verificarExtrato()
    {
        return valorDevido;
    }
}
