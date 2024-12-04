using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

class Day2
{
    
    /*static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        String path="C:\\Users\\usuario\\Desktop\\input.txt";
        
        Console.Write("Safe reports: "+ Day2FirstProblem(path)+"\n");
        Console.Write("Problem Dampener Safe reports:  "+ Day2SecondProblem(path)+"\n");
    }*/

    public static int Day2FirstProblem(string path){
    int safeReports=0;
    if (File.Exists(path))

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                //We read each line and we check if its safe
                while ((s = sr.ReadLine()) != null)
                {
                    String[]report=s.Split(" ");
                    List<int> reportIntFormat = new List<int>();
                    foreach(string str in report){
                        reportIntFormat.Add(Int32.Parse(str.Trim()));   
                    }
                    if(IsSafe(reportIntFormat)){
                        safeReports++;
                    }
                }

            }
    return safeReports;
}

    public static int Day2SecondProblem(string path){
    int safeReportsDampener=0;
    if (File.Exists(path))

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                //We read each line and we check if its safe
                while ((s = sr.ReadLine()) != null)
                {
                    String[]report=s.Split(" ");
                    List<int> reportIntFormat = new List<int>();
                    foreach(string str in report){
                        reportIntFormat.Add(Int32.Parse(str.Trim()));   
                    }
                    if(IsSafe(reportIntFormat)){
                        safeReportsDampener++;
                    }else{
                        //We check if its safe deleting one number in a iterative way
                        for(int i=0; i<reportIntFormat.Count;i++){
                            List<int> copy=new List<int>(reportIntFormat);
                            copy.RemoveAt(i);
                            if(IsSafe(copy)){
                                safeReportsDampener++;
                                //we have found its safe withouth that number so we can exit this loop
                                break;
                            }

                        }
                    }
                }

            }
    return safeReportsDampener;
}

public static bool IsSafe(List<int> report){
    bool safe=true;
    //First level check to know if its an increase of decrease
    int firstLevel=report[0];
    int secondLevel=report[1];
    bool increase=false;
    bool decrease=false;
    if((firstLevel<secondLevel)&&(BetweenOneAndThree(secondLevel-firstLevel))){
        increase=true;
    }
    if((secondLevel<firstLevel)&&(BetweenOneAndThree(firstLevel-secondLevel))){
        decrease=true;
    }
    //1st level is wrong
    if(!increase&&!decrease){
        return false;
    }
    //We check for the next levels (the 1st one we know its false, we return false)
    for(int level=1;level<report.Count-1;level++){
        if(increase){
            if(report[level]>=report[level+1]||!BetweenOneAndThree(report[level+1]-report[level])){
                return false;
            }
        }
        if(decrease){
            if(report[level+1]>=report[level]||!BetweenOneAndThree(report[level]-report[level+1])){
                return false;
            }
        }

    }
    return safe;

}

//To check the level differ
public static bool BetweenOneAndThree(int number){
    return(number<4&&number>0);
}







    }






