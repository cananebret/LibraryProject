//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class BOOK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOOK()
        {
            this.IS_STATUS = true;
            this.ACTIONs = new HashSet<ACTION>();
        }
    
        public int BOOK_ID { get; set; }
        public string BOOK_NAME { get; set; }
        public Nullable<int> BOOK_CAT { get; set; }
        public Nullable<int> AUTHOR { get; set; }
        public string EDITION { get; set; }
        public string PUBLISER { get; set; }
        public string PAGE { get; set; }
        public Nullable<bool> IS_STATUS { get; set; }
        public string BOOK_IMAGE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTION> ACTIONs { get; set; }
        public virtual AUTHOR AUTHOR1 { get; set; }
        public virtual CATEGORY CATEGORY { get; set; }
    }
}
