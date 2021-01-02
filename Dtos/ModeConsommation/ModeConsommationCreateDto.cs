using System;
using System.ComponentModel.DataAnnotations;

namespace GestionParcInformatique.Dtos.ModeConsommation
{
    public class ModeConsommationCreateDto
    {
    
        public Guid Id{get;set;}
        public string DesignationFr{get;set;}
        public string DesignationAr { get; set; }
    }
}