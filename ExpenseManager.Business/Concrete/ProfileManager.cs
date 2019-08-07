using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Concrete
{
    public class ProfileManager : IProfileService
    {
        private readonly IRepositoryWrapper _wrapper;

        public ProfileManager(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public void Create(Profile entity)
        {
            _wrapper.Profile.Create(entity);
        }

        public void Delete(Profile entity)
        {
            _wrapper.Profile.Delete(entity);
        }

        public List<Profile> GetAll()
        {
            return _wrapper.Profile.GetList();
        }

        public Profile GetById(int id)
        {
            return _wrapper.Profile.Get(x => x.Id == id);
        }

        public bool ItemExists(int id)
        {
            return _wrapper.Profile.ItemExists(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _wrapper.Save();
        }

        public void Update(Profile entity)
        {
            _wrapper.Profile.Update(entity);
        }
    }
}
