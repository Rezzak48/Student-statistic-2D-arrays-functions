using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int numberOfWeeks = 36;
            int numberOfSubjects = 8;
            int scale = 20;
            int[,] data;

            data = generateData(numberOfWeeks, numberOfSubjects, scale);
            printData(data);
            // U can modify the data using dataModify(int weekIndex, int subjectIndex, int[,] data, int element)
            dataModify(0, 0, data, 100);
            //Printing the new data after modifying
            printData(data);
            totalScore(data);
            GoodResult(data);
            subjectAverage(data);
            isIncrease(data);
            favouriteSubjects(data);
            hatedSubject(data);

            Console.WriteLine();
            Console.ReadLine();
        }

        // Problem with generating data in a specific way
        private static int[,] generateData(int numberOfWeeks, int numberOfSubjects, int scale)
        {
            int[,] data = new int[numberOfWeeks, numberOfSubjects];
            Random rnd = new Random();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = rnd.Next(0, (16 + 1));

                    if (j < 3)
                    {
                        data[i, j] = rnd.Next(15, (scale + 1));
                    }

                    if ((j + 1) % 4 == 0 && data[i, j] != 0)
                    {
                        data[i, rnd.Next(3, data.GetLength(1))] = 0;
                    }
                }
            }
            return data;
        }

        private static string printData(int[,] data)
        {
            string dataPr = "";
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    dataPr += (data[i, j] + ";");
                }
                dataPr += "\n";
            }
            Console.WriteLine("Printing the Data:" + "\n" + dataPr);
            return dataPr;
        }

        private static void dataModify(int weekIndex, int subjectIndex, int[,] data, int element)
        {
            data[weekIndex, subjectIndex] = element;
        }

        private static int totalScore(int[,] data)
        {
            int total = 0;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    total += data[i, j];
                }
            }
            Console.WriteLine("The totalScore is : " + total);
            return total;
        }

        private static int GoodResult(int[,] data)
        {
            int count = 0;
            int successfulTest = 15;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    int result = data[i, j];
                    if (result > successfulTest)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine("\nThe Number of Succesful test above 15 is : " + count);
            return count;
        }

        private static double[] subjectAverage(int[,] data)
        {
            double sumOfsubjectsScore = 0;
            double[] average = new double[data.GetLength(1)];

            for (int i = 0; i < data.GetLength(1); i++)
            {
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    sumOfsubjectsScore += data[j, i];
                }
                average[i] = (Math.Round((sumOfsubjectsScore / data.GetLength(0)), 2));
                sumOfsubjectsScore = 0;
            }

            Console.WriteLine("\nThe AVERAGE OF EACH IS SUB : ");
            for (int i = 0; i < average.Length; i++)
            {
                Console.WriteLine(average[i]);
            }

            return average;
        }

        private static bool isIncrease(int[,] data)
        {
            Console.Write("\nAverage week result is increasing : ");
            int weeklySum;
            double[] weeklyAvg = new double[data.GetLength(0)];
            double previousWeek = weeklyAvg[0];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                weeklySum = 0;
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    weeklySum += data[i, j];
                }
                weeklyAvg[i] = weeklySum / data.GetLength(1);
            }

            for (int i = 0; i < weeklyAvg.Length; i++)
            {
                if (weeklyAvg[i] < previousWeek)
                {
                    Console.WriteLine(false);
                    return false;
                }
                else
                {
                    previousWeek = weeklyAvg[i];
                }
            }
            Console.WriteLine(true);
            return true;
        }

        private static int favouriteSubjects(int[,] data)
        {
            //THE INDEX OF FAV SUB
            Console.Write("\nTHE INDEX OF FAV SUB is : ");
            double sum;
            double[] yearlyAvrg = new double[data.GetLength(1)];
            double favSubject = yearlyAvrg[0];
            int favSubjectIndex = -1;

            //Storing subjects average
            for (int j = 0; j < data.GetLength(1); j++)
            {
                sum = 0;
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    sum += data[i, j];
                }
                yearlyAvrg[j] = sum / data.GetLength(0);
            }

            //Check the best yearly average
            for (int i = 0; i < yearlyAvrg.Length; i++)
            {
                if (favSubject <= yearlyAvrg[i])
                {
                    favSubject = yearlyAvrg[i];
                    favSubjectIndex = i;
                }
            }
            Console.WriteLine(favSubjectIndex);
            return favSubjectIndex;
        }

        private static int hatedSubject(int[,] data)
        {
            Console.Write("\nTHE INDEX OF HATED SUB is: ");
            double sum;
            double[] yearlyAvrg = new double[data.GetLength(1)];
            double hatedSubject;
            int hatedSubjectIndex = -1;

            //Storing subjects average
            for (int j = 0; j < data.GetLength(1); j++)
            {
                sum = 0;
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    sum += data[i, j];
                }
                yearlyAvrg[j] = sum / data.GetLength(0);
            }

            //Check the worst yearly average
            hatedSubject = yearlyAvrg[0];
            for (int i = 0; i < yearlyAvrg.Length; i++)
            {
                if (yearlyAvrg[i] <= hatedSubject)
                {
                    hatedSubject = yearlyAvrg[i];
                    hatedSubjectIndex = i;
                }
            }
            Console.WriteLine(hatedSubjectIndex);
            return hatedSubjectIndex;
        }
    }
}