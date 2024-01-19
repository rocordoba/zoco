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
    public class TasaInteresService : ITasaInteresService
    {
        private readonly IGenericRepository<TasaIntere> _repotasainteres;
        

        public TasaInteresService(IGenericRepository<TasaIntere> tasainteres)
        {
                _repotasainteres = tasainteres;
        }
        public async Task<List<TasaIntere>> Lista()
        {
            IQueryable<TasaIntere> query = await _repotasainteres.Consultar();
            return query.ToList();
        }
    }
}
