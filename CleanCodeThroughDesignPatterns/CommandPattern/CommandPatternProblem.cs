using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.CommandPattern
{
    public class TextEditor
    {
        private string text = string.Empty;

        public void AppendText(string newText)
        {
            text += newText;
        }

        public void DeleteText(string newText)
        {
           text = text.Replace(newText, string.Empty);
        }
        

        public void Copy()
        {
            // Copy logic here
            Console.WriteLine("Text copied to clipboard.");
        }

        public string GetText()
        {
            return text;
        }
    }

    public class TextEditor2
    {
        private string text = string.Empty;
        public void Execute(string command,string payload)
        {
            if(command == "Append")
            {
                text = text + payload;
            }
            else if (command == "Delete")
            {
                text = text.Replace(payload, string.Empty);
            }
            else if (command == "Copy")
            {
                Console.WriteLine("Text copied to clipboard.");
            }
        }
    }
}
