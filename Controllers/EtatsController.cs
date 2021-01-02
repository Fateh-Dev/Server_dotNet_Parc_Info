using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using GestionParcInformatique.Dtos.Etat;
using System;
using System.Threading.Tasks;
using GestionParcInformatique.Authentication;

namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtatsController : ControllerBase
    {
        private readonly IEtatRepo _repository;
        private readonly IMapper _mapper;

        public EtatsController(IEtatRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/Etats
        [HttpGet]
        public ActionResult<IEnumerable<Etat>> GetAllEtats()
        {
            var EtatItems=_repository.GetAllEtats();
            return Ok(_mapper.Map<IEnumerable<Etat>>(EtatItems));
        }

        // Get Api /api/Etats/{id}
        [HttpGet("{id}",Name="GetEtatById")]       
        public ActionResult<Etat> GetEtatById(Guid id)
        {
            var EtatItem=_repository.GetEtatById(id);
            if(EtatItem!=null){
            return Ok(_mapper.Map<Etat>(EtatItem)); 
            }
            return NotFound(); 
        }

        // Create Etat /api/Etats
        [HttpPost]
        public ActionResult<Etat> CreateEtat(EtatCreateDto EtatCreateDto)
        {
            EtatCreateDto.Id = Guid.NewGuid();
            var EtatModel=_mapper.Map<Etat>(EtatCreateDto);
            EtatModel.DateCreation=DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateEtat(EtatModel);
            _repository.SaveChanges();
            var EtatReadDto=_mapper.Map<Etat>(EtatModel);
            return CreatedAtRoute(nameof(GetEtatById),new {Id=EtatReadDto.Id},EtatReadDto); 
        }
        // Update Etat /api/Etats
        [HttpPut("{id}")]
         public ActionResult<EtatReadDto> UpdateEtat([FromBody] EtatUpdateDto EtatUpdateDto,Guid id)
        {
            var EtatToUpdate=_repository.GetEtatById(id);
            if(EtatToUpdate == null)
            {
                return NotFound();
            }            
            
            var EtatModel=_mapper.Map<Etat>(EtatUpdateDto);
            EtatToUpdate.DesignationFr=EtatUpdateDto.DesignationFr;
            EtatToUpdate.DesignationAr=EtatUpdateDto.DesignationAr;
            _repository.UpdateEtat(EtatModel);
            _repository.SaveChanges();

            var EtatReadDto=_mapper.Map<EtatReadDto>(EtatModel);
            return CreatedAtRoute(nameof(GetEtatById),new {Id=EtatReadDto.Id},EtatReadDto); 
        }

        // Get Etat/api/
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