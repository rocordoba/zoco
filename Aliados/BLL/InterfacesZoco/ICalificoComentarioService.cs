﻿using Entity.Zoco;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterfacesZoco
{
    public interface ICalificoComentarioService
    {
        Task<CalificoCom> Crear(CalificoCom entidad);
    }
}