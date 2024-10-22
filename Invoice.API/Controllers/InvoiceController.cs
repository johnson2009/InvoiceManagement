using Invoice.API.Contract;
using Invoice.API.Contract.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.API.Controllers;

[ApiController]
[Route("api/invoice/[action]")] 
public class InvoiceController : BaseController
{
    public InvoiceController(APIEvent apiEvent) : base(apiEvent)
    {
       
    }

    [HttpGet]
    public JsonResult GetList()
    {
        return Do(() => new List<InvoiceDto>{
            new InvoiceDto
            {
                InvoiceID = Guid.NewGuid(),
                InvoiceNumber = "INV-2021-0001",
                InvoiceDate = DateTime.Now,
                InvoiceAmount = 1000
            },
            new InvoiceDto
            {
                InvoiceID = Guid.NewGuid(),
                InvoiceNumber = "INV-2021-0002",
                InvoiceDate = DateTime.Now,
                InvoiceAmount = 2000
            }
        });
    }
}
