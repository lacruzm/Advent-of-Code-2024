using System.Numerics;



class Day1
{
    //Decomment to check results
    /* static void Main(string[] args)
     {
         var builder = WebApplication.CreateBuilder(args);
         String path="C:\\Users\\usuario\\Desktop\\input.txt";

         Console.Write("Total distance "+ Day1FirstProblem(path)+"\n");
         Console.Write("Similarity score "+ Day1SecondProblem(path));
     }*/

    public static int Day1FirstProblem(string path)
    {
        List<int> stcolumn = new List<int>();
        List<int> ndcolumn = new List<int>();
        int totalDistance = 0;
        if (File.Exists(path))

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                int row = 0;
                //Adding from the input text the 1st column and the 2nd to a int list
                while ((s = sr.ReadLine()) != null)
                {
                    String[] columns = s.Split("   ");
                    stcolumn.Add(Int32.Parse(columns[0].Trim()));
                    ndcolumn.Add(Int32.Parse(columns[1].Trim()));
                    row++;
                }
                List<int> stcolumnSorted = stcolumn.OrderBy(x => x).ToList();
                List<int> ndcolumnSorted = ndcolumn.OrderBy(x => x).ToList();
                for (int i = 0; i < stcolumnSorted.Count; i++)
                {
                    //calculating the value of its subtract
                    int value = Math.Abs(stcolumnSorted[i] - ndcolumnSorted[i]);
                    totalDistance = totalDistance + value;
                }
            }
        return totalDistance;
    }


    public static int Day1SecondProblem(string path)
    {
        List<int> stcolumn = new List<int>();
        List<int> ndcolumn = new List<int>();
        int similarityScore = 0;
        if (File.Exists(path))

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                int row = 0;
                //Adding from the input text the 1st column and the 2nd to a 
                while ((s = sr.ReadLine()) != null)
                {
                    String[] columns = s.Split("   ");
                    stcolumn.Add(Int32.Parse(columns[0].Trim()));
                    ndcolumn.Add(Int32.Parse(columns[1].Trim()));
                    row++;
                }
                List<int> stcolumnSorted = stcolumn.OrderBy(x => x).ToList();
                List<int> ndcolumnSorted = ndcolumn.OrderBy(x => x).ToList();
                for (int i = 0; i < stcolumnSorted.Count; i++)
                {
                    int repetitions = CheckRepetitions(ndcolumnSorted, stcolumnSorted[i]);
                    similarityScore = similarityScore + (repetitions * stcolumnSorted[i]);
                }
            }
        return similarityScore;
    }

    public static int CheckRepetitions(List<int> listToSearch, int numberToSearch)
    {
        int initialSize = listToSearch.Count;
        //We delete the number which are the same as the one entered and the method return the number
        int sizeWithRemoved = listToSearch.RemoveAll(x => x == numberToSearch);
        return (sizeWithRemoved);
    }
}




