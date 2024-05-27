namespace TimerDelete
{
    internal class Program
    {


        public static string FILE_PATH = Environment.CurrentDirectory + "\\del_path.txt";
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    try
                    {
                        if (Spaceno2G())
                        {
                            //@"E:\downloadAndDeal\netcoreapp3.1\video"
                            //第二行 文件夹地址
                            string Line = ReadSecondLine(3);
                            Console.WriteLine("删除文件夹");
                            Directory.Delete(Line, true);

                        }
                       
                    }
                    catch
                    {
                        continue;
                    }
                    int Min = Convert.ToInt32(ReadSecondLine(4));

                    Thread.Sleep(1000 * 60 * Min);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }




        public static bool Spaceno2G()
        {

            //第一行line 是哪个盘的地址 E、C
            string Line = ReadSecondLine(1);
            DriveInfo eDrive = new DriveInfo(Line);

            long availableSpaceInBytes = eDrive.AvailableFreeSpace;
            long availableSpaceInGB = availableSpaceInBytes / (1024 * 1024 * 1024); // 转换为GB

            if (availableSpaceInGB < Convert.ToInt32(ReadSecondLine(2)))
            {
                Console.WriteLine("可以删除");
                return true;
            }
            else
            {
                Console.WriteLine("空间还够"+ availableSpaceInGB);
                return false;
            }
        }


        //static void Main()
        //{
        //    string filePath = "your_file_path.txt"; // 替换为你的文本文件路径

        //    // 读取文件的第二行数据
        //    string secondLine = ReadSecondLine(filePath);

        //    Console.WriteLine("第二行数据：");
        //    Console.WriteLine(secondLine);
        //}

        static string ReadSecondLine(int n)
        {
            string nLine = null;

            using (StreamReader reader = new StreamReader(FILE_PATH))
            {

                for (var i = 0; i < n; i++)
                {
                    nLine = reader.ReadLine();

                }

            }

            return nLine;
        }

    }
}