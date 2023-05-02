using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    /// <summary>
    /// Represents a mapping profile for AutoMapper that defines mappings between entity and DTO types.
    /// </summary>
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of the MappingProfiles class and defines the entity-to-DTO mappings.
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
        }
    }

}
