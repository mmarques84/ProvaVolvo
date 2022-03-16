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
    public class CaminhaoTest
    {
        ICaminhaoRepository _repository;
        ApiDbContext _context;
        [SetUp]
        public void Setup()
        {
           
            var options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseSqlServer("Server=DESKTOP-LV90RO3\\SQLEXPRESS;Database=Caminhao;Integrated Security=SSPI;")
                .Options;
           

            _context = new ApiDbContext(options);
            _repository = new CaminhaoRepository(_context);
        }

        [Test]

        public async Task GetCaminhao()
        {
            var controller = new CaminhaoController(_context, _repository);
            //Act
            var result =await controller.GetCaminhao();
            foreach (var item in result.Value)
            {
                Console.WriteLine("Caminhao"+item.descricao);
            }
         
            Assert.IsNotNull(result);
            Modelo mod = result.Value as Modelo;

            Assert.Pass();
        }
        [Test]
        [TestCase(1)]       
        public async Task GetCaminhaoID(int ID)
        {
            var controller = new CaminhaoController(_context, _repository);
            //Act
            var result = await controller.GetCaminhao(ID);  
            
            if (result.Value != null)
            {
                Console.WriteLine("Caminhao" + result.Value.descricao);   
            }
            else
            {
                Console.WriteLine("Caminhao não existe");

            }

            
        }
        [Test]
        [TestCase(1)] 
        public async Task PutCaminhao(int ID)
        {
            Caminhao newcaminhao = new Caminhao
            {
                ID= ID,   
                descricao= "Volvo VM 480 4x2 2p (diesel) (E5) NEW",
                ativo=true

            };
            var controller = new CaminhaoController(_context, _repository);
            //Act
            var result = await controller.PutCaminhao(ID, newcaminhao);

            if (result != null)
            {
                Console.WriteLine("Caminhao" + result);
                // Assert.Pass();
            }
            else
            {
                Console.WriteLine("Caminhao não existe");
            }


        }

        [Test]   
        public async Task PostModelo()
        {
         
            Caminhao newcaminhao = new Caminhao
            {
                descricao = "Volvo VM 480 4x2 2p (diesel) (E5)",
                ativo = true,
             

            };
            var controller = new CaminhaoController(_context, _repository);
            //Act
            var result = await controller.PostCaminhao(newcaminhao);

            if (result != null)
            {
                Console.WriteLine("Caminhao" + result);     
            }
            else
            {
                Console.WriteLine("Caminhao não existe");
            }


        }
        [Test]
        [TestCase(3)]
        public async Task DeleteCaminhao(int ID)
        {
            
            var controller = new CaminhaoController(_context, _repository);
            //Act
            var result = await controller.DeleteCaminhao(ID);
            var statusCodeResult = (IStatusCodeActionResult)result;
            if (statusCodeResult.StatusCode == 200)
            {
                Console.WriteLine("Caminhao deletado" + result);
                // Assert.Pass();
            }
            else
            {
                Console.WriteLine("Caminhao não existe");
            }


        }
    }
}