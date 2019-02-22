using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordMngr
{
    class Record
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string URL { get; set; }
        public List<string> Tags { get; set; }

        public Record()
        {
            Tags = new List<string>();
        }

        public override string ToString()
        {
            return $"{Id},{Name},{Password},{string.Join("|",Tags)}";
        }
    }
}
