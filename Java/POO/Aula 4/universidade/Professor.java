package universidade;

public class Professor extends Pessoa
{

    public Professor()
    {

    }

    public String getEmail()
    {
        return this.nome + '.' + this.sobrenome + "@ufabc.edu.br";
    }

    public String getVinculo()
    {
        return "Professor da UFABC";
    }
}
