using System;
namespace StudentAdmission;//File Scoped namespace
class Program 
{
    public static void Main(string[] args)
    {
        //calling create method to create files to store data
        FileHandling.Create();
        //Calling Default Data
        //Operations.AddDefaultData();

        //reading data from csv
        FileHandling.ReadFromCSV();
        //Calling Main menu
        Operations.MainMenu();
        FileHandling.WriteToCSV();
    }
}
