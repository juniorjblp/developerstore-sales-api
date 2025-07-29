using Ambev.DeveloperEvaluation.Application.Branches.GetBranches;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.GetBranches;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchesController(IMapper mapper, IMediator mediator) : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<GetBranchesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBranches([FromQuery] GetBranchesRequest request, CancellationToken cancellationToken)
        {
            var validator = new GetBranchesRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = mapper.Map<GetBranchesCommand>(request);

            var response = await mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetBranchesResponse>
            {
                Success = true,
                Message = "Branches retrieved successfully",
                Data = mapper.Map<GetBranchesResponse>(response)
            });
        }
    }
}
