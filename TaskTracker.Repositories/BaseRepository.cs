using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Model.DTO;
using TaskTracker.Repositories.Interfaces.CRUD;
using TaskTracker.Database;
using TaskTracker.Database.Context;

namespace TaskTracker.Repositories
{

    /// <summary>
    /// Base repository for CRUD operations
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public abstract class BaseRepository<TDto, TModel> : ICrudRepository<TDto, TModel>
        where TDto : BaseDto
        where TModel : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly TaskTrackerContext _сontext;
        protected DbSet<TModel> DbSet => _сontext.Set<TModel>();

        protected BaseRepository(TaskTrackerContext context, IMapper mapper)
        {
            _сontext = context;
            _mapper = mapper;
        }

        public async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TModel>(dto);
            await DbSet.AddAsync(entity);
            await _сontext.SaveChangesAsync();
            return await GetAsync(entity.Id);
        }

        public async System.Threading.Tasks.Task DeleteAsync(params long[] ids)
        {
            var entities = await DbSet
                                .Where(x => ids.Contains(x.Id))
                                .ToListAsync();

            _сontext.RemoveRange(entities);
            await _сontext.SaveChangesAsync();
        }

        public async Task<TDto> GetAsync(long id)
        {
            var entity = await DefaultIncludeProperties(DbSet)
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.Id == id);

            var dto = _mapper.Map<TDto>(entity);

            return dto;
        }

        public async Task<TDto> UpdateAsync(TDto dto, CancellationToken token = default)
        {
            var entity = _mapper.Map<TModel>(dto);
            _сontext.Update(entity);
            await _сontext.SaveChangesAsync(token);
            var newEntity = await GetAsync(entity.Id);

            return _mapper.Map<TDto>(newEntity);
        }

        public async Task<IEnumerable<TDto>> GetAsync(CancellationToken token = default)
        {
            var entities = await DbSet.AsNoTracking().ToListAsync();

            var dtos = _mapper.Map<IEnumerable<TDto>>(entities);

            return dtos;
        }

        protected virtual IQueryable<TModel> DefaultIncludeProperties(DbSet<TModel> dbSet) => dbSet;
    }
}