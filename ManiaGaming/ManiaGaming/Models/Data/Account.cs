using System;

namespace ManiaGaming.Models.Data
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Naam { get; set; }
        public string AchterNaam { get; set; }
        public bool Actief { get; set; }
        public int RoleId { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get { return Naam.ToUpper(); } set { Naam = value.ToUpper(); } }

        public Account() { }

        public Account(int id, string userName, string email, string password, int roleid)
        {
            Id = id;
            Naam = userName;
            Email = email;
            Password = password;
            RoleId = roleid;
            if (userName != null)
            {
                NormalizedUserName = userName.ToUpper();
            }
            NormalizedEmail = email.ToUpper();
        }

        public Account(int id, string naam, string achternaam, string email)
        {
            Id = id;
            Naam = naam;
            AchterNaam = achternaam;
            Email = email;
            NormalizedUserName = naam.ToUpper();
            NormalizedEmail = email.ToUpper();
        }

        public string GetRole()
        {
            string role = "";
            switch (RoleId)
            {
                case 1:
                    role = "Werknemer";
                    break;
                case 2:
                    role = "Klant";
                    break;
                case 3:
                    role = "Beheerder";
                    break;
                default:
                    break;
            }
            return role;
        }
    }
}
