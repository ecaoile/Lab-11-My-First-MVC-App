﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Lab_11_First_MVC_App.Models
{
    /// <summary>
    /// class that holds each person taken from the .csv file
    /// </summary>
    public class TimePerson
    {
        /// <summary>
        /// properties found in the csv file
        /// </summary>
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int Death_Year { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        /// <summary>
        /// creates a list full of TimePerson objects
        /// </summary>
        /// <param name="begYear">beginning year to filter list</param>
        /// <param name="endYear">end year to filter list</param>
        /// <returns>filtered list of TimePerson objects</returns>
        public List<TimePerson> GetPeople(int begYear, int endYear)
        {
            // creates a list of TimePerson objects
            List<TimePerson> mahPeepz = new List<TimePerson>();
            
            // sets up the current directory to work with the incoming .csv file
            string datPath = Environment.CurrentDirectory;

            // creates a new path that is easier to use with other queries
            string newPath = Path.GetFullPath(Path.Combine(datPath, @"wwwroot\personOfTheYear.csv"));
           
            // creates a string array of each line of the .csv file
            string[] myFile = File.ReadAllLines(newPath);

            // for loop that traverses the .csv file and grabs certain parts of the text to make each person object
            for (int i=1; i < myFile.Length; i++)
            {
                //splits each field in a line by comma
                string[] fields = myFile[i].Split(',');

                //creates a new TimePerson object for each line
                mahPeepz.Add(new TimePerson
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    Death_Year = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8]
                });
            }

            // uses linq to filter out the list of people to display based on what the user input for beginning and end year
            List<TimePerson> filteredList = mahPeepz.Where(peepz => (peepz.Year >= begYear) && (peepz.Year <= endYear)).ToList();
            return filteredList;
        }
    }
}
