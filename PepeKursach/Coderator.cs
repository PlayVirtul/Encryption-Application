using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepeKursach
{
    public class Coderator
    {
        private readonly char[] alphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

        public string Decode(string text, string keyword)
        {
            char[] message = text.ToCharArray();
            char[] key = keyword.ToLower().ToCharArray();

            int pos;
            int keyIndex = 0;
            int messageIndex, shift;

            for (int i = 0; i < message.Length; i++)
            {
                messageIndex = new string(alphabet).IndexOf(Char.ToLower(message[i]));

                if (messageIndex != -1)
                {
                    // Ключ закончился - начинаем сначала.
                    if (keyIndex > key.Length - 1)
                    {
                        keyIndex = 0;
                    }

                    shift = new string(alphabet).IndexOf(key[keyIndex]);

                    if (shift != -1)
                    {
                        pos = messageIndex - shift + alphabet.Length;
                    }
                    else
                    {
                        pos = messageIndex;
                    }

                    if (pos > alphabet.Length - 1)
                    {
                        pos = pos - alphabet.Length;
                    }

                    if (Char.IsUpper(message[i]))
                    {
                        message[i] = Char.ToUpper(alphabet[pos]);
                    }
                    else
                    {
                        message[i] = alphabet[pos];
                    }
                    keyIndex++;
                }
            }

            return new string(message);
        }

        public string Encode(string text, string keyword)
        {
            char[] message = text.ToCharArray();
            char[] key = keyword.ToLower().ToCharArray();

            int pos;
            int keyIndex = 0;
            int messageIndex, shift;

            for (int i = 0; i < message.Length; i++)
            {
                messageIndex = new string(alphabet).IndexOf(Char.ToLower(message[i]));

                if (messageIndex != -1)
                {
                    // Ключ закончился - начинаем сначала.
                    if (keyIndex > key.Length - 1)
                    {
                        keyIndex = 0;
                    }

                    shift = new string(alphabet).IndexOf(key[keyIndex]);

                    if (shift != -1)
                    {
                        pos = messageIndex + shift;
                    }
                    else
                    {
                        pos = messageIndex;
                    }

                    if (pos > alphabet.Length - 1)
                    {
                        pos = pos - alphabet.Length;
                    }

                    if (Char.IsUpper(message[i]))
                    {
                        message[i] = Char.ToUpper(alphabet[pos]);
                    }
                    else
                    {
                        message[i] = alphabet[pos];
                    }
                    keyIndex++;
                }
            }

            return new string(message);
        }
    }
}