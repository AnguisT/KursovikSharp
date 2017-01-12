namespace MemberShip.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class People
    {
        public int idPeople { get; set; }
        public int idRole { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
    
        public virtual Administrator Administrator { get; set; }
        public virtual Applicant Applicant { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual Role Role { get; set; }
    }
}
