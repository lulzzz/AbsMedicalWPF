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
    
    public partial class absmedical
    {
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Note { get; set; }
        public string Guid { get; set; }
        public System.DateTime VisitDate { get; set; }
        public string StudentGuid { get; set; }
    
        public virtual doctor doctor { get; set; }
        public virtual student student { get; set; }
        public virtual visit visit { get; set; }
    }
}