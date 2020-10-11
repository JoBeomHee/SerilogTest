using Serilog;
using System;

namespace SerilogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            InitSerilogTest();
            Console.WriteLine();
            CreateFileSerilogTest();
        }

        //Serilog 초기 기본 설정 및 사용법
        private static void InitSerilogTest()
        {
            using (var log = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger())
            {
                log.Information("Hello, Serilog!");
                log.Warning("Goodbye, Serilog.");
            }
        }

        //Log 파일에 기록
        private static void CreateFileSerilogTest()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(@"c:\log\log_.txt",
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true)
            .CreateLogger();


            for (int idx = 0; idx < 10; idx++)
            {
                Log.Information("Hello, Serilog!");
            }

            Log.CloseAndFlush();
        }
    }
}
