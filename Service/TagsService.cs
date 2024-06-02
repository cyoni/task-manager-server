using AutoMapper;
using Azure;
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
        Task<IEnumerable<TagResponse>> GetTagsAsync();
        Task<TagResponse> CreateTagAsync(TagRequestDto tatagsk);
        Task<bool> UpdateTagAsync(int id, TagRequestDto tag);
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

        public async Task<IEnumerable<TagResponse>> GetTagsAsync()
        {
            var tags = await _tagRepository.GetTagsAsync();
            return _mapper.Map<IEnumerable<TagResponse>>(tags);
        }

        public async Task<TagResponse> CreateTagAsync(TagRequestDto tagDto)
        {
            var tag = _mapper.Map<Tag>(tagDto);
            var createdTag = await _tagRepository.CreateTagAsync(tag);
            return _mapper.Map<TagResponse>(createdTag);
        }

        public async Task<bool> UpdateTagAsync(int id, TagRequestDto tagDto)
        {
            var tag = _mapper.Map<Tag>(tagDto);
            return await _tagRepository.UpdateTagAsync(tag);
        }

        public async Task<bool> DeleteTagAsync(int id)
        {
            return await _tagRepository.DeleteTagAsync(id);
        }
    }
}
