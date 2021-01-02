
using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using GestionParcInformatique.Dtos.Article;
using System;
using System.Threading.Tasks;
using GestionParcInformatique.Authentication;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepo _repository;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArticleReadDto>> GetAllArticles()
        {
            var ArticleItems=_repository.GetAllArticles();
            return Ok(_mapper.Map<IEnumerable<ArticleReadDto>>(ArticleItems));
        }

             
        // Get Api /api/Articles/{id}
        [HttpGet("{id}",Name="GetArticleById")]       
        public ActionResult <ArticleReadDto> GetArticleById(Guid id)
        {
            var ArticleItem=_repository.GetArticleById(id);
            if(ArticleItem!=null){
            return Ok(_mapper.Map<ArticleReadDto>(ArticleItem));
            }
            return NotFound(); 
        }

        //Create Article /api/Articles
        [HttpPost]
        public ActionResult<ArticleReadDto> CreateArticle(ArticleCreateDto ArticleCreateDto)
        {

            ArticleCreateDto.Id = Guid.NewGuid();
            var ArticleModel=_mapper.Map<Article>(ArticleCreateDto);
            ArticleModel.DateCreation=DateTime.Now;
            ArticleModel.NumOrdre=_repository.getMaxNumOrdre();
            //TODO Add Owner ID 
            _repository.CreateArticle(ArticleModel);
            _repository.SaveChanges();
            var ArticleReadDto=_mapper.Map<ArticleReadDto>(ArticleModel);
            
            return CreatedAtRoute(nameof(GetArticleById),new {Id=ArticleReadDto.Id},ArticleReadDto); 
        }

        //Update Article /api/Articles
        [HttpPut("{id}")]
        public ActionResult<ArticleReadDto> UpdateArticle([FromBody]ArticleUpdateDto articleUpdateDto,Guid id)
        {
            var articleToUpdate=_repository.GetArticleById(id);
            if(articleToUpdate == null)
            {
                return NotFound();
            }            
            var ArticleModel=_mapper.Map<Article>(articleUpdateDto);

            articleToUpdate.NumSerie=articleUpdateDto.NumSerie;
            articleToUpdate.NumRef=articleUpdateDto.NumRef;
            articleToUpdate.IdCategorie=articleUpdateDto.IdCategorie;
            articleToUpdate.IdCouleur=articleUpdateDto.IdCouleur;
            articleToUpdate.IdEtat=articleUpdateDto.IdEtat;
            articleToUpdate.IdMarque=articleUpdateDto.IdMarque;
            articleToUpdate.IdModeConsommation=articleUpdateDto.IdModeConsommation;
            articleToUpdate.IdModelArticle=articleUpdateDto.IdModelArticle;
            articleToUpdate.IdUniteMesure=articleUpdateDto.IdUniteMesure;
            articleToUpdate.QteSeuil=articleUpdateDto.QteSeuil;
            articleToUpdate.NumKit=articleUpdateDto.NumKit;
            articleToUpdate.DateReception=articleUpdateDto.DateReception;
            articleToUpdate.IdTypeArticle=articleUpdateDto.IdTypeArticle;

            _repository.UpdateArticle(ArticleModel);
            _repository.SaveChanges();
            var ArticleReadDto=_mapper.Map<ArticleReadDto>(ArticleModel);
            
            return CreatedAtRoute(nameof(GetArticleById),new {Id=ArticleReadDto.Id},ArticleReadDto); 
        }
        //Delete Article /api/Articles
        [HttpDelete("{id}")]
        public ActionResult DeleteById(Guid id)
        {
            if(_repository.Delete(id)){
                _repository.SaveChanges();
                return Ok(new Response { Status = "Success", Message = "Item Deleted successfully!" });  
            }
            return NotFound();
        }

    }
}