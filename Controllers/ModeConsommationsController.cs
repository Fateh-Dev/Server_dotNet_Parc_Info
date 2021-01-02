
using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using GestionParcInformatique.Dtos.ModeConsommation;
using System;
using GestionParcInformatique.Authentication;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeConsommationsController : ControllerBase
    {
        private readonly IModeConsommationRepo _repository;
        private readonly IMapper _mapper;

        public ModeConsommationsController(IModeConsommationRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/ModeConsommations
        [HttpGet]
        public ActionResult<IEnumerable<ModeConsommationReadDto>> GetAllModeConsommations()
        {
            var ModeConsommationItems=_repository.GetAllModeConsommations();
            return Ok(_mapper.Map<IEnumerable<ModeConsommationReadDto>>(ModeConsommationItems));
        }

        // Get Api /api/ModeConsommations/{id}
        [HttpGet("{id}",Name="GetModeConsommationById")]       
        public ActionResult <ModeConsommationReadDto> GetModeConsommationById(Guid id)
        {
            var ModeConsommationItem=_repository.GetModeConsommationById(id);
            if(ModeConsommationItem!=null){
            return Ok(_mapper.Map<ModeConsommationReadDto>(ModeConsommationItem));
            }
            return NotFound(); 
        }

        //Create ModeConsommation /api/ModeConsommations
        [HttpPost]
        public ActionResult<ModeConsommationReadDto> CreateModeConsommation(ModeConsommationCreateDto ModeConsommationCreateDto)
        {
           
                ModeConsommationCreateDto.Id = Guid.NewGuid();
            
            var ModeConsommationModel=_mapper.Map<ModeConsommation>(ModeConsommationCreateDto);
            ModeConsommationModel.DateCreation=DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateModeConsommation(ModeConsommationModel);
            _repository.SaveChanges();
            var ModeConsommationReadDto=_mapper.Map<ModeConsommationReadDto>(ModeConsommationModel);
            
            return CreatedAtRoute(nameof(GetModeConsommationById),new {Id=ModeConsommationReadDto.Id},ModeConsommationReadDto); 
        }

        [HttpPut("{id}")]
         public ActionResult<ModeConsommationReadDto> UpdateModeConsommation([FromBody] ModeConsommationUpdateDto ModeConsommationUpdateDto,Guid id)
        {
            var ModeConsommationToUpdate=_repository.GetModeConsommationById(id);
            if(ModeConsommationToUpdate == null)
            {
                return NotFound();
            }            
            
            var ModeConsommationModel=_mapper.Map<ModeConsommation>(ModeConsommationUpdateDto);
            ModeConsommationToUpdate.DesignationFr=ModeConsommationUpdateDto.DesignationFr;
            ModeConsommationToUpdate.DesignationAr=ModeConsommationUpdateDto.DesignationAr;
            _repository.UpdateModeConsommation(ModeConsommationModel);
            _repository.SaveChanges();

            var ModeConsommationReadDto=_mapper.Map<ModeConsommationReadDto>(ModeConsommationModel);
            return CreatedAtRoute(nameof(GetModeConsommationById),new {Id=ModeConsommationReadDto.Id},ModeConsommationReadDto); 
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