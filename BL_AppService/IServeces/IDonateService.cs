using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL.Models;

namespace BL_AppService.IServeces
{
    public interface IDonateService: IService<DonateDTO>
    {
        List<Donate> GetAllByNeeded(double id);
        List<Donate> GetAllByStatus(int id);
        List<Donate> GetAllByNumOfChildren(int from, int to);

    }
}
