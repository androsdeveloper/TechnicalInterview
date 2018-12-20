
namespace MasGlobal.Interview.BusinessLogic
{
    using Dto;
    using System.Collections.Generic;
    using Dao;
    using MasGlobal.Interview.Interfaces;
    using System.Linq;

    public class BlEmployees : IBlEmployees
    {
        IDaoEmployees daoEmployees;
        List<DtoEmployees> lstEmployees;
        public BlEmployees(IDaoEmployees daoEmployees)
        {
            this.daoEmployees = daoEmployees;
            lstEmployees = new List<DtoEmployees>();

        }
        public List<DtoEmployees> GetEmployees(int? id)
        {
            lstEmployees = this.daoEmployees.GetEmployees();

            if (id != null)
            {
                lstEmployees = lstEmployees.Where(c=>c.Id == id).ToList();
            }

            foreach (var item in lstEmployees)
            {
                if (item.ContractTypeName == ResourceFile.HourlySalary)
                {
                    item.CalculatedAnualSalary = 120 * item.HourlySalary * 12;
                }
                else
                {
                    item.CalculatedAnualSalary = item.MonthlySalary * 12;
                }
            }

            return lstEmployees;
        }
    }
}
