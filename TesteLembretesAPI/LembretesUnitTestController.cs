using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using ListaDeLembretesAPI.Context;
using ListaDeLembretesAPI.Controllers;
using ListaDeLembretesAPI.DTOs;
using ListaDeLembretesAPI.DTOs.Mappings;
using ListaDeLembretesAPI.Models;
using ListaDeLembretesAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace Testes
{
    public class LembretesUnitTestController
    {
        private IMapper mapper;
        private IUnitOfWork repository;

        public static DbContextOptions<AppDbContext> dbContextOptions { get; }

        static LembretesUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
             .UseInMemoryDatabase(databaseName: "testingDB").Options;
        }

        public LembretesUnitTestController()
        {
            var config = new MapperConfiguration(cfg =>
                {

                    cfg.AddProfile(new MappingProfile());

                });
            mapper = config.CreateMapper();

            var context = new AppDbContext(dbContextOptions);
            repository = new UnitOfWork(context);
        }

        [Fact]

        public void PostLembretes_Return_OkResult()
        {
            var Controller = new LembretesController(repository, mapper);

            var lembrete = new LembreteDTO()
            { Nome = "Lembrete Teste", Data = new DateOnly(2025, 4, 5) };

            var data = Controller.Post(lembrete);
            Assert.IsType<CreatedAtRouteResult>(data);
        }



        [Fact]

        public void GetLembretes_Return_OkResult()
        {
            var Controller = new LembretesController(repository, mapper);

            var lembreteA = new LembreteDTO()
            { Nome = "Lembrete Teste", Data = new DateOnly(2025, 4, 5) };
            var lembreteB = new LembreteDTO()
            { Nome = "Lembrete Teste2", Data = new DateOnly(2025, 4, 5) };

            Controller.Post(lembreteA);
            Controller.Post(lembreteB);

            var data = Controller.Get();
            Assert.IsType<List<Lembrete>>(data.Value);

        }


        [Fact]

        public void GetLembrete_Return_Correct_Result()
        {
            var Controller = new LembretesController(repository, mapper);

            var lembreteA = new LembreteDTO()
            { Nome = "Lembrete Teste", Data = new DateOnly(2025, 4, 5) };
            var lembreteB = new LembreteDTO()
            { Nome = "Lembrete Teste2", Data = new DateOnly(2025, 4, 5) };

            Controller.Post(lembreteA);
            Controller.Post(lembreteB);

            var data = Controller.Get(1);
            var lembrete = data.Value.Should().BeAssignableTo<Lembrete>().Subject;
            Assert.Equal(lembreteA.Nome, lembrete.Nome);
            Assert.Equal(lembreteA.Data, lembrete.Data);

        }


        public void GetLembrete_Return_NotFound()
        {
            var Controller = new LembretesController(repository, mapper);

            var data = Controller.Get(25);

            Assert.IsType<NotFoundResult>(data);

        }


        [Fact]

        public void DeleteLembretes_Return_OkResult()
        {
            var Controller = new LembretesController(repository, mapper);

            var lembrete = new LembreteDTO()
            { Nome = "Lembrete Teste", Data = new DateOnly(2025, 4, 5) };

            Controller.Post(lembrete);

            var data = Controller.Delete(1);
            Assert.IsType<OkResult>(data);

        }

        [Fact]
        public void DeleteLembretes_Return_NotFound()
        {
            var Controller = new LembretesController(repository, mapper);

            var data = Controller.Delete(999);

            Assert.IsType<NotFoundObjectResult>(data);

        }

        [Fact]

        public void GetGroupedByDate_Return_Ok()
        {

            var Controller = new LembretesController(repository, mapper);

            var lembreteA = new LembreteDTO()
            { Nome = "Lembrete Teste", Data = new DateOnly(2025, 4, 5) };
            var lembreteB = new LembreteDTO()
            { Nome = "Lembrete Teste2", Data = new DateOnly(2025, 4, 5) };
            var lembreteC = new LembreteDTO()
            { Nome = "Lembrete Teste3", Data = new DateOnly(2025, 5, 5) };

            Controller.Post(lembreteA);
            Controller.Post(lembreteB);
            Controller.Post(lembreteC);

            var data = Controller.GetGroupedByDate();

            Assert.IsType<List<List<Lembrete>>>(data.Value);

        }

        [Fact]
        public void GetGroupedByDate_Return_Corrext_Order()
        {

            var Controller = new LembretesController(repository, mapper);

            var lembreteA = new LembreteDTO()
            { Nome = "Lembrete Teste", Data = new DateOnly(2025, 6, 5) };
            var lembreteB = new LembreteDTO()
            { Nome = "Lembrete Teste2", Data = new DateOnly(2025, 4, 5) };
            var lembreteC = new LembreteDTO()
            { Nome = "Lembrete Teste3", Data = new DateOnly(2025, 5, 5) };

            Controller.Post(lembreteA);
            Controller.Post(lembreteB);
            Controller.Post(lembreteC);

            var data = Controller.GetGroupedByDate();

            var listaLembretes = data.Value.Should().BeAssignableTo<List<List<Lembrete>>>().Subject;
            Assert.Equal(lembreteB.Data, listaLembretes[0][0].Data);


        }







    }

}