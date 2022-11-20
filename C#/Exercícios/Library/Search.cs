using Library.DataStructures;
using static Library.DataStructures.Tree;

namespace Library
{
    public class Search
    {
        public static int LinearSearch(List<int> list, int number)
        {
            for(int i = 0; i < list.Count; i++)
                if(list[i] == number)
                    return i;
            return -1;
        }

        public static int BinarySearch(List<int> list, int number)
        {
            int start = 0, stop = list.Count - 1, middle = (start + stop) / 2;

            while (list[middle] != number && start < stop)
            {
                if(number < list[middle])
                    stop = middle--;
                else
                    start = middle++;

                middle = (start + stop) / 2;
            }

            return list[middle] != number ? -1 : middle;
        }

        public static int InterpolationSearch(List<int> list, int number)
        {
            int low = 0, high = list.Count - 1;

            while(low <= high && number >= list[low] && number <= list[high])
            {
                if(low == high)
                {
                    if (list[low] == number)
                        return low;
                    else
                        return -1;
                }

                int pos = low + (high - low) / (list[high] - list[low]) * (number - list[low]);

                if (list[pos] == number)
                    return pos;

                if (list[pos] < number)
                    low = pos++;
                else
                    high = pos--;
            }

            return -1;
        }
    }
}