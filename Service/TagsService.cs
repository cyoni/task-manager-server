using AutoMapper;
using Models;
using Models.Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITagsService
    {
        Task<IEnumerable<Tag>> GetTagsAsync();
        Task<Tag> CreateTagAsync(Tag tatagsk);
        Task<bool> UpdateTagAsync(int id, Tag tag);
        Task<bool> DeleteTagAsync(int id);

    }
    public class TagsService : ITagsService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagsService(IMapper mapper, ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            var tags = await _tagRepository.GetTagsAsync();
            return tags;
        }

        public async Task<Tag> CreateTagAsync(Tag tag)
        {

            var createdTag = await _tagRepository.CreateTagAsync(tag);

            return createdTag;
        }

        public async Task<bool> UpdateTagAsync(int id, Tag tag)
        {
            return await _tagRepository.UpdateTagAsync(tag);
        }

        public async Task<bool> DeleteTagAsync(int id)
        {
            return await _tagRepository.DeleteTagAsync(id);
        }
    }
}
