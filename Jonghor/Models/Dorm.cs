//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jonghor.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dorm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dorm()
        {
            this.Dorm_Option = new HashSet<Dorm_Option>();
            this.Dorm_Rate = new HashSet<Dorm_Rate>();
            this.Person1 = new HashSet<Person>();
        }
    
        public int Dorm_ID { get; set; }
        public string Name { get; set; }
        public string M_username { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string information { get; set; }
        public string Line { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string Deposit { get; set; }
        public Nullable<int> W_minimum { get; set; }
        public Nullable<int> W_Per_Unit { get; set; }
        public string Internet { get; set; }
        public Nullable<int> E_Minimum { get; set; }
        public Nullable<int> E_Per_Unit { get; set; }
    
        public virtual Dorm_Label Dorm_Label { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dorm_Option> Dorm_Option { get; set; }
        public virtual Person Person { get; set; }
        public virtual Dorm_Picture Dorm_Picture { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dorm_Rate> Dorm_Rate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person1 { get; set; }
    }
}
