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
        public ActionResult AdicionarLeao([FromBody] LeaoDto dto)
        {
            if(dto.nome.ToLower()[0] != 'j') return StatusCode(400, "Nome não permitido");

            var leao = new Leao(dto.nome, dto.sexo, dto.idade, dto.peso, dto.pelagem);
            _leaoCollection.InsertOne(leao);
            
            return StatusCode(201, "Leão adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterLeoes()
        {
            var leoes = _leaoCollection.Find(Builders<Leao>.Filter.Empty).ToList();
            
            return Ok(leoes);
        }

        [HttpPut]
        public ActionResult AtualizarPesoLeao([FromBody] LeaoDto dto)
        {
            _leaoCollection.UpdateOne(Builders<Leao>.Filter.Where(_ => _.nome == dto.nome), Builders<Leao>.Update.Set("peso", dto.peso));
            
            return StatusCode(201, "Peso de " + dto.nome + " atualizado com sucesso");
        }

        [HttpDelete]
        public ActionResult ApagarLeao([FromBody] LeaoDto dto)
        {
            _leaoCollection.DeleteOne(Builders<Leao>.Filter.Where(_ => _.nome == dto.nome));
            
            return Ok("Leão deletado com sucesso");
        }
        
    }

}