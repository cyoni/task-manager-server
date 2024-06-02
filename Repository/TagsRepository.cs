
using AutoMapper;
using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Models;
using Repositories;
using Services;


namespace Repository
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetTagsAsync();
        Task<Tag> CreateTagAsync(Tag tag);
        Task<bool> UpdateTagAsync(Tag tag);
        Task<bool> DeleteTagAsync(int id);

    }
    public class TagRepository(ILoggerService logger, TaskDbContext context) : ITagRepository
    {
        private readonly TaskDbContext _context = context;
        private readonly ILoggerService _logger = logger;

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            var tags = await _context.Tags.ToListAsync();
            return tags;
        }

        public async Task<Tag> CreateTagAsync(Tag tag)
        {
            try
            {
                EntityEntry<Tag> newTag = _context.Tags.Add(tag);
                await _context.SaveChangesAsync();
                return newTag.Entity;
            }
            catch (Exception ex)
            {
                _logger.Log(E_LogLevel.High, "Exception in CreateTagAsync", ex);
                throw;
            }
        }

        public async Task<bool> UpdateTagAsync(Tag tag)
        {
            var tagInDb = await _context.Tags.FindAsync(tag.Id);
            if (tagInDb == null)
            {
                return false;
            }

            _context.Entry(tag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(E_LogLevel.High, "Exception in UpdateTagAsync", ex);
                throw;
            }
        }

        public async Task<bool> DeleteTagAsync(int id)
        {
            try
            {
                var tag = await _context.Tags.FindAsync(id);
                if (tag == null)
                {
                    return false;
                }

                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(E_LogLevel.High, "Exception in DeleteTagAsync", ex);
                throw;
            }
        }

    }

}