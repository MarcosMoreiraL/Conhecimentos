package usuarios;

public class PerfilRedeSocial extends PerfilUsuario
{
    String mensagemPaginaInicial;

    public PerfilRedeSocial(String nome, String login) 
    {
        super(nome, login);
    }
    
    public PerfilRedeSocial(String nome, String login, String mensagemPaginaInicial) 
    {
        super(nome, login);
        this.mensagemPaginaInicial = mensagemPaginaInicial;
    }

    String getPerfil()
    {
        return String.format("%s %s", super.getNome(), this.mensagemPaginaInicial);
    }
}
