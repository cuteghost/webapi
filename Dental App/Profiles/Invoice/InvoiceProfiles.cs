using Dental_App.Models.DTO.InvoiceDTO;

namespace Dental_App.Profiles.Invoice;
public class InvoiceProfiles : AutoMapper.Profile
{
	public InvoiceProfiles()
	{
		CreateMap<Models.Domain.Invoice, InvoiceGET>();
		CreateMap<Models.Domain.Invoice, InvoicePOST>().ReverseMap();
		CreateMap<Models.Domain.Invoice, InvoicePATCH>().ReverseMap();
    }
}
