using System;

using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http.Features;

class Day4
{

    /*static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        String path="C:\\Users\\usuario\\Desktop\\input.txt";
        Console.Write("XMAS appears "+ Day4FirstProblem(path)+" times\n");
        Console.Write("XMAS in X form appears: "+ Day4SecondProblem(path)+" times");
        
        
 
    }*/
    public static int Day4FirstProblem(string path)
    {
        int result = 0;
        if (File.Exists(path))
        {
            result = result + Vertical(path) + VerticalBack(path) + Horizontal(path) + HorizontalBack(path) + DiagonalRight(path) + DiagonalRightBack(path) + DiagonalLeft(path) + DiagonalLeftBack(path);
        }

        return result;
    }

    public static int Day4SecondProblem(string path)
    {
        int result = 0;
        if (File.Exists(path))
        {
            result = Xmas(path);
        }
        return result;
    }


    public static int Horizontal(string path)
    {
        int count = 0;
        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                count = count + Regex.Matches(s, "XMAS").Count;

            }
        }
        return count;
    }

    public static int HorizontalBack(string path)
    {
        int countBack = 0;
        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                countBack = countBack + Regex.Matches(s, "SAMX").Count; ;
            }
        }



        return countBack;
    }

    public static int Vertical(string path)
    {
        int count = 0;

        using (StreamReader srX = File.OpenText(path)) using (StreamReader srM = File.OpenText(path)) using (StreamReader srA = File.OpenText(path)) using (StreamReader srS = File.OpenText(path))
        {
            string sX;
            string sM;
            string sA;
            string sS;
            //We start in second line for M
            srM.ReadLine();
            //We start in third line for A
            srA.ReadLine();
            srA.ReadLine();
            //We start in fourth line for S
            srS.ReadLine();
            srS.ReadLine();
            srS.ReadLine();
            while ((sX = srX.ReadLine()) != null && (sM = srM.ReadLine()) != null && (sA = srA.ReadLine()) != null && (sS = srS.ReadLine()) != null)
            {
                List<int> foundIndexes = new List<int>();
                //Loop to get the char X indexes
                for (int i = sX.IndexOf("X"); i > -1; i = sX.IndexOf("X", i + 1))
                {
                    foundIndexes.Add(i);
                }
                foreach (int i in foundIndexes)
                {
                    //We can found the word vertically
                    if ("M".CompareTo(sM[i].ToString()) == 0 && "A".CompareTo(sA[i].ToString()) == 0 && "S".CompareTo(sS[i].ToString()) == 0)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    public static int VerticalBack(string path)
    {
        int count = 0;

        using (StreamReader srX = File.OpenText(path)) using (StreamReader srM = File.OpenText(path)) using (StreamReader srA = File.OpenText(path)) using (StreamReader srS = File.OpenText(path))
        {
            string sX;
            string sM;
            string sA;
            string sS;
            //We start in second line for A
            srA.ReadLine();
            //We start in third line for M
            srM.ReadLine();
            srM.ReadLine();
            //We start in fourth line for X
            srX.ReadLine();
            srX.ReadLine();
            srX.ReadLine();
            while ((sX = srX.ReadLine()) != null && (sM = srM.ReadLine()) != null && (sA = srA.ReadLine()) != null && (sS = srS.ReadLine()) != null)
            {
                List<int> foundIndexes = new List<int>();
                //Loop to get the char S indexes
                for (int i = sS.IndexOf("S"); i > -1; i = sS.IndexOf("S", i + 1))
                {
                    foundIndexes.Add(i);
                }
                foreach (int i in foundIndexes)
                {
                    //We can found the word vertically backwards
                    if ("M".CompareTo(sM[i].ToString()) == 0 && "A".CompareTo(sA[i].ToString()) == 0 && "X".CompareTo(sX[i].ToString()) == 0)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    public static int DiagonalRight(string path)
    {
        int count = 0;

        using (StreamReader srX = File.OpenText(path)) using (StreamReader srM = File.OpenText(path)) using (StreamReader srA = File.OpenText(path)) using (StreamReader srS = File.OpenText(path))
        {
            string sX;
            string sM;
            string sA;
            string sS;
            //We start in second line for M
            srM.ReadLine();
            //We start in third line for A
            srA.ReadLine();
            srA.ReadLine();
            //We start in fourth line for S
            srS.ReadLine();
            srS.ReadLine();
            srS.ReadLine();
            while ((sX = srX.ReadLine()) != null && (sM = srM.ReadLine()) != null && (sA = srA.ReadLine()) != null && (sS = srS.ReadLine()) != null)
            {
                List<int> foundIndexes = new List<int>();
                //X cant be in the last 3 letters if its diagonally
                sX.Remove(sX.Length - 3);
                //Loop to get the char X indexes
                for (int i = sX.IndexOf("X"); i > -1; i = sX.IndexOf("X", i + 1))
                {
                    foundIndexes.Add(i);
                }
                foreach (int i in foundIndexes)
                {
                    //We can found the word diagonally right (1st condition because X cant be in last 3 line positiosn)
                    if (i < sX.Length - 3 && "M".CompareTo(sM[i + 1].ToString()) == 0 && "A".CompareTo(sA[i + 2].ToString()) == 0 && "S".CompareTo(sS[i + 3].ToString()) == 0)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    public static int DiagonalRightBack(string path)
    {
        int count = 0;

        using (StreamReader srX = File.OpenText(path)) using (StreamReader srM = File.OpenText(path)) using (StreamReader srA = File.OpenText(path)) using (StreamReader srS = File.OpenText(path))
        {
            string sX;
            string sM;
            string sA;
            string sS;
            //We start in second line for A
            srA.ReadLine();
            //We start in third line for M
            srM.ReadLine();
            srM.ReadLine();
            //We start in fourth line for X
            srX.ReadLine();
            srX.ReadLine();
            srX.ReadLine();
            while ((sX = srX.ReadLine()) != null && (sM = srM.ReadLine()) != null && (sA = srA.ReadLine()) != null && (sS = srS.ReadLine()) != null)
            {
                List<int> foundIndexes = new List<int>();
                //X cant be in the last 3 letters if its diagonally
                //sS.Remove(sS.Length-3);
                //Loop to get the char S indexes
                for (int i = sS.IndexOf("S"); i > -1; i = sS.IndexOf("S", i + 1))
                {
                    foundIndexes.Add(i);
                }
                foreach (int i in foundIndexes)
                {
                    //We can found the word diagonally right (1st condition because X cant be in last 3 line positiosn)
                    if ((i < sS.Length - 3) && ("A".CompareTo(sA[i + 1].ToString()) == 0 && "M".CompareTo(sM[i + 2].ToString()) == 0 && "X".CompareTo(sX[i + 3].ToString()) == 0))
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    public static int DiagonalLeft(string path)
    {
        int count = 0;

        using (StreamReader srX = File.OpenText(path)) using (StreamReader srM = File.OpenText(path)) using (StreamReader srA = File.OpenText(path)) using (StreamReader srS = File.OpenText(path))
        {
            string sX;
            string sM;
            string sA;
            string sS;
            //We start in second line for M
            srM.ReadLine();
            //We start in third line for A
            srA.ReadLine();
            srA.ReadLine();

            //We start in fourth line for S
            srS.ReadLine();
            srS.ReadLine();
            srS.ReadLine();
            while ((sX = srX.ReadLine()) != null && (sM = srM.ReadLine()) != null && (sA = srA.ReadLine()) != null && (sS = srS.ReadLine()) != null)
            {
                List<int> foundIndexes = new List<int>();

                //Loop to get the char X indexes
                for (int i = sX.IndexOf("X"); i > -1; i = sX.IndexOf("X", i + 1))
                {
                    foundIndexes.Add(i);
                }
                foreach (int i in foundIndexes)
                {
                    //We can found the word diagonally right (X xcant be in 1st 3 positions)
                    if (i > 2 && "M".CompareTo(sM[i - 1].ToString()) == 0 && "A".CompareTo(sA[i - 2].ToString()) == 0 && "S".CompareTo(sS[i - 3].ToString()) == 0)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    public static int DiagonalLeftBack(string path)
    {
        int count = 0;

        using (StreamReader srX = File.OpenText(path)) using (StreamReader srM = File.OpenText(path)) using (StreamReader srA = File.OpenText(path)) using (StreamReader srS = File.OpenText(path))
        {
            string sX;
            string sM;
            string sA;
            string sS;
            //We start in second line for A
            srA.ReadLine();
            //We start in third line for M
            srM.ReadLine();
            srM.ReadLine();

            //We start in fourth line for X
            srX.ReadLine();
            srX.ReadLine();
            srX.ReadLine();
            while ((sX = srX.ReadLine()) != null && (sM = srM.ReadLine()) != null && (sA = srA.ReadLine()) != null && (sS = srS.ReadLine()) != null)
            {
                List<int> foundIndexes = new List<int>();

                //Loop to get the char S indexes
                for (int i = sS.IndexOf("S"); i > -1; i = sS.IndexOf("S", i + 1))
                {
                    foundIndexes.Add(i);
                }
                foreach (int i in foundIndexes)
                {
                    //We can found the word diagonally right (S cant be in 1st 3 positions)
                    if (i > 2 && "A".CompareTo(sA[i - 1].ToString()) == 0 && "M".CompareTo(sM[i - 2].ToString()) == 0 && "X".CompareTo(sX[i - 3].ToString()) == 0)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    public static int Xmas(string path)
    {
        int count = 0;
        using (StreamReader srA = File.OpenText(path)) using (StreamReader srUp = File.OpenText(path)) using (StreamReader srDown = File.OpenText(path))
        {
            string sUp;
            string sA;
            string sDown;
            //We start in second line for A
            srA.ReadLine();
            //We start in third line for Down
            srDown.ReadLine();
            srDown.ReadLine();

            while ((sUp = srUp.ReadLine()) != null && (sA = srA.ReadLine()) != null && (sDown = srDown.ReadLine()) != null)
            {
                List<int> foundIndexes = new List<int>();
                //Loop to get the char A indexes
                for (int i = sA.IndexOf("A"); i > -1; i = sA.IndexOf("A", i + 1))
                {
                    foundIndexes.Add(i);
                }
                foreach (int i in foundIndexes)
                {
                    //We can found the word in all X forms right (A cant be in 1st or last positions)
                    if (i > 0 && i < sA.Length - 1 && "M".CompareTo(sUp[i - 1].ToString()) == 0 && "S".CompareTo(sDown[i - 1].ToString()) == 0 && "S".CompareTo(sDown[i + 1].ToString()) == 0 && "M".CompareTo(sUp[i + 1].ToString()) == 0)
                    {
                        count++;


                    }
                    else if (i > 0 && i < sA.Length - 1 && "M".CompareTo(sUp[i + 1].ToString()) == 0 && "S".CompareTo(sDown[i - 1].ToString()) == 0 && "S".CompareTo(sUp[i - 1].ToString()) == 0 && "M".CompareTo(sDown[i + 1].ToString()) == 0)
                    {
                        count++;


                    }
                    else if (i > 0 && i < sA.Length - 1 && "M".CompareTo(sDown[i - 1].ToString()) == 0 && "S".CompareTo(sUp[i + 1].ToString()) == 0 && "M".CompareTo(sUp[i - 1].ToString()) == 0 && "S".CompareTo(sDown[i + 1].ToString()) == 0)
                    {
                        count++;

                    }
                    else if (i > 0 && i < sA.Length - 1 && "M".CompareTo(sDown[i + 1].ToString()) == 0 && "S".CompareTo(sUp[i - 1].ToString()) == 0 && "S".CompareTo(sUp[i + 1].ToString()) == 0 && "M".CompareTo(sDown[i - 1].ToString()) == 0)
                    {
                        count++;

                    }
                }

            }
        }
        return count;
    }



}






