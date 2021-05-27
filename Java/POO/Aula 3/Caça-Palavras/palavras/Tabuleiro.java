package palavras;

public class Tabuleiro
{
    public char[][] matriz;

    public Tabuleiro(char[][] matriz)
    {
        this.matriz = matriz;
    }

    public Tabuleiro(int qtdLinhas, int qtdColunas, char[] dadosMatriz)
    {
        this.matriz = new char[qtdLinhas][qtdColunas];
        int indice = 0;
        for(int i = 0; i < qtdLinhas; i++)
        {
            for(int j = 0; j < qtdColunas; j++)
            {
                this.matriz[i][j] = dadosMatriz[indice];
                indice++;
            }
        }
    }

    public PalavraEncontrada buscar(String palavra)
    {    
        for(int i = 0; i < matriz.length; i++)
        {
            for(int j = 0; j < matriz[0].length; j++)
            {
                if(matriz[i][j] == palavra.charAt(0))
                {
                    if(EncontraLinha1(palavra, matriz, i, j) != null)
                    {
                        return EncontraLinha1(palavra, matriz, i, j);

                    }else if(EncontraLinha2(palavra, matriz, i, j) != null)
                    {
                        return EncontraLinha2(palavra, matriz, i, j);

                    }else if(EncontraColuna1(palavra, matriz, i, j) != null)
                    {
                        return EncontraColuna1(palavra, matriz, i, j);

                    }else if(EncontraColuna2(palavra, matriz, i, j) != null)
                    {
                        return EncontraColuna2(palavra, matriz, i, j);

                    }else if(EncontraDiagonal1(palavra, matriz, i, j) != null)
                    {
                        return EncontraDiagonal1(palavra, matriz, i, j);

                    }else if(EncontraDiagonal2(palavra, matriz, i, j) != null)
                    {
                        return EncontraDiagonal2(palavra, matriz, i, j);

                    }else if(EncontraDiagonal3(palavra, matriz, i, j) != null)
                    {
                        return EncontraDiagonal3(palavra, matriz, i, j);

                    }else if(EncontraDiagonal4(palavra, matriz, i, j) != null)
                    {
                        return EncontraDiagonal4(palavra, matriz, i, j);
                    }
                }
            }
        }
        return null;
    }

    public PalavraEncontrada[] buscar(String[] palavras)
    {
        PalavraEncontrada[] vetorTemp = new PalavraEncontrada[palavras.length];
        int nEncontradas = 0, indice = 0;
        for(int i = 0; i < palavras.length; i++)
        {
            PalavraEncontrada temp = buscar(palavras[i]);
            if(temp != null)
            {
                vetorTemp[i] = temp;
                nEncontradas++;
            }
        }
        PalavraEncontrada[] retornar = new PalavraEncontrada[nEncontradas];
        for(int i = 0; i < vetorTemp.length; i++)
        {
            if(vetorTemp[i] != null)
            {
                retornar[indice] = vetorTemp[i];
                indice++;
            }
        }
        return retornar;
    }

    public PalavraEncontrada EncontraLinha1(String palavra, char[][] matriz, int linha, int coluna)
    {
        try
        {
            PalavraEncontrada retornar = new PalavraEncontrada();
            for(int i = 0; i < palavra.length(); i++)
            {
                if(palavra.charAt(i) != matriz[linha][coluna + i])
                {
                    return null;
                }
            }
    
            retornar.palavra = palavra;
            retornar.posicao[0] = linha;
            retornar.posicao[1] = coluna; 
            retornar.tipo = 1;
            retornar.direcao = 1;
    
            return retornar;
        }catch(Exception e)
        {
          return null;  
        }
    }

    public PalavraEncontrada EncontraLinha2(String palavra, char[][] matriz, int linha, int coluna)
    {
        try
        {
            PalavraEncontrada retornar = new PalavraEncontrada();
            for(int i = 0; i < palavra.length(); i++)
            {
                if(palavra.charAt(i) != matriz[linha][coluna - i])
                {
                    return null;
                }
            }
    
            retornar.palavra = palavra;
            retornar.posicao[0] = linha;
            retornar.posicao[1] = coluna; 
            retornar.tipo = 1;
            retornar.direcao = 2;
            
            return retornar;
        }catch(Exception e)
        {
            return null;
        }
        
    }

    public PalavraEncontrada EncontraColuna1(String palavra, char[][] matriz, int linha, int coluna)
    {
        try
        {
            PalavraEncontrada retornar = new PalavraEncontrada();
            for(int i = 0; i < palavra.length(); i++)
            {
                if(palavra.charAt(i) != matriz[linha + i][coluna])
                {
                    return null;
                }
            }
    
            retornar.palavra = palavra;
            retornar.posicao[0] = linha;
            retornar.posicao[1] = coluna; 
            retornar.tipo = 2;
            retornar.direcao = 1;
            
            return retornar;
        }catch(Exception e)
        {
            return null;
        }
        
    }

    public PalavraEncontrada EncontraColuna2(String palavra, char[][] matriz, int linha, int coluna)
    {
        try
        {
            PalavraEncontrada retornar = new PalavraEncontrada();
            for(int i = 0; i < palavra.length(); i++)
            {
                if(palavra.charAt(i) != matriz[linha - i][coluna])
                {
                    return null;
                }
            }
    
            retornar.palavra = palavra;
            retornar.posicao[0] = linha;
            retornar.posicao[1] = coluna; 
            retornar.tipo = 2;
            retornar.direcao = 2;
            
            return retornar;
        }catch(Exception e)
        {
            return null;
        }
        
    }

    public PalavraEncontrada EncontraDiagonal1(String palavra, char[][] matriz, int linha, int coluna)
    {
        try
        {
            PalavraEncontrada retornar = new PalavraEncontrada();
            for(int i = 0; i < palavra.length(); i++)
            {
                if(palavra.charAt(i) != matriz[linha - i][coluna + i])
                {
                    return null;
                }
            }
    
            retornar.palavra = palavra;
            retornar.posicao[0] = linha;
            retornar.posicao[1] = coluna; 
            retornar.tipo = 3;
            retornar.direcao = 1;
            
            return retornar;
        }catch(Exception e)
        {
            return null;
        }
        
    }

    public PalavraEncontrada EncontraDiagonal2(String palavra, char[][] matriz, int linha, int coluna)
    {
        try
        {
            PalavraEncontrada retornar = new PalavraEncontrada();
            for(int i = 0; i < palavra.length(); i++)
            {
                if(palavra.charAt(i) != matriz[linha + i][coluna + i])
                {
                    return null;
                }
            }
    
            retornar.palavra = palavra;
            retornar.posicao[0] = linha;
            retornar.posicao[1] = coluna; 
            retornar.tipo = 3;
            retornar.direcao = 2;
            
            return retornar;
        }catch(Exception e)
        {
            return null;
        }
        
    }

    public PalavraEncontrada EncontraDiagonal3(String palavra, char[][] matriz, int linha, int coluna)
    {
        try
        {
            PalavraEncontrada retornar = new PalavraEncontrada();
            for(int i = 0; i < palavra.length(); i++)
            {
                if(palavra.charAt(i) != matriz[linha + i][coluna - i])
                {
                    return null;
                }
            }
    
            retornar.palavra = palavra;
            retornar.posicao[0] = linha;
            retornar.posicao[1] = coluna; 
            retornar.tipo = 3;
            retornar.direcao = 3;
            
            return retornar;
        }catch(Exception e)
        {
            return null;
        }
        
    }

    public PalavraEncontrada EncontraDiagonal4(String palavra, char[][] matriz, int linha, int coluna)
    {
        try
        {
            PalavraEncontrada retornar = new PalavraEncontrada();
            for(int i = 0; i < palavra.length(); i++)
            {
                if(palavra.charAt(i) != matriz[linha - i][coluna - i])
                {
                    return null;
                }
            }
    
            retornar.palavra = palavra;
            retornar.posicao[0] = linha;
            retornar.posicao[1] = coluna; 
            retornar.tipo = 3;
            retornar.direcao = 4;
            
            return retornar;
        }catch(Exception e)
        {
            return null;
        }
    }
}