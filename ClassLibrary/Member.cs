using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{

    public enum MemberType
    {
        Cardholder,
        Spouse,
        ChildOverage,
        ChildUnverage,
        Dependant,
    }

    public class Member : Entity
    {
        public string MemberId { get; set; }
        public MemberType MemberType { get; set; }
        public DateTime DOB { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
