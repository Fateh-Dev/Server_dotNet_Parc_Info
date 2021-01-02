using System;
using System.ComponentModel.DataAnnotations;

namespace GestionParcInformatique.Dtos.UniteMesure
{
    public class UniteMesureCreateDto
    {
    
        public Guid Id{get;set;}
        public string DesignationFr{get;set;}
        public string DesignationAr { get; set; }
    }
}