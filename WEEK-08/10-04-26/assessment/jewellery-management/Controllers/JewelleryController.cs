using JewelleryApi.Models.Dtos;
using JewelleryApi.Models.entities;
using Microsoft.AspNetCore.Mvc;

namespace JewelleryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JewelleryController : ControllerBase
    {
        public static List<JewelleryItem> items = new List<JewelleryItem>();

        public JewelleryController()
        {
            if (items.Count == 0)
            {
                items.Add(new JewelleryItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Gold Ring",
                    Category = "Ring",
                    Material = "Gold",
                    Price = 25000,
                    Quantity = 5
                });
            }
        }

        // 🔹 GET ALL
        [HttpGet]
        public IActionResult GetAllItems()
        {
            var response = items.Select(i => new JewelleyResponseDto
            {
                Id = i.Id,
                Name = i.Name,
                Category = i.Category,
                Material = i.Material,
                Price = i.Price,
                Quantity = i.Quantity
            }).ToList();

            return Ok(response);
        }

        // 🔹 GET BY ID
        [HttpGet("{id}")]
        public IActionResult GetItemById(Guid id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound(new { message = "Item not found" });
            }

            var response = new JewelleyResponseDto
            {
                Id = item.Id,
                Name = item.Name,
                Category = item.Category,
                Material = item.Material,
                Price = item.Price,
                Quantity = item.Quantity
            };

            return Ok(response);
        }

        // 🔹 POST (CREATE)
        [HttpPost]
        public IActionResult AddItem(CreateJewelleryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newItem = new JewelleryItem
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Category = dto.Category,
                Material = dto.Material,
                Price = dto.Price,
                Quantity = dto.Quantity
            };

            items.Add(newItem);

            var response = new JewelleyResponseDto
            {
                Id = newItem.Id,
                Name = newItem.Name,
                Category = newItem.Category,
                Material = newItem.Material,
                Price = newItem.Price,
                Quantity = newItem.Quantity
            };

            return CreatedAtAction(nameof(GetItemById), new { id = response.Id }, response);
        }

        // 🔹 PUT (UPDATE)
        [HttpPut("{id}")]
        public IActionResult UpdateItem(Guid id, CreateJewelleryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingItem = items.FirstOrDefault(i => i.Id == id);

            if (existingItem == null)
            {
                return NotFound(new { message = "Item not found" });
            }

            existingItem.Name = dto.Name;
            existingItem.Category = dto.Category;
            existingItem.Material = dto.Material;
            existingItem.Price = dto.Price;
            existingItem.Quantity = dto.Quantity;

            var response = new JewelleyResponseDto
            {
                Id = existingItem.Id,
                Name = existingItem.Name,
                Category = existingItem.Category,
                Material = existingItem.Material,
                Price = existingItem.Price,
                Quantity = existingItem.Quantity
            };

            return Ok(response);
        }

        // 🔹 DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(Guid id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound(new { message = "Item not found" });
            }

            items.Remove(item);

            return Ok(new { message = "Item deleted successfully" });
        }
    }
}