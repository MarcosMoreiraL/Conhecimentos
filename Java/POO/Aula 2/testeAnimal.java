import java.util.*;

public class testeAnimal 
{
    public static void main(String[] args)
    {
        int idade = 0, fator = 0;
        String especie = "";
        Animal animal = new Animal();
        Scanner sc = new Scanner(System.in);

        idade = sc.nextInt();
        fator = sc.nextInt();
        especie = sc.next();

        animal.setIdade(idade);
        animal.setEspecie(especie);
        animal.setFatorProporcao(fator);

        System.out.println(animal.getIdadeReal());
        System.out.println(animal.getSubReino());
    }   
}
