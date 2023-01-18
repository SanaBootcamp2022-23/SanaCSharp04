using System;
using System.ComponentModel.Design;
using System.Text;
using Matrix;

/* 
 Для матриці N на M цілого типу визначити:
    1. кількість додатних елементів;
    2. максимальне із чисел, що зустрічається в заданій матриці більше одного разу;
    3. кількість рядків, які не містять жодного нульового елемента;
    4. кількість стовпців, які містять хоча б один нульовий елемент;
    5. номер рядка, в якому знаходиться найдовша серія однакових елементів;
    6. добуток елементів в тих рядках, які не містять від’ємних елементів;
    7. максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці;
    8. суму елементів в тих стовпцях, які не містять від’ємних елементів;
    9. мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці;
    10. суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент;
    11. транспоновану матрицю.
 */

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            var matrix = MatrixOperations.GenerateMatrix(5, 5, -2, 10);
            MatrixOperations.PrintMatrix(matrix);
            //1
            Console.WriteLine($"\n1. Кількість додатних елементів: {MatrixOperations.GetCountOfPositiveNumbers(matrix)}");

            //2
            Console.WriteLine($"\n2. Mаксимальне із чисел, що зустрічається в заданій матриці більше одного разу: {MatrixOperations.GetMaxElemMoreThanOneTime(matrix)}");

            //3
            Console.WriteLine($"\n3. Kількість рядків, які не містять жодного нульового елемента: {MatrixOperations.GetCountOfNotContainedZeroForRows(matrix)}");

            //4
            Console.WriteLine($"\n4. Kількість стовпців, які містять хоча б один нульовий елемент: {MatrixOperations.GetCountOfContainedZeroForColumns(matrix)}");

            //5
            Console.WriteLine($"\n5. Hомер рядка, в якому знаходиться найдовша серія однакових елементів: {MatrixOperations.GetRowIndexWithLargestRepeated(matrix)}");

            //6
            Console.WriteLine("\n6. Добуток елементів в тих рядках, які не містять від’ємних елементів:");
            MatrixOperations.MultiplicationOfRowsWithoutNegativeNumbers(matrix);

            //7
            Console.WriteLine($"\n7. Mаксимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: {MatrixOperations.GetMaxAmongSumsOfDiagonalElementsParallelToMain(matrix)}");

            //8
            Console.WriteLine($"\n8. Cуму елементів в тих стовпцях, які не містять від’ємних елементів");
            MatrixOperations.SumOfColumnsWithoutNegativeNumbers(matrix);

            //9
            Console.WriteLine($"\n9. Mінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: {MatrixOperations.GetMinSumAmongSumsOfDiagonalElementsParallelToSide(matrix)}");

            //10
            Console.WriteLine($"\n10. Cуму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент:");
            MatrixOperations.SumOfColumnsWithNegativeNumbers(matrix);

            //11
            Console.WriteLine("\n11. Tранспоновану матрицю:");
            MatrixOperations.PrintTransportMatrix(matrix);
        }
    }
}
