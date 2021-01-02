using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using System;
using System.Threading.Tasks;
using GestionParcInformatique.Authentication;

namespace GestionParcInformatique.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepo _repository;
        private readonly IMapper _mapper;

        public ServicesController(IServiceRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/Services
        [HttpGet]
        public ActionResult<IEnumerable<Service>> GetAllServices()
        {
            var ServiceItems=_repository.GetAllServices();
            return Ok(_mapper.Map<IEnumerable<Service>>(ServiceItems));
        }

        // Get Api /api/Services/{id}
        [HttpGet("{id}",Name="GetServiceById")]       
        public ActionResult <Service> GetServiceById(Guid id)
        {
            var ServiceItem=_repository.GetServiceById(id);
            if(ServiceItem!=null){
            return Ok(_mapper.Map<Service>(ServiceItem));
            }
            return NotFound(); 
        }

        //Create Service /api/Services
        [HttpPost]
        public ActionResult<Service> CreateService(Service Service)
        {

                Service.Id = Guid.NewGuid();
            Service.DateCreation= DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateService(Service);
            _repository.SaveChanges();
            
            return CreatedAtRoute(nameof(GetServiceById),new {Id=Service.Id},Service); 
        }
        //Delete Service /api/Services
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