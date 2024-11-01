using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelingManagementSystem.Application.Abstraction.Repository;
using TravelingManagementSystem.Application.Abstraction.Services;
using TravelingManagementSystem.Application.Abstraction.UnitOfWork;
using TravelingManagementSystem.Application.Dtos.RequestDtos;
using TravelingManagementSystem.Application.Dtos.ResponseDtos;
using TravelingManagementSystem.Domain.Entities;

namespace TravelingManagementSystem.Infrastructure.Services.InternalServices;

public class CustomerService(IGenericRepository<Customer> _customerRepository,IUnitOfWork _unitOfWork,IMapper _mapper): ICustomerService
{
    public async Task<CustomerResponseDto> CreateAsync(CustomerRequestDto customerRequestDto)
    {
        var entity = _mapper.Map<Customer>(customerRequestDto);
       await _customerRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<CustomerResponseDto>(entity);
    }

    public async Task<CustomerResponseDto> RemoveAsync(Guid id)
    {
        var entity = await _customerRepository.GetAsync(id);
       _customerRepository.Remove(entity);
       _unitOfWork.SaveChanges();
      return _mapper.Map<CustomerResponseDto>(entity);
    }

    public async Task<CustomerResponseDto> GetAsync(Guid id)
    {
       var entity = await _customerRepository.GetAsync(id);
       return _mapper.Map<CustomerResponseDto>(entity);
    }

    public async Task<IList<CustomerResponseDto>> GetAllAsync()
    {
        var query = _customerRepository.GetAll();
        var entities = await query.ToListAsync();
        var dtos = _mapper.Map<List<CustomerResponseDto>>(entities);
        return dtos;
    }

    public async Task<CustomerResponseDto> UpdateAsync(Guid id,CustomerRequestDto requestDto)
    {
        var entity = await _customerRepository.GetAsync(id);
        var entityToUpdate = _mapper.Map<Customer>(requestDto);
        entityToUpdate.Id = entity.Id;
        _customerRepository.Update(entityToUpdate);
        _unitOfWork.SaveChanges();
        return _mapper.Map<CustomerResponseDto>(entityToUpdate);
    }
    
}