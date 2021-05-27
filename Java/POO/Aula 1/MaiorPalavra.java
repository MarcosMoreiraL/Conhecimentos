import java.util.*;

public class MaiorPalavra 
{
    public static void main(String[] args) 
    {
        String sentence = "";
        int numberOfChar = 0;
        Scanner sc = new Scanner(System.in);

        sentence = sc.nextLine();
        numberOfChar = CheckSentence(sentence);

        System.out.println(numberOfChar);
        sc.close();
    }    

    public static int CheckSentence(String sentence)
    {
        List<Integer> indexList = new ArrayList<Integer>();
        int numberOfChar = 0, temp = 0;
        
        for(int i = 0; i < sentence.length(); i++)
        {
            if(sentence.charAt(i) == ' ')
            {
                indexList.add(i);
            }
        }

        if(indexList.size() == 0)
        {
            //System.out.println(indexList.size()); 
            return sentence.length();
        }else
        {
            indexList.add(sentence.length() - 1);
        
            for(int j = 0; j < indexList.size(); j++)
            {
                if(j == 0)
                {
                    numberOfChar = indexList.get(j);
                }else if(j != indexList.size() - 1)
                {
                    temp = indexList.get(j) - indexList.get(j - 1) - 1;
                    if(temp > numberOfChar)
                    {
                        numberOfChar = temp;
                    }
                }else if(j == indexList.size() - 1)
                {
                    temp = indexList.get(j) - indexList.get(j - 1);
                    if(temp > numberOfChar)
                    {
                        numberOfChar = temp;
                    }
                }
            }
            return numberOfChar;
        }   
    }
}
