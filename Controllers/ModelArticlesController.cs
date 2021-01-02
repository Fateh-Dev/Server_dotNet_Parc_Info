
using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using GestionParcInformatique.Dtos.ModelArticle;
using System;
using GestionParcInformatique.Authentication;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelArticlesController : ControllerBase
    {
        private readonly IModelArticleRepo _repository;
        private readonly IMapper _mapper;

        public ModelArticlesController(IModelArticleRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/ModelArticles
        [HttpGet]
        public ActionResult<IEnumerable<ModelArticleReadDto>> GetAllModelArticles()
        {
            var ModelArticleItems=_repository.GetAllModelArticles();
            return Ok(_mapper.Map<IEnumerable<ModelArticleReadDto>>(ModelArticleItems));
        }

        // Get Api /api/ModelArticles/{id}
        [HttpGet("{id}",Name="GetModelArticleById")]       
        public ActionResult <ModelArticleReadDto> GetModelArticleById(Guid id)
        {
            var ModelArticleItem=_repository.GetModelArticleById(id);
            if(ModelArticleItem!=null){
            return Ok(_mapper.Map<ModelArticleReadDto>(ModelArticleItem));
            }
            return NotFound(); 
        }

        //Create ModelArticle /api/ModelArticles
        [HttpPost]
        public ActionResult<ModelArticleReadDto> CreateModelArticle(ModelArticleCreateDto ModelArticleCreateDto)
        {
            ModelArticleCreateDto.Id = Guid.NewGuid();
            var ModelArticleModel=_mapper.Map<ModelArticle>(ModelArticleCreateDto);
            ModelArticleModel.DateCreation=DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateModelArticle(ModelArticleModel);
            _repository.SaveChanges();
            var ModelArticleReadDto=_mapper.Map<ModelArticleReadDto>(ModelArticleModel);
            
            return CreatedAtRoute(nameof(GetModelArticleById),new {Id=ModelArticleReadDto.Id},ModelArticleReadDto); 
        }

        [HttpPut("{id}")]
         public ActionResult<ModelArticleReadDto> UpdateModelArticle([FromBody] ModelArticleUpdateDto ModelArticleUpdateDto,Guid id)
        {
            var ModelArticleToUpdate=_repository.GetModelArticleById(id);
            if(ModelArticleToUpdate == null)
            {
                return NotFound();
            }            
            
            var ModelArticleModel=_mapper.Map<ModelArticle>(ModelArticleUpdateDto);
            ModelArticleToUpdate.DesignationFr=ModelArticleUpdateDto.DesignationFr;
            ModelArticleToUpdate.DesignationAr=ModelArticleUpdateDto.DesignationAr;
            _repository.UpdateModelArticle(ModelArticleModel);
            _repository.SaveChanges();

            var ModelArticleReadDto=_mapper.Map<ModelArticleReadDto>(ModelArticleModel);
            return CreatedAtRoute(nameof(GetModelArticleById),new {Id=ModelArticleReadDto.Id},ModelArticleReadDto); 
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