namespace Helper
{
    public class Print
    {
        /// <summary>
        /// 默认绿色
        /// </summary>
        /// <param name="s"></param>
        /// <param name="color"></param>
        public static void WriteLine(string s,ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(s);

            Console.ResetColor();
        }

    }
}