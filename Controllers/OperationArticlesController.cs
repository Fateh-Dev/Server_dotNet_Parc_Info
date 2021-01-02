using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using System;
using System.Threading.Tasks;
using GestionParcInformatique.Authentication;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationArticlesController : ControllerBase
    {
        private readonly IOperationArticleRepo _repository;
        private readonly IMapper _mapper;

        public OperationArticlesController(IOperationArticleRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/OperationArticles
        [HttpGet]
        public ActionResult<IEnumerable<OperationArticle>> GetAllOperationArticles()
        {
            var OperationArticleItems=_repository.GetAllOperationArticles();
            return Ok(_mapper.Map<IEnumerable<OperationArticle>>(OperationArticleItems));
        }

        // Get Api /api/OperationArticles/{id}
        [HttpGet("{id}",Name="GetOperationArticleById")]       
        public ActionResult <OperationArticle> GetOperationArticleById(Guid id)
        {
            var OperationArticleItem=_repository.GetOperationArticleById(id);
            if(OperationArticleItem!=null){
            return Ok(_mapper.Map<OperationArticle>(OperationArticleItem));
            }
            return NotFound(); 
        }

        //Create OperationArticle /api/OperationArticles
        [HttpPost]
        public ActionResult<OperationArticle> CreateOperationArticle(OperationArticle OperationArticle)
        {
      
            OperationArticle.Id = Guid.NewGuid();
            OperationArticle.DateCreation= DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateOperationArticle(OperationArticle);
            _repository.SaveChanges();
            
            return CreatedAtRoute(nameof(GetOperationArticleById),new {Id=OperationArticle.Id},OperationArticle); 
        }
        //Delete OperationArticle /api/OperationArticles
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