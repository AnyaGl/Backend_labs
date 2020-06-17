using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ITypeService
    {
        List<TypeDTO> GetTypes();
    }
}
