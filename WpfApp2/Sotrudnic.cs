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
    
    public partial class Sotrudnic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sotrudnic()
        {
            this.Material = new HashSet<Material>();
            this.Zapis = new HashSet<Zapis>();
        }
    
        public int ID_Sotudnica { get; set; }
        public string FName { get; set; }
        public string Name { get; set; }
        public string Othestvo { get; set; }
        public string Adres { get; set; }
        public Nullable<int> Telefon { get; set; }
        public string Poshta { get; set; }
        public string Doljnost { get; set; }
        public Nullable<int> Shas_Rabot { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Material> Material { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zapis> Zapis { get; set; }
    }
}
