using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotaRuntime
{
    class Program
    {
        static void Main(string[] args)
        {
            using (LotaGame game = new LotaGame())
                game.Run(50, 50);
        }
    }
}
