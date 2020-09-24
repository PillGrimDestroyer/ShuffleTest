using System;
using System.Security.Cryptography;
using System.Text;

namespace ShuffleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = new Random(DateTime.Now.Millisecond).Next(1, Caesar.ALPH.Length);
            string md5 = "Hey bro how are you I need 32 symbols Oke".Replace(" ", ""); //GetMd5Hash(@"login:pass");
            string randomText = RandomSymbol(md5.Length);

            string shuffledText = Shuffle(md5, randomText);
            string unShuffledText = UnShuffle(shuffledText, randomText);

            string encodedText = Caesar.Encrypt(shuffledText, key);
            string decodedText = Caesar.Decrypt(encodedText, key);

            string encodedTextKey = encodedText.Insert(md5.Length, string.Format("{0:d2}", key));

            Console.WriteLine(string.Format(
                "MD5 = {1}{0}Random string = {2}{0}{0}Shuffled text = {3}{0}UnShuffled text = {4}{0}{0}Encoded text = {5}{0}Decoded text = {6}{0}Encoded text with key = {7}{0}{0}Id = {8}", 
                Environment.NewLine, md5, randomText, shuffledText, unShuffledText, encodedText, decodedText, encodedTextKey, encodedTextKey.Substring(md5.Length, 2)
                ));

            Console.ReadKey();
        }

        private static string Shuffle(string md5, string base64)
        {
            string answer = md5;

            for (int i = 0; i < 32; i++)
            {
                answer = answer.Insert(i + i, base64[i].ToString());
            }

            return answer;
        }

        private static string UnShuffle(string shuffledText, string base64)
        {
            string answer = shuffledText;

            for (int i = 0; i < 32; i++)
            {
                answer = answer.Remove(i, 1);
            }

            return answer;
        }

        private static string RandomSymbol(int count)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            string txt = "";

            char[] pwdChars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            for (int i = 0; i < count; i++)
                txt += pwdChars[rnd.Next(0, pwdChars.Length)];

            return txt;
        }

        public static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }
}
