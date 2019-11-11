using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace tictactoerest.Controllers
{
    public class GameController : ApiController
    {
        static Core.TicTacToe game= new Core.TicTacToe();

        // GET: api/Game
        public char[][] Get()
        {
            return game.GetState();
        }
        

        public string Post([FromBody]Models.PlayerMove data)
        {
            string result = game.Move(data.id,data.row, data.col);
            if (result.Equals("Game is Over") || result.StartsWith("Winner")  || result.Equals("Tie"))
                 game = new Core.TicTacToe();
            
            return result;
        }

    }
}
