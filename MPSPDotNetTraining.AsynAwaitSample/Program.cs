using System;
using System.Text;
using System.Threading.Tasks;

namespace AsyncConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 🔥 Fix Unicode (VERY IMPORTANT)
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("မနက်စာ စပြင်ပါမယ်...");

            // Start async task (not waiting yet)
            Task<string> toastTask = ToastBreadAsync();

            // Do other work
            PourCoffee();

            // Wait for result
            string toastResult = await toastTask;

            Console.WriteLine(toastResult);
            Console.WriteLine("မနက်စာ အဆင်သင့်ဖြစ်ပါပြီ!");

            Console.WriteLine("Enter နှိပ်ပါ...");
            Console.ReadLine();
        }

        static async Task<string> ToastBreadAsync()
        {
            Console.WriteLine("ပေါင်မုန့်ကင်စက် ခလုတ်နှိပ်လိုက်ပါပြီ...");

            await Task.Delay(3000); // simulate delay

            return "ပေါင်မုန့် ကျက်ပါပြီ!";
        }

        static void PourCoffee()
        {
            Console.WriteLine("ကော်ဖီ ဖျော်နေပါပြီ...");
        }
    }
}