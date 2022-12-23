using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [Route("api/CarShops")]
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
        [HttpGet]
        public IActionResult GetCarsShops()
        {
            var carShops = _repository.CarShop.GetAllCarShops(trackChanges: false);
            var carShopsdTO = _mapper.Map<IEnumerable<CarShopDto>>(carShops);
            return Ok(carShopsdTO);
        }
    }
}
