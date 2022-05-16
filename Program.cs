using System.Diagnostics;

internal class Program
{
    static int _sortingArrayLen;
    static Random _random = new Random();
    static Stopwatch _stopwatch = new Stopwatch();
    static ISort[] _sorts = { new QuickSort(), new MergeSort(), new InsertSort(), new SelectionSort()};

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Введите количество семплов:");
            _sortingArrayLen = GetConsolValue();

            if (_sortingArrayLen > 0)
            {
                int[] _randomArray = GetNewRandomArray(_sortingArrayLen);
                int[] _arrayToSort = new int[_sortingArrayLen];

                foreach (var sort in _sorts)
                {
                    bool isSorted = true;
                    _randomArray.CopyTo(_arrayToSort, 0);
                    _stopwatch.Restart();
                    sort.Sort(_arrayToSort);
                    _stopwatch.Stop();
                    Console.WriteLine("Сортировка: " + sort.ToString() + " выполнялась: " + _stopwatch.Elapsed);
                    Console.Write("Проверка правильности сортировки... ");
                    for (int i = 1; i < _arrayToSort.Length; i++)
                    {
                        if (_arrayToSort[i - 1] > _arrayToSort[i])
                        {
                            isSorted = false;
                            break;
                        }
                    }  
                    Console.WriteLine(isSorted? "Правильно" : "Не правльно");
                    Console.Write('\n');
                }
            } else 
                if (_sortingArrayLen == -1)
                    Console.WriteLine("Ошибка ввода");
                else
                    Console.WriteLine("Ведена пустая строка");

            Console.Write('\n');
        }
    }

    static private int[]? GetArray()
    {
        try
        {
            string? inputString = Console.ReadLine();
            if (inputString != null)
            {
                var inputLines = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int[] tempArray = new int[inputLines.Length];
                for (int i = 0; i < inputLines.Length; i++) tempArray[i] = int.Parse(inputLines[i]);
                return tempArray;
            } else
                return null;
        } catch 
        {
            return null;
        }
    }

    static private int GetConsolValue()
    {
        try
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            return -1;
        }  
    }

    static private int[] GetNewRandomArray(int size)
    {
        int[] tempArray = new int[size];
        for (int i = 0; i < size; i++)
            tempArray[i] = _random.Next();
        return tempArray;
    }
}
