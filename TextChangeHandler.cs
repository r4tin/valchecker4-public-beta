namespace valchecker_4._0_private_beta
{
    public delegate void TextChangeEventHandler(object sender, TextChangeEventArgs e);

    public static class TextChangeHandler
    {
        // Define the event that will be raised when the text needs to be changed.
        public static event TextChangeEventHandler TextChangeEvent;

        // Method to raise the event and pass the new text value.
        public static void RaiseTextChangeEvent(string newText, string labelname)
        {
            TextChangeEvent?.Invoke(null, new TextChangeEventArgs(newText, labelname));
        }
    }

    // Custom EventArgs class to pass the new text value.
    public class TextChangeEventArgs : EventArgs
    {
        public string NewText { get; }
        public string Labelname { get; }

        public TextChangeEventArgs(string newText, string labelname)
        {
            NewText = newText;
            Labelname = labelname;
        }
    }
}
