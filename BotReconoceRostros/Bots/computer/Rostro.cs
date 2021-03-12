using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotReconoceRostros.Bots.computer
{
    public class Rostro
    {
        public string Gender { get; set; }
        public int Age { get; set; }

        public override string ToString() => $"Rostro[Gender:{Gender}, Age:{Age}]";
    }
}
