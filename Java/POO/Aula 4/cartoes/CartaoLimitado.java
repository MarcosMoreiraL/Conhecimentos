package cartoes;

public class CartaoLimitado extends CartaoCredito
{
    public CartaoLimitado()
    {

    }   

    public boolean pagarComCredito(double valor)
    {
        if(valor + valorDevido > 200.0)
        {
            return false;
        }else
        {
            valorDevido+=valor;
            return true;
        }
    }
}
