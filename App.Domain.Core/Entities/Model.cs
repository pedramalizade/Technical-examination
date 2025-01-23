using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
    public class Model
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "انتخاب مدل خودرو اجباری است")]
        public string Title { get; set; }
        public List<UserCar> usercars { get; set; }
    }
}
