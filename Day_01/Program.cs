// See https://aka.ms/new-console-template for more information
using Day_01;

Console.WriteLine("Day 1!");


// Get the full path of the file
string fullPath = Path.GetFullPath(@"..\..\..\input-day01.txt");


//populate two arrays with the two sorted values
(int[] array1, int[] array2) = FileReader.GetArrays(fullPath);

//iterate through the array and calculate difference
int totalDistance = 0;
for (int i = 0; i < array1.Length; i++)
{
    totalDistance += Math.Abs(array2[i] - array1[i]);
}

Console.WriteLine("Part A");
Console.WriteLine("Total Difference Score: " + totalDistance);

//**********************Part B**********************


//convert array's to lists, for LINQ
List<int> list1 = array1.ToList();
List<int> list2 = array2.ToList();

int similarityScore = 0;

foreach (int i in list1)
{
    //add this value from list1, times the number of times this value is present in list2
    similarityScore += (i * list2.Where(m => m == i).Count());
}
Console.WriteLine("Part-B");
Console.WriteLine("Similarity Score: " + similarityScore);