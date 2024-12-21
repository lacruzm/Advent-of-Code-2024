using System;

using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http.Features;

class Day6
{

    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        String path = "C:\\Users\\usuario\\Desktop\\input.txt";
        Console.Write("The guard visists: " + Day6FirstProblem(path) + " positions\n");
        //Console.Write("The enabled multiplication result is: " + Day5SecondProblem(path));



    }
    public static int Day6FirstProblem(string path)
    {
        int line = 0;
        List<List<string>> map = new List<List<string>>();
        int[] positionsStart = new int[2];
        if (File.Exists(path))
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while (!String.IsNullOrEmpty(s = sr.ReadLine()))
                {
                    List<string> row = new List<string>();
                    int rowPosition = 0;
                    foreach (char c in s)
                    {
                        row.Add(c.ToString());
                        //We mark the starting position
                        if (c == '^')
                        {
                            Tuple<int, int> positionStart = new Tuple<int, int>(line, rowPosition);
                            positionsStart[0] = line;
                            positionsStart[1] = rowPosition;

                        }
                        rowPosition++;
                    }
                    map.Add(row);
                    line++;
                }
            }
        //we got the map in the list of lists, now lets start the game
        try
        {
            //We play the game until we reach the boundary
            int row=positionsStart[0];
            int column=positionsStart[1];
            string start=map[row][column];
            map[row][column]="X";
            string charMap;
            while(true){   
                switch(start){
                    case "^":
                    row--;
                    charMap=map[row][column];
                    map[row][column]="X";
                    //We find an obstacle so we go back and change direction
                    if(charMap.Equals("#")){
                        map[row][column]="#";
                        row++;
                        charMap=map[row][column];
                        start=">";
                    }
                    break;
                    case "<":
                    column--;
                    charMap=map[row][column];
                    map[row][column]="X";
                    if(charMap.Equals("#")){
                        map[row][column]="#";
                        column++;
                        charMap=map[row][column];
                        start="^";
                    }
                    break;
                    case ">":
                    column++;
                    charMap=map[row][column];
                    map[row][column]="X";
                    if(charMap.Equals("#")){
                        map[row][column]="#";
                        column--;
                        charMap=map[row][column];
                        start="v";
                    }
                    break;
                    case "v":
                    row++;
                    charMap=map[row][column];
                    map[row][column]="X";
                    if(charMap.Equals("#")){
                        map[row][column]="#";
                        row--;
                        charMap=map[row][column];
                        start="<";
                    }
                    break;
                }
            }

        }
        catch (Exception e)
        {
            //The exception appeared because we reach the boundary
            return ReadX(map);


        }
    }

    public static int ReadX(List<List<string>> data)
    {
        int result = 0;
        foreach(List<string> row in data){
            foreach(string s in row){
                if(s.Equals("X")){
                    result++;
                }
            }

        }
        return result;
}





}






