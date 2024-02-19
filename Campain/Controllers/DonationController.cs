using BL_AppService.IServeces;
using BL_AppService.Services;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Create(DonationAllDTO donationDTO)
        {
            try
            {
               await donationService.Create(donationDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update( DonationDTO donationDTO)
        {
            try
            {
               await donationService.Update(donationDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               await donationService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var donations =await donationService.GetAll();
                return Ok(donations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var donation =await donationService.GetById(id);
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
                int SumDonation =await donationService.GetSumDonation();
                return Ok(SumDonation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region HttpGetSumDonationByDonated
        [HttpGet("GetSumDonationsByDonated/{IdDonated}")]


        public async Task<ActionResult<int>> GetSumDonationsByDonated(int IdDonated)
        {
            try
            {
                int SumDonation =await donationService.GetSumDonationsByDonated(IdDonated);
                return Ok(SumDonation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpGetAllSumDonationsByDonated
        [HttpGet("GetAllSumDonationsByDonated")]

        public async Task<ActionResult <List<int>>> GetAllSumDonationsByDonated()
        {
            try
            {
                List<int> SumDonations =await donationService.GetAllSumDonationsByDonated();
                return Ok(SumDonations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpGetAllDonationsByDonated
        [HttpGet("GetAllDonationsByDonated/{IdDonated}")]

        public async Task<ActionResult<List<DonationDTO>>> GetAllDonationsByDonated(int IdDonated)
        {
            try
            {
                List<DonationDTO> Donations =await donationService.GetAllDonationsByDonated( IdDonated);
                return  Ok(Donations);
            }
            catch (Exception ex)
            {
                return  BadRequest(ex.Message);
            }
        }
        #endregion



        #region GetDonationsByExcel

        [HttpGet("GetDonationsByExcel")]
        public async Task<IActionResult> GetDonationsByExcel()
        {
            try
            {

                var csvStream =await donationService.GetDonationsByExcel();
                return File(csvStream, "text/csv");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpDeleteAllEntities
        [HttpDelete("DeleteAllEntities")]
        public async Task<IActionResult>  DeleteAllEntities()
        {
            try
            {
              await donationService.DeleteAllEntities();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}

