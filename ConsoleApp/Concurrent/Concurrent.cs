using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Concurrent
{
    public class Concurrent
    {
        public async void Run()
        {
            //Synchronos call to Async method..
            //string text = GetHtmlAsync().Result;
            //string text2 = GetFirstCharactersCountAsync("https://jsonplaceholder.typicode.com/todos/1", 10).Result;

            // var result =  DoSomethingAsync();
            // while (!result.IsCompleted)
            // {
            //     Console.WriteLine("After Async await");
            //     Thread.Sleep(1000);
            // }
        }
        public async Task DoSomethingAsync()
        {
            // In the Real World, we would actually do something...
            //Waits for 1000 ms before finishing the task.
            await Task.Delay(5000);
            
            Console.WriteLine("After delay");
        }
        
        public async Task<int> CalculateAnswer()
        {
            await Task.Delay(100);

            // Return a type of "int", not "Task<int>"
            return 42;
        }
        
        //https://docs.microsoft.com/en-us/dotnet/standard/async-in-depth
        //I/O bound operations
        //Calls an async method and returns an active task
        public Task<string> GetHtmlAsync()
        {
            // Execution is synchronous here
            var client = new HttpClient();

            return client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/1");
        }
        
        public async Task<string> GetFirstCharactersCountAsync(string url, int count)
        {
            // Execution is synchronous here
            var client = new HttpClient();

            // Execution of GetFirstCharactersCountAsync() is yielded to the caller here
            // GetStringAsync returns a Task<string>, which is *awaited*
            var page = await client.GetStringAsync(url);

            // Execution resumes when the client.GetStringAsync task completes,
            // becoming synchronous again.

            if (count > page.Length)
            {
                return page;
            }
            else
            {
                return page.Substring(0, count);
            }
        }
        
        //CPU-bound Task
        public async Task<int> CalculateResult(string data)
        {
            // This queues up the work on the threadpool.
            var expensiveResultTask = Task.Run(() => DoExpensiveCalculation(data));

            // Note that at this point, you can do some other work concurrently,
            // as CalculateResult() is still executing!

            // Execution of CalculateResult is yielded here!
            var result = await expensiveResultTask;

            return result;
        }
        
        
        private int DoExpensiveCalculation(string data)
        {
            throw new System.NotImplementedException();
        }
    }
}