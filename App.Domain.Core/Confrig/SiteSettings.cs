using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Confrig
{
    public class SettingsSite
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Limitation Limitation { get; set; }
        public string ApiKey { get; set; }
    }
}
