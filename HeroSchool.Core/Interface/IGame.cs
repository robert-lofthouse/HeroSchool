using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Interface
{
    public interface IGame
    {
        string Name { get; set; }
        string _id { get; }
    }
}
