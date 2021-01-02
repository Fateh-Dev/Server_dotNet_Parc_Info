using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using System;
using System.Threading.Tasks;
using GestionParcInformatique.Authentication;
using GestionParcInformatique.Dtos.Document;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentRepo _repository;
        private readonly IMapper _mapper;

        public DocumentsController(IDocumentRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/Documents
        [HttpGet]
        public ActionResult<IEnumerable<Document>> GetAllDocuments()
        {
            var DocumentItems=_repository.GetAllDocuments();
            return Ok(_mapper.Map<IEnumerable<Document>>(DocumentItems));
        }

        // Get Api /api/Documents/{id}
        [HttpGet("{id}",Name="GetDocumentById")]       
        public ActionResult <Document> GetDocumentById(Guid id)
        {
            var DocumentItem=_repository.GetDocumentById(id);
            if(DocumentItem!=null){
            return Ok(_mapper.Map<Document>(DocumentItem));
            }
            return NotFound(); 
        }

        //Create Document /api/Documents
        [HttpPost]
        public ActionResult<Document> CreateDocument(Document Document)
        {
            
            Document.Id = Guid.NewGuid();
            Document.DateCreation=DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateDocument(Document);
            _repository.SaveChanges();
            
            return CreatedAtRoute(nameof(GetDocumentById),new {Id=Document.Id},Document); 
        }

        [HttpPut]
        public ActionResult<Document> UpdateDocument(Document Document)
        {
            _repository.UpdateDocument(Document);
            _repository.SaveChanges();
            
            return CreatedAtRoute(nameof(GetDocumentById),new {Id=Document.Id},Document); 
        }


        //Delete Document /api/Documents
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