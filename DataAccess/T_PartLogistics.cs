//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_PartLogistics
    {
        public int PartLogisticsID { get; set; }
        public Nullable<int> PartID { get; set; }
        public Nullable<int> ConditionID { get; set; }
        public Nullable<bool> SafetyStock { get; set; }
        public Nullable<int> MinBuy { get; set; }
        public Nullable<bool> Stockable { get; set; }
        public Nullable<bool> Retunable { get; set; }
        public string Location1 { get; set; }
        public string Location2 { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual M_PartCondition M_PartCondition { get; set; }
        public virtual T_Part T_Part { get; set; }
    }
}