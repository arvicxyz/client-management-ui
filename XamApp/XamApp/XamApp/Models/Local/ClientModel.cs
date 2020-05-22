using System;

namespace XamApp.Models.Local
{
    public class ClientModel : BaseLocalModel
    {
        public string ProfileImage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Address
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        // Contact Numbers
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
