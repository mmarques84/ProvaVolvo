
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProvaCaminhao.Controllers.APIs;
using ProvaCaminhao.Data;
using ProvaCaminhao.Data.Repository;
using ProvaCaminhao.Models;
using System.Collections.Generic;


namespace TestProject
{

    [TestClass]

        public class Tests
        {
            IModeloRepository _repository;
            ApiDbContext _context;

        [TestInitialize]
            public void Initialize()
            {
            var options = new DbContextOptionsBuilder<ApiDbContext>()
                 .UseInMemoryDatabase(databaseName: "DefaultConnection")
                 .Options;

            var context = new ApiDbContext(options);
            var modelo = new List<Modelo>();
            //carSamples.Add(new Car() { Name = "Fiesta", Model = "Fiesta SE", YearOfManufacture = 2015 });
            //carSamples.Add(new Car() { Name = "Golf", Model = "Golf Sport", YearOfManufacture = 2015 });
            //carSamples.Add(new Car() { Name = "Civic", Model = "Civic S", YearOfManufacture = 2016 });

            _repository = new ModeloRepository(context);
        }

            [TestMethod]
            public void ShouldGetAllCars()
            {
                var controller = new ModelosController(_context,_repository);
                //controller.Request = new HttpRequestMessage();
               // controller.Configuration = new HttpConfiguration();

                var result = controller.GetModelo();

                IEnumerable<Modelo> modelos;

               // Assert.IsTrue(result.TryGetContentValue<IEnumerable<Modelo>>(out modelos));
                //Assert.IsNotNull(modelos);
                //Assert.AreEqual(3, modelos.Count());
            }



        }
}