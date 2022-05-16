
public class MergeSort : ISort
{
    int[] sortingArray = {};

    public void Sort(int[] arrayToSort)
    {
        sortingArray = arrayToSort;
        RecursSort(0, sortingArray.Length - 1);
    }

    private void RecursSort(int startIndex, int finishIndex)
    {
        if (startIndex >= finishIndex) return;
        var middleIndex = (finishIndex + startIndex) / 2;
        RecursSort(startIndex, middleIndex);
        RecursSort(middleIndex + 1, finishIndex);
        Merge(startIndex, middleIndex, finishIndex);
    }

    private void Merge(int startPoint, int midPoint, int endPoint)
    {
        Stack<int> firstStack = new Stack<int>();
        Stack<int> secondStack = new Stack<int>();
        for (int i = midPoint; i >= startPoint; i--) firstStack.Push(sortingArray[i]);
        for (int i = endPoint; i >= midPoint + 1; i--) secondStack.Push(sortingArray[i]);
        int index = startPoint;
        while (firstStack.Count != 0 || secondStack.Count != 0)
        {
            if (firstStack.Count > 0 && secondStack.Count > 0)
                sortingArray[index] = firstStack.Peek() >= secondStack.Peek() ? secondStack.Pop() : firstStack.Pop();
            else
                sortingArray[index] = firstStack.Count > 0 ? firstStack.Pop() : secondStack.Pop();
            index++;
        }
    }
}
