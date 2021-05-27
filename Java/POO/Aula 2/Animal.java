public class Animal
{
    public int idade, fator;
    public String especie;   

    void setIdade(int idade)
    {
        this.idade = idade;
    }

    void setFatorProporcao(int fator)
    {
        this.fator = fator;
    }

    void setEspecie(String especie)
    {
        this.especie = especie;
    }

    int getIdadeReal()
    {
        return idade*fator;
    }

    String getSubReino()
    {
        String subReino = "";
        switch(especie)
        {
            case "coelho":
            subReino = "vertebrado";
            break;

            case "elefante":
            subReino = "vertebrado";
            break;

            case "lagarto":
            subReino = "vertebrado";
            break;

            case "polvo":
            subReino = "invertebrado";
            break;

            case "carangueijo":
            subReino = "invertebrado";
            break;

            case "escorpiao":
            subReino = "invertebrado";
            break;

            default:
            subReino = "invalido";
        }
        return subReino;
    }
}