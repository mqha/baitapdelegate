using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum Area
    {
        Africa,
        Europe,
        Asean
    }

    public enum Rank
    {
        Bronze,
        Silver,
        Gold,
        Diamond
    }

    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public Area Area { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public Rank Rank { get; set; }
    }
}
