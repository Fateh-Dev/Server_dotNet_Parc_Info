
using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using GestionParcInformatique.Dtos.TypeArticle;
using System;
using GestionParcInformatique.Authentication;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeArticlesController : ControllerBase
    {
        private readonly ITypeArticleRepo _repository;
        private readonly IMapper _mapper;

        public TypeArticlesController(ITypeArticleRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/TypeArticles
        [HttpGet]
        public ActionResult<IEnumerable<TypeArticleReadDto>> GetAllTypeArticles()
        {
            var TypeArticleItems=_repository.GetAllTypeArticles();
            return Ok(_mapper.Map<IEnumerable<TypeArticleReadDto>>(TypeArticleItems));
        }

        // Get Api /api/TypeArticles/{id}
        [HttpGet("{id}",Name="GetTypeArticleById")]       
        public ActionResult <TypeArticleReadDto> GetTypeArticleById(Guid id)
        {
            var TypeArticleItem=_repository.GetTypeArticleById(id);
            if(TypeArticleItem!=null){
            return Ok(_mapper.Map<TypeArticleReadDto>(TypeArticleItem));
            }
            return NotFound(); 
        }

        //Create TypeArticle /api/TypeArticles
        [HttpPost]
        public ActionResult<TypeArticleReadDto> CreateTypeArticle(TypeArticleCreateDto TypeArticleCreateDto)
        {
         
                TypeArticleCreateDto.Id = Guid.NewGuid();
            var TypeArticleModel=_mapper.Map<TypeArticle>(TypeArticleCreateDto);
            TypeArticleModel.DateCreation= DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateTypeArticle(TypeArticleModel);
            _repository.SaveChanges();
            var TypeArticleReadDto=_mapper.Map<TypeArticleReadDto>(TypeArticleModel);
            
            return CreatedAtRoute(nameof(GetTypeArticleById),new {Id=TypeArticleReadDto.Id},TypeArticleReadDto); 
        }

        [HttpPut("{id}")]
         public ActionResult<TypeArticleReadDto> UpdateTypeArticle([FromBody] TypeArticleUpdateDto TypeArticleUpdateDto,Guid id)
        {
            var TypeArticleToUpdate=_repository.GetTypeArticleById(id);
            if(TypeArticleToUpdate == null)
            {
                return NotFound();
            }            
            
            var TypeArticleModel=_mapper.Map<TypeArticle>(TypeArticleUpdateDto);
            TypeArticleToUpdate.DesignationFr=TypeArticleUpdateDto.DesignationFr;
            TypeArticleToUpdate.DesignationAr=TypeArticleUpdateDto.DesignationAr;
            _repository.UpdateTypeArticle(TypeArticleModel);
            _repository.SaveChanges();

            var TypeArticleReadDto=_mapper.Map<TypeArticleReadDto>(TypeArticleModel);
            return CreatedAtRoute(nameof(GetTypeArticleById),new {Id=TypeArticleReadDto.Id},TypeArticleReadDto); 
        }
        
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