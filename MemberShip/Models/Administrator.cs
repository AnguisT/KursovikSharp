namespace MemberShip.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Administrator
    {
        public int idAdministrator { get; set; }
        public string Communication { get; set; }
    
        public virtual People People { get; set; }
    }
}
