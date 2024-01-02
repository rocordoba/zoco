using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity.Entity;

namespace BLL.Interfaces
{
    public interface IUtilidadesService
    {

        string GenerarClave();

        string GenerateHash256(string texto);
        string GenerateHash(string texto);
    }
}
