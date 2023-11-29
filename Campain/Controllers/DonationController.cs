using BL_AppService.IServeces;
using Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Campain.Controllers
{
  
    public class DonationController : BaseController
    {
        IDonationService donationService;
        public DonationController(IDonationService donationService)
        {
            this.donationService = donationService;
        }

        [HttpPost]
        public IActionResult Create(DonationDTO donationDTO)
        {
            try
            {
                donationService.Create(donationDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update( DonationDTO donationDTO)
        {
            try
            {
                donationService.Update(donationDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                donationService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var donations = donationService.GetAll();
                return Ok(donations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var donation = donationService.GetById(id);
                if (donation == null)
                {
                    return NotFound();
                }
                return Ok(donation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #region HttpGetSumDonation
        [HttpGet("SumDonation")]
        public async Task<ActionResult<int>> GetSumDonation()
        {
            try
            {
                int SumDonation = donationService.GetSumDonation();
                return Ok(SumDonation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
