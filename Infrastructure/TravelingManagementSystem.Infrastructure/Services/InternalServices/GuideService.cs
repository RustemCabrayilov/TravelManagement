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

public class GuideService(IGenericRepository<Guide> _guideRepository, IMapper _mapper, IUnitOfWork _unitOfWork)
    : IGuideService
{
    public async Task<GuideResponseDto> CreateAsync(GuideRequestDto requestDto)
    {
        if (requestDto is null)
            throw new BadRequestException("Null guide parameters");
        var entity = _mapper.Map<Guide>(requestDto);
        await _guideRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<GuideResponseDto>(entity);
    }

    public async Task<GuideResponseDto> RemoveAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new BadRequestException($"Null id parameter");
        var entity = await _guideRepository.GetAsync(id);
        if (entity is null)
            throw new NotFoundException($"This {id} guide not found");
        bool removed = _guideRepository.Remove(entity);
        _unitOfWork.SaveChanges();
        return _mapper.Map<GuideResponseDto>(entity);
    }

    public async Task<GuideResponseDto> GetAsync(Guid id)
    {
        if(id == Guid.Empty)
            throw new BadRequestException("Null id parameter");
        var entity = await _guideRepository.GetAsync(id);
        if (entity is null)
            throw new NotFoundException($"This {id} guide not found");
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
        if(id == Guid.Empty)
            throw new BadRequestException("Null id parameter");
        if (requestDto is null)
            throw new BadRequestException("Null guide parameters");
        var entity = await _guideRepository.GetAsync(id);
        if (entity is null)
            throw new NotFoundException($"This {id} guide not found");
        var entityToUpdate = _mapper.Map<Guide>(requestDto);
        entityToUpdate.Id = id;
        _guideRepository.Update(entityToUpdate);
        _unitOfWork.SaveChanges();
        return _mapper.Map<GuideResponseDto>(entityToUpdate);
    }
}