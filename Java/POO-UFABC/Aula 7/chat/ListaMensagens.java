package chat;

public class ListaMensagens 
{
    private NoLista inicio = null;
    private int qtd = 0;

    static class NoLista
    {
        Mensagem mensagem;
        int indice;
        NoLista prox = null;
        
        NoLista(Mensagem mensagem)
        {
            this.mensagem = mensagem;
        }
    }

    public void adicionarMensagem(Mensagem mensagem)
    {
        NoLista novo = new NoLista(mensagem);
        novo.indice = qtd;

        if(this.inicio == null)
        {
            this.inicio = novo;
            this.qtd++;
        }else
        {
            NoLista anterior = null, atual = this.inicio;
            while(atual != null)
            {
                anterior = atual;
                atual = atual.prox;
            }
            anterior.prox = novo;
            this.qtd++;
        }
    }

    public void responderMensagem(int indiceMensagemOriginal, Mensagem resposta)
    {
        if(this.inicio != null)
        {
            NoLista atual = this.inicio;

            while(atual != null && atual.indice != indiceMensagemOriginal)
            {
                atual = atual.prox;
            }
            if(atual != null)
            {
                resposta.resposta = atual.mensagem;
            }
            adicionarMensagem(resposta);
        }
    }

    public Mensagem[] getMensagens()
    {
        if(this.inicio != null)
        {
            Mensagem[] vetor = new Mensagem[this.qtd];
            int indice = 0;
            NoLista atual = this.inicio;
            while(atual != null)
            {
                vetor[indice] = atual.mensagem;
                indice++;
                atual = atual.prox;
            }
            return vetor;
        }else
        {
            return null;
        }
    }

    public String[] getMensagensString()
    {
        if(this.inicio != null)
        {
            String[] vetor = new String[this.qtd];
            int indice = 0;
            NoLista atual = this.inicio;
            while(atual != null)
            {
                vetor[indice] = atual.mensagem.getRepresentacao();
                indice++;
                atual = atual.prox;
            }
            return vetor;
        }else
        {
            return null;
        }
    }

    public void like(int indiceMensangem)
    {
        if(this.inicio != null)
        {
            NoLista atual = this.inicio;

            while(atual != null && atual.indice != indiceMensangem)
            {
                atual = atual.prox;
            }
            if(atual != null)
            {
                atual.mensagem.like();
            }
        }
    }
}
