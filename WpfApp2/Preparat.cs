//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Preparat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Preparat()
        {
            this.Zakazanie_Preparat = new HashSet<Zakazanie_Preparat>();
        }
    
        public int ID_Preparat { get; set; }
        public string Nazvanie { get; set; }
        public Nullable<int> Kolishestvo { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Skidka { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zakazanie_Preparat> Zakazanie_Preparat { get; set; }
    }
}
