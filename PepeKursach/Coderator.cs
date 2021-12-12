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
            char[] message = text.ToLower().ToCharArray();
            char[] key = keyword.ToLower().ToCharArray();

            int pos;
            int keyIndex = 0;
            int messageIndex, shift;

            for (int i = 0; i < message.Length; i++)
            {
                messageIndex = new string(alphabet).IndexOf(message[i]);

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

                    message[i] = alphabet[pos];
                    keyIndex++;
                }
            }

            return new string(message);
        }

        public string Encode(string text, string keyword)
        {
            char[] massage = text.ToCharArray();
            char[] key = keyword.ToCharArray();

            int pos;
            int keyIndex = 0;
            int j, shift;
            // Перебираем каждый символ сообщения
            for (int i = 0; i < massage.Length; i++)
            {
                // Ищем индекс буквы
                for (j = 0; j < alphabet.Length; j++)
                {
                    if (massage[i] == alphabet[j])
                    {
                        break;
                    }
                }

                if (j != 33) // Если j равно 33, значит символ не из алфавита
                {
                    // Ключ закончился - начинаем сначала.
                    if (keyIndex > key.Length - 1) { keyIndex = 0; }

                    // Ищем индекс буквы ключа
                    for (shift = 0; shift < alphabet.Length; shift++)
                    {
                        if (key[keyIndex] == alphabet[shift])
                        {
                            break;
                        }
                    }

                    keyIndex++;

                    if (shift != 33) // Если f равно 33, значит символ не из алфавита
                    {
                        pos = j + shift;
                    }
                    else
                    {
                        pos = j;
                    }

                    // Проверяем, чтобы не вышли за пределы алфавита
                    if (pos > 32)
                    {
                        pos = pos - 33;
                    }

                    massage[i] = alphabet[pos]; // Меняем букву
                }
            }

            return new string(massage);
        }
    }
}