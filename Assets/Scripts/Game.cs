using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Assets.Scripts
{
    public class Game
    {
        [DataMember]
        public List<Character> Birds;
        [DataMember]
        public List<Character> Bricks;
        [DataMember]
        public List<Character> Pigs;

        public Game()
        {
            Birds = new List<Character>();
            Bricks = new List<Character>();
            Pigs = new List<Character>();
        }
    }
}
