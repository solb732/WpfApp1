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
    
    public partial class order
    {
        public int idorder { get; set; }
        public int idcheq { get; set; }
        public Nullable<int> idproduct { get; set; }
        public Nullable<int> total { get; set; }
        public Nullable<decimal> price { get; set; }
    
        public virtual cheque cheque { get; set; }
        public virtual product product { get; set; }
    }
}
