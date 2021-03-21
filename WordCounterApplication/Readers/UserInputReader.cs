using WordCounterApplication.Interfaces;
using WordCounterApplication.Views;

namespace WordCounterApplication.Readers
{
    /// <summary>
    /// UserInputReader represent specialization of IReader for the user input text.
    /// </summary>
    class UserInputReader : IReader
    {
        public string Read()
        {
            string text = string.Empty;

            UserInputView userInputView = new UserInputView();

            userInputView.ShowDialog();
            
            if(userInputView.DialogResult == true)
            {
                return userInputView.UserInputTexts;
            }

            return text;
        }
    }
}
