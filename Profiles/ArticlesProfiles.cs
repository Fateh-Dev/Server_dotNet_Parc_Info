using AutoMapper;
using GestionParcInformatique.Dtos.Article;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Profiles
{
    public class ArticlesProfiles : Profile
    {
        public ArticlesProfiles()
        {
            //Source --> Dest
            CreateMap<Article, ArticleReadDto>();
            CreateMap<ArticleCreateDto, Article>();
            CreateMap<ArticleUpdateDto, Article>();
        }
    }
}