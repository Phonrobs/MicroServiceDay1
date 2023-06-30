using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.Application.Features.Assets;
using Reservation.Domain.Models;

namespace Reservation.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly ISender _sender;

        public AssetsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public Task<Asset> CreateAsset(CreateAssetCommand data)
        {
            return _sender.Send(data);
        }
    }
}
