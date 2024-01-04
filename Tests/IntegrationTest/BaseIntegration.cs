using AutoMapper;
using CrossCutting.Mappings;
using Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;

namespace Tests.IntegrationTest
{
    public class BaseIntegration
    {
        public MyContext myContext{get; private set;}
        public HttpClient client  {get; private set;}
        public IMapper mapper { get; set; } 
        public string hostApi { get; set; }
        public HttpResponseMessage response { get; set; }

        public BaseIntegration()
        {
            hostApi = "https://localhost:7123/api/";
            var builder = new WebHostBuilder().UseEnvironment("Testing").UseStartup<Program>();
            
            var webAppFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Test");
            });

            myContext = webAppFactory.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();

            mapper = new AutoMapperFix().GetMapper();
            client = webAppFactory.CreateDefaultClient();
        }

        public static async Task<HttpResponseMessage>PostAsync(object data, string url, HttpClient client) 
        {
            return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            myContext.Dispose();
            client.Dispose();
        }
    }

    public class AutoMapperFix : IDisposable
    {
        public IMapper GetMapper()
        {
            var config =  new MapperConfiguration(c => 
            {
                    c.AddProfile(new DtoToModelProfile());
                    c.AddProfile(new EntityToDtoProfile());
                    c.AddProfile(new ModelToEntityProfile());
            });

            return config.CreateMapper();
        }
       
        public void Dispose()
        {   
        }
        
    }
}