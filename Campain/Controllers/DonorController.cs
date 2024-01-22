using BL_AppService.IServeces;
using Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Campain.Controllers
{
    public class DonorController : BaseController
    {
        IDonorService donorService;
        public DonorController(IDonorService donorService)
        {
            this.donorService = donorService;
        }

        #region HttpPost
        [HttpPost]
      
        public async Task<ActionResult<int>> Create(DonorAllDTO donorDTO)
        {
            try
            {
               int IdNewDonor= donorService.Create(donorDTO);
                return Ok(IdNewDonor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

       /* #region HttpPut
        [HttpPut]
        public async Task<IActionResult> Update( DonorDTO donorAllDTO)
        {
            try
            {              
                donorService.Update(donorAllDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion*/

        #region HttpDelete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                donorService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpGetAll

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonorDTO>>> GetAll()
        {
            try
            {

                var donorDTOs = donorService.GetAll();
                return Ok(donorDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region GetAllByCity

        [HttpGet("Donors/{city}")]
        public async Task<ActionResult<IEnumerable<DonorDTO>>> GetAllByCity(string city)
        {
            try
            {
                var DonorDTOs = donorService.GetAllByCity(city);
                return Ok(DonorDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

       

        #region HttpGetById
        [HttpGet("{id}")]
        public async Task<ActionResult<DonorDTO>> GetByTaz(int id)
        {
            try
            {
                var donorDTO = donorService.GetById(id);
                return Ok(donorDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }
        #endregion
        #region HttpDeleteAllEntities
        [HttpDelete("DeleteAllEntities")]
        public IActionResult DeleteAllEntities()
        {
            try
            {
                donorService.DeleteAllEntities();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

      /*  #region GetDonorsByExcel

        [HttpGet("GetDonorsByExcel")]
        public IActionResult GetDonorsByExcel()
        {
            try
            {

                var csvStream = donorService.GetDonorsByExcel();
                return File(csvStream, "text/csv");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion*/

    }
}
