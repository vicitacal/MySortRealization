
public class SelectionSort : ISort
{

    int[] sortingArray = {0};

    public void Sort(int[] array)
    {
        sortingArray = array;
        MakeSort();
    }

    private void MakeSort()
    {
        for (int i = 0; i < sortingArray.Length; i++)
        {
            int smallestIndex = i;
            int smallest = sortingArray[i];
            for (int j = i; j < sortingArray.Length; j++)
            {
                if (sortingArray[j] < smallest)
                {
                    smallest = sortingArray[j];
                    smallestIndex = j;
                }
            }
            Swap(i, smallestIndex);
        }
    }

    private void Swap(int first, int second)
    {
        if (first == second) return;
        int temp = sortingArray[first];
        sortingArray[first] = sortingArray[second];
        sortingArray[second] = temp;
    }
}