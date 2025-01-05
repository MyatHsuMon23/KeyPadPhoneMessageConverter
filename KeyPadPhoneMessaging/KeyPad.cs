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
            string inputSequence = HandleAsterisk(inputData);
            var keypad = new Dictionary<char, string>
            {
                { '1', "&'(" },
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" },
                { '0', " " }
            };

            List<char> result = new List<char>();
            char? currentDigit = null;
            int count = 0;

            foreach (char ch in inputSequence)
            {
                if (char.IsDigit(ch))
                {
                    if (currentDigit.HasValue && ch != currentDigit.Value)
                    {
                        result.Add(keypad[currentDigit.Value][(count - 1) % keypad[currentDigit.Value].Length]);
                        currentDigit = ch;
                        count = 1;
                    }
                    else
                    {
                        currentDigit = ch;
                        count++;
                    }
                }
                else if (ch == '*')
                {
                    if (result.Count > 0)
                    {
                        result.RemoveAt(result.Count - 1);
                    }
                    currentDigit = null;
                    count = 0;
                }
                else if (ch == ' ')
                {
                    if (currentDigit.HasValue)
                    {
                        result.Add(keypad[currentDigit.Value][(count - 1) % keypad[currentDigit.Value].Length]);
                        currentDigit = null;
                        count = 0;
                    }
                }
                else if (ch == '#')
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

        public static string HandleAsterisk(string input)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (c == '*')
                {
                    if (result.Length > 0)
                    {
                        char lastChar = result[result.Length - 1];
                        while (result.Length > 0 && result[result.Length - 1] == lastChar)
                        {
                            result.Remove(result.Length - 1, 1);
                        }
                    }
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

    }
}
