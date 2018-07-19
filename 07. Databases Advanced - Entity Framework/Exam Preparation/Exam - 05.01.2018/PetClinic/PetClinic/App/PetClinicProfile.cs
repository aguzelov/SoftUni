namespace PetClinic.App
{
    using AutoMapper;
    using PetClinic.App.Models;
    using PetClinic.Models;

    public class PetClinicProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public PetClinicProfile()
        {
            CreateMap<AnimalAidDto, AnimalAid>();
            CreateMap<AnimalPassportDto, Passport>();
            CreateMap<AnimalDto, Animal>();
            CreateMap<ProcedureAnimalAidDto, AnimalAid>();
            CreateMap<ProcedureDto, Procedure>();
            CreateMap<VetDto, Vet>();
        }
    }
}