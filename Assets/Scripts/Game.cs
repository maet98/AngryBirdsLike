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
        List<Character> Birds;
        [DataMember]
        List<Character> Bricks;
        [DataMember]
        List<Character> Pigs;
    }
}
