//File handling in C# is all about working with files and folders: creating them, reading and writing data, and 
//managing their life cycle on disk. 
//Below is a structured path with the most important concepts and a small example for each
using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {

        Console.WriteLine("Ready for File operation");

        //File is helper class used for quick read, write, open, close, check existence and move;

        //File.Exists(path) – check if a file exists.

        //File.WriteAllText(path, text) – create / overwrite and write text.

        //File.ReadAllText(path) – read whole file as a string.

        //File.Copy, File.Move, File.Delete – manage files.



        //--> File.WriteAllText(path, "Hello from C# file handling!");

        ///--->  string content = File.ReadAllText(path);
        //--> Console.WriteLine("File content: " + content);

        //using File.class will be suitable for when working with small files.

        //important constructor arguments are: Path, Filemode, FileAccess, FileShare.
        string path = "C:\\Users\\Munish\\Hcl_task\\DotNet\\Test1.txt"; 
        string text = "Hello via FileStream!";
        byte[] data = Encoding.UTF8.GetBytes(text);

        //using- will automatically close the resource after the usage.
        //FileStream usally overwrite the content....

        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            fs.Write(data, 0, data.Length);
        }

        Console.WriteLine("File written using FileStream.");


        //StreamWriter used to avoid overwrite and For line‑by‑line or incremental text operations.

        using (StreamWriter fw = new StreamWriter(path, append: true))
        {
            fw.WriteLine("I'm from the Stream Writer at"+ DateTime.Now);
        }

        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            while((line = sr.ReadLine())!= null)
            {
                Console.WriteLine(line);
            }
        }

        //BinaryWriter and BinaryReader
        string path1 = "C:\\Users\\Munish\\Hcl_task\\DotNet\\demo.bin";

        using (BinaryWriter br =new BinaryWriter(File.Open(path1,FileMode.OpenOrCreate)))
        {
            
            br.Write('A');
            br.Write(23);
        }

        using (BinaryReader bw = new BinaryReader(File.Open(path1, FileMode.OpenOrCreate))) {
            
            char i =bw.ReadChar();
            int j= bw.ReadInt32();

            Console.WriteLine(i+":"+j);
        
        }

        string folder = "MyFolder";
        Directory.CreateDirectory(folder);
        Console.WriteLine("Directory created if it did not exist.");

        string[] files = Directory.GetFiles(".");
        Console.WriteLine("Files in current directory:");
        foreach (string file in files)
        {
            Console.WriteLine(file);
        }


    }
}