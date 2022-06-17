﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Models;
using ECommerce.API.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public ImageController(ECommerceDbContext context)
        {
            _context = context;
        }

        //Get all Category
        [HttpGet]
        public async Task<ActionResult<List<Image>>> GetAllImage()
        {
            return Ok(await _context.Images.ToListAsync());  
        }

        //Get one Category
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetOneImage(int id)
        {
            var Image = await _context.Images.FindAsync(id);
            if (Image == null) return BadRequest("Image not found :(");
            return Ok(Image);    
        }

        //Post Category
        [HttpPost]
        public async Task<ActionResult<List<Image>>> PostHero(Image info)
        {
            _context.Images.Add(info);
            await _context.SaveChangesAsync();
            return Ok(await _context.Images.ToListAsync());
        }


    }
}