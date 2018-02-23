using Inlämninguppgift1.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Inlämninguppgift1
{
    class Runtime
    {
        public void Start()
        {
            int[] numbers = GetNumbersFromFile("Unsorted.txt");
            //numbers.BubbleSort(false);
            numbers.MergeSort();
            string fileName = string.Format("{0:yyyy-MM-dd--H-mm-ss}",
            DateTime.Now);

            SavenumbersToFile(numbers, fileName);
        }

        int[] GetNumbersFromFile(string fileNameWithExtension)
        {
            var filePath = $@"{Directory.GetCurrentDirectory()}\TextFiles\{fileNameWithExtension}";
            int[] numbers = Array.ConvertAll(File.ReadAllLines(filePath), int.Parse);
            return numbers;
        }

        void SavenumbersToFile(int[] numbers, string filename)
        {
            string[] numbersToString = Array.ConvertAll(numbers, n => n.ToString());
            var filePath = $@"{Directory.GetCurrentDirectory()}\TextFiles\{filename}";
            File.WriteAllLines(filePath, numbersToString);
        }
    }
}
