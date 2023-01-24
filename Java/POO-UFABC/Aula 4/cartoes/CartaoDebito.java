package cartoes;

public class CartaoDebito 
{
    public String titular;
    public double saldo = 0.0;


    public CartaoDebito()
    {

    }   

    public void setTitular(String titular)
    {
        this.titular = titular;
    }

    public void adicionarSaldoDebito(double valor)
    {
        this.saldo+=valor;
    }

    public double verificarSaldoDebito()
    {
        return this.saldo;
    }

    public boolean pagarComDebito(double valor)
    {
        if(this.saldo >= valor)
        {
            this.saldo-=valor;
            return true;
        }else
        {
            return false;
        }
    }
}
