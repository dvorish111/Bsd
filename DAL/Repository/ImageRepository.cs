using DAL.IRepositorys;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   //ImageContext _context;
    public class ImageRepository  : IImageRepository
    {
        CampainContext _context;

        public ImageRepository(CampainContext context)
        {
            _context = context;
          
        }
        public Task Create(Images ObjToAdd)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var images = _context.Images.FirstOrDefault(I => I.Id == id);
            if (images != null)
            {
                _context.Images.Remove(images);
                _context.SaveChanges();
            }
            _context.SaveChanges();
        }
        //public void  Deletes(int id)
        //{
        //    var images = _context.Images.FirstOrDefault(I => I.Id == id);
        //    if (images != null)
        //    {
        //        _context.Images.Remove(images);
        //         _context.SaveChanges();
        //    }
        //    _context.SaveChanges();
        //}
        public Task DeleteAllEntities()
        {
            throw new NotImplementedException();
        }

        public Task<List<Images>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Images> GetById(int id)
        {
           
            return await _context.Images.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task SaveImage(Images images)
        {
            Delete(images.Id);

            /*
                         _context.Images.AddAsync(images);
                        await _context.SaveChangesAsync();*/

            _context.Images.Add(images);
            await _context.SaveChangesAsync();

        }



        public Task Update(Images ObjToUpdate)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Images>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
