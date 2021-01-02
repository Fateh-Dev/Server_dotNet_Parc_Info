
using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using GestionParcInformatique.Dtos.TypeDocument;
using System;
using GestionParcInformatique.Authentication;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeDocumentsController : ControllerBase
    {
        private readonly ITypeDocumentRepo _repository;
        private readonly IMapper _mapper;

        public TypeDocumentsController(ITypeDocumentRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/TypeDocuments
        [HttpGet]
        public ActionResult<IEnumerable<TypeDocumentReadDto>> GetAllTypeDocuments()
        {
            var TypeDocumentItems=_repository.GetAllTypeDocuments();
            return Ok(_mapper.Map<IEnumerable<TypeDocumentReadDto>>(TypeDocumentItems));
        }

        // Get Api /api/TypeDocuments/{id}
        [HttpGet("{id}",Name="GetTypeDocumentById")]       
        public ActionResult <TypeDocumentReadDto> GetTypeDocumentById(Guid id)
        {
            var TypeDocumentItem=_repository.GetTypeDocumentById(id);
            if(TypeDocumentItem!=null){
            return Ok(_mapper.Map<TypeDocumentReadDto>(TypeDocumentItem));
            }
            return NotFound(); 
        }

        //Create TypeDocument /api/TypeDocuments
        [HttpPost]
        public ActionResult<TypeDocumentReadDto> CreateTypeDocument(TypeDocumentCreateDto TypeDocumentCreateDto)
        {
      
                TypeDocumentCreateDto.Id = Guid.NewGuid();
            
            var TypeDocumentModel=_mapper.Map<TypeDocument>(TypeDocumentCreateDto);
            TypeDocumentModel.DateCreation= DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateTypeDocument(TypeDocumentModel);
            _repository.SaveChanges();
            var TypeDocumentReadDto=_mapper.Map<TypeDocumentReadDto>(TypeDocumentModel);
            
            return CreatedAtRoute(nameof(GetTypeDocumentById),new {Id=TypeDocumentReadDto.Id},TypeDocumentReadDto); 
        }
        
        [HttpPut("{id}")]
         public ActionResult<TypeDocumentReadDto> UpdateTypeDocument([FromBody] TypeDocumentUpdateDto TypeDocumentUpdateDto,Guid id)
        {
            var TypeDocumentToUpdate=_repository.GetTypeDocumentById(id);
            if(TypeDocumentToUpdate == null)
            {
                return NotFound();
            }            
            
            var TypeDocumentModel=_mapper.Map<TypeDocument>(TypeDocumentUpdateDto);
            TypeDocumentToUpdate.DesignationFr=TypeDocumentUpdateDto.DesignationFr;
            TypeDocumentToUpdate.DesignationAr=TypeDocumentUpdateDto.DesignationAr;
            _repository.UpdateTypeDocument(TypeDocumentModel);
            _repository.SaveChanges();

            var TypeDocumentReadDto=_mapper.Map<TypeDocumentReadDto>(TypeDocumentModel);
            return CreatedAtRoute(nameof(GetTypeDocumentById),new {Id=TypeDocumentReadDto.Id},TypeDocumentReadDto); 
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