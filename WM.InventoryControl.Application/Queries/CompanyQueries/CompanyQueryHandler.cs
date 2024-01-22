using MediatR;
using WM.InventoryControl.Application.Dtos;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.CompanyQueries
{
    public class CompanyQueryHandler(ICompanyService companyService) : IRequestHandler<GetCompanyQuery, CompanyDto>, IRequestHandler<GetAllCompanyQuery, IEnumerable<CompanyDto>>
    {
        private readonly ICompanyService _companyService = companyService;

        public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyService.GetCompanyAsync(request.Id);

            if (company is null) return default!;

            return new CompanyDto(company.Id, company.Name,
                                   new AddressDto(
                                        company.Address.Id,
                                        company.Address.Country,
                                        company.Address.State,
                                        company.Address.City,
                                        company.Address.District,
                                        company.Address.Street,
                                        company.Address.ZipCode));
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            return (from company in await _companyService.GetAllCompaniesAsync()
                    select new CompanyDto(company.Id, company.Name,
                                    new AddressDto(
                                         company.Address.Id,
                                         company.Address.Country,
                                         company.Address.State,
                                         company.Address.City,
                                         company.Address.District,
                                         company.Address.Street,
                                         company.Address.ZipCode))).ToList();
        }
    }
}
