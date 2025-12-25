using AutoMapper;
using BlogApp.Application.DtoInterfaces;
using BlogApp.Application.Exceptions.Abstract;
using BlogApp.Application.Exceptions.Concrete;
using BlogApp.Application.ManagerInterfaces;
using BlogApp.Contract.RepositoryInterfaces;
using BlogApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.InnerInfrastructure.ManagerConcretes
{
    public abstract class BaseManager<T, U> : IManager<T, U> where T : class, IDto where U : class, IEntity
    {
        private readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;
        private readonly IErrorHandler _errorHandler;
        public BaseManager(IRepository<U> repository, IMapper mapper, IErrorHandler errorHandler)
        {
            _repository = repository;
            _mapper = mapper;
            _errorHandler = errorHandler;
        }
        public virtual async Task CreateAsync(T entity)
        {
            await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                U domainEntity = _mapper.Map<U>(entity);
                //domainEntity.CreatedDate = DateTime.Now;
                domainEntity.Status = Domain.Enums.DataStatus.Inserted;

                await _repository.CreateAsync(domainEntity);
            });
        }

        public List<T> GetActives()
        {
            List<U> values = _repository.Where(x => x.Status != Domain.Enums.DataStatus.Deleted).ToList();

            return _mapper.Map<List<T>>(values);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {

                List<U> values = await _repository.GetAllAsync();
                return _mapper.Map<List<T>>(values);
            });
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {

                U value = await _repository.GetByIdAsync(id);
                return _mapper.Map<T>(value);
            });
        }

        public List<T> GetPassives()
        {
            List<U> values = _repository.Where(x => x.Status == Domain.Enums.DataStatus.Deleted).ToList();
            return _mapper.Map<List<T>>(values);
        }

        public List<T> GetUpdateds()
        {
            List<U> values = _repository.Where(x => x.Status == Domain.Enums.DataStatus.Updated).ToList();
            return _mapper.Map<List<T>>(values);
        }

        public async Task<string> HardDeleteAsync(int id)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                U value = await _repository.GetByIdAsync(id);
                if (value == null) throw new CustomException("Silinecek veri bulunamadı.", 404);

                await _repository.DeleteAsync(value);
                return $"{id} id'li veri kalıcı olarak silindi";
            });
        }

   

        public virtual async Task UpdateAsync(T entity)
        {
            await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                U originalValue = await _repository.GetByIdAsync(entity.Id);
                U newValue = _mapper.Map<U>(entity);
                newValue.Status = Domain.Enums.DataStatus.Updated;
                //newValue.UpdatedDate = DateTime.Now;
                await _repository.UpdateAsync(originalValue, newValue);
            });
        }
    }
}
