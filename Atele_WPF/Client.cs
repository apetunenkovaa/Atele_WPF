//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Atele_WPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.Order = new HashSet<Order>();
            this.Client_photo = new HashSet<Client_photo>();
        }
    
        public int ID_Client { get; set; }
        public string Surname_Client { get; set; }
        public string Firstname_Client { get; set; }
        public string Patronymic_Client { get; set; }
        public string Adress { get; set; }
        public string Mobile_phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public int Password { get; set; }
        public int ID_Role { get; set; }
    
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client_photo> Client_photo { get; set; }
    }
}
