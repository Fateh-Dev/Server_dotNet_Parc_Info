using System;
using System.ComponentModel.DataAnnotations;

namespace GestionParcInformatique.Dtos.Etat
{
    public class EtatCreateDto
    {
        public Guid Id{get;set;}
        public string DesignationFr{get;set;}
        public string DesignationAr { get; set; }
    }
}