using FoodBoxClassLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontEnd.Controllers;

[ApiController]
[Route("items")]
public class ItemController : Controller
{
    private readonly ILogger<ItemController> _logger;
    private readonly FoodBoxDB _context;

    public ItemController(ILogger<ItemController> logger, IDbContextFactory<FoodBoxDB> contextFacotory)
    {
        _logger = logger;
        _context = contextFacotory.CreateDbContext();
    }

    [HttpGet("")]
    public async Task<List<Item>> GetAllItems()
    {
        return await _context.Items.ToListAsync();
    }
}
