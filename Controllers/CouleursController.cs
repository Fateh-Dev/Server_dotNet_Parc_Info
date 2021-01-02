
using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using GestionParcInformatique.Dtos.Couleur;
using System;
using GestionParcInformatique.Authentication;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouleursController : ControllerBase
    {
        private readonly ICouleurRepo _repository;
        private readonly IMapper _mapper;

        public CouleursController(ICouleurRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/Couleurs
        [HttpGet]
        public ActionResult<IEnumerable<CouleurReadDto>> GetAllCouleurs()
        {
            var CouleurItems=_repository.GetAllCouleurs();
            return Ok(_mapper.Map<IEnumerable<CouleurReadDto>>(CouleurItems));
        }

        // Get Api /api/Couleurs/{id}
        [HttpGet("{id}",Name="GetCouleurById")]       
        public ActionResult <CouleurReadDto> GetCouleurById(Guid id)
        {
            var CouleurItem=_repository.GetCouleurById(id);
            if(CouleurItem!=null){
            return Ok(_mapper.Map<CouleurReadDto>(CouleurItem));
            }
            return NotFound(); 
        }

        //Create Couleur /api/Couleurs
        [HttpPost]
        public ActionResult<CouleurReadDto> CreateCouleur(CouleurCreateDto CouleurCreateDto)
        {
         
            CouleurCreateDto.Id = Guid.NewGuid();
            var CouleurModel=_mapper.Map<Couleur>(CouleurCreateDto);
            CouleurModel.DateCreation=DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateCouleur(CouleurModel);
            _repository.SaveChanges();
            var CouleurReadDto=_mapper.Map<CouleurReadDto>(CouleurModel);
            
            return CreatedAtRoute(nameof(GetCouleurById),new {Id=CouleurReadDto.Id},CouleurReadDto); 
        }

        [HttpPut("{id}")]
         public ActionResult<CouleurReadDto> UpdateCouleur([FromBody] CouleurUpdateDto couleurUpdateDto,Guid id)
        {
            var couleurToUpdate=_repository.GetCouleurById(id);
            if(couleurToUpdate == null)
            {
                return NotFound();
            }            
            
            var couleurModel=_mapper.Map<Couleur>(couleurUpdateDto);
            couleurToUpdate.DesignationFr=couleurUpdateDto.DesignationFr;
            couleurToUpdate.DesignationAr=couleurUpdateDto.DesignationAr;
            _repository.UpdateCouleur(couleurModel);
            _repository.SaveChanges();

            var couleurReadDto=_mapper.Map<CouleurReadDto>(couleurModel);
            return CreatedAtRoute(nameof(GetCouleurById),new {Id=couleurReadDto.Id},couleurReadDto); 
        }

        //Delete Couleur /api/Couleurs
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