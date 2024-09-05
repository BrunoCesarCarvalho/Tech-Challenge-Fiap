using Microsoft.AspNetCore.Mvc;
using TechChallengeFIAP.Domain.InterfacesUserCases.Services;
using TechChallengeFIAP.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechChallengeFIAP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        
        private readonly IProdutoUserCase _produtoService;

        public ProdutoController(IProdutoUserCase produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary>
        /// Metodo que obtém todos os Produtos criados no sistema
        /// </summary>
        /// <returns>Uma lista de Produtos.</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()        
        {
            return Ok(await _produtoService.GetAllAsync());
        }


        /// <summary>
        /// Metodo que cria um produto no sistema
        /// </summary>        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProdutoModel produtoDTO)
        {
            //var foto = System.IO.File.ReadAllBytes(@"C:\\Users\\ricar\\Pictures\\Screenshots\\Screenshot 2023-03-11 221322.png");          
            await _produtoService.CreateAsync(produtoDTO);
            return StatusCode(StatusCodes.Status201Created);
        }


        /// <summary>
        /// Metodo que edita um produto no sistema
        /// </summary>      
        [HttpPut]
        public async Task<IActionResult> EditAsync([FromBody] EditProdutoModel editProdutoDTO)
        {
            await _produtoService.EditAsync(editProdutoDTO);
            return StatusCode(StatusCodes.Status204NoContent);
        }


        /// <summary>
        /// Metodo que deleta um produto no sistema
        /// </summary>  
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _produtoService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }


        /// <summary>
        /// Metodo obtém uma lista de produtos de acordo com o Id da categoria
        /// </summary>  
        /// <returns>Retorna uma lista produtos</returns>
        [HttpGet("ListByIdCategoryAsync/{categoryId}")]
        public async Task<IActionResult> GetListByIdCategoryAsync([FromRoute] int categoryId)
        {            
            return Ok(await _produtoService.GetListByIdCategoryAsync(categoryId));
        }


        /// <summary>
        /// Metodo obtém uma lista de produtos de acordo com nome da categoria
        /// </summary>  
        /// <returns>Retorna uma lista produtos</returns>
        [HttpGet("ListByNomeCategoryAsync/{nome}")]
        public async Task<IActionResult> GetListByNomeCategoryAsync([FromRoute] string nome)
        {
            return Ok(await _produtoService.GetListByNomeCategoryAsync(nome));
        }
    }
}
