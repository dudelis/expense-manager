using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Concrete
{
    public class ProfileMemberManager : IProfileMemberService
    {
        private readonly IRepositoryWrapper _wrapper;

        public ProfileMemberManager(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public void Create(ProfileMember entity)
        {
            _wrapper.ProfileMember.Create(entity);
        }

        public void Delete(ProfileMember entity)
        {
            _wrapper.ProfileMember.Delete(entity);
        }

        public List<ProfileMember> GetAll()
        {
            return _wrapper.ProfileMember.GetList();
        }

        public ProfileMember GetById(int id)
        {
            return _wrapper.ProfileMember.Get(x => x.Id == id);
        }

        public bool ItemExists(int id)
        {
            return _wrapper.ProfileMember.ItemExists(x => x.Id == id);
        }

        public bool ItemExists(string userId)
        {
            return _wrapper.ProfileMember.ItemExists(x => x.UserId == userId);
        }

        public void SaveChanges()
        {
            _wrapper.Save();
        }

        public void Update(ProfileMember entity)
        {
            _wrapper.ProfileMember.Update(entity);
        }
    }
}
