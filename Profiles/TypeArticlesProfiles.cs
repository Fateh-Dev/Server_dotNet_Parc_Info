using AutoMapper;
using GestionParcInformatique.Dtos.TypeArticle;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Profiles
{
    public class TypeArticlesProfile : Profile
    {
        public TypeArticlesProfile()
        {
            //Source --> Dest
            CreateMap<TypeArticle, TypeArticleReadDto>();
            CreateMap<TypeArticleCreateDto, TypeArticle>();
            CreateMap<TypeArticleUpdateDto, TypeArticle>();

        }
    }
}