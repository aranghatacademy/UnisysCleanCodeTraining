using System;


namespace CleanCodeThroughDesignPatterns.CommandPattern
{
    public interface ICommand<T>
    {
        T Target { get; set; }
        void Execute();
    }

    public class TextEditorObject
    {
        private string text;

        public TextEditorObject()
        {
            text = string.Empty;
        }

        public void SetText(string newText)
        {
            text = newText;
        }

        public string GetText()
        {
            return text;
        }
    }

    public class AppendTextCommand : ICommand<TextEditorObject>
    {
       public TextEditorObject Target { get; set; }

        private readonly string _textToAppend;
        public AppendTextCommand(string textToAppend)
        {
            _textToAppend = textToAppend;
        }
        public void Execute()
        {
            var currentText = Target?.GetText();
            Target.SetText(currentText + _textToAppend);   
        }
    }

    public class DeleteTextCommand : ICommand<TextEditorObject> { 
    
        public TextEditorObject Target { get; set; }
        private readonly string _textToDelete;
        public DeleteTextCommand(string textToDelete)
        {
            _textToDelete = textToDelete;
        }
        public void Execute()
        {
            var currentText = Target?.GetText();
            Target.SetText(currentText.Replace(_textToDelete, string.Empty));
        }
    }

    public class ResetTextEditorCommand : ICommand<TextEditorObject> { 
        public TextEditorObject Target { get; set; }

        public void Execute()
        {
            Target.SetText(string.Empty);
        }
    }

    public class ReplaceTextCommand : ICommand<TextEditorObject>
    {
        public TextEditorObject Target { get; set; }
        private readonly string _oldText;
        private readonly string _newText;
        public ReplaceTextCommand(string oldText, string newText)
        {
            _oldText = oldText;
            _newText = newText;
        }
        public void Execute()
        {
            var currentText = Target?.GetText();
            Target.SetText(currentText.Replace(_oldText, _newText));
        }
    }

        public class TextEditorClient
    {
        public readonly TextEditorObject textEditor;
        Stack<ICommand<TextEditorObject>> commandHistory = new Stack<ICommand<TextEditorObject>>();

        public TextEditorClient()
        {
            textEditor = new TextEditorObject();
        }


        public void ExecuteCommand(ICommand<TextEditorObject> command)
        {
            if (commandHistory.Count > 100)
            {
                Console.WriteLine("Sorry you have exceeded the maximum number of operations allowed.");
            }
            else
            {
                command.Target = textEditor;
                command.Execute();
            }
        }
    }

}
