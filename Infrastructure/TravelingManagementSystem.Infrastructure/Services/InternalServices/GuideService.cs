using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelingManagementSystem.Application.Abstraction.Repository;
using TravelingManagementSystem.Application.Abstraction.Services;
using TravelingManagementSystem.Application.Abstraction.UnitOfWork;
using TravelingManagementSystem.Application.Dtos.RequestDtos;
using TravelingManagementSystem.Application.Dtos.ResponseDtos;
using TravelingManagementSystem.Domain.Entities;

namespace TravelingManagementSystem.Infrastructure.Services.InternalServices;

public class GuideService(IGenericRepository<Guide> _guideRepository, IMapper _mapper, IUnitOfWork _unitOfWork)
    : IGuideService
{
    public async Task<GuideResponseDto> CreateAsync(GuideRequestDto guideRequestDto)
    {
        var entity = _mapper.Map<Guide>(guideRequestDto);
        await _guideRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<GuideResponseDto>(entity);
    }

    public async Task<GuideResponseDto> RemoveAsync(Guid id)
    {
        var entity = await _guideRepository.GetAsync(id);
        bool removed = _guideRepository.Remove(entity);
        _unitOfWork.SaveChanges();
        return _mapper.Map<GuideResponseDto>(entity);
    }

    public async Task<GuideResponseDto> GetAsync(Guid id)
    {
        var entity = await _guideRepository.GetAsync(id);
        return _mapper.Map<GuideResponseDto>(entity);
    }

    public async Task<IList<GuideResponseDto>> GetAllAsync()
    {
        var query = _guideRepository.GetAll();
        var entities = await query.ToListAsync();
        return _mapper.Map<IList<GuideResponseDto>>(entities);
    }

    public async Task<GuideResponseDto> UpdateAsync(Guid id, GuideRequestDto requestDto)
    {
        var entity = await _guideRepository.GetAsync(id);
        var entityToUpdate = _mapper.Map<Guide>(requestDto);
        entityToUpdate.Id = id;
        _guideRepository.Update(entityToUpdate);
        _unitOfWork.SaveChanges();
        return _mapper.Map<GuideResponseDto>(entityToUpdate);
    }
}