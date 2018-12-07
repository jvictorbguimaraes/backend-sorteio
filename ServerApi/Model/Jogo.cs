using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApi.Model
{
    public class Jogo
    {
        public int Id { get; set; }
        public List<int> Numeros { get; set; }
        public DateTime Data { get; set; }
        public int Acertos { get; set; }
    }

    public class Resultado
    {
        public List<int> Quadra { get; set; }
        public List<int> Quina { get; set; }
        public List<int> Sena { get; set; }
        public List<int> NumerosSorteados { get; set; }

        public Resultado()
        {
            Quadra = new List<int>();
            Quina = new List<int>();
            Sena = new List<int>();
        }
    }

    public class Ganhadores
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
    }
}
