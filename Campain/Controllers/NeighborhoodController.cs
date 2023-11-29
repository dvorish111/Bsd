using BL_AppService.IServeces;
using Common;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Campain.Controllers
{
    public class NeighborhoodController : BaseController
    {
         INeighborhoodService neighborhoodService;

        public NeighborhoodController(INeighborhoodService neighborhoodService)
        {
            this.neighborhoodService = neighborhoodService;
        }

        [HttpPost]
        public IActionResult Create(NeighborhoodDTO neighborhoodDTO)
        {
            try
            {
                neighborhoodService.Create(neighborhoodDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       /* [HttpPut]
        public IActionResult Update( NeighborhoodDTO neighborhoodDTO)
        {
            try
            {
                neighborhoodService.Update(neighborhoodDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
*/
       /* [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                neighborhoodService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var neighborhoods = neighborhoodService.GetAll();
                return Ok(neighborhoods);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

     /*   [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var neighborhood = neighborhoodService.GetById(id);
                if (neighborhood == null)
                {
                    return NotFound();
                }
                return Ok(neighborhood);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
    }
}
