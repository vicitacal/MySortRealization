
public class InsertSort : ISort
{

    int[] sortingArray = {0};

    public void Sort(int[] array)
    {
        sortingArray = array;
        MakeSort();
    }

    private void MakeSort()
    {
        for (int i = 1; i < sortingArray.Length; i++)
        {
            int key = sortingArray[i];
            int j = i - 1;
            while (j >= 0 && sortingArray[j] > key)
            {
                sortingArray[j + 1] = sortingArray[j];
                j--;
            }
            sortingArray[j + 1] = key;
        }
    }
}
