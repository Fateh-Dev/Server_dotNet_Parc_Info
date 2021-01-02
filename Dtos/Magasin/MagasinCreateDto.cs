using System;
using System.ComponentModel.DataAnnotations;

namespace GestionParcInformatique.Dtos.Magasin
{
    public class MagasinCreateDto
    {
    
        public Guid Id{get;set;}
        public string DesignationFr{get;set;}
        public string DesignationAr { get; set; }
    }
}