using System;
using System.Collections.Generic;
using System.Text;

namespace KargoTakip.DataAccsess.Abstract.Example2
{
    public class KargoManager : IKargoTeslim
    {
        private IKargoRepository _kargoRepository;
        public KargoManager(IKargoRepository kargoRepository)
        {
            _kargoRepository = kargoRepository;
        }

        public Kargo CreateKargo(Kargo kargo)
        {
            return _kargoRepository.CreateKargo(kargo);
        }

        public void DeleteKargo(int id)
        {
            _kargoRepository.DeleteKargo(id);
        }

        public List<Kargo> GetAllKargolar()
        {
            return _kargoRepository.GetAllKargolar();
        }

        public Kargo GetKargoById(int id)
        {
            if (id > 0)
            {
                return _kargoRepository.GetKargoById(id);
            }
            throw new Exception("id can not be less than 1");
        }

        public Kargo GetKargoByName(string name)
        {
            return _kargoRepository.GetKargoByName(name);
        }


        public Kargo UpdateKargo(Kargo kargo)
        {
            return _kargoRepository.UpdateKargo(kargo);
        }
    }
}