using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TextParser;

namespace TextParser_Unit_Tests
{
    [TestFixture]
    public class UnitTest1
    {
        public TextParserTool textparser = new TextParserTool();

        [Test]
        public void Returns_Correct_Number_Of_Sentences()
        {
            string sentences = "This is my sentence. There are many like it but this one is mine";
            int numberofSentencesExpected = 2;

            int sentenceCount = textparser.GetSentenceCount(sentences);

            Assert.AreEqual(numberofSentencesExpected, sentenceCount);

        }

        [Test]
        public void Returns_Correct_Number_Of_Words()
        {
            string words = "Born To Kill";
            int numberofWordsExpected = 3;

            string[] wordCount = textparser.NumberOfWords(words);

            Assert.AreEqual(numberofWordsExpected, wordCount.Length);
        }

        [Test]
        public void Check_Longest_Sentence_Returned_Is_Correct()
        {

            string text = "This is my rifle this is my gun, this is a long sentence. This is a short sentence";
            string expectsSentence = "This is my rifle this is my gun, this is a long sentence";

            string longSentence = textparser.LongestSentence(text);

            Assert.AreEqual(expectsSentence, longSentence);
        }

        [Test]
        public void Check_Returns_Most_Frequent_Word()
        {

            string[] words = { "Yeah man, love meat, I really enjoyed that meat feast pizza, it was a meat extravaganza" };
            string expectedMostFrequentWord = "meat";

            string frequencyOfWordSearch = textparser.MostFrequentWord(words);

            Assert.AreEqual(expectedMostFrequentWord, frequencyOfWordSearch);
        }     
    }
}
