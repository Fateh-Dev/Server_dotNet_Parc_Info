using AutoMapper;
using GestionParcInformatique.Dtos.Magasin;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Profiles
{
    public class MagasinsProfile : Profile
    {
        public MagasinsProfile()
        {
            //Source --> Dest
            CreateMap<Magasin, MagasinReadDto>();
            CreateMap<MagasinCreateDto, Magasin>();
            CreateMap<MagasinUpdateDto, Magasin>();
        }
    }
}