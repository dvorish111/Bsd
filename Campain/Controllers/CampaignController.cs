﻿using BL_AppService.IServeces;
using Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Campain.Controllers
{
    
    public class CampaignController : BaseController
    {
        ICampaignService campaignService;
        public CampaignController(ICampaignService campaignService)
        {
           this.campaignService = campaignService;
        }

        #region HttpPost
        [HttpPost]
        public IActionResult Create(CampaignDTO campaignDTO)
        {
            try
            {
                campaignService.Create(campaignDTO);
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
        public IActionResult Update(CampaignDTO campaignDTO)
        {
            try
            {
                campaignService.Update(campaignDTO);
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
                campaignService.Delete(id);
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
                var campaigns = campaignService.GetAll();
                return  Ok(campaigns);
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
                var campaign = campaignService.GetById(id);
                if (campaign == null)
                {
                    return NotFound();
                }
                return Ok(campaign);
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
                campaignService.DeleteAllEntities();
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

