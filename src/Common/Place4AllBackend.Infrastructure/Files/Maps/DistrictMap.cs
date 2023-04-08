using System.Globalization;
using Place4AllBackend.Application.Dto;
using CsvHelper.Configuration;

namespace Place4AllBackend.Infrastructure.Files.Maps
{
    public sealed class DistrictMap : ClassMap<DistrictDto>
    {
        public DistrictMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Villages).Convert(_ => "");
        }
    }
}