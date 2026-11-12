using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDevFinal.Model
{
    public class LoginResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public Student student { get; set; }
    }

    public class Student
    {
        public int STUDENTID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string EMAIL { get; set; }
    }
}
