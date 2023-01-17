using Matrix;

int n, m;
Console.WriteLine("Привiт!");
Console.WriteLine("Введiть число рядкiв: ");
n = int.Parse(Console.ReadLine());
Console.WriteLine("Введiть число колонок: ");
m = int.Parse(Console.ReadLine());
int[,] Array = Method.CreateMatrix(n,m) ;
Method.OutPutMatrix(Array);
int positive = Method.ShowPositiveElement(Array);
int max_num=Method.ElementRepit(Array);
int rowsWithOut = Method.NumbRowWtZero(Array);
int colCount=Method.NumbColWtZero(Array);
int maxRow=Method.NumbrMostRep(Array);
int sumElCol=Method.SumOfElementWithoutNegative(Array);
double product=Method.MultipNumbWithTNegative(Array);
int maxSum=Method.MaximumsOfSumFirstDiagonal(Array);
int minSum=Method.MinimumSumOfModules(Array);
int sumColl=Method.SumOfColsWhichHaveNegativeElement(Array);
Console.WriteLine(
            $"Кiлькiсть додатних елементiв: {positive} \n" +
            $"Максимальне iз чисел, що зустрiчається в заданiй матрицi бiльше одного разу: {max_num}\n" +
            $"Кiлькiсть рядкiв, якI не мiстять жодного нульового елемента: {rowsWithOut}\n" +
            $"Кiлькiсть стовпцiв, якi мiстять хоча б один нульовий елемент: {colCount}\n" +
            $"Номер рядка в якому знаходиться найдовша серiя однакових чисел: {maxRow}\n" +
            $"Cумa елементiв в тих стовпцях, якi не мiстять вiд’ємних елементiв: {sumElCol} \n" +
            $"Добуток елементiв в тих рядках, якi не мiстять вiд’ємних елементiв: {product}\n" +
            $"Mаксимум серед сум елементiв дiагоналей, паралельних головнiй дiагоналi матрицi: {maxSum}\n" +
            $"Мiнiмум серед сум модулiв елементiв дiагоналей, паралельних побiчнiй дiагоналi матрицi: {minSum}\n" +
            $"Суму елементiв в тих стовпцях, якi  мiстять хоча б один вiд’ємний елемент: {sumColl}\n");
Method.TransponMatrixOutPut(Array);
