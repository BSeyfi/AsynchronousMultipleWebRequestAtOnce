using System.Diagnostics;
using Asynchronous;

class Program
{
    
    public async static Task Main(string[] args)
    {
        int delay = 500;
        Stopwatch stopwatch = new();
        stopwatch.Start();

        //Create an array of tasks
        Task<string?>[] tasks = new Task<string?>[10];
        string?[] tasksResult = new string?[10];
        foreach (var index in Enumerable.Range(0,10))
        {
            tasks[index] = AsyncSandbox.HttpGetWithDelay(delay);
        }
        
        // Wait for all tasks to be done
        tasksResult= await Task.WhenAll(tasks);
        
        
        stopwatch.Stop();

        foreach (var index in Enumerable.Range(0,10))
            
        {
            Console.WriteLine($"Task {index} response message is:\n{tasksResult[index]}\n");
        }

        Console.WriteLine($"Elapsed Time For Completion of 10 Get Requests each wait at least {delay} miliseconds on serevr side: {stopwatch.ElapsedMilliseconds} milisecond");
    }

    public async static Task<string> SampleAsyncMethod()
    {
        return "";
    }
}
