public class Email
{
    static String dominio = "@dominio.generico.com.br";
    String email = "";
    private static int totalEmails = 0;

    public Email(String email)
    {
        if(email.charAt(0) == '@')
        {
            this.dominio = email;
        }else
        {
            this.email = email;
            this.totalEmails++;
        }
    }

    String getEmail()
    {
        return this.email + dominio;
    }

    static int getTotalEmails()
    {
        return totalEmails;
    }
}   