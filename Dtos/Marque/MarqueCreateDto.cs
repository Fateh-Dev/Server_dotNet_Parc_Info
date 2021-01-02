using System;
using System.ComponentModel.DataAnnotations;

namespace GestionParcInformatique.Dtos.Marque
{
    public class MarqueCreateDto
    {
        public Guid Id{get;set;}
        public string DesignationFr{get;set;}
        public string DesignationAr { get; set; }
    }
}