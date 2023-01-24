package chat;

public abstract class Mensagem 
{
    int likes = 0;
    Mensagem resposta = null;

    void like()
    {
        this.likes++;
    }

    void responder(Mensagem resposta)
    {
        this.resposta = resposta;
    }

    public abstract String getRepresentacao();

    public String formatarRepresentação(String representacao)
    {
        String retornar = "";
        for(int i = 0; i < representacao.length(); i++)
        {
            if(representacao.charAt(i + 1) != '(')
            {
                retornar+= representacao.charAt(i);
            }else
            {
                break;
            }
        }
        return retornar;
    }   
}

class MensagemTexto extends Mensagem
    {
        public String texto;

        public MensagemTexto(String texto)
        {
            this.texto = texto;
        }

        @Override
        public String getRepresentacao() 
        {
            String representacao = "";
            if(this.resposta == null)
            {
                representacao = String.format("%s (likes=%d)", this.texto, this.likes);
            }else
            {
                representacao = String.format("%s RESPOSTA A [%s] (likes=%d)", this.texto, formatarRepresentação(this.resposta.getRepresentacao()),this.likes);
            }
            return representacao;
        }

    }

    class MensagemImagem extends Mensagem
    {
        public String arquivoImagem;
        int largura, altura;

        public MensagemImagem(String arquivoImagem, int largura, int altura)
        {
            this.arquivoImagem = arquivoImagem;
            this.largura = largura;
            this.altura = altura;
        }

        @Override
        public String getRepresentacao() 
        {
            String representacao = "";
            if(this.resposta == null)
            {
                representacao = String.format("%s %dx%d (likes=%d)", this.arquivoImagem, this.largura, this.altura, this.likes);
            }else
            {
                representacao = String.format("%s %dx%d RESPOSTA A [%s] (likes=%d)", this.arquivoImagem, this.largura, this.altura, formatarRepresentação(this.resposta.getRepresentacao()), this.likes);
            }
            return representacao;
        }
    }
