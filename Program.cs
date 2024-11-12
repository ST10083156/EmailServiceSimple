using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmailSender sender = new EmailSender();
            sender.SendEmail("st10083156@vcconnect.edu.za", "Test Subject", "It works!");
            Console.ReadLine();
            
        }
    }
}
