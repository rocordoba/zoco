﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity.Entity;

namespace BLL.Interfaces
{
    public interface ILocalidadService
    {
        Task<List<Localidad>> Lista();
        Task<Localidad> Crear(Localidad entidad);
        Task<Localidad> Editar(Localidad entidad);
        Task<bool> Eliminar(int IdLocalidad);
    }
}