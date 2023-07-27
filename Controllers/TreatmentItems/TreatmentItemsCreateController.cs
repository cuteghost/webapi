using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.TreatmentItemsDTO;

namespace Controllers.TreatmentItemsControllers
{
    public partial class TreatmentItemsController : Controller
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(TreatmentItemsPOST treatmentItemPost)
        {
            var newTreatmentItem = new TreatmentItems();
            newTreatmentItem.Treatment = await _treatmentsRead.GetTreatment(treatmentItemPost.TreatmentID);
            newTreatmentItem.Material = new Material(); //Ali kad se doda materijal onda uradit isto ko i za treatment
            newTreatmentItem.RequiredAmount = treatmentItemPost.RequiredAmount;

            /* 
                ovdje moze se dodati provejra da li ima tog materijala toliko na stanju na stocku 
            */

            await _treatmentItemsCreate.CreateTreatmentItem(newTreatmentItem);
            return Ok("Done");
        }
    }
}