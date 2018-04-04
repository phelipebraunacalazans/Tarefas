using AutoMapper;

namespace Tarefas.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile<DomainToViewModelMappingProfile>();
                ps.AddProfile<ViewModelToDomainMappingProfile>();
            });


            //Mapper.Initialize(x =>
            //{
            //    x.AddProfile<DomainToViewModelMappingProfile>();
            //    x.AddProfile<ViewModelToDomainMappingProfile>();
            //});

        }
    }
}
