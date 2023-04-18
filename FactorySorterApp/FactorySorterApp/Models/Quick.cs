﻿using System.Globalization;


namespace FactorySorterApp.Models;

public class Quick : ISorter
{

    private ArrayGenerator _arrayGenerator;
    public Quick(ArrayGenerator array)
    {
        _arrayGenerator = array;
    }

    //The QuickSort method
    public void Sort()
    {
        int[] arrayToBeSorted = _arrayGenerator.SortableArray;
        int length = _arrayGenerator.SortableArray.Length;
        QuickSort(arrayToBeSorted, -1, arrayToBeSorted[length]);

    }

    //The Quick Sort method
    public void QuickSort(int[] arr, int start, int end)
    {
        if (start < end)
        {
            //partitionIndex found after calling method and pivot (typically end)
            int partionIndex = partition(arr, start, end);

            //Recursively sort elements after and before partition
            QuickSort(arr, start, partionIndex - 1);
            QuickSort(arr, partionIndex + 1, end);

        }

    }

    //----------------- HELPER FUNCTIONS AND SUBROUTINES ---------------------------------

    //Partition subroutine. Routines index of partition
    public int partition(int[] arr, int start, int end)
    {
        //pivot initialized as last element in array
        int pivot = arr[end];

        //Subroutine aims to find final position of pivot
        //i initiated as Pending pivot index. 
        int i = start - 1;

        for (int j = start; j <= end - 1; j++)
        {
            //If current element smaller, increment i and SWAP with j
            //This ensures elements smaller than pivot
            //are on the right of the pivot after process
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }

        }

        Swap(arr, i + 1, end);
        return i;
    }

    //Swap helper method
    public void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
