using Advent_2024;
using System.IO;

Console.WriteLine("Day 2!");

// Get the full path of the file
string fullPath = Path.GetFullPath(@"..\..\..\input-day02.txt");

//get the lines from the file
var inputArr = FileReader.ReadFile(fullPath);


//Convert an array of strings to a nested array of int's using LINQ.  
List<List<int>> workingList = inputArr.ToList<string>()
        .Select(row => row.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList())
    .ToList();



//convert this to a list of changes
List<List<int>> changeList = new List<List<int>>();
foreach (var row in workingList)
{
    List<int> thisRow = new List<int>();
    for (int i = 1; i < row.Count; i++)
    {
        //add the change in this row
        thisRow.Add(row[i] - row[i - 1]);
    }
    changeList.Add(thisRow);
}

//loooking at the changes, find dangerious rows
var unsafeRows = changeList
    .Where(r =>
        (r.Any(v => v > 0) && r.Any(v => v < 0))//if the row has a positive and a negative change
        || (r.Any(v => v == 0)) //if the row has an instance of no change (less than 1 difference)
        || (r.Any(v => int.Abs(v) > 2)) //if the row has a change, positive or negative, of magnitude greater than 2
        || (r.Any(v => int.Abs(v) != 1 && int.Abs(v) != 2))
    ).ToList();

Console.WriteLine("Total rows (working/change): " + workingList.Count + "/" + changeList.Count);
Console.WriteLine("Safe rows: " + (changeList.Count - unsafeRows.Count));
Console.WriteLine("Dangerious rows: " + unsafeRows.Count);