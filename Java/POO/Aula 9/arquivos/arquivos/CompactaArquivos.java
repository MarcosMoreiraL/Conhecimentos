package arquivos;

import java.util.Scanner;

public class CompactaArquivos
{
    public static void main(String[] args)
    {
        int nArquivos = 0;
        PastaCompactada<Texto> pastaTextos = new PastaCompactada<Texto>();
        PastaCompactada<Imagem> pastaImagens = new PastaCompactada<Imagem>();
        Scanner sc = new Scanner(System.in);

        for(int i = 0; i < nArquivos; i++)
        {
            String tipo = sc.next();
            switch (tipo) {
                case "Texto":
                    pastaTextos.adicionar(new Texto());
                    break;
                case "TextoTXT":
                    pastaTextos.adicionar(new TextoTXT());
                    break;
                case "TextoDOCX":
                    pastaTextos.adicionar(new TextoDOCX());
                    break;
                case "Imagem":
                    pastaImagens.adicionar(new Imagem());
                    break;
                case "ImagemJPEG":
                    pastaTextos.adicionar(new ImagemJPEG());
                    break;
                case "ImagemPNG":
                    pastaTextos.adicionar(new ImagemPNG());
                    break;
                default:
                    break;
            }
        }

        pastaTextos.imprimir();
        pastaImagens.imprimir();
    }

    
}