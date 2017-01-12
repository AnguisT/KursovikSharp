namespace MemberShip.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Applicant
    {
        public Applicant()
        {
            this.Resume = new HashSet<Resume>();
        }
    
        public int idApplicant { get; set; }
        public System.DateTime TimeAction { get; set; }
    
        public virtual People People { get; set; }
        public virtual ICollection<Resume> Resume { get; set; }
    }
}
