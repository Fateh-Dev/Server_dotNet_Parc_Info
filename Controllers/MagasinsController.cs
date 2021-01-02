
using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using GestionParcInformatique.Dtos.Magasin;
using System;
using GestionParcInformatique.Authentication;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagasinsController : ControllerBase
    {
        private readonly IMagasinRepo _repository;
        private readonly IMapper _mapper;

        public MagasinsController(IMagasinRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/Magasins
        [HttpGet]
        public ActionResult<IEnumerable<MagasinReadDto>> GetAllMagasins()
        {
            var MagasinItems=_repository.GetAllMagasins();
            return Ok(_mapper.Map<IEnumerable<MagasinReadDto>>(MagasinItems));
        }

        // Get Api /api/Magasins/{id}
        [HttpGet("{id}",Name="GetMagasinById")]       
        public ActionResult <MagasinReadDto> GetMagasinById(Guid id)
        {
            var MagasinItem=_repository.GetMagasinById(id);
            if(MagasinItem!=null){
            return Ok(_mapper.Map<MagasinReadDto>(MagasinItem));
            }
            return NotFound(); 
        }

        //Create Magasin /api/Magasins
        [HttpPost]
        public ActionResult<MagasinReadDto> CreateMagasin(MagasinCreateDto MagasinCreateDto)
        {
            MagasinCreateDto.Id = Guid.NewGuid();
            var MagasinModel=_mapper.Map<Magasin>(MagasinCreateDto);
            MagasinModel.DateCreation=DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateMagasin(MagasinModel);
            _repository.SaveChanges();
            var MagasinReadDto=_mapper.Map<MagasinReadDto>(MagasinModel);
            
            return CreatedAtRoute(nameof(GetMagasinById),new {Id=MagasinReadDto.Id},MagasinReadDto); 
        }

        [HttpPut("{id}")]
         public ActionResult<MagasinReadDto> UpdateMagasin([FromBody] MagasinUpdateDto MagasinUpdateDto,Guid id)
        {
            var MagasinToUpdate=_repository.GetMagasinById(id);
            if(MagasinToUpdate == null)
            {
                return NotFound();
            }            
            
            var MagasinModel=_mapper.Map<Magasin>(MagasinUpdateDto);
            MagasinToUpdate.DesignationFr=MagasinUpdateDto.DesignationFr;
            MagasinToUpdate.DesignationAr=MagasinUpdateDto.DesignationAr;
            _repository.UpdateMagasin(MagasinModel);
            _repository.SaveChanges();

            var MagasinReadDto=_mapper.Map<MagasinReadDto>(MagasinModel);
            return CreatedAtRoute(nameof(GetMagasinById),new {Id=MagasinReadDto.Id},MagasinReadDto); 
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