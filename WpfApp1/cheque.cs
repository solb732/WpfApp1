//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class cheque
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cheque()
        {
            this.order = new HashSet<order>();
        }
    
        public int idcheq { get; set; }
        public int iduser { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<decimal> total { get; set; }

        public string FIOC { get; set; }
        public string products { get; set; }
        public string cost { get; set; }
        public DateTime date1 { get; set; }
        public string price { get; set; }

        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> order { get; set; }
    }
}