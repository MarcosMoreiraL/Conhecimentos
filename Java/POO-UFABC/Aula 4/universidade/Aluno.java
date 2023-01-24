package universidade;

public class Aluno extends Pessoa
{
    public Aluno()
    {

    }

    public String getEmail()
    {
        return this.nome + '.' + this.sobrenome + "@aluno.ufabc.edu.br";
    }

    public String getVinculo()
    {
        return "Aluno da UFABC";
    }
}
