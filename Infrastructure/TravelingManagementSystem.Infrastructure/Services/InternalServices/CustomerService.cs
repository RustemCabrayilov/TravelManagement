using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TravelingManagementSystem.Application.Abstraction.Repository;
using TravelingManagementSystem.Application.Abstraction.Services;
using TravelingManagementSystem.Application.Abstraction.UnitOfWork;
using TravelingManagementSystem.Application.Dtos.RequestDtos;
using TravelingManagementSystem.Application.Dtos.ResponseDtos;
using TravelingManagementSystem.Domain.Entities;
using TravelingManagementSystem.Persistence.Exceptions;

namespace TravelingManagementSystem.Infrastructure.Services.InternalServices;

public class CustomerService(IGenericRepository<Customer> _customerRepository,
    IUnitOfWork _unitOfWork,
    IMapper _mapper)
    : ICustomerService
{
    public async Task<CustomerResponseDto> CreateAsync(CustomerRequestDto requestDto)
    {
        if (requestDto is null)
            throw new BadRequestException("Null customer parameters");
        var entity = _mapper.Map<Customer>(requestDto);
        await _customerRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<CustomerResponseDto>(entity);
    }

    public async Task<CustomerResponseDto> RemoveAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new BadRequestException("Null id parameter");
        var entity = await _customerRepository.GetAsync(id);
        if (entity == null)
            throw new NotFoundException($"This {id} customer not Found");
        _customerRepository.Remove(entity);
        _unitOfWork.SaveChanges();
        return _mapper.Map<CustomerResponseDto>(entity);
    }

    public async Task<CustomerResponseDto> GetAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new BadRequestException("Null id parameter");
        var entity = await _customerRepository.GetAsync(id);
        if (entity == null)
            throw new NotFoundException($"This {id} customer not Found");
        return _mapper.Map<CustomerResponseDto>(entity);
    }

    public async Task<IList<CustomerResponseDto>> GetAllAsync()
    {
        var query = _customerRepository.GetAll();
        var entities = await query.ToListAsync();
        var dtos = _mapper.Map<List<CustomerResponseDto>>(entities);
        return dtos;
    }

    public async Task<CustomerResponseDto> UpdateAsync(Guid id, CustomerRequestDto requestDto)
    {
        if(id==Guid.Empty)
            throw new BadRequestException("Null id parameter");
        if (requestDto is null)
            throw new BadRequestException("Null customer parameters");
        var entity = await _customerRepository.GetAsync(id);
        if (entity == null)
            throw new NotFoundException($"This {id} customer not Found");
        var entityToUpdate = _mapper.Map<Customer>(requestDto);
        entityToUpdate.Id = entity.Id;
        _customerRepository.Update(entityToUpdate);
        _unitOfWork.SaveChanges();
        return _mapper.Map<CustomerResponseDto>(entityToUpdate);
    }
}