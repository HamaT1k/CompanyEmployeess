using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CompanyEmployeess.Controllers
{
    [ApiVersion("2.0", Deprecated = true)]
    [Route("api/{v:apiversion}/carShops")]
    [ApiController]
    public class CarShopsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CarShopsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)

        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet, Authorize(Roles = "Manager")]
        [HttpHead]
        public IActionResult GetCarsShops()
        {
            var carShops = _repository.CarShop.GetAllCarShops(trackChanges: false);
            var carShopsdTO = _mapper.Map<IEnumerable<CarShopDto>>(carShops);
            return Ok(carShopsdTO);
        }

        [HttpOptions]
        public IActionResult GetCarShopsOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST");
            return Ok();
        }
    }
}
