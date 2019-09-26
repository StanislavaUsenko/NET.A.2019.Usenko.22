using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IRepository<T> 
    { 
        void Write(List<T> listObj);
        void AppendToEnd(T obj);
        List<T> Read();
    }
}
