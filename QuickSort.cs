
public class QuickSort : ISort
{
    int[] sortingArray = {0};
    Random random = new Random();

    public void Sort(int[] array)
    {
        sortingArray = array;
        RecursiveSort(0, sortingArray.Length - 1);
    }

    private void RecursiveSort(int start, int end)
    {
        if (start >= end) return;
        int mid = Partition(start, end);
        RecursiveSort(start, mid - 1);
        RecursiveSort(mid + 1, end);
    }

    private int Partition(int start, int end)
    {
        Swap(random.Next(start, end), end);
        int middle = start;
        int referencElement = sortingArray[end];
        for (int i = start; i < end; i++)
            if (sortingArray[i] <= referencElement) Swap(i, middle++);
        Swap(middle, end);
        return middle;
    }

    private void Swap(int first, int second)
    {
        if (first == second) return;
        int temp = sortingArray[first];
        sortingArray[first] = sortingArray[second];
        sortingArray[second] = temp;
    }
}

