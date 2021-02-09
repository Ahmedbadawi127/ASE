using AutoMapper;

namespace eServices.Shared
{
    public interface IMapFrom<T>
    {   
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
    public interface IMappableTo<T>
    {
        void Mapping(Profile profile) => profile.CreateMap( GetType(), typeof(T));
    }

    
}
