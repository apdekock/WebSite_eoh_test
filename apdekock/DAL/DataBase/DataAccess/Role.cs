//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.DataBase.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public Role()
        {
            this.EmployeeRoles = new HashSet<EmployeeRole>();
        }
    
        public int RoleId { get; set; }
        public string Role1 { get; set; }
        public string Description { get; set; }
        public double BaseRate { get; set; }
    
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
