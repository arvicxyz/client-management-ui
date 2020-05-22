using System;
using System.Collections.Generic;
using System.Linq;
using XamApp.Models.Local;

namespace XamApp.Services
{
    public class ClientService
    {
        public ClientService()
        {
        }

        public List<ClientModel> GetClients()
        {
            //return new List<ClientModel>(); // TODO: For testing
            var list = new List<ClientModel>
            {
                new ClientModel()
                {
                    // 3rd
                    Id = 1,
                    ProfileImage = "img_profile_1.png",
                    Name = "Pete MacDonald",
                    Description = "Pete is a creative former gallery-commisioned artist who is obsessed with over-knee socks.",
                    Street = "",
                    City = "",
                    State = "",
                    PostalCode = "",
                    HomePhone = "",
                    MobilePhone = "",
                    WorkPhone = "",
                    DateCreated = new DateTime(2020, 5, 3)
                },
                new ClientModel()
                {
                    // 2nd
                    Id = 2,
                    ProfileImage = "img_profile.png",
                    Name = "Clarke Raymond",
                    Description = "Clarke is an exciting former consultant programmer who enjoys travelling.",
                    Street = "4909 Emma Street",
                    City = "Halfway",
                    State = "Texas",
                    PostalCode = "79408",
                    HomePhone = "806-889-7931",
                    MobilePhone = "281-989-8244",
                    WorkPhone = "774-573-3679",
                    DateCreated = new DateTime(2020, 4, 30)
                },
                new ClientModel()
                {
                    // 4th
                    Id = 3,
                    ProfileImage = "img_profile_3.png",
                    Name = "Susan Nolan",
                    Description = "Susan is a cleaner at a studio with a serious addiction to chocolate.",
                    Street = "674  Boundary Street",
                    City = "Jacksonville",
                    State = "Florida",
                    PostalCode = "32202",
                    HomePhone = "904-613-4428",
                    MobilePhone = "904-316-7260",
                    WorkPhone = "508-473-5992",
                    DateCreated = new DateTime(2020, 5, 4)
                },
                new ClientModel()
                {
                    // 1st
                    Id = 4,
                    ProfileImage = "img_profile_4.png",
                    Name = "May Catherine Ramsbottom",
                    Description = "May is a creative tradesperson's assistant who enjoys spreading good news on Facebook.",
                    Street = "4217 Ferguson Street",
                    City = "Milford",
                    State = "Massachusetts",
                    PostalCode = "01757",
                    HomePhone = "",
                    MobilePhone = "",
                    WorkPhone = "",
                    DateCreated = new DateTime(2020, 4, 6)
                },
                new ClientModel()
                {
                    Id = 5,
                    ProfileImage = "img_profile.png",
                    Name = "Sharon Barker",
                    Description = "Sharon is an exciting local activist who suffers from a severe phobia of bridges.",
                    Street = "",
                    City = "",
                    State = "",
                    PostalCode = "",
                    HomePhone = "907-271-9476",
                    MobilePhone = "907-720-4723",
                    WorkPhone = "217-689-5714",
                    DateCreated = new DateTime(2020, 5, 5)
                },
                new ClientModel()
                {
                    Id = 6,
                    ProfileImage = "img_profile_6.png",
                    Name = "Mike Graham",
                    Description = "Mike is a creative trainee tradesperson who enjoys working on cars.",
                    Street = "",
                    City = "",
                    State = "Alaska",
                    PostalCode = "99503",
                    HomePhone = "",
                    MobilePhone = "",
                    WorkPhone = "217-766-3359",
                    DateCreated = new DateTime(2020, 5, 6)
                },
                new ClientModel()
                {
                    Id = 7,
                    ProfileImage = "img_profile_7.png",
                    Name = "Steve Johnson",
                    Description = "",
                    Street = "",
                    City = "Champaign",
                    State = "",
                    PostalCode = "61820",
                    HomePhone = "217-689-5714",
                    MobilePhone = "",
                    WorkPhone = "2217-766-3359",
                    DateCreated = new DateTime(2020, 5, 8)
                },
                new ClientModel()
                {
                    Id = 8,
                    ProfileImage = "img_profile.png",
                    Name = "Amir Fahd Hadji Usop",
                    Description = "Amir is a passionate mobile app developer who can stay all night to finish the task at hand.",
                    Street = "Kamuning St, El Rio Vista Village",
                    City = "Davao City",
                    State = "Davao del Sur",
                    PostalCode = "8000",
                    HomePhone = "09072635988",
                    MobilePhone = "09072635988",
                    WorkPhone = "09072635988",
                    DateCreated = new DateTime(2020, 5, 7)
                }
            };
            return list;
        }

        public ClientModel GetClientById(int id)
        {
            return GetClients().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
