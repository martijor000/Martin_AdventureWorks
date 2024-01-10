using Martin_AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_AdventureWorks.Services
{
    public interface IAdventureWorksService
    {
        List<MasterListModel> MasterListModels { get; }
        PersonDetailsModel PersonDetailsModels { get; }
        Task GetMasterList();
        Task<PersonDetailsModel> GetPersonDetails(int id);
        
    }
}
