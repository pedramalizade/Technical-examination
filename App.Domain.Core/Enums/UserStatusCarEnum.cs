using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Enums
{
    public enum UserStatusCarEnum
    {
        [Display(Name = "معلق")]
        apending = 1,
        [Display(Name = "تایید شده")]
        aproved = 2,
        [Display(Name = " رد شده")]
        Rejected = 3
    }
}
