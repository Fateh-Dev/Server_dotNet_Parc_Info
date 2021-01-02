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
    public class PersonnesController : ControllerBase
    {
        private readonly IPersonneRepo _repository;
        private readonly IMapper _mapper;

        public PersonnesController(IPersonneRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/Personnes
        [HttpGet]
        public ActionResult<IEnumerable<Personne>> GetAllPersonnes()
        {
            var PersonneItems=_repository.GetAllPersonnes();
            return Ok(_mapper.Map<IEnumerable<Personne>>(PersonneItems));
        }

        // Get Api /api/Personnes/{id}
        [HttpGet("{id}",Name="GetPersonneById")]       
        public ActionResult <Personne> GetPersonneById(Guid id)
        {
            var PersonneItem=_repository.GetPersonneById(id);
            if(PersonneItem!=null){
            return Ok(_mapper.Map<Personne>(PersonneItem));
            }
            return NotFound(); 
        }

        //Create Personne /api/Personnes
        [HttpPost]
        public ActionResult<Personne> CreatePersonne(Personne Personne)
        {
            
                Personne.Id = Guid.NewGuid();
            Personne.DateCreation= DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreatePersonne(Personne);
            _repository.SaveChanges();
            
            return CreatedAtRoute(nameof(GetPersonneById),new {Id=Personne.Id},Personne); 
        }
        //Delete Personne /api/Personnes
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