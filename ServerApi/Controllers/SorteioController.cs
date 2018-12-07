using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerApi.Model;

namespace ServerApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SorteioController : ControllerBase
    {       

        [HttpGet("RealizarSorteio")]
        public ActionResult<Resultado> RealizarSorteio(string json)
        {
            List<Jogo> jogos = JsonConvert.DeserializeObject<List<Jogo>>(json);
            List<int> listSorteados = new List<int>();
            Resultado winners = new Resultado();
            Random rnd = new Random();
            int number;

            while (listSorteados.Count < 6)
            {
                number = rnd.Next(1, 60);
                if (!listSorteados.Contains(number))
                    listSorteados.Add(number);
            }

            winners.NumerosSorteados = listSorteados;
            winners.NumerosSorteados.Sort();

            foreach (Jogo jogo in jogos)
            {
                foreach (int numero in jogo.Numeros)
                {
                    if (listSorteados.Contains(numero))
                        jogo.Acertos++;
                }
                jogo.Numeros.Sort();

                if (jogo.Acertos == 4)
                {                    
                    winners.Quadra.Add(jogo.Id);
                }
                else if (jogo.Acertos == 5)
                {
                    winners.Quina.Add(jogo.Id);
                }
                else if (jogo.Acertos == 6)
                {
                    winners.Sena.Add(jogo.Id);
                }
            }
            return winners;
        }

        [HttpGet("Test")]
        public ActionResult<List<Jogo>> Test(string id)
        {
            List<Jogo> list = JsonConvert.DeserializeObject<List<Jogo>>(id);
            return list;
        }

        [HttpPost, Route("TestPost")]
        public ActionResult TestPost([FromBody]string id)
        {


            return null;
        }
    }
}