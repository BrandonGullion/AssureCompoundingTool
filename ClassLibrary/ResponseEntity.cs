using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ResponseEntity<T>
    {
        public T ResponseObject { get; set; }
        public List<Error> Errors { get; set; }
    }
}
