using System.Text;

namespace ShuffleTest
{
    /// <summary>
    /// Шифр Цезаря
    /// </summary>
    class Caesar
    {
        public static readonly string ALPH = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Encrypt(string text, int key)
        {
            var res = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
                for (int j = 0; j < ALPH.Length; j++)
                    if (text[i] == ALPH[j]) res.Append(ALPH[(j + key) % ALPH.Length]);

            return res.ToString();
        }

        public static string Decrypt(string crypt, int key)
        {
            var res = new StringBuilder();

            for (int i = 0; i < crypt.Length; i++)
                for (int j = 0; j < ALPH.Length; j++)
                    if (crypt[i] == ALPH[j]) res.Append(ALPH[(j - key + ALPH.Length) % ALPH.Length]);

            return res.ToString();
        }
    }
}
