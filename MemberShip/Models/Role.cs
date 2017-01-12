namespace MemberShip.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public Role()
        {
            this.People = new HashSet<People>();
        }
    
        public int idRole { get; set; }
        public string NameRole { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<People> People { get; set; }
    }
}
