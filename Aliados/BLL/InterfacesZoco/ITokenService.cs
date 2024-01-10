﻿using Entity.Zoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterfacesZoco
{
    public interface ITokenService
    {
        Task<Token> GenerarTokenAsync(int usuarioId);
        Task<Token> ObtenerTokenPorUsuarioIdAsync(int usuarioId);
        Task<bool> ValidarTokenAsync(string token);
        Task<bool> EliminarTokenAsync(int usuarioId);
    }
}
