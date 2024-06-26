﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositorys
{
    public interface IDonateRepository: IRepository<Donate>
    {
        Task<Donate> GetByTaz(string donateTaz);
        Task<List<Donate>> GetAllByNeeded(double id);
        Task<List<Donate>> GetAllByStatus(int id);
        Task<List<Donate>> GetAllByNumOfChildren(int to);
         Task<int> GetNumFamily();
         Task<int> GetNumChildren();
        Task<List<int>> CraeteDonatesByExcel(List<Donate> donates);
        void UpdateRaised(int? id, int raised);
    }
}
