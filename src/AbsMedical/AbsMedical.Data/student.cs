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
    
    public partial class student
    {
        public student()
        {
            this.absmedical = new HashSet<absmedical>();
        }
    
        public string Guid { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string StudentId { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public string SchoolGuid { get; set; }
    
        public virtual ICollection<absmedical> absmedical { get; set; }
        public virtual country country { get; set; }
        public virtual school school { get; set; }
    }
}