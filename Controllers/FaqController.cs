using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FaqController : ControllerBase
    {
        private readonly ILogger<FaqController> _logger;
        private readonly IFaqService _faqApiService;

        public FaqController(ILogger<FaqController> logger, IFaqService faqApiService)
        {
            _logger = logger;
            _faqApiService = faqApiService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetListFaq()
        {
            return Ok(await _faqApiService.GetList());
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _faqApiService.GetById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(FaqRequest data)
        {
            return Ok(await _faqApiService.Create(data));
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(string id, FaqRequest data)
        {
            return Ok(await _faqApiService.Update(id, data));
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _faqApiService.Delete(id));
        }
    }
}