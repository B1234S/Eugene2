using System;
using System.IO;

namespace BinaryFileApplication
{
    public static class Extension
    {
        public static string TextInBetween(this string value, string start, string end)
        {
            return value[(value.IndexOf(start) + start.Length)..value.IndexOf(end)];
        }

        
    }
    class Program
    {

        static void Main(string[] args)
        {
            BinaryWriter bw;
            BinaryReader br;
            string s = "<strong>bold</strong> and some <i>italic</i> and a <a href=\"https://google.com\">link</a>";

            //create the file
            try
            {
                bw = new BinaryWriter(new FileStream("mydata", FileMode.Create));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot create file.");
                return;
            }

            //writing into the file
            try
            {
                bw.Write(s);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot write to file.");
                return;
            }
            bw.Close();

            //reading from the file
            try
            {
                br = new BinaryReader(new FileStream("mydata", FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot open file.");
                return;
            }

            try
            {
                string str = br.ReadString();
                string st = str.TextInBetween("<strong>", "</strong>");
                string i = str.TextInBetween("<i>", "</i>");

                Console.WriteLine($"{st} {i}");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot read from file.");
                return;
            }
            br.Close();

            Console.ReadLine();
        }

    }
}