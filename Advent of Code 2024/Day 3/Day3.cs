using System;

using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http.Features;

class Day3
{
    
    /*static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        String path="C:\\Users\\usuario\\Desktop\\input.txt";
        Console.Write("The multiplication result is: "+ Day3FirstProblem(path)+"\n");
        Console.Write("The enabled multiplication result is: "+ Day3SecondProblem(path));
        
        
 
    }*/
    public static int Day3FirstProblem(string path){
    int result=0;
    if (File.Exists(path))

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                MatchCollection m1=Regex.Matches("","");
                List<Match> combinedList = new List<Match>();
                List<string> mulResults=new List<string>();
                //We read each line and we check if its safe
                while ((s = sr.ReadLine()) != null)
                {
                    m1 = Regex.Matches(s, @"mul\(\d{1,3},\d{1,3}\)");
                    //we add to the list with the whole matches
                    foreach (Match match in m1) combinedList.Add(match);

                }

                for (int i=0;i<combinedList.Count;i++){
                    string mul=combinedList[i].ToString();
                    List<int>numbers =extractNumbers(mul);
                    int calculation=numbers[0]*numbers[1];
                    result=result+calculation;
                   
                 }

            }
    return result;
}

public static int Day3SecondProblem(string path){
    int result=0;
    if (File.Exists(path))

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                bool isdont=false;
                MatchCollection m1=Regex.Matches("","");
                List<Match> combinedList = new List<Match>();
                List<string> mulResults=new List<string>();
                //We read each line and we check if its safe
                while ((s = sr.ReadLine()) != null)
                {
                    //we split by the does
                    List<string> does=s.Split("do()").ToList();
                    List<string> donts=new List<string>();
                    for(int i=0;i<does.Count;i++){
                        if(isdont){
                            i++;
                            isdont=false;


                        }
                         //We split by the donts and we just consider the 1st part which we want
                         donts=does[i].Split("don't()").ToList();
                         m1 = Regex.Matches(donts[0], @"mul\(\d{1,3},\d{1,3}\)");
                         foreach (Match match in m1) combinedList.Add(match);
                        
                    }
                    //If the last thing read is a dont we have to keep ignoring it
                    if(donts.Count>1){
                        isdont=true;
                    }
                    


                }

                for (int i=0;i<combinedList.Count;i++){
                    string mul=combinedList[i].ToString();
                    List<int>numbers =extractNumbers(mul);
                    int calculation=numbers[0]*numbers[1];
                    result=result+calculation;
                   
                 }

            }
    return result;
}


public static List<int> extractNumbers(string input){
    int startIndex = input.IndexOf('(') + 1; 
    int endIndex = input.IndexOf(')');       

    // Parenthesis out
    string numbers = input.Substring(startIndex, endIndex - startIndex);

    //Dividing by the comma
    string[] parts = numbers.Split(',');

    List<int> numbersReturn = new List<int>();
    numbersReturn.Add(Int32.Parse(parts[0].Trim()));
    numbersReturn.Add(Int32.Parse(parts[1].Trim()));
 


        return numbersReturn;
}




    }






