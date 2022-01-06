using System;
using System.IO;
using System.Collections.Generic;

namespace CSh_Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex_1();
            Ex_2();
        }

        static void Ex_1()
        {
            string text;
            using (StreamReader file = new StreamReader("text.txt"))
            {
                text = file.ReadToEnd();
            }

            string[] sentenses = text.Split(new char[] { '?', '!', '.' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string i in sentenses)
            {
                if (!i.Contains(','))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void Ex_2()
        {
            // Чтение с файла
            string text1;
            using (StreamReader file1 = new StreamReader("text1.txt"))
            {
                text1 = file1.ReadToEnd();
            }

            // Отделение только списка профессий
            string[] doctors = text1.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            string[] speciality = new string [doctors.Length];
            int k = 0;
            foreach (string i in doctors)
            {
                speciality[k] = i.Substring(i.IndexOf(' ') + 1, i.Length - 1 - i.IndexOf(' '));
                k += 1;
            }

            // Составление списка  оригинальных професий
            List<string> originalProfessions = new List<string>();
            originalProfessions.Add(speciality[0]);
            foreach(string i in speciality) if (originalProfessions.IndexOf(i) == -1) originalProfessions.Add(i);

            int[] num = new int[originalProfessions.Count];
            int q = 0;
            foreach (string original in originalProfessions)
            {
                foreach (string clone in speciality)
                {
                    if (String.Compare(original, clone) == 0)
                    {
                        num[q] += 1;
                    }
                }
                q += 1;
            }

            //Вывод в файл
            using (StreamWriter file2 = new StreamWriter("text2.txt", false))
            {
                for (int i = 0; i < originalProfessions.Count; i++)
                {
                    file2.Write($"{originalProfessions[i]} - {num[i]}");
                }
            }
        }
    }
}
