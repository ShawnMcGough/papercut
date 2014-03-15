namespace papercut
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://www.example.com";
            const int requests = 5;

            var papercut = new Papercut();
            papercut.Start(url, requests);

        }
    }
}
