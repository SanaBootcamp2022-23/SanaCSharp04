using Matrix;

using static Utils.Idx;
using static Utils.Terminal;
using static Matrix.MatrixMethods;

NewLine();

int N, M;
N = ParseIntVar("N(Rows)");
M = ParseIntVar("M(Cols)");

int[,] matrix = new int[N, M];
FillIntMatrix(matrix, -10, 10);
// FillIntMatrix(matrix, -1, 10);

NewLine();
Console.WriteLine("Generated matrix: ");
PrintMatrix(matrix);

int positiveCounter, maxNumRepeated, rowsWithoutAnyZero,
 colsWithSomeZero, rowWithLongestSimilarElSeries,
 maxSumAmongMainParallelDiagonals, minAbsSumAmongSecondaryParallelDiagonals;

var matrixStats = new MatrixStats(matrix);

var frequency = matrixStats.Frequency;
var rowsStats = matrixStats.RowsStats;
var colsStats = matrixStats.ColsStats;
var seriesesExists = matrixStats.AtLeastOneSeriesExists;

positiveCounter = matrixStats.PositiveCount;

maxNumRepeated = frequency
    .Where(freq => freq.Value > 1).DefaultIfEmpty()
    .MaxBy(freq => freq.Key)
    .Key;

rowsWithoutAnyZero = rowsStats
    .Where(row => row.Value.NoZeroNums)
    .Count();

colsWithSomeZero = colsStats
    .Where(col => col.Value.ZeroCount >= 1)
    .Count();

rowWithLongestSimilarElSeries = rowsStats
    .MaxBy(row => row.Value.LongestElementsSeries)
    .Key;

List<int> rowsWithoutNegatives = rowsStats
    .Where(row => row.Value.NoNegativeNums)
    .Select(row => row.Key)
    .ToList();

List<int> colsWithoutNegatives = colsStats
    .Where(col => col.Value.NoNegativeNums)
    .Select(col => col.Key)
    .ToList();

List<int> colsWithAtLeastOneNegative = colsStats
    .Where(col => col.Value.NegativeCount >= 1)
    .Select(col => col.Key)
    .ToList();

maxSumAmongMainParallelDiagonals = MaxSumAmongMainParallelDiagonals(matrix);
minAbsSumAmongSecondaryParallelDiagonals = MinAbsSumAmongSecondaryParallelDiagonals(matrix);

NewLine();

Console.WriteLine("Task results: ");
PrintAsListItem($"1) Number of positive elements: {positiveCounter}");
PrintAsListItem($"2) Max number repeated more than once: {maxNumRepeated}");
PrintAsListItem($"3) Rows without any zero element: {rowsWithoutAnyZero}");
PrintAsListItem($"4) Cols with at least one zero element: {colsWithSomeZero}");
PrintAsListItem(
    string.Format("5) Row with longest similar elements series: {0}",
        seriesesExists
            ? toNum(rowWithLongestSimilarElSeries)
            : "No serieses"
    )
);

rowsWithoutNegatives.ForEach(row =>
{
    long product = 1;

    for (int col = 0; col < M; col++)
        product *= matrix[row, col];

    PrintAsListItem($"6) Product for row №{toNum(row)} (no negative elements): {product}");
});

PrintAsListItem(
    $"7) Max sum among the sums of diagonals parallel to the main one: {maxSumAmongMainParallelDiagonals}"
);

colsWithoutNegatives.ForEach(col =>
{
    long sum = 0;

    for (int row = 0; row < N; row++)
        sum += matrix[row, col];

    PrintAsListItem($"8) Sum for col №{toNum(col)} (no negative elements): {sum}");
});

PrintAsListItem(
    $"9) Min absolute sum among the sums of diagonals parallel to the secondary one: {minAbsSumAmongSecondaryParallelDiagonals}"
);

colsWithAtLeastOneNegative.ForEach(col =>
{
    long sum = 0;

    for (int row = 0; row < N; row++)
        sum += matrix[row, col];

    PrintAsListItem($"10) Sum for col №{toNum(col)} (at least one negative): {sum}");
});

PrintAsListItem("11) Transposed matrix: ");
PrintMatrix(TransposeMatrix(matrix));

