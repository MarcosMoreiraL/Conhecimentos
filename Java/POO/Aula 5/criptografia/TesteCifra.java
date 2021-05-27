package criptografia;

public class TesteCifra 
{
    public static void main(String[] args)
    {
        String palavra = "abcdeyzf";
        CifraCesar cifra = new CifraCesar(6);
        String resultCifra = cifra.cifrar(palavra), resultDecifra = cifra.decifrar(palavra);

        System.out.printf("CIFRA: %s\nDECIFRA: %s\n", resultCifra, resultDecifra);
    }   
}
