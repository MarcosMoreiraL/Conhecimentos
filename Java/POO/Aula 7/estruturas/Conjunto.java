package estruturas;

public class Conjunto implements Lista
{
    static class NoLista
    {
        int numero;
        NoLista prox = null;

        NoLista(int numero)
        {
            this.numero = numero;
        }
    }
    private NoLista inicio = null;
    private int qtd = 0;

    @Override
    public int getQtd() 
    {
        return this.qtd;
    }

    @Override
    public void adicionar(int numero) 
    {
        NoLista novo = new NoLista(numero);

        if(this.inicio == null)
        {
            this.inicio = novo;
            this.qtd++;
        }else if(this.buscar(numero) == -1)
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

    @Override
    public void remover(int numero) 
    {
        if(this.inicio != null)
        {
            NoLista anterior = null, atual = this.inicio;
            while(atual != null && numero != atual.numero)
            {
                anterior = atual;
                atual = atual.prox;
            }
            if(atual == null) return;

            if(anterior == null)
            {
                this.inicio = atual.prox;
            }else
            {
                anterior.prox = atual.prox;
            }
        }
        this.qtd--;
    }

    @Override
    public int buscar(int numero) 
    {
        if(this.inicio != null)
        {
            NoLista anterior = null, atual = this.inicio;
            int indice = 0;

            while(atual != null && numero != atual.numero)
            {
                anterior = atual;
                atual = atual.prox;
                indice++;
            }
            if(atual == null) return -1;

            return indice;
        }else
        {
            return -1;
        }  
    } 
    
    @Override
    public String toString()
    {
        if(this.inicio != null)
        {
            String retornar = "";
            NoLista atual = this.inicio;
            while(atual != null)
            {
                if(atual.prox != null)
                {
                    retornar += String.valueOf(atual.numero) + ' ';
                }else
                {
                    retornar += String.valueOf(atual.numero);
                }
                atual = atual.prox;
            }
            return retornar;
        }else
        {
            return null;
        }
    }

    public static Conjunto uniao(Conjunto a, Conjunto b)
    {
        Conjunto novoConjunto = new Conjunto();
        if(a.inicio != null)
        {
            NoLista atual = a.inicio;
            while(atual != null)
            {
                novoConjunto.adicionar(atual.numero);
                atual = atual.prox;
            }
        }
        if(b.inicio != null)
        {
            NoLista atual = b.inicio;
            while(atual != null)
            {
                if(a.buscar(atual.numero) == -1)
                {
                    novoConjunto.adicionar(atual.numero);
                }
                atual = atual.prox;
            }
        }
        return novoConjunto;
    }

    public static Conjunto intersecao(Conjunto a, Conjunto b)
    {
        if(a.inicio != null && b.inicio != null)
        {
            Conjunto novoConjunto = new Conjunto();

            NoLista atual = a.inicio;

            while(atual != null)
            {
                if(b.buscar(atual.numero) > 0)
                {
                    novoConjunto.adicionar(atual.numero);
                }
                atual = atual.prox;
            }
            return novoConjunto;
        }
        return null;
    }
}
