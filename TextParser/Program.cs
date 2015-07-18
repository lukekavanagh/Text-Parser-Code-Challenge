using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TextParser
{
    class Program
    {
        static void Main(string[] args)
        {
            TextParserTool textparser = new TextParserTool();

            var intergenText = "Intergen is New Zealand's most experienced provider of Microsoft based business solutions. We focus on delivering business value in our solutions and work closely with Microsoft to ensure we have the best possible understanding of their technologies and directions. Intergen is a Microsoft Gold Certified Partner with this status recognising us as an \"elite business partner\" for implementing solutions based on our capabilities and experience with Microsoft products.";
            textparser.PrintResultsToConsole(intergenText);
        }
    }
}
