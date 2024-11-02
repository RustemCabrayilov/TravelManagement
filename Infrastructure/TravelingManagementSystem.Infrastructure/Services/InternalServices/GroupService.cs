using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelingManagementSystem.Application.Abstraction.Repository;
using TravelingManagementSystem.Application.Abstraction.Services;
using TravelingManagementSystem.Application.Abstraction.UnitOfWork;
using TravelingManagementSystem.Application.Dtos.RequestDtos;
using TravelingManagementSystem.Application.Dtos.ResponseDtos;
using TravelingManagementSystem.Domain.Entities;
using TravelingManagementSystem.Persistence.Exceptions;

namespace TravelingManagementSystem.Infrastructure.Services.InternalServices;

public class GroupService(
    IGenericRepository<Group> _groupRepository,
    IGenericRepository<Guide> _guideRepository,
    IGenericRepository<Customer> _customerRepository,
    IMapper _mapper,
    IUnitOfWork _unitOfWork) : IGroupService
{
    public async Task<GroupResponseDto> CreateAsync(GroupRequestDto requestDto)
    {
        if (requestDto is null)
            throw new BadRequestException("Null group parameters");
        var entity = _mapper.Map<Group>(requestDto);
        await _groupRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        var guide = await _guideRepository.GetAsync(entity.GuideId);
        entity.Guide = guide;
        var dto = _mapper.Map<GroupResponseDto>(entity);
        return dto;
    }

    public async Task<GroupResponseDto> RemoveAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new BadRequestException("Null id parameter");
        var entity = await _groupRepository.GetAsync(id);
        if (entity is null)
            throw new NotFoundException($"This {id} group not found");
        _groupRepository.Remove(entity);
        _unitOfWork.SaveChanges();
        var guide = await _guideRepository.GetAsync(entity.GuideId);
        entity.Guide = guide;
        return _mapper.Map<GroupResponseDto>(entity);
    }

    public async Task<GroupResponseDto> GetAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new BadRequestException("Null id parameter");
        var entity = await _groupRepository.GetAsync(id);
        if (entity is null)
            throw new NotFoundException($"This {id} group not found");
        var guide = await _guideRepository.GetAsync(entity.GuideId);
        var customers = _customerRepository.GetAll().Where(x => x.GroupId == entity.Id).ToList();
        entity.Guide = guide;
        entity.Customers = customers;
        return _mapper.Map<GroupResponseDto>(entity);
    }
    public async Task<IList<GroupResponseDto>> GetAllAsync()
    {
        //
        var query = _groupRepository.GetAll().Include(g => g.Guide).AsQueryable();
        var entities = await query.ToListAsync();
        
        foreach (var entity in entities)
        {
            
            var guide = await _guideRepository.GetAsync(entity.GuideId);
            var customers = _customerRepository.GetAll().Where(x => x.GroupId == entity.Id).ToList();
            entity.Guide = guide;
            entity.Customers = customers;
        }
    
        return _mapper.Map<IList<GroupResponseDto>>(entities);
    }

    public async Task<GroupResponseDto> UpdateAsync(Guid id, GroupRequestDto requestDto)
    {
        if (id == Guid.Empty)
            throw new BadRequestException("Null id parameter");
        if (requestDto is null)
            throw new BadRequestException("Null group parameters");
        var entity = await _groupRepository.GetAsync(id);
        if (entity is null)
            throw new NotFoundException($"This {id} group not found");
        var entityToUpdate = _mapper.Map<Group>(requestDto);
        entityToUpdate.Id = entity.Id;
        var guide = await _guideRepository.GetAsync(entity.GuideId);
        entityToUpdate.Guide = guide;
        _groupRepository.Update(entityToUpdate);
        _unitOfWork.SaveChanges();
        return _mapper.Map<GroupResponseDto>(entityToUpdate);
    }
}