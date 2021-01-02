using AutoMapper;
using GestionParcInformatique.Dtos.Categorie;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            //Source --> Dest
            CreateMap<Categorie, CategorieReadDto>();
            CreateMap<CategorieCreateDto, Categorie>();
            CreateMap<CategorieUpdateDto, Categorie>();
        }
    }
}