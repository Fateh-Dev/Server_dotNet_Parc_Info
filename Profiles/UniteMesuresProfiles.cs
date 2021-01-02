using AutoMapper;
using GestionParcInformatique.Dtos.UniteMesure;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Profiles
{
    public class UniteMesuresProfile : Profile
    {
        public UniteMesuresProfile()
        {
            //Source --> Dest
            CreateMap<UniteMesure, UniteMesureReadDto>();
            CreateMap<UniteMesureCreateDto, UniteMesure>();
            CreateMap<UniteMesureUpdateDto, UniteMesure>();
        }
    }
}