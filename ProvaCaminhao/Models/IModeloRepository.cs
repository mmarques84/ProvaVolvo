using ProvaCaminhao.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaCaminhao.Models
{
    public interface IModeloRepository 
    {
        Task<IEnumerable<Modelo>> ObterTodos();
        Task<Modelo> ObterPorId(int id);

        void Adicionar(Modelo modelo);
        void Atualizar(Modelo modelo);
        void SalvarTodos();
    }
}
