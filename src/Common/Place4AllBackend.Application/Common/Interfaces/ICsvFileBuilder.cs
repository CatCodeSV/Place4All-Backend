using System.Collections.Generic;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildDistrictsFile(IEnumerable<DistrictDto> districts);
    }
}