using System;

using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http.Features;

class Day5
{

   /* static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        String path = "C:\\Users\\usuario\\Desktop\\input.txt";
        Console.Write("The multiplication result is: " + Day5FirstProblem(path) + "\n");
        Console.Write("The enabled multiplication result is: " + Day5SecondProblem(path));



    }*/
    public static int Day5FirstProblem(string path)
    {
        int result = 0;
        List<Tuple<int, int>> firstPart = new List<Tuple<int, int>>();
        if (File.Exists(path))
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                //We check if its the 1st part
                while (!String.IsNullOrEmpty(s = sr.ReadLine()))
                {
                    firstPart.Add(new Tuple<int, int>(Int32.Parse(s.Split("|")[0]), Int32.Parse(s.Split("|")[1])));
                }
                //We read the second part
                while ((s = sr.ReadLine()) != null)
                {
                    List<int> numbers = s.Split(",").ToList().Select(int.Parse).ToList();
                    //we check te rules
                    List<int> numbersChecked = new List<int>();
                    bool errorRegla = false;
                    for (int i = 0; i < numbers.Count && !errorRegla; i++)
                    {
                        List<Tuple<int, int>> before = firstPart.FindAll(x => x.Item2 == numbers[i]);
                        foreach (Tuple<int, int> numberBefore in before)
                        {
                            //You have a rule that it is not acoplish
                            if (numbers.Contains(numberBefore.Item1) && !numbersChecked.Contains(numberBefore.Item1))
                            {
                                errorRegla = true;
                                break;
                            }
                        }
                        numbersChecked.Add(numbers[i]);
                    }
                    //Not an error in the rule
                    if (!errorRegla)
                    {
                        result = result + numbers[numbers.Count / 2];
                    }


                }



            }
        return result;
    }

    public static int Day5SecondProblem(string path)
    {
        int result = 0;
        List<Tuple<int, int>> firstPart = new List<Tuple<int, int>>();
        if (File.Exists(path))
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                //We check if its the 1st part
                while (!String.IsNullOrEmpty(s = sr.ReadLine()))
                {
                    firstPart.Add(new Tuple<int, int>(Int32.Parse(s.Split("|")[0]), Int32.Parse(s.Split("|")[1])));
                }
                //We read the second part
                while ((s = sr.ReadLine()) != null)
                {
                    List<int> numbers = s.Split(",").ToList().Select(int.Parse).ToList();
                    //we check te rules
                    List<int> numbersChecked = new List<int>();
                    bool errorRegla = false;
                    bool tryagain = false;
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        List<Tuple<int, int>> before = firstPart.FindAll(x => x.Item2 == numbers[i]);
                        foreach (Tuple<int, int> numberBefore in before)
                        {
                            //You have the error here so you swap numbers (you dont need break because several rules can be break)                          
                            tryagain = false;
                            if (numbers.Contains(numberBefore.Item1) && !numbersChecked.Contains(numberBefore.Item1))
                            {
                                tryagain = true;
                                errorRegla = true;
                                int index = numbers.IndexOf(numberBefore.Item1);
                                int temp = numbers[i];
                                numbers[i] = numbers[index];
                                numbers[index] = temp;
                                break;

                            }
                        }
                        //We detect an error so we start again   
                        if (tryagain)
                        {
                            //We try again for the beggining
                            i = -1;
                            numbersChecked = new List<int>();
                            tryagain = false;
                        }
                        else
                        {
                            numbersChecked.Add(numbers[i]);
                        }
                    }
                    //An error in the rule so you add it
                    if (errorRegla)
                    {
                        result = result + numbers[numbers.Count / 2];
                    }



                }



            }
        return result;
    }

    public static void swap(int number1, int number2)
    {

        int temp = number1;
        number1 = number2;
        number2 = temp;

    }





}






