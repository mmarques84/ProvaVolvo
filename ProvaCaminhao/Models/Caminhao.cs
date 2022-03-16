using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaCaminhao.Models
{
    public class Caminhao
    {
        public int ID { set; get; }
        public string descricao { set; get; }
        public bool ativo { set; get; }
       // public int IdModelo { set; get; }
        public  Modelo modelo { set; get; }
    }
}
