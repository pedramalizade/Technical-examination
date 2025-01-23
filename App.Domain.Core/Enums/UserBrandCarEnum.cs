using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Enums
{
    public enum UserBrandCarEnum
    {
        [Display(Name = "ایران خودرو")]
        IranKhodro = 1,
        [Display(Name = "سایپا")]
        Saipa = 2
    }
}
