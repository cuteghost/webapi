using Models.DTO.InvoiceDTO;

namespace Profiles.Invoice;
public class InvoiceProfiles : AutoMapper.Profile
{
	public InvoiceProfiles()
	{
		CreateMap<Models.Domain.Invoice, InvoiceGET>().ReverseMap();
		CreateMap<Models.Domain.Invoice, InvoicePOST>().ReverseMap();
		CreateMap<Models.Domain.Invoice, InvoicePATCH>().ReverseMap();
    }
}
