//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Glumac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Glumac()
        {
            this.GlumioN = new HashSet<Glumi>();
        }
    
        public int ID_Glumca { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Ime_lika { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Glumi> GlumioN { get; set; }
    }
}
