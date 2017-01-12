namespace MemberShip.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employer
    {
        public Employer()
        {
            this.Jobs = new HashSet<Jobs>();
        }
    
        public int idEmployer { get; set; }
        public System.DateTime TimeAction { get; set; }
    
        public virtual People People { get; set; }
        public virtual ICollection<Jobs> Jobs { get; set; }
    }
}
