using Ambev.DeveloperEvaluation.Application.Branches.GetBranches;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.GetBranches
{
    public class GetBranchesProfile : Profile
    {
        public GetBranchesProfile() 
        {
            CreateMap<GetBranchesResult, GetBranchesResponse>();
            CreateMap<GetBranchesRequest, GetBranchesCommand>();
        }
    }
}
