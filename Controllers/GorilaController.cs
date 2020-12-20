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
        public ActionResult AdicionarGorila([FromBody] GorilaDto dto)
        {
            if(dto.nome.ToLower()[0] != 'j') return StatusCode(400, "Nome não permitido");

            var gorila = new Gorila(dto.nome, dto.sexo, dto.idade, dto.peso);
            _gorilaCollection.InsertOne(gorila);
            
            return StatusCode(201, "Gorila adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterGorilas()
        {
            var gorilas = _gorilaCollection.Find(Builders<Gorila>.Filter.Empty).ToList();
            
            return Ok(gorilas);
        }

        [HttpPut]
        public ActionResult AtualizarPesoGorila([FromBody] GorilaDto dto)
        {
            _gorilaCollection.UpdateOne(Builders<Gorila>.Filter.Where(_ => _.nome == dto.nome), Builders<Gorila>.Update.Set("peso", dto.peso));
            
            return StatusCode(201, "Peso de " + dto.nome + " atualizado com sucesso");
        }

        [HttpDelete]
        public ActionResult ApagarGorila([FromBody] GorilaDto dto)
        {
            _gorilaCollection.DeleteOne(Builders<Gorila>.Filter.Where(_ => _.nome == dto.nome));
            
            return Ok("Gorila deletada com sucesso");
        }
        
    }

}