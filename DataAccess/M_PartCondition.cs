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
    
    public partial class M_PartCondition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_PartCondition()
        {
            this.T_PartConditionPrice = new HashSet<T_PartConditionPrice>();
            this.T_PartLogistics = new HashSet<T_PartLogistics>();
        }
    
        public int ConditionID { get; set; }
        public string ConditionDescription { get; set; }
        public string Abbrevation { get; set; }
        public Nullable<bool> Stockable { get; set; }
        public Nullable<bool> Retunable { get; set; }
        public Nullable<int> PositionID { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual M_PartCondition M_PartCondition1 { get; set; }
        public virtual M_PartCondition M_PartCondition2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_PartConditionPrice> T_PartConditionPrice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_PartLogistics> T_PartLogistics { get; set; }
    }
}
