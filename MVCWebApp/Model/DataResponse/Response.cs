using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataResponse
{
     public class Response
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public object data  { get; set; }
    }
}
