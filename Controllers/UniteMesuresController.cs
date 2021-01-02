
using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using GestionParcInformatique.Dtos.UniteMesure;
using System;
using GestionParcInformatique.Authentication;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniteMesuresController : ControllerBase
    {
        private readonly IUniteMesureRepo _repository;
        private readonly IMapper _mapper;

        public UniteMesuresController(IUniteMesureRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/UniteMesures
        [HttpGet]
        public ActionResult<IEnumerable<UniteMesureReadDto>> GetAllUniteMesures()
        {
            var UniteMesureItems=_repository.GetAllUniteMesures();
            return Ok(_mapper.Map<IEnumerable<UniteMesureReadDto>>(UniteMesureItems));
        }

        // Get Api /api/UniteMesures/{id}
        [HttpGet("{id}",Name="GetUniteMesureById")]       
        public ActionResult <UniteMesureReadDto> GetUniteMesureById(Guid id)
        {
            var UniteMesureItem=_repository.GetUniteMesureById(id);
            if(UniteMesureItem!=null){
            return Ok(_mapper.Map<UniteMesureReadDto>(UniteMesureItem));
            }
            return NotFound(); 
        }

        //Create UniteMesure /api/UniteMesures
        [HttpPost]
        public ActionResult<UniteMesureReadDto> CreateUniteMesure(UniteMesureCreateDto UniteMesureCreateDto)
        {
           
            UniteMesureCreateDto.Id = Guid.NewGuid();
            var UniteMesureModel=_mapper.Map<UniteMesure>(UniteMesureCreateDto);
            UniteMesureModel.DateCreation= DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateUniteMesure(UniteMesureModel);
            _repository.SaveChanges();
            var UniteMesureReadDto=_mapper.Map<UniteMesureReadDto>(UniteMesureModel);
            
            return CreatedAtRoute(nameof(GetUniteMesureById),new {Id=UniteMesureReadDto.Id},UniteMesureReadDto); 
        }

        [HttpPut("{id}")]
         public ActionResult<UniteMesureReadDto> UpdateUniteMesure([FromBody] UniteMesureUpdateDto UniteMesureUpdateDto,Guid id)
        {
            var UniteMesureToUpdate=_repository.GetUniteMesureById(id);
            if(UniteMesureToUpdate == null)
            {
                return NotFound();
            }            
            
            var UniteMesureModel=_mapper.Map<UniteMesure>(UniteMesureUpdateDto);
            UniteMesureToUpdate.DesignationFr=UniteMesureUpdateDto.DesignationFr;
            UniteMesureToUpdate.DesignationAr=UniteMesureUpdateDto.DesignationAr;
            _repository.UpdateUniteMesure(UniteMesureModel);
            _repository.SaveChanges();

            var UniteMesureReadDto=_mapper.Map<UniteMesureReadDto>(UniteMesureModel);
            return CreatedAtRoute(nameof(GetUniteMesureById),new {Id=UniteMesureReadDto.Id},UniteMesureReadDto); 
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