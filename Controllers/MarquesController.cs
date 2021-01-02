using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using GestionParcInformatique.Dtos.Marque;
using System;
using GestionParcInformatique.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarquesController : ControllerBase
    {
        private readonly IMarqueRepo _repository;
        private readonly IMapper _mapper;

        public MarquesController(IMarqueRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/Marques
        [HttpGet]
        public ActionResult<IEnumerable<MarqueReadDto>> GetAllMarques()
        {
            var MarqueItems=_repository.GetAllMarques();
            return Ok(_mapper.Map<IEnumerable<MarqueReadDto>>(MarqueItems));
        }

        // Get Api /api/Marques/{id}
        [HttpGet("{id}",Name="GetMarqueById")]       
        public ActionResult <MarqueReadDto> GetMarqueById(Guid id)
        {
            var MarqueItem=_repository.GetMarqueById(id);
            if(MarqueItem!=null){
            return Ok(_mapper.Map<MarqueReadDto>(MarqueItem));
            }
            return NotFound(); 
        }

        //Create Marque /api/Marques
        [HttpPost]
        public ActionResult<MarqueReadDto> CreateMarque(MarqueCreateDto MarqueCreateDto)
        {
            MarqueCreateDto.Id = Guid.NewGuid();
            var MarqueModel=_mapper.Map<Marque>(MarqueCreateDto);
            MarqueModel.DateCreation=DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateMarque(MarqueModel);
            _repository.SaveChanges();
            var MarqueReadDto=_mapper.Map<MarqueReadDto>(MarqueModel);
            return CreatedAtRoute(nameof(GetMarqueById),new {Id=MarqueReadDto.Id},MarqueReadDto); 
        }

        // Update Etat /api/Etats
        [HttpPut("{id}")]
         public ActionResult<MarqueReadDto> UpdateMarque([FromBody] MarqueUpdateDto MarqueUpdateDto,Guid id)
        {
            var marqueToUpdate=_repository.GetMarqueById(id);
            if(marqueToUpdate == null)
            {
                return NotFound();
            }            
            
            var MarqueModel=_mapper.Map<Marque>(MarqueUpdateDto);
            marqueToUpdate.DesignationFr=MarqueUpdateDto.DesignationFr;
            marqueToUpdate.DesignationAr=MarqueUpdateDto.DesignationAr;
            _repository.UpdateMarque(MarqueModel);
            _repository.SaveChanges();

            var MarqueReadDto=_mapper.Map<MarqueReadDto>(MarqueModel);
            return CreatedAtRoute(nameof(GetMarqueById),new {Id=MarqueReadDto.Id},MarqueReadDto); 
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