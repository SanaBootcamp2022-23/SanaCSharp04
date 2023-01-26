using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class CheckCorrectness
    {
        static bool correct;
        static string message;
        static uint result;
        static int leftBorderMatrix;
        static int rightBorderMatrix;
        public static uint SizeMatrix(NameEnum name)
        {
            do
            {
                if (name == NameEnum.Width)
                    Console.Write($"Matrix width = ");
                else
                    Console.Write($"Matrix height = ");
                correct = uint.TryParse(Console.ReadLine(), out result);

                if (!correct)
                {
                    message = "Error! Incorrect data";
                    PrintText.PrintRedText(message);
                }
                else if (result == 0 && correct)
                {
                    message = "Error! Width must be greater than zero";
                    PrintText.PrintRedText(message);
                }
                else
                {
                    message = "Great!";
                    PrintText.PrintGreenText(message);
                }

            } while (!correct || result == 0);
            return result;
        }

        public static int LeftBorder()
        {
            do
            {
                Console.Write("The left border of the matrix range = ");
                correct = int.TryParse(Console.ReadLine(), out leftBorderMatrix);
                if (correct)
                {
                    message = "Great!";
                    PrintText.PrintGreenText(message);
                }
                else
                {
                    message = "Error! Incorrect data";
                    PrintText.PrintRedText(message);
                }

            } while (!correct);
            return leftBorderMatrix;
        }

        public static int RightBorder()
        {

            do
            {
                Console.Write("The right border of the matrix range = ");
                correct = int.TryParse(Console.ReadLine(), out rightBorderMatrix);
                if (correct && rightBorderMatrix > leftBorderMatrix + 1)
                {
                    message = "Great!";
                    PrintText.PrintGreenText(message);
                }
                else
                {
                    message = "Error! Incorrect data";
                    PrintText.PrintRedText(message);
                }
                if (rightBorderMatrix <= leftBorderMatrix + 1)
                {
                    message = "The right border should be greater than the left border by two points";
                    PrintText.PrintRedText(message);
                }

            } while (!correct || rightBorderMatrix <= leftBorderMatrix + 1);
            return rightBorderMatrix;
        }
    }
}
