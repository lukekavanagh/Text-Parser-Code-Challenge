using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;


namespace TextParser
{
    public class TextParserTool
    {
        public string ErasePunctuation(string input)
        {
            return Regex.Replace(input, @"[^\w\s]", "");
            //Regex expression removes all punctuation from the intergen text sample.
        }

        public int GetSentenceCount(string input)
        {
            List <string> SentenceCount = FindSentences(input); //List sentence count invokes remove sentence method
            return SentenceCount.Count();
        }

        public string[] NumberOfWords(string input)
        {
            return ErasePunctuation(input).Split(' '); // returns string with no punctuation, and splits each word at each occurance of whitespace.
        }

        public string LongestSentence(string input) //method takes string array as parameter
        {
            List<string> sentences = FindSentences(input); // Invoke remove sentence method on input and store in a variable.
            string Longest = sentences.OrderByDescending(x => x.Length).First(); //we take order the input in descending order by length and obtain the first value
            return Longest; //Return the result of the Linq expression
        }

        public string MostFrequentWord(string[] input)
        {
            return input.GroupBy(x => x).OrderByDescending(y => y.Count()).First().Key;
        }

        public IGrouping<int, string> FindThirdLongestWord(string[] input)
        {
            var thirdLongestWord = input.OrderByDescending(x => x.Count()).GroupBy(y => y.Length).Skip(2).First(); //Creates a descending-by-size/descending by count IGroup. Skips first two and takes the first, which is now the third largest.
            return thirdLongestWord;
        } 

        public List<string> FindSentences(string input)
        {
            List<string> sentences = input.Split('!', '?', '.').ToList(); // input is split by punctuation - as each punctuation symbol denotes the end of a sentence and put into a list

            for (int i = 0; i < sentences.Count; i++) //for loop loops through this list
            {
                
                if (string.IsNullOrEmpty(sentences[i]) || string.IsNullOrWhiteSpace(sentences[i])) //if whilst looping through, if at position I and it's null or whitespace

                    sentences.Remove(sentences[i]); //remove the element at position [I].
            }

            return sentences; 
        }

        public void PrintResultsToConsole(string input)

        {
            TextParserTool textparser = new TextParserTool();

            var thirdLargestWord = string.Join(", ", FindThirdLongestWord(NumberOfWords(input)).ToList());
            var CountOfThirdWordChars = FindThirdLongestWord(NumberOfWords(input)).Key;

            Console.WriteLine("The number of words in the sample text is {0}.", textparser.NumberOfWords(input).Length);
            Console.WriteLine("\n");
            Console.WriteLine("The number of sentences is {0}.",textparser.GetSentenceCount(input));
            Console.WriteLine("\n");
            Console.WriteLine("The longest sentence is : {0}.", textparser.LongestSentence(input));
            Console.WriteLine("\n");
            Console.WriteLine("The most frequent word is : {0}.", MostFrequentWord(NumberOfWords(input)));
            Console.WriteLine("\n");
            Console.WriteLine("The joint third most longest words are {0}.\n\nThese words both have a character count of : {1}.", thirdLargestWord, CountOfThirdWordChars );
            Console.ReadLine();
        }




        



    }
}
