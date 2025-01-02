using System;

public static class Kata
{
    public static int Score(int[] dice)
    {
        int score = 0;

        int[] countValuesApparence = [0, 0, 0, 0, 0, 0];

        // Let's store the number of apparence of each value in an array
        // The number of apparence of a value is stored at the index equivalent to the value
        for (int i = 0; i < 5; i++)
        {
            switch (dice[i])
            {
                case 1:
                    countValuesApparence[0] += 1;
                    break;
                case 2:
                    countValuesApparence[1] += 1;
                    break;
                case 3:
                    countValuesApparence[2] += 1;
                    break;
                case 4:
                    countValuesApparence[3] += 1;
                    break;
                case 5:
                    countValuesApparence[4] += 1;
                    break;
                case 6:
                    countValuesApparence[5] += 1;
                    break;
                default:
                    break;
            }
        }

        // Dealing with 1's
        if (countValuesApparence[0] <= 2)
        {
            score += 100 * countValuesApparence[0];
        }
        else if (countValuesApparence[0] <= 5)
        {
            score += 1000 + 100 * (countValuesApparence[0] - 3);
        }
        else if (countValuesApparence[0] == 6)
        {
            score += 2000;
        }

        // Dealing with 5's
        if (countValuesApparence[4] <= 2)
        {
            score += 50 * countValuesApparence[4];
        }
        else if (countValuesApparence[4] <= 5)
        {
            score += 500 + 50 * (countValuesApparence[4] - 3);
        }
        else if (countValuesApparence[4] == 6)
        {
            score += 1000;
        }

        // Dealing with 2's, 3's, 4's and 6's
        int[] defaultDieValues = [1, 2, 3, 5];
        foreach (int i in defaultDieValues)
        {
            if (countValuesApparence[i] >= 3)
            {
                score += 100 * (i + 1);
            }
            else if (countValuesApparence[i] == 6)
            {
                {
                    score += 2 * 100 * (i + 1);
                }
            }
        }

        return score;
    }
}