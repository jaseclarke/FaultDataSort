using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FaultDataSort
{
    public class FaultFileSorter
    {
        public static void Sort(string sourceFile, string destFile)
        {
            FaultFileSorter s = new FaultFileSorter(sourceFile,destFile);
        }

        private FaultFileSorter(string sourceFile, string destFile)
        {
            List<string>  allLines = File.ReadAllLines(sourceFile).ToList();

            using (StreamWriter outputFile = new StreamWriter(destFile))
            {
                while (allLines.Count > 0)
                {
                    string lineToProcess = allLines[0];
                    allLines.RemoveAt(0);

                    CopyLinesToOutput(outputFile, lineToProcess);

                    string currentTag = GetLineTag(lineToProcess);

                    CopyAllLinesWithTagToOutput(outputFile, allLines, currentTag);
                }
            }
        }

        private void CopyAllLinesWithTagToOutput(StreamWriter outputFile, List<string> lines, string currentTag)
        {
            foreach (string line in lines)
            {
                string tag = GetLineTag(line);
                if (tag == currentTag)
                {
                    CopyLinesToOutput(outputFile, line);
                }
            }
            lines.RemoveAll(l => GetLineTag(l) == currentTag);
        }

        private void CopyLinesToOutput(StreamWriter outputFile, string lineToProcess)
        {
            outputFile.WriteLine(lineToProcess);
        }

        private string GetLineTag(string lineText)
        {
//            string[] elements = lineText.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
//            if (elements.Length < 7) return null;
          
            string tag =lineText.Substring(52,45).Trim(); // get the required tag - starts at column 52
            return tag;
        }
    }
}