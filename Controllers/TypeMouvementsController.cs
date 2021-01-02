
using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using GestionParcInformatique.Dtos.TypeMouvement;
using System;
using GestionParcInformatique.Authentication;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeMouvementsController : ControllerBase
    {
        private readonly ITypeMouvementRepo _repository;
        private readonly IMapper _mapper;

        public TypeMouvementsController(ITypeMouvementRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/TypeMouvements
        [HttpGet]
        public ActionResult<IEnumerable<TypeMouvementReadDto>> GetAllTypeMouvements()
        {
            var TypeMouvementItems=_repository.GetAllTypeMouvements();
            return Ok(_mapper.Map<IEnumerable<TypeMouvementReadDto>>(TypeMouvementItems));
        }

        // Get Api /api/TypeMouvements/{id}
        [HttpGet("{id}",Name="GetTypeMouvementById")]       
        public ActionResult <TypeMouvementReadDto> GetTypeMouvementById(Guid id)
        {
            var TypeMouvementItem=_repository.GetTypeMouvementById(id);
            if(TypeMouvementItem!=null){
            return Ok(_mapper.Map<TypeMouvementReadDto>(TypeMouvementItem));
            }
            return NotFound(); 
        }

        //Create TypeMouvement /api/TypeMouvements
        [HttpPost]
        public ActionResult<TypeMouvementReadDto> CreateTypeMouvement(TypeMouvementCreateDto TypeMouvementCreateDto)
        {
        
                TypeMouvementCreateDto.Id = Guid.NewGuid();
            
            var TypeMouvementModel=_mapper.Map<TypeMouvement>(TypeMouvementCreateDto);
            TypeMouvementModel.DateCreation= DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateTypeMouvement(TypeMouvementModel);
            _repository.SaveChanges();
            var TypeMouvementReadDto=_mapper.Map<TypeMouvementReadDto>(TypeMouvementModel);
            
            return CreatedAtRoute(nameof(GetTypeMouvementById),new {Id=TypeMouvementReadDto.Id},TypeMouvementReadDto); 
        }

        [HttpPut("{id}")]
         public ActionResult<TypeMouvementReadDto> UpdateTypeMouvement([FromBody] TypeMouvementUpdateDto TypeMouvementUpdateDto,Guid id)
        {
            var TypeMouvementToUpdate=_repository.GetTypeMouvementById(id);
            if(TypeMouvementToUpdate == null)
            {
                return NotFound();
            }            
            
            var TypeMouvementModel=_mapper.Map<TypeMouvement>(TypeMouvementUpdateDto);
            TypeMouvementToUpdate.DesignationFr=TypeMouvementUpdateDto.DesignationFr;
            TypeMouvementToUpdate.DesignationAr=TypeMouvementUpdateDto.DesignationAr;
            _repository.UpdateTypeMouvement(TypeMouvementModel);
            _repository.SaveChanges();

            var TypeMouvementReadDto=_mapper.Map<TypeMouvementReadDto>(TypeMouvementModel);
            return CreatedAtRoute(nameof(GetTypeMouvementById),new {Id=TypeMouvementReadDto.Id},TypeMouvementReadDto); 
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