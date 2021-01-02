using AutoMapper;
using GestionParcInformatique.Dtos.TypeDocument;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Profiles
{
    public class TypeDocumentsProfile : Profile
    {
        public TypeDocumentsProfile()
        {
            //Source --> Dest
            CreateMap<TypeDocument, TypeDocumentReadDto>();
            CreateMap<TypeDocumentCreateDto, TypeDocument>();
            CreateMap<TypeDocumentUpdateDto, TypeDocument>();
        }
    }
}