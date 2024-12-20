namespace Implementations.Helpers;

public static class FileLoader
{
    public static string[] DownloadFile(string url, string sessionCookie)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Cookie", $"session={sessionCookie}");
        var response = client.GetAsync(url).Result;
        response.EnsureSuccessStatusCode();
        var content = response.Content.ReadAsStringAsync().Result;
        return content.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
    }

    public static string[] GetInput(string path, string url)
    {
        if (File.Exists(path))
        {
            return File.ReadAllLines(path);
        }

        var sessionCookie = GetSessionCookie();
        return DownloadFile(url, sessionCookie);
    }

    private static string GetSessionCookie()
    {
        var configPath = "config.txt";
        if (File.Exists(configPath))
        {
            return File.ReadAllText(configPath).Trim();
        }
        throw new FileNotFoundException("Session cookie configuration file not found.");
    }
}
