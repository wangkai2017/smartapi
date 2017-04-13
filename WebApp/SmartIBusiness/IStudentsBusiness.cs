using SmartEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIBusiness
{
    public interface IStudentsBusiness
    {
        List<T_Students> GetStudentList();
    }
}
