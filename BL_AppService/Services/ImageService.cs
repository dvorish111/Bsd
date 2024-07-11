using AutoMapper;
using BL_AppService.IServeces;
using Common;
using DAL.IRepositorys;
using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_AppService.Services
{
    public class ImageService:IImageService
    {
        IImageRepository imageRepository;
        IMapper mapper;
        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;

        }

        public Task Create(ImagesDTO ObjToAdd)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllEntities()
        {
            throw new NotImplementedException();
        }

        public Task<List<ImagesDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

     /*   public async Task<ImagesDTO> GetById(int id)
        {
            ImagesDTO imagesDTO= mapper.Map<ImagesDTO>(await imageRepository.GetById(id));
            imagesDTO.FileName= imagesDTO.FileName.Split('.')[0];
            return imagesDTO;

        }*/

        public async Task SaveImage(ImagesSaveDTO ImagesSaveDTO)
        {

            Images images= mapper.Map<Images>(ImagesSaveDTO);
            await imageRepository.SaveImage(images);
        }

        public Task Update(ImagesDTO ObjToUpdate)
        {
            throw new NotImplementedException();
        }
    /*    public async Task<string> GetImage(int id)
        {
           
            *//* var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

             var imagePath = Path.Combine(uploadsFolder, $"{images.FileName}"); // לדוגמה, התמונות בשרת נשמרות בפורמט JPG ושמות הקבצים הם ה-ID של התמונה

             return imagePath;*//*

        }*/
        public async Task<ImagesDTO> GetById(int id)
        {
            var image =  await imageRepository.GetById(id);

            if (image == null)
                return null;

            return new ImagesDTO
            {
                Id = image.Id,
                FileName = image.FileName,
                FileData = Convert.ToBase64String(image.FileData),
                ContentType = image.ContentType,
                Size = image.Size.Value
            };
            /*            return mapper.Map<ImagesDTO>(await imageRepository.GetById(id));
            */
        }

        private async Task<byte[]> ConvertToBytes(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
