public class Doenca 
{
    boolean tosse, febre, faltaDeAr;

    void setSintomas(boolean tosse, boolean febre, boolean faltaDeAr)
    {
        this.tosse = tosse;
        this.febre = febre;
        this.faltaDeAr = faltaDeAr;
    }

    String getDoenca()
    {
        String doenca = "";

        if(tosse && febre && faltaDeAr)
        {
            doenca = "coronavirus";
        }else if(tosse && febre && !faltaDeAr)
        {
            doenca = "resfriado";
        }else if(!tosse && febre && !faltaDeAr)
        {
            doenca = "quadro febril";
        }else if(tosse && !febre && faltaDeAr)
        {
            doenca = "asma";
        }else if(tosse && !febre && !faltaDeAr)
        {
            doenca = "tosse";
        }
        return doenca;
    }

    String getRecomendacao()
    {
        String recomendacao = "";
        if(getDoenca().equals("coronavirus"))
        {
            recomendacao = "procure um centro de atendimento especializado";
        }else
        {
            recomendacao = "procure um medico";
        }
        return recomendacao;
    }    
}
