using AutoMapper;
using SCMDWH.Shared.DTO;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Automapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CarAdviceMainTable, CarAdviceLogExtended>();
            CreateMap<CarAdviceGrTruckItems, GrTruckItemsDTO>()
                .ForMember(d => d.EtdForDisplay, o => o.MapFrom(s => s.Truck.ETD));
                

           
        }

    }
}
