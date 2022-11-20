using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Algorithms
{
    public class Combination
    {
        int numberOfPossibleCombinations(int n, int k)
        {
            if (k == 0 || k == n)
                return 1;

            return numberOfPossibleCombinations(n - 1, k) + numberOfPossibleCombinations(n - 1, k - 1);
        }
    }
}
