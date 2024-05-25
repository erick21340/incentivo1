using Microsoft.EntityFrameworkCore;
using registrotecnico.DAL;
using registrotecnico.Models;
using System.Linq.Expressions;

namespace registrotecnico.Service
{
    public class tecnicoServices
    {
        private readonly Contexto _contexto;
        public tecnicoServices(Contexto contexto)
        {
            _contexto = contexto;
        }


        public async Task<bool> Existe(int tecnicosid)
        {
            return await _contexto.tecnicos!.AnyAsync(t => t.TecnicosId == tecnicosid);
        }

        private async Task<bool> Insertar(Tecnicos tecnicos)
        {
            _contexto.Add(tecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Tecnicos tecnicos)
        {
            _contexto.Update(tecnicos);
            var guardado = await _contexto.SaveChangesAsync() > 0;
            _contexto.tecnicos!.Entry(tecnicos).State = EntityState.Detached;
            return guardado;
        }

        public async Task<bool> Eliminar(Tecnicos tecnicos)
        {
            var cantidad = await _contexto.tecnicos
                .Where(c => c.TecnicosId == tecnicos.TecnicosId)
                .ExecuteDeleteAsync();
            return cantidad > 0;
        }



        public async Task<Tecnicos?> Buscar(int tecnicoID)
        {
            return await _contexto.tecnicos!.AsNoTracking().FirstOrDefaultAsync(t => t.TecnicosId == tecnicoID);
        }

        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            return await _contexto.tecnicos!.AsNoTracking().Where(criterio).ToListAsync();
        }

        public async Task<bool> Guardar(Tecnicos tecnicos)
        {
            if (!await Existe(tecnicos.TecnicosId))
            {
                return await Insertar(tecnicos);
            }
            else
            {
                return await Modificar(tecnicos);
            }
        }
    }
}
