using System;
//dotent run  --launch-profile dev

namespace testenv
{
    class Program
    {
        static void Main(string[] args)
        {
            var envName = Environment.GetEnvironmentVariable("DEPLOY_ENVIRONMENT");
            Console.WriteLine($"Hello World! {envName}");
        }
    }
}
