namespace MemberShip.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resume
    {
        public int idResume { get; set; }
        public int idApplicant { get; set; }
        public string Locations { get; set; }
        public System.DateTime DateBirthday { get; set; }
        public string Communication { get; set; }
        public string Education { get; set; }
        public string Position { get; set; }
        public string Experience { get; set; }
        public string ProffesionalSkills { get; set; }
        public string OtherSkills { get; set; }
        public string PersonalQualites { get; set; }
        public System.DateTime TimeCreation { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual Applicant Applicant { get; set; }
    }
}
