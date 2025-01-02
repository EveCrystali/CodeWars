using System.Collections.Generic;

public class Kata
{
  public static int[] MoveZeroes(int[] arr)
  {
    List<int> movedZeroes = [];
    List<int> zeroList = [];

    for (int i = 0; i < arr.Length; i++)
    {
      if (arr[i] == 0) zeroList.Add(0);
      if (arr[i] != 0) movedZeroes.Add(arr[i]);
    }
    
    movedZeroes.AddRange(zeroList);

    return movedZeroes.ToArray();
  }
}