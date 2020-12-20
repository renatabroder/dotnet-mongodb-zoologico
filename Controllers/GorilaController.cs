using System;
using dotnet_mongodb_zoologico.Data.Collections;
using dotnet_mongodb_zoologico.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace dotnet_mongodb_zoologico.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GorilaController: ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Gorila> _gorilaCollection;

        public GorilaController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _gorilaCollection = _mongoDB.DB.GetCollection<Gorila>(typeof(Gorila).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] GorilaDto dto)
        {
            var gorila = new Gorila(dto.nome, dto.sexo, dto.idade, dto.peso);

            _gorilaCollection.InsertOne(gorila);
            
            return StatusCode(201, "Gorila adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var gorilas = _gorilaCollection.Find(Builders<Gorila>.Filter.Empty).ToList();
            
            return Ok(gorilas);
        }


        // [HttpPut]
        // public ActionResult AtualizarInfectado([FromBody] GorilaDto dto)
        // {
        //     _gorilaCollection.UpdateOne(Builders<Gorila>.Filter.Where(_ => _.DataNascimento == dto.DataNascimento), Builders<Gorila>.Update.Set("sexo", dto.Sexo));
            
        //     return StatusCode(201, "Infectado atualizado com sucesso");
        // }

        // [HttpDelete("{dataNasc}")]
        // public ActionResult ApagarInfectado(DateTime dataNasc)
        // {
        //     _gorilaCollection.DeleteOne(Builders<Gorila>.Filter.Where(_ => _.DataNascimento == dataNasc));
            
        //     return Ok("Deletado com sucesso");
        // }
        
    }

}