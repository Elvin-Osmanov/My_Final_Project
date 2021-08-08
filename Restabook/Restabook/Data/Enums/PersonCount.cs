using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Restabook.Data.Enums
{
    public enum PersonCount
    {
        [EnumMember(Value = "1 Person")]
        One_Person,
        [EnumMember(Value = "2 People")]
        Two_People,
        [EnumMember(Value = "3 People")]
        Three_People,
        [EnumMember(Value = "4 People")]
        Four_People,
        [EnumMember(Value = "Banquet")]
        Banquet
    }
}
