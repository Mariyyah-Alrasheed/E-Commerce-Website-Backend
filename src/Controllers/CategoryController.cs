using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;
namespace sda_onsite_2_csharp_backend_teamwork.src.Controllers;

public class CategoryController : BaseController
{
    private ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IEnumerable<CategoryReadDto> FindAll()
    {
        return _categoryService.FindAll();
    }

    [HttpPost]
    // [Authorize(Roles = "Admin")]

    public CategoryReadDto CreateOne([FromBody] CategoryCreateDto category)
    {
        return _categoryService.CreateOne(category);
    }
}
