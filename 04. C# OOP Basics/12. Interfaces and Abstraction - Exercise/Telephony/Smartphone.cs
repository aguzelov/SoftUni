public class Smartphone : ICallable, IBrowsable
{
    public string Browsing(string url)
    {
        foreach (char c in url)
        {
            if (char.IsDigit(c))
            {
                return "Invalid URL!";
            }
        }
        return $"Browsing: {url}!";
    }

    public string Calling(string phoneNumber)
    {
        foreach (char c in phoneNumber)
        {
            if (!char.IsDigit(c))
            {
                return "Invalid number!";
            }
        }
        return $"Calling... {phoneNumber}"; ;
    }
}