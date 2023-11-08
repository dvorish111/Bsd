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
        List<DonateDTO> GetAllByNeeded(double id);
        List<DonateDTO> GetAllByStatus(int id);
        List<DonateDTO> GetAllByNumOfChildren(int from, int to);

    }
}
