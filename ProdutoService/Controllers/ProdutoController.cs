using Microsoft.AspNetCore.Mvc;
using ProdutoService.Data;
using ProdutoService.Models;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;
    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProdutos() => Ok(_context.Produtos.ToList());

    [HttpGet("{id}")]
    public IActionResult GetProduto(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null) return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public IActionResult CreateProduto([FromBody] Product produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEstoque(int id, [FromBody] Product produto)
    {
        var existing = _context.Produtos.Find(id);
        if (existing == null) return NotFound();

        existing.Nome = produto.Nome;
        existing.Categoria = produto.Categoria;
        existing.Preco = produto.Preco;
        existing.Estoque = produto.Estoque;

        _context.SaveChanges();
        return NoContent();
    }
}
