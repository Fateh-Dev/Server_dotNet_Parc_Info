using AutoMapper;
using GestionParcInformatique.Dtos.ModelArticle;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Profiles
{
    public class ModelArticlesProfile : Profile
    {
        public ModelArticlesProfile()
        {
            //Source --> Dest
            CreateMap<ModelArticle, ModelArticleReadDto>();
            CreateMap<ModelArticleCreateDto, ModelArticle>();
            CreateMap<ModelArticleUpdateDto, ModelArticle>();
        }
    }
}