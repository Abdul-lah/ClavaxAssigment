using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clavax.Utility.Dto
{
    public interface IGernalResult
    {
        string Message { get; set; }
        bool Succsefully { get; set; }
        object value { get; set; }
    }
    public class GernalResult : IGernalResult
    {
        public string Message { get; set; }
        public bool Succsefully { get; set; }
        public object value { get; set; }
    }
}
