using System;
using dotnet_mongodb_zoologico.Data.Collections;
using dotnet_mongodb_zoologico.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace dotnet_mongodb_zoologico.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CobraController: ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Cobra> _cobraCollection;

        public CobraController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _cobraCollection = _mongoDB.DB.GetCollection<Cobra>(typeof(Cobra).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarCobra([FromBody] CobraDto dto)
        {
            var cobra = new Cobra(dto.nome, dto.sexo, dto.idade, dto.peso, dto.especie, dto.venenosa);
            _cobraCollection.InsertOne(cobra);
            
            return StatusCode(201, "Cobra adicionada com sucesso");
        }

        [HttpGet]
        public ActionResult ObterCobras()
        {
            var cobras = _cobraCollection.Find(Builders<Cobra>.Filter.Empty).ToList();
            return Ok(cobras);
        }


        [HttpPut]
        public ActionResult AtualizarPesoCobra([FromBody] CobraDto dto)
        {
            _cobraCollection.UpdateOne(Builders<Cobra>.Filter.Where(_ => _.nome == dto.nome), Builders<Cobra>.Update.Set("peso", dto.peso));
            
            return StatusCode(201, "Peso de " + dto.nome + " atualizado com sucesso");
        }

        [HttpDelete("{nome}")]
        public ActionResult ApagarCobra(string nome)
        {
            _cobraCollection.DeleteOne(Builders<Cobra>.Filter.Where(_ => _.nome == nome));
            
            return Ok("Cobra deletada com sucesso");
        }
        
    }

}