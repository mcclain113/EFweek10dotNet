using System.Threading.Channels;
using System.Xml.Schema;
using EFweek10dotNet.Models;

namespace EFweek10dotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuGenerator menuGenerator = new MenuGenerator();
            menuGenerator.AppMenu();

        }
    }
}