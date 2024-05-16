using BL_AppService.IServeces;
using BL_AppService.Services;
using Common;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Campain.Controllers
{

    public class ImageController : BaseController
    {
        ImageService ImageService;
        public ImageController(ImageService ImageService)
        {
            this.ImageService = ImageService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetImage(int id)
        {
            string imagePath =await this.ImageService.GetImage(id);

            var imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return  File(imageBytes, "image/jpeg");
            



        }
       

        [HttpPost("{num}")]
        public async Task<IActionResult> SaveImage(IFormFile file,int num)
        {
            try
            
            {
                // Check if file exists and is not empty
                if (file == null || file.Length == 0)
                    return BadRequest("No file uploaded.");

                //DeleteImage( num);
                // Define the path where you want to save the file
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                var filePath = Path.Combine(uploadsFolder, file.FileName);
                

                // Save the file to the specified path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                ImagesDTO imagesDTO=new ImagesDTO() {FileSize=1,FileName=file.FileName,ContentType=file.ContentType,Id=num };
                this.ImageService.SaveImage(imagesDTO);
                
                return Ok("File uploaded successfully.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
             
            }
        }


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteImage(int id)
        //{
        //    try
        //    {
        //        ImagesDTO imagesDTO=await ImageService.GetById(id);
        //        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        //        var filePath = Path.Combine(uploadsFolder, $"{imagesDTO.FileName}"); // אני מניח פה ששמות הקבצים הם לפי ה-ID שלהם עם סיומת jpg, אבל זה יכול להשתנות על פי הקונבנציה שלך

        //        if (System.IO.File.Exists(filePath))
        //        {
        //            System.IO.File.Delete(filePath);
        //            return Ok("File deleted successfully.");
        //        }
        //        else
        //        {
        //            return NotFound("File not found.");
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}


        [HttpGet("ImageId/{imageId}")]
        public async Task<ActionResult<ImagesDTO>> GetById(int imageId)
        {
            try
            {
                var imageDTO = await ImageService.GetById(imageId);
                return Ok(imageDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
