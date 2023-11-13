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
        public IActionResult Create(PermissionDTO permissionDTO)
        {
            try
            {
                permissionService.Create(permissionDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region HttpPut

        [HttpPut("{id}")]
        public IActionResult Update(int id, PermissionDTO PermissionDTO)
        {
            try
            {
                PermissionDTO.Id = id;
                permissionService.Update(PermissionDTO);
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

        #region HttpGetById

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var Permission = permissionService.GetById(id);
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

