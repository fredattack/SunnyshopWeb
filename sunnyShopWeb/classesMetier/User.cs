using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sunnyShopWeb.classesMetier
{
    public class User
    {
        private int idUser;
        private String firstName;
        private String login;
        private String lastName;
        private String adresUser;
        private String password;
        private String birthDate;
        private String role;
        private Decimal totalAchat;



        #region Constructor

        public User()
        {
        }

        public User(int idUser, string firstName, string login, 
            string lastName, string adresUser, string password,
            string birthDate, string role, Decimal totalAchat)
        {
            IdUser = idUser;
            FirstName = firstName;
            Login = login;
            LastName = lastName;
            AdresUser = adresUser;
            Password = password;
            BirthDate = birthDate;
            Role = role;
            TotalAchat = totalAchat;
        }



        #endregion

        #region Get/Set
        public int IdUser
        {
            get
            {
                return idUser;
            }

            set
            {
                idUser = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string AdresUser
        {
            get
            {
                return adresUser;
            }

            set
            {
                adresUser = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
            }
        }

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }

        public Decimal TotalAchat
        {
            get
            {
                return totalAchat;
            }

            set
            {
                totalAchat = value;
            }
        }
        #endregion
    }
}