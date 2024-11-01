using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelingManagementSystem.Application.Abstraction.Repository;
using TravelingManagementSystem.Application.Abstraction.Services;
using TravelingManagementSystem.Application.Abstraction.UnitOfWork;
using TravelingManagementSystem.Application.Dtos.RequestDtos;
using TravelingManagementSystem.Application.Dtos.ResponseDtos;
using TravelingManagementSystem.Domain.Entities;

namespace TravelingManagementSystem.Infrastructure.Services.InternalServices;

public class GroupService(IGenericRepository<Group> _groupRepository,
    IGenericRepository<Guide> _guideRepository,
    IMapper _mapper,
    IUnitOfWork _unitOfWork): IGroupService
{
    public async Task<GroupResponseDto> CreateAsync(GroupRequestDto groupRequestDto)
    {
        var entity =_mapper.Map<Group>(groupRequestDto);
        await _groupRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<GroupResponseDto>(entity);
    }

    public async Task<GroupResponseDto> RemoveAsync(Guid id)
    {
        var entity = await _groupRepository.GetAsync(id);
        _groupRepository.Remove(entity);
        _unitOfWork.SaveChanges();
        var guide= await _guideRepository.GetAsync(entity.GuideId);
        entity.Guide = guide;
        return _mapper.Map<GroupResponseDto>(entity);
    }

    public async Task<GroupResponseDto> GetAsync(Guid id)
    {
       var entity = await _groupRepository.GetAsync(id);
       var guide= await _guideRepository.GetAsync(entity.GuideId);
       entity.Guide = guide;
       return _mapper.Map<GroupResponseDto>(entity);
    }

    public async Task<IList<GroupResponseDto>> GetAllAsync()
    {
        var query = _groupRepository.GetAll();
        var entities = await query.ToListAsync();
        return _mapper.Map<IList<GroupResponseDto>>(entities);
    }

    public async Task<GroupResponseDto> UpdateAsync(Guid id, GroupRequestDto requestDto)
    {
       var entity = await _groupRepository.GetAsync(id);
       var entityToUpdate = _mapper.Map<Group>(requestDto);
       entityToUpdate.Id = entity.Id;
       var guide= await _guideRepository.GetAsync(entity.GuideId);
       entityToUpdate.Guide = guide;
       _groupRepository.Update(entityToUpdate);
       _unitOfWork.SaveChanges();
       return _mapper.Map<GroupResponseDto>(entityToUpdate);
    }
}