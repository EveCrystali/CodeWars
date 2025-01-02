using System;
using System.Collections.Generic;

namespace PickPeaks;

public class PickPeaks
{
    public static Dictionary<string, List<int>> GetPeaks(int[] arr)
    {
        List<int> peakNumber = [];
        List<int> peakPos = [];

        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i - 1] && arr[i] >= arr[i + 1])
            {
                if (arr[i] == arr[i + 1] && plateauOrFlat(arr, i) == "flat")
                {
                    continue;
                }
                peakNumber.Add(arr[i]);
                peakPos.Add(i);
            }
        }

        Dictionary<string, List<int>> peaks = new()
        {
            ["pos"] = peakPos,
            ["peaks"] = peakNumber
        };

        if (peaks["pos"].Count > 0)
        {
            if (peakIsOnTheEdgeOfTheArray(arr, peaks["pos"][^1]))
            {
                peaks["pos"].RemoveAt(peaks["pos"].Count - 1);
                peaks["peaks"].RemoveAt(peaks["peaks"].Count - 1);
            }
        }

        return peaks;
    }

    private static bool peakIsOnTheEdgeOfTheArray(int[] arr, int i)
    {
        bool peakIsOnTheEdgeOfTheArray = true;
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i] != arr[j]) peakIsOnTheEdgeOfTheArray = false;
        }
        return peakIsOnTheEdgeOfTheArray;
    }

    private static string plateauOrFlat(int[] arr, int i)
    {
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i]== arr[j])
            {
                continue;
            }
            if (wasAscendingOrDescending(arr, i) == "wasAscending")
            {
                if (arr[i]< arr[j]) return "flat";
                else if (arr[i]> arr[j]) return "plateau";
            }
            else if (wasAscendingOrDescending(arr, i) == "wasDescending")
            {
                if (arr[i]< arr[j]) return "plateau";
                else if (arr[i]> arr[j]) return "flat";
            }
        }
        return "plateau";
    }

    private static string wasAscendingOrDescending(int[] arr, int i)
    {
        if (arr[i - 1] > arr[i]) return "wasDescending";
        return "wasAscending";
    }
}
