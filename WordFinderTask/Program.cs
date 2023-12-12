using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinderTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new string[] { "chill", "wind", "snow", "cold" };
            var src = new string[] { "abcdc", 
                                     "fgwio", 
                                     "chill", 
                                     "pqnsd", 
                                     "uvdxy" }; // Can be considered as 2D Array
            
            try
            {
                ValidateParameters(dictionary, src);
                var result = Find(dictionary, src);

                // Display found words
                foreach (string word in result)
                {
                    Console.WriteLine(word);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }

        public static string[] Find(string[] dictionary, string[] matrix)
        {
            // Use of HashSet will ensure that all elements are unique
            HashSet<string> foundWords = new HashSet<string>();

            // Traversing through the matrix
            for(var i = 0; i < matrix.Length; i++)
            {
                // Setting row and column variables to store the strings horizontally and vertically
                var row = "";
                var column = "";

                for(var j = 0; j < matrix[i].Length; j++)
                {
                    row += matrix[i][j];    // Get the character horizontally and append 
                    column += matrix[j][i]; // Get the character vertically and append
                }

                // Traversing words in dictionary
                for(var word = 0; word < dictionary.Length; word++)
                {
                    // Checks if the current word is in the row/column
                    if (row.Contains(dictionary[word]) || column.Contains(dictionary[word]))
                    {
                        foundWords.Add(dictionary[word]);
                    }
                }
            }

            // Convert HashSet to Array
            return foundWords.ToArray();
        }

        public static void ValidateParameters(string[] dictionary, string[] matrix)
        {
            // Checking the number of items in the dictionary should not exceed 2048
            if (dictionary.Length > 2048) throw new Exception("Items in the dictionary should not exceed 2048");

            // Check if all strings in matrix contain the same number of characters based on the first string of the matrix
            for (var index = 0; index < matrix.Length; index++)
            {
                if (matrix[0].Length != matrix[index].Length) throw new Exception("Strings in matrix should have the same number of characters.");
            }

            // Matrix size should not exceed 64x64
            if (matrix[0].Length > 64 || matrix.Length > 64) throw new Exception("Matrix size hould not exceed 64x64");
        }
    }
}