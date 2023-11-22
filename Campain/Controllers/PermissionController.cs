using BL_AppService.IServeces;
using BL_AppService.Services;
using Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Campain.Controllers
{

    public class PermissionController : BaseController
    {
        IPermissionService permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            this.permissionService = permissionService;
        }

        #region HttpPost
        [HttpPost]
        public IActionResult Create(SignUpDTO signUpDTO)
        {
            try
            {
                permissionService.Create(signUpDTO);
                return Ok("successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region UpdateByGmail

        [HttpPut("UpdateByGmail/{gmail}")]
        public IActionResult UpdateByGmail(string gmail, LogInDTO logInDTO)
        {
            try
            {
                logInDTO.Email = gmail;
                permissionService.Update(logInDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region UpdateByPassword

        [HttpPut]
        public IActionResult UpdateByPassword( LogInDTO logInDTO)
        {
            try
            {
                permissionService.Update(logInDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion

        #region HttpDelete
        [HttpDelete("{id}")]//לא בטוח שצריך
        public IActionResult Delete(int id)
        {
            try
            {
                permissionService.Delete(id);
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
                var permissions = permissionService.GetAll();
                return Ok(permissions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpGetByPassword&Email

        [HttpGet("Password&Email")]
        public async Task<ActionResult<LogInDTO>> GetByPassword_Email(string password, string email)
        {
            try
            {
                var Permission = permissionService.GetByPassword_Email(password,email);
                if (Permission == null)
                {
                    return NotFound();
                }
                return Ok(Permission);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}


