using System;

namespace Open_Lab_05._05
{
    public class StringTools
    {
        public string AlternatingCaps(string original)
        {
            string result = "";
            int x = 0;
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] == ' ')
                {
                    result += " ";
                    continue;
                }
                if (x%2 == 0)
                {
                   result += char.ToUpper(original[i]);
                    x++;
                }
                else
                {
                    result += char.ToLower(original[i]);
                    x++;
                }
            }
            return result;
        }
    }
}
