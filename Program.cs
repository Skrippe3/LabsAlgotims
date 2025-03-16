using LabsAlgotims;
using System;
using System.Collections.Generic;

class Graph
{
    private int V; // Количество вершин
    private Dictionary<int, List<int>> adj; // Список смежности для BFS и DFS
    private List<(int, int)>[] weightedAdj; // Список смежности с весами для Дейкстры

    public Graph(int vertices)
    {
        V = vertices + 1; // Вершины нумеруются с 1 до vertices
        adj = new Dictionary<int, List<int>>();
        weightedAdj = new List<(int, int)>[V];

        for (int i = 1; i < V; i++) // Начинаем с 1
        {
            adj[i] = new List<int>();
            weightedAdj[i] = new List<(int, int)>();
        }
    }

    // Добавление ребра для BFS и DFS
    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    // Добавление взвешенного ребра для Дейкстры
    public void AddWeightedEdge(int u, int v, int weight)
    {
        weightedAdj[u].Add((v, weight));
    }

    // Поиск в ширину (BFS)
    public void BFS(int start)
    {
        bool[] visited = new bool[V];
        Queue<int> queue = new Queue<int>();

        visited[start] = true;
        queue.Enqueue(start);

        Console.WriteLine("Поиск в ширину (BFS), начиная с вершины " + start + ":");
        while (queue.Count != 0)
        {
            int current = queue.Dequeue();
            Console.Write(current + " ");

            foreach (int neighbor in adj[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
        Console.WriteLine();
    }

    // Поиск в глубину (DFS)
    public void DFS(int start)
    {
        bool[] visited = new bool[V];
        Console.WriteLine("Поиск в глубину (DFS), начиная с вершины " + start + ":");
        DFSUtil(start, visited);
        Console.WriteLine();
    }

    // Вспомогательный метод для DFS
    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        foreach (int neighbor in adj[v])
        {
            if (!visited[neighbor])
            {
                DFSUtil(neighbor, visited);
            }
        }
    }

    // Алгоритм Дейкстры
    public void Dijkstra(int start)
    {
        int[] dist = new int[V];
        for (int i = 1; i < V; i++) // Начинаем с 1
        {
            dist[i] = int.MaxValue;
        }
        dist[start] = 0;

        PriorityQueue<int> pq = new PriorityQueue<int>();
        pq.Enqueue(start, 0);

        while (pq.Count > 0)
        {
            int u = pq.Dequeue();

            foreach ((int v, int weight) in weightedAdj[u])
            {
                if (dist[u] + weight < dist[v])
                {
                    dist[v] = dist[u] + weight;
                    pq.Enqueue(v, dist[v]);
                }
            }
        }

        // Вывод результатов
        Console.WriteLine("Кратчайшие расстояния от вершины " + start + ":");
        for (int i = 1; i < V; i++) // Начинаем с 1
        {
            Console.WriteLine($"Вершина {i}: {dist[i]}");
        }
    }
}

// Класс для приоритетной очереди (упрощённая реализация)
class PriorityQueue<T>
{
    private List<(T, int)> elements = new List<(T, int)>();

    public int Count => elements.Count;

    public void Enqueue(T item, int priority)
    {
        elements.Add((item, priority));
    }

    public T Dequeue()
    {
        int bestIndex = 0;
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].Item2 < elements[bestIndex].Item2)
            {
                bestIndex = i;
            }
        }

        T bestItem = elements[bestIndex].Item1;
        elements.RemoveAt(bestIndex);
        return bestItem;
    }
}

class SortingAlgorithms
{
    // Сортировка пузырьком
    public static int[] BubbleSort(int[] array)
    {
        int len = array.Length;

        for (int i = 1; i < len; i++)
        {
            for (int j = 0; j < len - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                }
            }
        }
        return array;
    }

    // Сортировка вставками
    public static int[] InsertionSort(int[] array)
    {
        int len = array.Length;

        for (int i = 1; i < len; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }

        return array;
    }

    // Быстрая сортировка
    public static void QuickSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(array, left, right);
            QuickSort(array, left, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, right);
        }
    }

    private static int Partition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(ref array[i], ref array[j]);
            }
        }
        Swap(ref array[i + 1], ref array[right]);
        return i + 1;
    }

    // Сортировка слиянием
    public static int[] MergeSort(int[] array)
    {
        int len = array.Length;
        if (len <= 1)
        {
            return array;
        }

        int mid = len / 2;
        int[] left = new int[mid];
        int[] right = new int[len - mid];

        Array.Copy(array, 0, left, 0, mid);
        Array.Copy(array, mid, right, 0, len - mid);

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    private static int[] Merge(int[] left, int[] right)
    {
        int leftIndex = 0, rightIndex = 0;
        int[] result = new int[left.Length + right.Length];

        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            if (left[leftIndex] < right[rightIndex])
            {
                result[leftIndex + rightIndex] = left[leftIndex];
                leftIndex++;
            }
            else
            {
                result[leftIndex + rightIndex] = right[rightIndex];
                rightIndex++;
            }
        }

        while (leftIndex < left.Length)
        {
            result[leftIndex + rightIndex] = left[leftIndex];
            leftIndex++;
        }

        while (rightIndex < right.Length)
        {
            result[leftIndex + rightIndex] = right[rightIndex];
            rightIndex++;
        }

        return result;
    }

    // Вспомогательный метод для обмена элементов
    private static void Swap(ref int e1, ref int e2)
    {
        var temp = e1;
        e1 = e2;
        e2 = temp;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(" \n//////////////////////////////////////////////////////////////////// \n" +
           "//-----------------------------LABA_1-----------------------------// \n" +
           "//////////////////////////////////////////////////////////////////// \n");

        // Сортировки
        int[] arr = new int[] { 7, 21, 3, 6, 5, 2, 9, 12, 4, 8 };

        int[] bubbleSortedArr = SortingAlgorithms.BubbleSort((int[])arr.Clone());
        Console.WriteLine("Сортировка пузырьком: " + string.Join(", ", bubbleSortedArr));

        int[] insertionSortedArr = SortingAlgorithms.InsertionSort((int[])arr.Clone());
        Console.WriteLine("Сортировка вставками: " + string.Join(", ", insertionSortedArr));

        int[] quickSortedArr = (int[])arr.Clone();
        SortingAlgorithms.QuickSort(quickSortedArr, 0, quickSortedArr.Length - 1);
        Console.WriteLine("Быстрая сортировка: " + string.Join(", ", quickSortedArr));

        int[] mergeSortedArr = SortingAlgorithms.MergeSort((int[])arr.Clone());
        Console.WriteLine("Сортировка слиянием: " + string.Join(", ", mergeSortedArr)+"\n" );


        // Граф
        Graph g = new Graph(6); // 6 вершин (x1=1, x2=2, x3=3, x4=4, x5=5, x6=6)

        // Добавляем рёбра для BFS и DFS
        g.AddEdge(1, 2); // x1 -> x2
        g.AddEdge(2, 4); // x2 -> x4
        g.AddEdge(6, 4); // x6 -> x4
        g.AddEdge(3, 1); // x3 -> x1
        g.AddEdge(3, 2); // x3 -> x2
        g.AddEdge(5, 3); // x5 -> x3
        g.AddEdge(5, 6); // x5 -> x6
        g.AddEdge(5, 4); // x5 -> x4
        g.AddEdge(4, 5); // x4 -> x5

        // Добавляем взвешенные рёбра для Дейкстры
        g.AddWeightedEdge(1, 2, 1); // x1 -> x2 (вес 1)
        g.AddWeightedEdge(2, 4, 3); // x2 -> x4 (вес 3)
        g.AddWeightedEdge(6, 4, 4); // x6 -> x4 (вес 4)
        g.AddWeightedEdge(3, 1, 5); // x3 -> x1 (вес 5)
        g.AddWeightedEdge(3, 2, 7); // x3 -> x2 (вес 7)
        g.AddWeightedEdge(5, 3, 2); // x5 -> x3 (вес 2)
        g.AddWeightedEdge(5, 6, 2); // x5 -> x6 (вес 2)
        g.AddWeightedEdge(5, 4, 7); // x5 -> x4 (вес 7)
        g.AddWeightedEdge(4, 5, 1); // x4 -> x5 (вес 1)

        // Выполняем BFS, начиная с x1 (индекс 1)
        g.BFS(1);

        // Выполняем DFS, начиная с x1 (индекс 1)
        g.DFS(1);

        // Выполняем алгоритм Дейкстры, начиная с x1 (индекс 1)
        g.Dijkstra(1);

 


        ////////////////////////////////////////////////////////////////////
        //-----------------------------LABA_2-----------------------------//
        ////////////////////////////////////////////////////////////////////
        
        //Выполнение алгоритма машины Тьюринга
        int x = 10;
        int y = 5;
        Console.WriteLine(" \n//////////////////////////////////////////////////////////////////// \n" +
            "//-----------------------------LABA_2-----------------------------// \n" +
            "//////////////////////////////////////////////////////////////////// \n");
        
        
        Console.WriteLine("Алгоритм машины Тьюринга: " + Class1.LABS2(x, y));

    }
}
