using System.Threading.Tasks;
using AutoMapper;
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

        public void PostLembretes_Retunr_OkResult()
        {
            var Controller = new LembretesController(repository, mapper);

            var lembrete = new LembreteDTO()
            { Nome = "Lembrete Teste", Data = new DateOnly(2022, 4, 5) };

            var data = Controller.Post(lembrete);
            Assert.IsType<CreatedAtRouteResult>(data);
        }

        [Fact]

        public void GetLembretes_Return_OkResult()
        {
            var Controller = new LembretesController(repository, mapper);

            var data = Controller.Get();
            Assert.IsType<List<Lembrete>>(data.Value);

        }





    }

}