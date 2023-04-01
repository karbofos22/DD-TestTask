namespace DD_TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UniqueWords uniqueWords = new();

            uniqueWords.ProcessFile("dostoewskij"); //tolstoy - доп. файл для проверки
        }
    }
}