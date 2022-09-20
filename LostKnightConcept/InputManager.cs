using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class InputManager
    {
        private ConsoleKeyInfo _input;
        public ConsoleKey input;
        public InputManager()
        {

        }

        public void Update()
        {
            _input = Console.ReadKey(true);
            input = _input.Key;
        }
    }
}
