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
        public ActionResult Create(DonateAllDTO DonateAllDTO)
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
        [HttpPut("{Taz}")]
        public ActionResult Update(int Taz, DonateAllDTO donateAllDTO)
        {
            try
            {
                donateAllDTO.ParentTaz = Taz;
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
        public ActionResult Delete(int id)
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
        public IActionResult GetAll()
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

        [HttpGet("status/{idStatus}")]
        public ActionResult<List<DonateDTO>> GetAllByStatus(int idStatus)
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
        public ActionResult<List<DonateDTO>> GetAllByNeeded(double idNeeded)
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

        #region HttpGetById
        [HttpGet("ID/{idDonate}")]
        public ActionResult<DonateDTO> GetById( int idDonate)
        {
            try
            {
                var donateDTO = donateService.GetById(idDonate);
                return Ok(donateDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpGetBynumOfChildren
        [HttpGet("numOfChildren")]
        public ActionResult<List<DonateDTO>> GetAllByNumOfChildren(int from, int to)
        {
            try
            {
                var donateDTOs = donateService.GetAllByNumOfChildren(from, to);
                return Ok(donateDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion



    }
}
