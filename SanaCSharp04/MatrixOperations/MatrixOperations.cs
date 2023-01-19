namespace MatrixOperations
{
    public class MatrixOperations
    {
        private int[,] _matrix;

        public MatrixOperations(int[,] matrix)
        {
            _matrix = matrix;
        }

        // 1) Максимальне із чисел, що зустрічається в заданій матриці більше одного разу;
        public int GetCountOfPositiveElements()
        {
            var counter = 0;

            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j] > 0)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        // 2) Mаксимальне із чисел, що зустрічається в заданій матриці більше одного разу
        public int? GetMaxOfRepeatNumbers()
        {
            var repeatsList = new List<int>();

            var arrayFromMatrix = MatrixToArray(_matrix);

            for (var i = 0; i < arrayFromMatrix.Length; i++)
            {
                for (var j = i + 1; j < arrayFromMatrix.Length; j++)
                {
                    if (arrayFromMatrix[i] == arrayFromMatrix[j])
                    {
                        repeatsList.Add(arrayFromMatrix[i]);
                    }
                }
            }

            if (!repeatsList.Any())
                return null;

            return repeatsList.Max();
        }

        // 3) Кількість рядків, які не містять жодного нульового елемента
        public int GetCountOfRowsWithoutZeroElements()
        {
            var rowsCounter = 0;

            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                var isRowWithZeroElements = false;
                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j] == 0)
                    {
                        isRowWithZeroElements = true;
                        break;
                    }
                }

                if (!isRowWithZeroElements)
                {
                    rowsCounter++;
                }
            }

            return rowsCounter;
        }


        // 4) Кількість стовпців, які містять хоча б один нульовий елемент
        public int GetCountOfColumnsWithZeroElements()
        {
            var columnsCounter = 0;

            for (var j = 0; j < _matrix.GetLength(1); j++)
            {
                var isColumnWithZeroElement = false;
                for (var i = 0; i < _matrix.GetLength(0); i++)
                {
                    if (_matrix[i, j] == 0)
                    {
                        isColumnWithZeroElement = true;
                        break;
                    }
                }

                if (isColumnWithZeroElement)
                {
                    columnsCounter++;
                }
            }

            return columnsCounter;
        }

        // 5) Номер рядка, в якому знаходиться найдовша серія однакових елементів
        public int FindRowIdWithMaxSeriesSameElements()
        {
            var maxSeries = 0;
            var rowId = -1;

            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                var maxInRow = 0;
                var counter = 0;

                for (var j = 1; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j - 1] == _matrix[i, j])
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }

                    if (counter > maxInRow)
                    {
                        maxInRow = counter;
                    }
                }

                if (maxInRow > maxSeries)
                {
                    maxSeries = maxInRow;
                    rowId = i;
                }
            }


            return rowId;
        }

        // 6) Добуток елементів в тих рядках, які не містять від’ємних елементів
        public Dictionary<int, long> GetProductElementsInRowWithoutNegativeElements()
        {
            var rowsIndexesList = new List<int>();

            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                var isRowWithNegativeElements = false;
                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j] < 0)
                    {
                        isRowWithNegativeElements = true;
                        break;
                    }
                }

                if (!isRowWithNegativeElements)
                {
                    rowsIndexesList.Add(i);  
                }
            }

            var resultDictionary = new Dictionary<int, long>();
            foreach (var i in rowsIndexesList)
            {
                long product = 1;
                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    product *= _matrix[i, j];
                }

                resultDictionary.Add(i, product);
            }

            return resultDictionary;
        }

        // 7) Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці (включно з головною діагоналлю)
        public int GetMaxOfSumsParallelOfMainDiagonal()
        {
            var rows = _matrix.GetLength(0);
            var columns = _matrix.GetLength(1);

            var sums = 
                rows >= columns 
                ? new int[2 * rows - 1 - (rows - columns)] 
                : new int[2 * columns - 1 - (columns - rows)];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    sums[i + j] += _matrix[i, columns - j - 1];
                    
                }
            }

            return sums.Max();
        }

        // 8) Сума елементів в тих стовпцях, які не містять від’ємних елементів
        public Dictionary<int, int> GetSumsInColumnsWithoutNegativeElements()
        {
            var columnsIndexesList = new List<int>();

            for (var j = 0; j < _matrix.GetLength(1); j++)
            {
                var isColumnWithNegativeElements = false;
                for (var i = 0; i < _matrix.GetLength(0); i++)
                {
                    if (_matrix[i, j] < 0)
                    {
                        isColumnWithNegativeElements = true;
                        break;
                    }
                }

                if (!isColumnWithNegativeElements)
                {
                    columnsIndexesList.Add(j);
                }
            }

            var resultDictionary = new Dictionary<int, int>();
            
            foreach (var j in columnsIndexesList)
            {
                var sum = 0;
                for (var i = 0; i < _matrix.GetLength(0); i++)
                {
                    sum += _matrix[i, j];
                }

                resultDictionary.Add(j, sum);
            }

            return resultDictionary;
        }

        // 9) Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці (включно з побічною діагоналлю матриці)
        public int GetMinOfAbsSumsParallelOfSideDiagonal()
        {
            var rows = _matrix.GetLength(0);
            var columns = _matrix.GetLength(1);

            var sums =
                rows >= columns
                    ? new int[2 * rows - 1 - (rows - columns)]
                    : new int[2 * columns - 1 - (columns - rows)];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    sums[i + j] += Math.Abs(_matrix[i, j]);
                }
            }

            return sums.Min();
        }

        // 10) Сума елементів в тих стовпцях, які  містять хоча б один від’ємний елемент
        public Dictionary<int, int> GetSumsInColumnsWithAnyNegativeElements()
        {
            var columnsIndexesList = new List<int>();

            for (var j = 0; j < _matrix.GetLength(1); j++)
            {
                var isColumnWithNegativeElements = false;
                for (var i = 0; i < _matrix.GetLength(0); i++)
                {
                    if (_matrix[i, j] < 0)
                    {
                        isColumnWithNegativeElements = true;
                        break;
                    }
                }

                if (isColumnWithNegativeElements)
                {
                    columnsIndexesList.Add(j);
                }
            }

            var resultDictionary = new Dictionary<int, int>();

            foreach (var j in columnsIndexesList)
            {
                var sum = 0;
                for (var i = 0; i < _matrix.GetLength(0); i++)
                {
                    sum += _matrix[i, j];
                }

                resultDictionary.Add(j, sum);
            }

            return resultDictionary;
        }

        // 11) Tранспонованa матриця
        public int[,] GetTransposedMatrix()
        {
            var tranposedMatrix = new int[_matrix.GetLength(1), _matrix.GetLength(0)];

            for (var i = 0; i < tranposedMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < tranposedMatrix.GetLength(1); j++)
                {
                    tranposedMatrix[i, j] = _matrix[j, i];
                }
            }

            return tranposedMatrix;
        }

        private int[] MatrixToArray(int[,] matrix)
        {
            var array = new int[matrix.GetLength(0) * matrix.GetLength(1)];

            var arrayId = 0;

            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    array[arrayId] = _matrix[i, j];
                    arrayId++;
                }
            }

            return array;
        }
    }
}