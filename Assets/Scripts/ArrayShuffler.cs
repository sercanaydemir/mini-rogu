using System;
using System.Collections.Generic;

public static class ArrayShuffler
{
    private static System.Random rng = new System.Random();

    public static T[] GetShuffledArray<T>(T[] original)
    {
        T[] copy = (T[])original.Clone(); // Clone to avoid modifying original
        int n = copy.Length;

        while (n > 1)
        {
            int k = rng.Next(n--);
            (copy[n], copy[k]) = (copy[k], copy[n]);
        }

        return copy;
    }
    public static void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--); // Pick random index
            (array[n], array[k]) = (array[k], array[n]); // Swap
        }
    }

    public static void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            int k = rng.Next(n--);
            (list[n], list[k]) = (list[k], list[n]);
        }
    }
}