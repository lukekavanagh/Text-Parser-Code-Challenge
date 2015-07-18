using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextParser
{
    public class TextParser
    {
        public string ErasePunctuation(string input)
        {
            return Regex.Replace(input, @"[^\w\s]", "");
            //Regex expression removes all punctuation from the intergen text sample - we then split each word at wach whitespace
        }

        public int GetSentenceCount(string input)
        {
            List <string> SentenceCount = RemoveSentences(input); //List sentence count invokes remove sentence method
            return SentenceCount.Count();
        }

        private string[] WordArray(string input)
        {
            return ErasePunctuation(input).Split(' '); // returns string with no punctuation and no whitespace
        }

        public string LongestSentence(string input) //method takes string array as parameter
        {
            List<string> sentences = RemoveSentences(input); // Invoke remove sentence method on input and store in a variable.
            string Longest = sentences.OrderByDescending(x => x.Length).First(); //we take order the input in descending order by length and obtain the first value
            return Longest; //Return the result of the Linq expression
        }


        private string MostFrequentWord(string[] input)
        {
            return input.GroupBy(x => x).OrderByDescending(y => y.Count()).First().Key;
        }

        public IGrouping<int, string> FindThirdLongestWord(string[] input)
        {
            var thirdLongestWord = input.OrderByDescending(x => x.Count()).GroupBy(y => y.Length).Skip(2).First(); //Creates a descending-by-size/descending by count IGroup. Skips first two and takes the first, which is now the third largest.
            return thirdLongestWord;
        } 

        public List<string> RemoveSentences(string input)
        {
            List<string> sentences = input.Split('!', '?', '.').ToList(); // input is split by punctuation and put into a list

            for (int i = 0; i < sentences.Count; i++) //for loop loops through this list
            {
                
                if (string.IsNullOrEmpty(sentences[i]) || string.IsNullOrWhiteSpace(sentences[i])) //if whilst looping through, if at position I and it's null or whitespace

                    sentences.Remove(sentences[i]); //remove the element at position [I].
            }

            return sentences; 
        }

        public void PrintResultsToConsole(string input)

        {
            TextParser textparser = new TextParser();

            var thirdLargestWord = string.Join(", ", FindThirdLongestWord(WordArray(input)).ToList());
            var CountOfThirdWordChars = FindThirdLongestWord(WordArray(input)).Key;

            Console.WriteLine("The Number of Words is {0}", textparser.WordArray(input).Length);
            Console.WriteLine("The Number of Sentences is {0}",textparser.GetSentenceCount(input));
            Console.WriteLine("The Longest Sentence is : {0}", textparser.LongestSentence(input));
            Console.WriteLine("The Most Frequent Word is : {0}", MostFrequentWord(WordArray(input)));
            Console.WriteLine("The Joint Third Most Longest Words are {0}. \n The number of characters in each word is : {1}", thirdLargestWord, CountOfThirdWordChars );
            Console.ReadLine();
        }




        



    }
}
