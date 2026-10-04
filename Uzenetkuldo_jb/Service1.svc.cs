using System.Collections.Generic;
using Uzenetkuldo_jb.Models;
using Uzenetkuldo_jb.Services;
using Uzenetkuldo_jb;

namespace Uzenetkuldo_jb
{
    public class Service1 : IService1
    {
        private readonly UzenetServices dbService = new UzenetServices();

        public List<Uzenet> GetUzenetek()
        {
            return dbService.GetAllUzenetek();
        }

        public void AddUzenet(Uzenet uzenet)
        {
            dbService.AddUzenet(uzenet);
        }

        public void UpdateUzenet(Uzenet uzenet)
        {
            dbService.UpdateUzenet(uzenet);
        }

        public void DeleteUzenet(string id)
        {
            if (int.TryParse(id, out int parsedId))
            {
                dbService.DeleteUzenet(parsedId);
            }
        }
    }
}