using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace _2_laba
{
    public class Sentence
    {
        private string enter = "I am from Ukraine";
        private int lengthl = 0;
        private int lenghtw = 0;


        public string Enter // створюємо аксесори

        {
            get { return enter; }
            set { enter = value; }
        }

        public int Lengthl // створюємо аксесори
        {
            set { lengthl = value; }
            get { return lengthl; }
        }

        public int Lengthw // створюємо аксесори
        {
            get { return lenghtw; }
            set { lenghtw = value; }
        }





    }


    class Program
    {



        static void Main(string[] args)
        {

            Sentence sentence = new Sentence(); // створюємо об'єкт класу 
            SaveToJSON(sentence);
            var Sentence = DeserializeObject();
            bool b = false; // створюємо булеву змінну для циклу
            do
            {
                Console.WriteLine("Your sentence is : " + sentence.Enter);
                Console.WriteLine();
                Console.WriteLine("Choose an option :");
                Console.WriteLine("1 - Add new word");
                Console.WriteLine("2 - Delete word");
                Console.WriteLine("3 - Insert new word");
                Console.WriteLine("4 - Amount of letters");
                Console.WriteLine("5 - Amount of words");
                Console.WriteLine("6 - The shortest word");
                Console.WriteLine("7 - The longest word");
                Console.WriteLine("8 - Check for existence");
                Console.WriteLine("9 - Check for similarity");
                Console.WriteLine();

                int n = int.Parse(Console.ReadLine()); // користувач вводить число методу яким хоче скористатись
                Console.WriteLine("You chose : " + n);

                switch (n) //за допомогою конструкції свіч кейс розглядаємо можлтві варіанти вводу числа користувачем
                {
                    case 1:
                        AddWord();
                        break;
                    case 2:
                        RemoveWord();
                        break;
                    case 3:
                        InsertWord();
                        break;
                    case 4:
                        AmountofLetters();
                        break;
                    case 5:
                        AmountofWords();
                        break;
                    case 6:
                        TheShortestWord();
                        break;
                    case 7:
                        TheLongestWord();
                        break;
                    case 8:
                        Exist();
                        break;
                    case 9:
                        Compare();
                        break;

                }
                void AddWord() // метод додавання слова
                {
                    Console.WriteLine("What do you want to add : ");
                    string add = Console.ReadLine();
                    string result = string.Concat(sentence.Enter, " ", add); // метод конкатинації
                    Console.WriteLine(result);
                }

                void RemoveWord() // метод видалення слова
                {
                    Console.Write("Enter what do you want to delete : ");
                    string remove1 = Console.ReadLine();
                    string result = sentence.Enter.Replace(remove1, " "); // метод Replace 
                    Console.WriteLine(result);
                }

                void InsertWord() // метод вставляння слова
                {
                    Console.Write("Enter WHAT do you want to insert : ");
                    string insert = Console.ReadLine();
                    Console.WriteLine("Enter WHERE do you want to inser (1 - Before the first word, 2 - Before the second word i tak dalee): ");
                    int n = int.Parse(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            sentence.Enter = sentence.Enter.Insert(0, insert + " ");
                            break;
                        case 2:
                            sentence.Enter = sentence.Enter.Insert(2, insert + " ");
                            break;
                        case 3:
                            sentence.Enter = sentence.Enter.Insert(5, insert + " ");
                            break;
                        case 4:
                            sentence.Enter = sentence.Enter.Insert(10, insert + " ");
                            break;


                    }


                    Console.WriteLine(sentence.Enter);
                }

                void AmountofLetters() // метод підрахунку літер
                {
                    char[] arr = sentence.Enter.ToCharArray(); // перетворюємо речення у масив символів
                    int result = 0;
                    foreach (var item in arr) // через цикл підраховуємо кількість літер
                    {
                        if (item != ' ')
                        {
                            sentence.Lengthl++;
                        }
                    }
                    result = sentence.Lengthl;
                    Console.WriteLine(result);
                }

                void AmountofWords() // метод підрахунку слів
                {
                    string[] arr = sentence.Enter.Split(' '); // перетворюєио речення у масив стрінгів 
                    sentence.Lengthw = arr.Length;
                    Console.WriteLine("The amount of words is : " + sentence.Lengthw);
                }

                void TheShortestWord() // метод найкоротшого слова
                {
                    sentence.Enter = sentence.Enter.Trim(); // прибираємо пробіли у реченні
                    string[] arr = sentence.Enter.Split();
                    int min = 999999;


                    for (int i = 0; i < arr.Length; i++) // через цикл знаходимо найкоротше слово
                    {
                        if (arr[i].Length < min)
                            min = arr[i].Length;
                    }
                    Console.WriteLine("The shortest word has : " + min + " letters ");
                }

                void TheLongestWord() // метод найдовшого слова
                {
                    sentence.Enter = sentence.Enter.Trim(); // прибираємо пробіли у реченні
                    string[] arr = sentence.Enter.Split();
                    int max = 0;


                    for (int i = 0; i < arr.Length; i++) // через цикл знаходимо найкоротше слово
                    {
                        if (arr[i].Length > max)
                            max = arr[i].Length;
                    }
                    Console.WriteLine("The longest word has : " + max + " letters ");
                }

                void Exist() // метод перевірки слова на існування
                {

                    Console.WriteLine("Enter the word you want to check for existence : ");
                    string enter = Console.ReadLine();
                    Console.WriteLine();

                    if (sentence.Enter.Contains(enter)) // метод Contains
                        Console.WriteLine("Yes! This word is exist");
                    else
                        Console.WriteLine("Unfortunately, there is no this word");


                }

                void Compare() // метод порівняння двох речень
                {
                    Console.WriteLine("Enter your sentence : ");
                    string enter1 = Console.ReadLine();
                    if (sentence.Enter == enter1)
                        Console.WriteLine("Your sentence is the same!");
                    else
                        Console.WriteLine("Your sentence is not the same");
                }

                Console.WriteLine();
                Console.WriteLine();
            } while (b != true);



            static void SaveToJSON(Sentence sentence)                    // метод збереження об'єкта у json файл
            {
                var ObjectJSON = JsonConvert.SerializeObject(sentence);  // серіалізація

                File.WriteAllText("D:/1.json", ObjectJSON);     // запис у файл об'екта
            }

            static Sentence DeserializeObject()  // десеріалізація об'екта 
            {
                string filePath = @"D:/1.json";
                if (File.Exists(filePath))   // метод Exist
                {
                    var DeserializationObj = JsonConvert.DeserializeObject<Sentence>(File.ReadAllText(filePath)); // десеріалізуєм


                    return DeserializationObj;
                }
                else
                {
                    return null;
                }
            }





        }


    }

}


















