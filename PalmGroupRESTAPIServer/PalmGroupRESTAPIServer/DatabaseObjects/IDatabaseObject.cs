using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmGroupRESTAPIServer.DatabaseObjects
{
    public interface IDatabaseObject 
    {
        int Id { get; set; }
        bool IsDeleted { get; set; } 
    }
}
