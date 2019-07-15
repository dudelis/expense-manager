using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Concrete
{
    public class PayeeManager: IPayeeService
    {
        private IRepositoryWrapper _repository;
        public PayeeManager(IRepositoryWrapper wrapper)
        {
            _repository = wrapper;
        }

        public void Create(Payee entity)
        {
            _repository.Payee.Create(entity);
        }

        public void Delete(Payee entity)
        {
            throw new NotImplementedException();
        }

        public List<Payee> GetAll()
        {
            return _repository.Payee.GetList();
        }

        public Payee GetById(int id)
        {
            return _repository.Payee.Get(x => x.Id == id);
        }

        public bool ItemExists(int id)
        {
            return _repository.Payee.ItemExists(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _repository.Save();
        }

        public void Update(Payee entity)
        {
            _repository.Payee.Update(entity);
        }
    }
}
