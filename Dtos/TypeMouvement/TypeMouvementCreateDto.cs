using System;
using System.ComponentModel.DataAnnotations;

namespace GestionParcInformatique.Dtos.TypeMouvement
{
    public class TypeMouvementCreateDto
    {
    
        public Guid Id{get;set;}
        public string DesignationFr{get;set;}
        public string DesignationAr { get; set; }
    }
}