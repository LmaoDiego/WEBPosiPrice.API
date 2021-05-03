using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Persistence.Contexts;
using PosiPrice.API.Domain.Persistence.Repositories;

namespace PosiPrice.API.Persitence.Repositories
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
        }

        public async Task<Tag> FindById(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<IEnumerable<Tag>> ListAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public void Remove(Tag tag)
        {
            _context.Tags.Remove(tag);
        }

        public void Update(Tag tag)
        {
            _context.Tags.Update(tag);
        }
    }
}
