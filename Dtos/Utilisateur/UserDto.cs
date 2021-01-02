using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GestionParcInformatique.Dtos.Utilisateur
{
    public class UserDto:IdentityUser
    {
     public string Password { get; set; }
        public DateTime DateCreation { get; set; }
        public Guid? IdPersonne { get; set; }
    }
}