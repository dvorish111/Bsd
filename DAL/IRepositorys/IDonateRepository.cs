using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositorys
{
    public interface IDonateRepository: IRepository<Donate>
    {
        Donate GetByTaz(int donateTaz);
         List<Donate> GetAllByNeeded(double id);
         List<Donate> GetAllByStatus(int id);
         List<Donate> GetAllByNumOfChildren(int to);
         int GetNumFamily();
         int GetNumChildren();
        void CraeteDonatesByExcel(List<Donate> donates);
    }
}
