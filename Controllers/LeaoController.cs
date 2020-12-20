using System;
using dotnet_mongodb_zoologico.Data.Collections;
using dotnet_mongodb_zoologico.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace dotnet_mongodb_zoologico.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LeaoController: ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Leao> _leaoCollection;

        public LeaoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _leaoCollection = _mongoDB.DB.GetCollection<Leao>(typeof(Leao).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] LeaoDto dto)
        {
            var leao = new Leao(dto.nome, dto.sexo, dto.idade, dto.peso, dto.pelagem);

            _leaoCollection.InsertOne(leao);
            
            return StatusCode(201, "Leao adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var leoes = _leaoCollection.Find(Builders<Leao>.Filter.Empty).ToList();
            
            return Ok(leoes);
        }


        // [HttpPut]
        // public ActionResult AtualizarInfectado([FromBody] LeaoDto dto)
        // {
        //     _leaoCollection.UpdateOne(Builders<Leao>.Filter.Where(_ => _.DataNascimento == dto.DataNascimento), Builders<Leao>.Update.Set("sexo", dto.Sexo));
            
        //     return StatusCode(201, "Infectado atualizado com sucesso");
        // }

        // [HttpDelete("{dataNasc}")]
        // public ActionResult ApagarInfectado(DateTime dataNasc)
        // {
        //     _leaoCollection.DeleteOne(Builders<Leao>.Filter.Where(_ => _.DataNascimento == dataNasc));
            
        //     return Ok("Deletado com sucesso");
        // }
        
    }

}