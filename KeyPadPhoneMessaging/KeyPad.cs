using System.Text;

namespace KeyPadPhoneMessaging
{
    public static class KeyPad
    {
        public static string OldPhonePad(string input)
        {
            return ConvertToLetter(input);
        }
        public static string ConvertToLetter(string inputData)
        {
            string inputSequence = HandleAsteriskCharacter(inputData);
            var keypad = new Dictionary<char, string>
            {

                {'0', " "},
                {'1', "&'("},
                {'2', "abc"},
                {'3', "def"},
                {'4', "ghi"},
                {'5', "jkl"},
                {'6', "mno"},
                {'7', "pqrs"},
                {'8', "tuv"},
                {'9', "wxyz"}
            };

            List<char> result = new List<char>();
            char? currentDigit = null;
            int count = 0;

            foreach (char letter in inputSequence)
            {
                if (char.IsDigit(letter))
                {
                    if (currentDigit.HasValue && letter != currentDigit.Value)
                    {
                        result.Add(keypad[currentDigit.Value][(count - 1) % keypad[currentDigit.Value].Length]);
                        currentDigit = letter;
                        count = 1;
                    }
                    else
                    {
                        currentDigit = letter;
                        count++;
                    }
                }
                else if (letter == '*')
                {
                    if (result.Count > 0)
                    {
                        result.RemoveAt(result.Count - 1);
                    }
                    currentDigit = null;
                    count = 0;
                }
                else if (letter == ' ')
                {
                    if (currentDigit.HasValue)
                    {
                        result.Add(keypad[currentDigit.Value][(count - 1) % keypad[currentDigit.Value].Length]);
                        currentDigit = null;
                        count = 0;
                    }
                }
                else if (letter == '#')
                {
                    if (currentDigit.HasValue)
                    {
                        result.Add(keypad[currentDigit.Value][(count - 1) % keypad[currentDigit.Value].Length]);
                    }
                    break;
                }
            }

            if (!inputSequence.Contains('#'))
            {
                if (currentDigit.HasValue)
                {
                    result.Add(keypad[currentDigit.Value][(count - 1) % keypad[currentDigit.Value].Length]);
                }
            }

            return new string(result.ToArray()).ToUpper();
        }

        public static string HandleAsteriskCharacter(string input)
        {
            StringBuilder result = new StringBuilder();

            foreach (char letter in input)
            {
                if (letter == '*')
                {
                    if (result.Length > 0)
                    {
                        char lastLetter = result[result.Length - 1];
                        while (result.Length > 0 && result[result.Length - 1] == lastLetter)
                        {
                            result.Remove(result.Length - 1, 1);
                        }
                    }
                }
                else
                {
                    result.Append(letter);
                }
            }

            return result.ToString();
        }

    }
}
