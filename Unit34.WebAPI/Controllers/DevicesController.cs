using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Unit34.WebAPI.Configuration;
using Unit34.WebAPI.Contracts.Devices;

namespace Unit34.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;
        public DevicesController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Просмотр списка подключенных устройств
        /// </summary>
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return StatusCode(200, "Устройства отсутствуют");
        }

        /// <summary>
        /// Добавление нового устройства
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(
            [FromBody] // Атрибут, указывающий, откуда брать значение объекта
            AddDeviceRequest request // Объект запроса
                                     )
        {
            // Ручное ограничение/ проверка получаемых параметров  запроса 
            if (request.CurrentVolts < 120)            {
                // Добавляем для клиента информативную ошибку ручной набор
                // return StatusCode(403, $"Устройства с напряжением меньше 120 вольт не поддерживаются!");
                // Добавляем для клиента информативную ошибку из модели данных
                ModelState.AddModelError("currentVolts", "Устройства с напряжением меньше 120 вольт не поддерживаются!");
                return BadRequest(ModelState);
            }

            return StatusCode(200, $"Устройство {request.Name} добавлено!");
            //return StatusCode(200, "Этот метод будет добавлять новые устройства");
        } 
    }
        
}