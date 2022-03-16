using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaCaminhao.Models
{
    public interface ICaminhaoRepository
    {
        Task<IEnumerable<Caminhao>> ObterTodos();
        Task<Caminhao> ObterPorId(int id);

        void Adicionar(Caminhao caminhao);
        void Atualizar(Caminhao caminhao);
        void SalvarTodos();
    }
}
