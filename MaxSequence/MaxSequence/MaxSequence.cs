using System.Collections.Generic;

namespace MaxSequence;

public static class Kata
{
    public static int MaxSequence(int[] arr)
    {
        int sum = 0;
        List<int> listSum = [];


        if (arr.Length < 1) return 0;
        if (arr.Length < 2) return arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            sum = arr[i];
            for (int j = i + 1; j < arr.Length; j++)
            {
                sum += arr[j];
                listSum.Add(sum);
            }
        }

        return listSum.Max() < 0 ? 0 : listSum.Max();
    }
}