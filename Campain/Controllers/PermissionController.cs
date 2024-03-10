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
        public async Task<IActionResult> Create(SignUpDTO signUpDTO)
        {
            try
            {
              await  permissionService.Create(signUpDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region UpdateByGmail

        [HttpPut("UpdateByGmail/{gmail}")]
        public async Task<IActionResult> UpdateByGmail(string gmail, SignUpDTO signUpDTO)
        {
            try
            {
                
              permissionService.UpdateByGmail(signUpDTO, gmail);
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
        public async Task<IActionResult> UpdateByPassword( LogInDTO logInDTO)
        {
            try
            {
               await permissionService.Update(logInDTO);
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               await permissionService.Delete(id);
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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var permissions =await permissionService.GetAll();
                return Ok(permissions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpGetByPassword&Email

      
        [HttpGet("Password/{password}/Email/{email}")]
        public async Task<ActionResult<LogInDTO>> GetByPassword_Email(string password, string email)
        {
            try
            {
                var Permission =await permissionService.GetByPassword_Email(password,email);
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


        #region confirmPassword

        [HttpPut("ConfirmPassword/{password}")]
        public async Task<ActionResult<bool>> ConfirmPassword(string password)
        {   bool passwordOk = false;
            try
            {
                passwordOk =  await permissionService.ConfirmPassword(password);
                return Ok(passwordOk);
            }
            catch (Exception ex)
            {
                return BadRequest(passwordOk);
            }
        }


        #endregion
    }
}


