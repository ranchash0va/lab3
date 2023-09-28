
class task993
{
    // Дана целочисленная квадратная матрица.
    // Найти в каждой строке наибольший элемент
    // и поменять его местами с элементом главной диагонали.

    public static void Run()
    {
        Console.WriteLine("task993  Дана целочисленная квадратная матрица." +
            "\nНайти в каждой строке наибольший элемент и поменять " +
            "\nего местами с элементом главной диагонали.\r\n");
        Console.WriteLine("Введите размер квадратной матрицы (n):");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Некорректный размер матрицы.");
            return;
        }

        int[,] matrix = new int[n, n];

        Console.WriteLine("Введите элементы матрицы (построчно):");
        for (int i = 0; i < n; i++)
        {
            string[] rowElements = Console.ReadLine().Split(' ');
            if (rowElements.Length != n)
            {
                Console.WriteLine("Некорректное количество элементов в строке.");
                return;
            }

            for (int j = 0; j < n; j++)
            {
                if (!int.TryParse(rowElements[j], out matrix[i, j]))
                {
                    Console.WriteLine("Некорректный элемент матрицы.");
                    return;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            int maxRowIndex = i;
            int max = matrix[i, i];

            for (int j = i + 1; j < n; j++)
            {
                if (matrix[j, i] > max)
                {
                    max = matrix[j, i];
                    maxRowIndex = j;
                }
            }

            if (maxRowIndex != i)
            {
                int temp = matrix[i, i];
                matrix[i, i] = max;
                matrix[maxRowIndex, i] = temp;
            }
        }

        Console.WriteLine("Матрица после замены:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

}


class task1000
{
    // Дана вещественная квадратная матрица порядка
    // n (n — нечетное), все элементы которой различны.
    // Найти наибольший элемент среди стоящих на главной
    // и побочной диагоналях и поменять его местами с элементом,
    // стоящим на пересечении этих диагоналей.

    public static void Run()
    {
        Console.WriteLine("\ntask1000 Дана вещественная квадратная матрица порядка n (n — нечетное), " +
            "\nвсе элементы которой различны. Найти наибольший элемент среди стоящих на главной " +
            "\nи побочной диагоналях и поменять его местами с элементом, " +
            "\nстоящим на пересечении этих диагоналей.\r\n");
        // Ввод размера матрицы
        Console.WriteLine("Ввод размера матрицы");
        int n = int.Parse(Console.ReadLine());

        // Проверка того, что n нечетное
        if (n % 2 == 0)
        {
            Console.WriteLine("n должно быть нечетным");
            return;
        }

        // Создание объекта класса Random
        Random rnd = new Random();

        // Создание матрицы
        double[,] matrix = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rnd.Next(0, 100);
            }
        }

        // Нахождение наибольших элементов на главной и побочной диагоналях
        double maxMainDiagonalElement = matrix[0, 0];
        for (int i = 1; i < n; i++)
        {
            if (matrix[i, i] > maxMainDiagonalElement)
            {
                maxMainDiagonalElement = matrix[i, i];
            }
        }

double maxSideDiagonalElement = matrix[n - 1, 0];
        for (int i = 1; i < n; i++)
        {
            int sideDiagonalElementIndex2 = n - i - 1;
            if (matrix[sideDiagonalElementIndex2, i] > maxSideDiagonalElement)
            {
                maxSideDiagonalElement = matrix[sideDiagonalElementIndex2, i];
            }
        }

        // Поиск индексов элементов, которые нужно поменять местами
        int mainDiagonalElementIndex = 0;
        int sideDiagonalElementIndex = n - 1;
        for (int i = 0; i < n; i++)
        {
            if (matrix[i, i] == maxMainDiagonalElement)
            {
                mainDiagonalElementIndex = i;
            }
            if (matrix[sideDiagonalElementIndex, i] == maxSideDiagonalElement)
            {
                sideDiagonalElementIndex = i;
            }
        }

        // Замена элементов местами
        double temp = matrix[mainDiagonalElementIndex, mainDiagonalElementIndex];
        matrix[mainDiagonalElementIndex, mainDiagonalElementIndex] = matrix[sideDiagonalElementIndex, sideDiagonalElementIndex];
        matrix[sideDiagonalElementIndex, sideDiagonalElementIndex] = temp;

        // Вывод матрицы
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    class task939
    {
        //Известен номер столбца,
        //на котором расположен элемент побочной диагонали массива.
        //Вывести на экран значение этого элемента.

        public static void Run()
        {
            Console.WriteLine("\ntask939  Известен номер столбца," +
                "\nна котором расположен элемент побочной диагонали массива. " +
                "\nВывести на экран значение этого элемента.\r\n");
            // Введите размерность матрицы
            Console.Write("Введите количество строк: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int cols = int.Parse(Console.ReadLine());

            // Создаем двумерный массив
            int[,] matrix = new int[rows, cols];

            // Создаем генератор случайных чисел
            Random random = new Random();

            // Заполняем массив рандомными целыми числами
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(1, 101); // Генерируем случайное число от 1 до 100 (включительно)
                }
            }

            // Выводим матрицу на экран (для наглядности)
            Console.WriteLine("Сгенерированная матрица:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Номер столбца элемента, который нам интересен
            Console.Write("Введите номер столбца для поиска элемента на побочной диагонали: ");
            int columnNumber = int.Parse(Console.ReadLine());

            // Находим элемент на побочной диагонали по номеру столбца
            int rowNumber = cols - columnNumber - 1;
            int diagonalElement = matrix[rowNumber, columnNumber];

            // Выводим значение элемента на экран
            Console.WriteLine($"Элемент на побочной диагонали в столбце {columnNumber} равен {diagonalElement}");
        }
    }
    class task903
    {


        public static void Run()
        {
            Console.WriteLine("Найти сумму всех четных элементов Двумерного массива целых чисел A[10, 10].\r\n");
            // Создаём двумерный массив.
            int[,] A = new int[10, 10];

            
// Заполняем массив случайными числами.
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = new Random().Next(100);
                }
            }

            // Находим сумму всех четных элементов массива.
            int sum = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i, j] % 2 == 0)
                    {
                        sum += A[i, j];
                    }
                }
            }

            // Выводим результат.
            Console.WriteLine("Сумма всех четных элементов массива: {0}", sum);
        }
    }
    class Program
    {
        static void Main()
        {
            task993.Run();
            task1000.Run();
            task939.Run();
            task903.Run();

        }
    }
}
