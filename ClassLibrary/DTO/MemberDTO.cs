using System;

namespace Classes.DTO
{
    public class MemberDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string MemberId { get; set; }
        public MemberType MemberType { get; set; }

    }
}