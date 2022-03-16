using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework;
using ProvaCaminhao.Controllers.APIs;
using ProvaCaminhao.Data;
using ProvaCaminhao.Data.Repository;
using ProvaCaminhao.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ModeloTest
    {
        IModeloRepository _repository;
        ApiDbContext _context;
        [SetUp]
        public void Setup()
        {
           
            var options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseSqlServer("Server=DESKTOP-LV90RO3\\SQLEXPRESS;Database=Caminhao;Integrated Security=SSPI;")
                .Options;
           

            _context = new ApiDbContext(options);
            _repository = new ModeloRepository(_context);
        }

        [Test]

        public async Task GetModelos()
        {
            var controller = new ModelosController(_context, _repository);
            //Act
            var result =await controller.GetModelo();
            foreach (var item in result.Value)
            {
                Console.WriteLine("modelos"+item.descricao);
            }
            //  var modelos = JsonConvert.DeserializeObject<Modelo>(result.Value).descricao.ToString;
           
            //Assert.AreEqual(person.descricao, "Bob");
            //Assert.AreEqual(person.anoModelo, 30);
            //Assert
            Assert.IsNotNull(result);
            Modelo mod = result.Value as Modelo;

            Assert.Pass();
        }
        [Test]
        [TestCase(1)]
        [TestCase(4)]
        public async Task GetModelosID(int ID)
        {
            var controller = new ModelosController(_context, _repository);
            //Act
            var result = await controller.GetModelo(ID);  
            
            if (result.Value != null)
            {
                Console.WriteLine("modelos" + result.Value.descricao);
               // Assert.Pass();
            }
            else
            {
                Console.WriteLine("modelos não existe");
                //Assert.IsTrue(true,"teste",result.Value != null);
            }

            
        }
        [Test]
        [TestCase(1)] 
        public async Task PutModelos(int ID)
        {
            Modelo newmodelo = new Modelo {
                ID= ID,
                anoFabricacao = "2018",
                anoModelo="2018",
                descricao= "Volvo FH 400 teste"

            };
            var controller = new ModelosController(_context, _repository);
            //Act
            var result = await controller.PutModelo(ID, newmodelo);

            if (result != null)
            {
                Console.WriteLine("modelos" + result);
                // Assert.Pass();
            }
            else
            {
                Console.WriteLine("modelos não existe");
                //Assert.IsTrue(true,"teste",result.Value != null);
            }


        }

        [Test]   
        public async Task PostModelo()
        {
            Modelo newmodelo = new Modelo
            {               
                anoFabricacao = "2019",
                anoModelo = "2019",
                descricao = "Volvo FH 370"

            };
            var controller = new ModelosController(_context, _repository);
            //Act
            var result = await controller.PostModelo(newmodelo);

            if (result != null)
            {
                Console.WriteLine("modelos" + result);
                // Assert.Pass();
            }
            else
            {
                Console.WriteLine("modelos não existe");
                //Assert.IsTrue(true,"teste",result.Value != null);
            }


        }
        [Test]
        [TestCase(5)]
        public async Task DeleteModelo(int ID)
        {
            
            var controller = new ModelosController(_context, _repository);
            //Act
            var result = await controller.DeleteModelo(ID);
            var statusCodeResult = (IStatusCodeActionResult)result;
            if (statusCodeResult.StatusCode == 200)
            {
                Console.WriteLine("modelos deletado" + result);
                // Assert.Pass();
            }
            else
            {
                Console.WriteLine("modelos não existe");
                //Assert.IsTrue(true,"teste",result.Value != null);
            }


        }
    }
}