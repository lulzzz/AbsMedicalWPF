//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AbsMedical.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class school
    {
        public school()
        {
            this.student = new HashSet<student>();
        }
    
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string CountryId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    
        public virtual country country { get; set; }
        public virtual ICollection<student> student { get; set; }
    }
}
