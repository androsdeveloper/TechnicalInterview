using System;
using System.Collections.Generic;
using Dao;
using Dto;
using MasGlobal.Interview.BusinessLogic;
using MasGlobal.Interview.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void TechnicalInterview_GetEmployees_SuccessWithIdNull()
        {
            //Arrange
            var stubDaoEmployee = new Mock<IDaoEmployees>();

            List<DtoEmployees> lstEmployee = new List<DtoEmployees>();

            lstEmployee.Add(new DtoEmployees { CalculatedAnualSalary = 100000, Name = "Sebastian", Id = 1, HourlySalary = 1000 });
            lstEmployee.Add(new DtoEmployees { CalculatedAnualSalary = 200000, Name = "Andrés", Id = 1, HourlySalary = 5000 });

            IBlEmployees blEmployee = new BlEmployees(stubDaoEmployee.Object);

            stubDaoEmployee.Setup(x => x.GetEmployees()).Returns( lstEmployee );


            //Act
            var resultado = blEmployee.GetEmployees(null);

            //Assert
            Assert.AreEqual(resultado, lstEmployee);
        }

        [TestMethod]
        public void TechnicalInterview_GetEmployees_SuccessWithIdValue()
        {
            //Arrange
            var stubDaoEmployee = new Mock<IDaoEmployees>();

            List<DtoEmployees> lstEmployee = new List<DtoEmployees>();

            lstEmployee.Add(new DtoEmployees { CalculatedAnualSalary = 100000, Name = "Sebastian", Id = 1, HourlySalary = 1000, MonthlySalary =1000 });
            lstEmployee.Add(new DtoEmployees { CalculatedAnualSalary = 200000, Name = "Andrés", Id = 2, HourlySalary = 5000, MonthlySalary = 1000 });

            List<DtoEmployees> lstResult = new List<DtoEmployees>();

            lstResult.Add(new DtoEmployees { CalculatedAnualSalary = 12000, Name = "Sebastian", Id = 1, HourlySalary = 1000, MonthlySalary = 1000 });


            IBlEmployees blEmployee = new BlEmployees(stubDaoEmployee.Object);

            stubDaoEmployee.Setup(x => x.GetEmployees()).Returns(lstEmployee);


            //Act
            var resultado = blEmployee.GetEmployees(1);

            //Assert
            Assert.ReferenceEquals(resultado, lstResult);
        }


    }
}
