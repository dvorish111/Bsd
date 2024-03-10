using BL_AppService.IServeces;
using Common;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Campain.Controllers
{
   
    public class DonateController : BaseController
    {
        IDonateService donateService;
        public DonateController(IDonateService donateService)
        {
            this.donateService = donateService;
        }

        #region HttpPost
        [HttpPost]
       /* [Microsoft.AspNetCore.Authorization.Authorize]*/
        public async Task<ActionResult<DonateAllDTO>> Create(DonateAllDTO DonateAllDTO)
        {
            try
            {
               await donateService.Create(DonateAllDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpPut
        [HttpPut]
        public async Task<IActionResult> Update( DonateAllDTO donateAllDTO)
        {
            try
            {
               
               await donateService.Update(donateAllDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpDelete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               await donateService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region HttpGetById


        [HttpGet("DonateId/{donateId}")]
        public async Task<ActionResult<DonateDTO>> GetById(int donateId)
        {
            try
            {
                var donateDTO =await donateService.GetById(donateId);
                return Ok(donateDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpGetAll

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonateDTO>>> GetAll()
        {
            try
            {
               
                var donateDTOs =await donateService.GetAll();
                return Ok(donateDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpGetAllByStatus

        [HttpGet("Status/{idStatus}")]
        public async Task<ActionResult<IEnumerable<DonateDTO>>> GetAllByStatus(int idStatus)
        {
            try
            {
                var donateDTOs =await donateService.GetAllByStatus(idStatus);
                return Ok(donateDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpGetAllByNeeded
        [HttpGet("Needed/{idNeeded}")]
        public async Task<ActionResult<IEnumerable<DonateDTO>>> GetAllByNeeded(double idNeeded)
        {
            try
            {
                var donateDTOs =await donateService.GetAllByNeeded(idNeeded);
                return Ok(donateDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Http


        [HttpGet("TazDonate/{tazDonate}")]
        public async Task<ActionResult<DonateAllDTO>> GetByTaz( string tazDonate)
        {
            try
            {
                var donateDTO =await donateService.GetByTaz(tazDonate);
                return Ok(donateDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpGetBynumOfChildren
        [HttpGet("NumOfChildren/{maxNumOfChildren}")]
        public async Task<ActionResult<IEnumerable<DonateDTO>>> GetAllByNumOfChildren(int maxNumOfChildren)
        {
            try
            {
                var donateDTOs =await donateService.GetAllByNumOfChildren(maxNumOfChildren);
                return Ok(donateDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpGetNumFamily
        [HttpGet("NumFamily")]
        public async Task<ActionResult<int>> GetNumFamily()
        {
            try { 
            
                int NumFamily = await donateService.GetNumFamily();
                return Ok(NumFamily);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region HttpGetNumChildren
        [HttpGet("NumChildren")]
        public async Task<ActionResult<int>> GetNumChildren()
        {
            try
            {

                int NumCildren = await donateService.GetNumChildren();
                return Ok(NumCildren);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region HttpCraeteDonatesByExcel
        [HttpPost("CraeteDonatesByExcel")]
        /* [Microsoft.AspNetCore.Authorization.Authorize]*/
        public async Task<IActionResult> CraeteDonatesByExcel(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("No file was uploaded.");
            }
            try
            {
                await donateService.CraeteDonatesByExcel(file);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region GetDonatesByExcel

        [HttpGet("GetDonatesByExcel")]
        public async Task<IActionResult> GetDonatesByExcel()
        {
            try
            {

                var csvStream = await donateService.GetDonatesByExcel();
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
        public async Task<IActionResult> DeleteAllEntities()
        {
            try
            {
                await donateService.DeleteAllEntities();
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
