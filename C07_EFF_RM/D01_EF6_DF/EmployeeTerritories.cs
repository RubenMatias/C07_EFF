//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace D01_EF6_DF
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeTerritories
    {
        public int EmployeeID { get; set; }
        public string TerritoryID { get; set; }
        public int EmployeesEmployeeID { get; set; }
    
        public virtual Employees Employees { get; set; }
        public virtual Territories Territories { get; set; }
    }
}
