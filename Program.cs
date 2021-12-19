using OtpNet;
using System;

namespace ConsoleAppOTP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var bytes = Base32Encoding.ToBytes("JBSWY3DPEHPK3PXP");

            var totp = new Totp(bytes, step: 300);

            var result = totp.ComputeTotp(DateTime.UtcNow);

            Console.WriteLine(result);

            var input = Console.ReadLine();
            long timeStepMatched;
            bool verify = totp.VerifyTotp(input, out timeStepMatched, window: null);

            Console.WriteLine("{0}-:{1}", "timeStepMatched", timeStepMatched);
            Console.WriteLine("{0}-:{1}", "Remaining seconds", totp.RemainingSeconds());
            Console.WriteLine("{0}-:{1}", "verify", verify);
        }
    }
}
