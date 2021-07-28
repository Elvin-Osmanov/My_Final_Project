using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.ViewModels
{
    public class SettingViewModel
    {
        public AppUser AppUser { get; set; }

        public Setting Setting { get; set; }
    }
}
