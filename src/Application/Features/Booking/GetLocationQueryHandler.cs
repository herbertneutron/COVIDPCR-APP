using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Behaviours;
using Application.Contracts.Domain.DTO;
using Application.Contracts.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Booking
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, LocationResponseII>
    {
        private readonly ISpacesRepository _spaceRepository;
        private readonly ILogger<GetLocationQueryHandler> _logger;
        public GetLocationQueryHandler(ISpacesRepository spaceRepository, ILogger<GetLocationQueryHandler> logger)
        {
            _logger = logger;
            _spaceRepository = spaceRepository;
            
        }
        public async Task<LocationResponseII> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _spaceRepository.GetSpace(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetLocationQueryHandler: {ex.Message}");
                throw new InvalidResponseException(ex.Message);
            }
        }
    }
}