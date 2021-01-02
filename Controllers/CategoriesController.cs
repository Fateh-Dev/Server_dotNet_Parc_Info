
using Microsoft.AspNetCore.Mvc;
using GestionParcInformatique.Models;
using System.Collections.Generic;
using GestionParcInformatique.Data;
using AutoMapper;
using GestionParcInformatique.Dtos.Categorie;
using System;
using System.Threading.Tasks;
using GestionParcInformatique.Authentication;
 
namespace GestionParcInformatique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategorieRepo _repository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategorieRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // Get Api /api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<CategorieReadDto>> GetAllCategories()
        {
            var CategorieItems=_repository.GetAllCategories();
            return Ok(_mapper.Map<IEnumerable<CategorieReadDto>>(CategorieItems));
        }

        // Get Api /api/Categories/{id}
        [HttpGet("{id}",Name="GetCategorieById")]       
        public ActionResult <CategorieReadDto> GetCategorieById(Guid id)
        {
            var CategorieItem=_repository.GetCategorieById(id);
            if(CategorieItem!=null){
            return Ok(_mapper.Map<CategorieReadDto>(CategorieItem));
            }
            return NotFound(); 
        }

        //Create Categorie /api/Categories
        [HttpPost]
        public ActionResult<CategorieReadDto> CreateCategorie(CategorieCreateDto CategorieCreateDto)
        {
            CategorieCreateDto.Id = Guid.NewGuid();
            var CategorieModel=_mapper.Map<Categorie>(CategorieCreateDto);
            CategorieModel.DateCreation=DateTime.Now;
            //TODO Add AutoIncrement To NumOrdre
            //TODO Add Owner ID 
            _repository.CreateCategorie(CategorieModel);
            _repository.SaveChanges();
            var CategorieReadDto=_mapper.Map<CategorieReadDto>(CategorieModel);
            
            return CreatedAtRoute(nameof(GetCategorieById),new {Id=CategorieReadDto.Id},CategorieReadDto); 
        }

        [HttpPut("{id}")]
         public ActionResult<CategorieReadDto> UpdateCategorie([FromBody] CategorieUpdateDto categorieUpdateDto,Guid id)
        {
            var categorieToUpdate=_repository.GetCategorieById(id);
            if(categorieToUpdate == null)
            {
                return NotFound();
            }            
            
            var categorieModel=_mapper.Map<Categorie>(categorieUpdateDto);

            categorieToUpdate.DesignationFr=categorieUpdateDto.DesignationFr;
            categorieToUpdate.DesignationAr=categorieUpdateDto.DesignationAr;

            
            _repository.UpdateCategorie(categorieModel);
            _repository.SaveChanges();

            var categorieReadDto=_mapper.Map<CategorieReadDto>(categorieModel);
            return CreatedAtRoute(nameof(GetCategorieById),new {Id=categorieReadDto.Id},categorieReadDto); 
        }
        
        //Delete Categorie /api/Categories
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