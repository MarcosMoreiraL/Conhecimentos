import java.util.*;

public class Login
{
    public static void main(String[] args)
    {
        String loginCadastrado = "flavio", senhaCadastrada = "1234",
        loginUsuario = " ", senhaUsuario = " ";

        Scanner sc = new Scanner(System.in);

        loginUsuario = sc.next();
        senhaUsuario = sc.next();

        if(loginUsuario.equals(loginCadastrado) && senhaUsuario.equals(senhaCadastrada))
        {
            System.out.println("Usuario flavio logado com sucesso");
        }else
        {
            System.out.println("Login ou senha invalidos");
        }
        sc.close();
    }
}