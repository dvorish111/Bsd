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
                donateService.Create(DonateAllDTO);
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
               
                donateService.Update(donateAllDTO);
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
                donateService.Delete(id);
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
        public async Task<ActionResult<IEnumerable<DonateDTO>>> GetAll()
        {
            try
            {
               
                var donateDTOs = donateService.GetAll();
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
                var donateDTOs = donateService.GetAllByStatus(idStatus);
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
                var donateDTOs = donateService.GetAllByNeeded(idNeeded);
                return Ok(donateDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpGetByTaz
        [HttpGet("TazDonate/{tazDonate}")]
        public async Task<ActionResult<DonateDTO>> GetByTaz( int tazDonate)
        {
            try
            {
                var donateDTO = donateService.GetByTaz(tazDonate);
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
                var donateDTOs = donateService.GetAllByNumOfChildren(maxNumOfChildren);
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
            
                int NumFamily = donateService.GetNumFamily();
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

                int NumCildren = donateService.GetNumChildren();
                return Ok(NumCildren);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

    }
}
