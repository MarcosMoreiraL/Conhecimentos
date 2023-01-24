import java.util.*;

public class ProgramaExpressao
{
    static class operation
    {
        int op = 0;
        int num = 0;
    }

    public static List<operation> numList = new ArrayList<operation>();

    public static void main(String[] args)
    {
        String expression = "";
        List<Character> list = new ArrayList<Character>();
        OperacaoMatematica opMat = new OperacaoMatematica();
        Impressao impressao = new Impressao();
        Scanner sc = new Scanner(System.in);

        expression = sc.nextLine();
        for(int i = 0; i < expression.length(); i++)
        {
            list.add(expression.charAt(i));
        }

        SetList(list);
        impressao.imprimirResultado(Calculate(numList, opMat));
        //Print(resultado);
        //System.out.println(numList.size());
        sc.close();
    }

    static void SetList(List<Character> list)
    {
        boolean contando = false;
        String tempNum = "";

        for(int i = 0; i < list.size(); i++)
        {
            if(Character.isDigit(list.get(i)))
            {
                if(!contando)
                {
                    contando = true;
                    tempNum+=list.get(i);
                }else
                {
                    tempNum+=list.get(i);
                }
            }else
            {
                operation newOp = new operation();
                switch(list.get(i))
                {
                    case '+':
                    newOp.op = 1;
                    break;
                    case '-':
                    newOp.op = 2;
                    break;
                    case '*':
                    newOp.op = 3;
                    break;
                    case '/':
                    newOp.op = 4;
                    break;
                }
                newOp.num = Integer.parseInt(tempNum);
                numList.add(newOp);
                //System.out.printf("num: %d Op: %d\n",newOp.num, newOp.op);
                tempNum = "";
            }
        }
    }

    static int Calculate(List<operation> list, OperacaoMatematica opMat)
    {
        List<operation> newList = list;
        int result = 0;
        int[] indexList = new int[2];
        boolean temMultDiv = false;
        while(newList.size() > 1)
        {
            temMultDiv = false;
            //Procurar por Multiplicação ou Divisão
            for(int i = 0; i < newList.size(); i++)
            {
                if(newList.get(i).op > 2)
                {
                    temMultDiv = true;
                }
            }

            for(int i = 0; i < newList.size(); i++)
            {
                if(list.get(i).op == 3 || list.get(i).op == 4)
                {
                    opMat.setValor1(list.get(i).num);
                    opMat.setValor2(list.get(i+1).num);
                    opMat.executaOperacao(list.get(i).op);
                    result = opMat.getResultado();
                    indexList[0] = i;
                    indexList[1] = i+1;
                    newList = Reorganize(list, indexList, result);
                    //System.out.printf("\n\nRESULTADO(%d): %d\n\n", i, result);
                }else if((list.get(i).op == 1 || list.get(i).op == 2) && !temMultDiv)
                {
                    opMat.setValor1(list.get(i).num);
                    opMat.setValor2(list.get(i+1).num);
                    opMat.executaOperacao(list.get(i).op);
                    result = opMat.getResultado();
                    indexList[0] = i;
                    indexList[1] = i+1;
                    newList = Reorganize(list, indexList, result);
                    //System.out.printf("RESULTADO(%d): %d\n\n", i, result);
                }
                result = 0;
                //Print(newList);
            }
        }
        return list.get(0).num;
    }

    static List<operation> Reorganize(List<operation> list, int[] indexList, int num)
    {
        List<operation> thisList = list;
        operation newOp = new operation();

        newOp.num = num;
        newOp.op = list.get(indexList[1]).op;

        list.remove(indexList[1]);
        list.set(indexList[0], newOp);

        return thisList;
    }

    /*static void Print(List<operation> list)
    {
        for(int i = 0; i < list.size(); i++)
        {
            System.out.printf("Num: %d Op: %d\n", list.get(i).num, list.get(i).op);
        }
        System.out.printf("\n");
    }*/
}