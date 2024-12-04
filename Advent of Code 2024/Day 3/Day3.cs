using System;

using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

class Day3
{
    
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        String path="C:\\Users\\usuario\\Desktop\\input.txt";
        
        
 
    }
    public static int Day3FirstProblem(string path){
    int result=0;
    if (File.Exists(path))

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                //We read each line and we check if its safe
                while ((s = sr.ReadLine()) != null)
                {
                    //var m1 = Regex.Matches(input1, @"\bmul\(\d{1,3},\d{1,3}\)");

                    /*if m:
                        print(m.group())  # => 09A4N5
                        print(m.start(0)) # => 16
                    String[]report=s.Split(" ");
                    List<int> reportIntFormat = new List<int>();
                    foreach(string str in report){
                        reportIntFormat.Add(Int32.Parse(str.Trim()));   
                    }
                    if(IsSafe(reportIntFormat)){
                        safeReports++;
                    }*/
                }

            }
    return result;
}




    }






