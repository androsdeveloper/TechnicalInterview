using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobal.Interview.Interfaces
{
    public interface IBlEmployees
    {
        List<DtoEmployees> GetEmployees(int? id);
    }
}
