using MediatR;
using WM.InventoryControl.Application.Queries.AddressQueries;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.CompanyQueries
{
    public class CompanyQueryHandler(ICompanyService companyService) : IRequestHandler<GetCompanyQuery, CompanyViewModel>, IRequestHandler<GetAllCompanyQuery, IEnumerable<CompanyViewModel>>
    {
        private readonly ICompanyService _companyService = companyService;

        public async Task<CompanyViewModel> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var company = await _companyService.GetCompanyAsync(request.Id);

                if (company is null) return default!;

                var companyViewModel = new CompanyViewModel(company.Id, company.Name,
                                       new AddressViewModel(
                                            company.Address.Id,
                                            company.Address.Country,
                                            company.Address.State,
                                            company.Address.City,
                                            company.Address.District,
                                            company.Address.Street,
                                            company.Address.ZipCode));

                return companyViewModel;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<CompanyViewModel>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return (from company in await _companyService.GetAllCompaniesAsync()
                        select new CompanyViewModel(company.Id, company.Name,
                                        new AddressViewModel(
                                             company.Address.Id,
                                             company.Address.Country,
                                             company.Address.State,
                                             company.Address.City,
                                             company.Address.District,
                                             company.Address.Street,
                                             company.Address.ZipCode))).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
