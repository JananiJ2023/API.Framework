using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Framework.Models
{
    public partial class GetSingleUserRes
    {
        public Data Data { get; set; }
        public Support Support { get; set; }
    }

    public partial class Data
    {
        public long id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Uri Avatar { get; set; }
    }
}
