using Microsoft.AspNetCore.HttpOverrides;
using CompanyEmployees.Extensions;
using NLog;
using System.Numerics;
using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;
using Microsoft.Extensions.Logging;
using LoggerService;

namespace CompanyEmployees;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
            "/nlog.config"));
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureCors();
        services.ConfigureIISIntegration();
        services.ConfigureLoggerService();
        services.ConfigureSqlContext(Configuration);
        services.ConfigureRepositoryManager();
        services.AddAutoMapper(typeof(Startup));
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.ConfigureVersioning();
        services.AddSwaggerGen();
        services.AddAuthentication();
        services.ConfigureIdentity();
        services.ConfigureJWT(Configuration);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerManager logger)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }
        app.ConfigureExceptionHandler(logger);
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCors("CorsPolicy");
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        app.UseAuthentication();
        app.UseAuthorization();
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>().ForMember(c => c.FullAddress, opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
            CreateMap<CarShop, CarShopDto>();
            CreateMap<Car, CarDto>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}