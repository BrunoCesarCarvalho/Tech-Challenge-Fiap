using Microsoft.AspNetCore.Mvc;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechChallengeFIAP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()        
        {
            return Ok(await _produtoService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProdutoDTO produtoDTO)
        {
            var foto = System.IO.File.ReadAllBytes(@"C:\\Users\\ricar\\Pictures\\Screenshots\\Screenshot 2023-03-11 221322.png");
            produtoDTO.ProdutoImagens = new List<CreateProdutoImagensDTO>()
            {
                new CreateProdutoImagensDTO()
                {
                    Foto = foto,
                }
            };
            await _produtoService.CreateAsync(produtoDTO);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> EditAsync([FromBody] EditProdutoDTO editProdutoDTO)
        {
            await _produtoService.EditAsync(editProdutoDTO);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _produtoService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet("ListByIdCategoryAsync/{categoryId}")]
        public async Task<IActionResult> GetListByIdCategoryAsync([FromRoute] int categoryId)
        {            
            return Ok(await _produtoService.GetListByIdCategoryAsync(categoryId));
        }

        [HttpGet("ListByNomeCategoryAsync/{nome}")]
        public async Task<IActionResult> GetListByNomeCategoryAsync([FromRoute] string nome)
        {
            return Ok(await _produtoService.GetListByNomeCategoryAsync(nome));
        }
    }
}
