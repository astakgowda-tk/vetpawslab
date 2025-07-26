using Aspire.Vetpaws.Lab.Models;
using Aspire.Vetpaws.Lab.Models.Bill;
using Aspire.Vetpaws.Lab.Models.Login;
using AutoMapper;

namespace Aspire.Vetpaws.Lab.AutoMapping
{
    public static class AutoMapperConfig
    {
        public static IMapperConfigurationExpression InitializeMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<LoginUserModel, LoginUser>();
            config.CreateMap<BillItemPriceModel, ItemPrice>();
            
            config.CreateMap<EntryBillModel, BillEntry>();
            config.CreateMap<BillItemModel, BillEntryItem>();

            return config;
        }
    }
}