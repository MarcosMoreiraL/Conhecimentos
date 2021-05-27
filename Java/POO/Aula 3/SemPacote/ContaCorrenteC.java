public class ContaCorrenteC 
{
    public String nome, cpf;
    public double saldo;

    public ContaCorrenteC(String nome, String cpf)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.saldo = 0.0;
    }

    public ContaCorrenteC(String nome, String cpf, double saldo)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.saldo = saldo;
    }
    
    double getSaldo()
    {
        return saldo;
    }

    String getTitular()
    {
        return nome + ',' + ' ' + cpf;
    }

    void depositar(double quantia)
    {
        if(quantia > 0 && nome != null && cpf != null)
        {
            saldo+=quantia;
        }
    }

    void sacar(double quantia)
    {
        if(quantia > 0 && quantia <= saldo && nome != null && cpf != null)
        {
            saldo-=quantia;
        }
    }

    static void transferir(ContaCorrenteC de, ContaCorrenteC para, double quantia)
    {
        if(de.nome != null && de.cpf != null && para.nome != null && para.cpf != null)
        {
            if(quantia > 0 && de.saldo >= quantia)
            {
                de.saldo -= quantia;
                para.saldo += quantia;
            }
        }
    }

}
