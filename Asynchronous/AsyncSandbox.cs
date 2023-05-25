namespace Asynchronous;

public class AsyncSandbox
{
    private const string _mockDelayWebApiURL = "http://mockbin.org/delay/";

    public static async Task<string?> HttpGetWithDelay(int delayInMiliSeconds)
    {
        using (var client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_mockDelayWebApiURL}{delayInMiliSeconds}");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}