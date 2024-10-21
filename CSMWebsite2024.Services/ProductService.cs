using CSMWebsite2024.Contracts.Infrastructure;
using CSMWebsite2024.Contracts.Posts;
using CSMWebsite2024.Data.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMWebsite2024.Services
{
	public class PostService : IPostService
	{
		private readonly IRepository<Post> _repository;
		public PostService(IRepository<Post> repository)
		{
			_repository = repository;
		}

		public async Task AddAsync(Post? entity)
		{
			if (entity != null)
			{
				await _repository.AddAsync(entity);
				await _repository.SaveChangesAsync();
			}
		}

		public async Task DeleteAsync(Guid? id)
		{
			Post? entity = _repository.All().FirstOrDefault(a => a.Id == id);

			if (entity != null)
			{
				_repository.Delete(entity);
				await _repository.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Post?>> GetAllAsync()
		{
			return _repository.All().ToList();
		}

		public async Task<Post?> GetByIdAsync(Guid? id)
		{
			return _repository.All().FirstOrDefault(a => a.Id == id);
		}

		public async Task UpdateAsync(Post? entity)
		{
			if (entity != null)
			{
				Post? oldEntity = _repository.All().FirstOrDefault(a => a.Id == entity.Id);

				if (oldEntity != null)
				{
					oldEntity.Title = entity.Title;
					oldEntity.Description = entity.Description;

					_repository.Update(oldEntity);
					await _repository.SaveChangesAsync();
				}
			}
		}
	}
}
