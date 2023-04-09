using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Infrastructure.Files.Maps;
using CsvHelper;

namespace Place4AllBackend.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildDistrictsFile(IEnumerable<DistrictDto> cities)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Context.RegisterClassMap<DistrictMap>();
                csvWriter.WriteRecords(cities);
            }

            return memoryStream.ToArray();
        }
    }
}