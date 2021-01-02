using System;
using System.ComponentModel.DataAnnotations;

namespace GestionParcInformatique.Dtos.Couleur
{
    public class CouleurCreateDto
    {
    public Guid Id{get;set;}
        public string DesignationFr{get;set;}
        public string DesignationAr { get; set; }
    }
}