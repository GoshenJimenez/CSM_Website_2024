﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMWebsite2024.Contracts.Infrastructure
{
	public interface IService<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIdAsync(Guid? id);
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(Guid? id);
		Task SoftDeleteAsync(Guid? id);
		Task UndeleteAsync(Guid? id);
	}
}
