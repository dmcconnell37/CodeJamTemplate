using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reverseWords
{
    public class Program
    {
        static void Main(string[] args)
        {
            string inputFile;
            string outputFile;
            string finishedOutput;
            List<string> inputList;

            inputFile = GetFilePath("Enter Input File: ");
            outputFile = GetFilePath("Enter Output File: ");

            inputList = ProcessFile(inputFile);
            //finishedOutput = ReverseSentences(ref inputList);
            finishedOutput = T9Spelling(ref inputList);
            WriteToFile(outputFile, finishedOutput);
        }

        private static string T9Spelling(ref List<string> codePhrases)
        {
            Dictionary<string, string> letterLookup = new Dictionary<string, string>();
            string nextLetter = "";
            string encodedLetter = "";
            string lastEncodedLetter = "";
            string encodedPhrase = "";
            string encodedPhrases = "";
            int counter = 1;

            letterLookup.Add("a", "2");
            letterLookup.Add("b", "22");
            letterLookup.Add("c", "222");
            letterLookup.Add("d", "3");
            letterLookup.Add("e", "33");
            letterLookup.Add("f", "333");
            letterLookup.Add("g", "4");
            letterLookup.Add("h", "44");
            letterLookup.Add("i", "444");
            letterLookup.Add("j", "5");
            letterLookup.Add("k", "55");
            letterLookup.Add("l", "555");
            letterLookup.Add("m", "6");
            letterLookup.Add("n", "66");
            letterLookup.Add("o", "666");
            letterLookup.Add("p", "7");
            letterLookup.Add("q", "77");
            letterLookup.Add("r", "777");
            letterLookup.Add("s", "7777");
            letterLookup.Add("t", "8");
            letterLookup.Add("u", "88");
            letterLookup.Add("v", "888");
            letterLookup.Add("w", "9");
            letterLookup.Add("x", "99");
            letterLookup.Add("y", "999");
            letterLookup.Add("z", "9999");
            letterLookup.Add(" ", "0");

            foreach (string codePhrase in codePhrases)
            {
                encodedPhrase = "";
                lastEncodedLetter = "X";
                for (int i = 0; i <= codePhrase.Length - 1; i++)
                {
                    nextLetter = codePhrase.Substring(i, 1);
                    encodedLetter = letterLookup[nextLetter];
                    if (encodedLetter.Substring(0, 1) == lastEncodedLetter.Substring(0, 1))
                    {
                        encodedPhrase += " " + encodedLetter;
                    }
                    else
                    {
                        encodedPhrase += encodedLetter;
                    }

                    lastEncodedLetter = encodedLetter;
                }
                encodedPhrases += "Case #" + counter + ": " + encodedPhrase + System.Environment.NewLine;
                counter ++;
            }

            return encodedPhrases;
        }

        private static string ReverseSentences(ref List<string> sentences)
        {
            int blank = -1;
            int savedBlank = -1;
            string reversedSentence = "";
            string reversedSentences = "";
            int counter = 1;

            foreach (string sentence in sentences)
                {
                reversedSentence = "";
                blank = sentence.IndexOf(' ');
                if (blank == -1)
                    {
                    reversedSentence = sentence;
                    }
                else
                    {
                    savedBlank = -1;
                    while(blank > 0)
                        {
                        reversedSentence = " " + sentence.Substring(savedBlank + 1, blank - savedBlank - 1) + reversedSentence;
                        savedBlank = blank;
                        blank = sentence.IndexOf(' ', blank + 1);
                        }
                    reversedSentence = sentence.Substring(savedBlank + 1, sentence.Length - savedBlank - 1) + reversedSentence;
                    }
                reversedSentences += "Case #" + counter + ": " + reversedSentence + System.Environment.NewLine;
                counter++;
                }
            return reversedSentences;
       }
                

        /// <summary>
        /// Prompts the user to enter a path to a file
        /// </summary>
        /// 
        /// <param name="message">The message that is displayed to the user</param>
        /// 
        /// <returns>A string containing the path to a file</returns>
        private static string GetFilePath(string message)
        {
            string filePath;

            do
            {
                Console.Write(message);
                filePath = Console.ReadLine();

            } while (filePath == null || filePath.Trim().Length == 0);

            return filePath;
        }

        /// <summary>
        /// Processes the input file
        /// </summary>
        /// 
        /// <param name="input">The input file that will be processed</param>
        /// 
        /// <returns>A string containing the output from processing the file</returns>
        private static List<string> ProcessFile(string input)
        {
            string currentLine;
            List<string> inputSentences = new List<string> ();
            StringBuilder stringBuilder = new StringBuilder();

            using( StreamReader reader = new StreamReader(input) )
            {
                currentLine = reader.ReadLine();
                currentLine = reader.ReadLine();

                //TODO: Possibly use WHILE instead of IF?
                while( currentLine != null )
                {
                    inputSentences.Add(currentLine);
                    currentLine = reader.ReadLine();
                }

                reader.Close();
            }

            return inputSentences;
        }

        /// <summary>
        /// Writes data to a file
        /// </summary>
        /// 
        /// <param name="outputFile">The output file to write to</param>
        /// <param name="words">The data that will be written to the file</param>
        private static void WriteToFile(string outputFile, string words)
        {
            using(StreamWriter writer = new StreamWriter(outputFile, true))
            {
                writer.Write(words);
                writer.Close();
            }
        }
    }
}
