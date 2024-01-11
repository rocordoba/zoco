using BLL.InterfacesZoco;
using DAL.Interfaces;
using Entity.Zoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ImplementacionZoco
{
    public class TokenService : ITokenService
    {
        private readonly IGenericRepository<Token> _repoToken;
        private readonly IGenericRepository<Usuarios> _repoUsuario;

        public TokenService(IGenericRepository<Token> token,IGenericRepository<Usuarios> repoUsuarios)
        {
            _repoToken = token;
            _repoUsuario = repoUsuarios;
        }
        public async Task<bool> EliminarTokenAsync(int usuarioId)
        {
            var token = await _repoToken.Obtener(t => t.UsuarioId == usuarioId);
            if (token != null)
            {
                return await _repoToken.Eliminar(token);
            }

            return false;
        }

        public async Task<Token> GenerarActualizarTokenAsync(int usuarioId, string nuevoToken, DateTime fechaCreacion, DateTime fechaExpiracion)
        {
            var tokenActual = await _repoToken.Obtener(t => t.UsuarioId == usuarioId);

            if (tokenActual != null)
            {
                if ( tokenActual.Token1 != nuevoToken)
                {
                    // Token existente está vencido o es diferente, actualizarlo
                    tokenActual.Token1 = nuevoToken;
                    tokenActual.FechaCreacion = fechaCreacion;
                    tokenActual.FechaExpiracion = fechaExpiracion;
                    await _repoToken.Editar(tokenActual);
                }
                else if(tokenActual.FechaExpiracion < DateTime.UtcNow)
                {
                    tokenActual.Token1 = nuevoToken;
                    tokenActual.FechaCreacion = fechaCreacion;
                    tokenActual.FechaExpiracion = fechaExpiracion;
                    await _repoToken.Editar(tokenActual);
                }
            }
            else
            {
                // No hay token existente, crear uno nuevo
                tokenActual = new Token
                {
                    UsuarioId = usuarioId,
                    Token1 = nuevoToken,
                    FechaCreacion = fechaCreacion,
                    FechaExpiracion = fechaExpiracion
                };
                await _repoToken.Crear(tokenActual);
            }

            return tokenActual;
        }


        //public async Task<Token> GenerarTokenAsync(int usuarioId)
        //{ eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIzMzMzMzMzMzMzMyIsIm5iZiI6MTcwNDk4NDI5OCwiZ
        //  XhwIjoxNzA0OTg0MzU4LCJpYXQiOjE3MDQ5ODQyOTh9.q-jsDdk-oKfZ2VYucxWP1q91wOPnS65PXo0OnHOE4g0

        //    var usuario = await _repoUsuario.Obtener(u => u.Id == usuarioId);
        //    if (usuario == null)
        //    {
        //        // Usuario no encontrado
        //        return null;
        //    }

        //    var nuevoToken = GenerarTokenSeguro(); // Implementa esta función para generar el token
        //    var token = new Token
        //    {
        //        UsuarioId = usuarioId,
        //        Token1 = nuevoToken,
        //        FechaCreacion = DateTime.UtcNow,
        //        FechaExpiracion = DateTime.UtcNow.AddHours(1)
        //    };

        //    await _repoToken.Crear(token);
        //    return token;
        //}


        public async Task<Token> ObtenerTokenPorUsuarioIdAsync(int usuarioId)
        {
            return await _repoToken.Obtener(t => t.UsuarioId == usuarioId);
        }


        public async Task<bool> ValidarTokenAsync(string token)
        {
            var tokenEncontrado = await _repoToken.Obtener(t => t.Token1 == token);
            if (tokenEncontrado == null || tokenEncontrado.FechaExpiracion < DateTime.UtcNow)
            {
                // Token no válido o expirado
                return false;
            }

            return true;
        }

    }
}
