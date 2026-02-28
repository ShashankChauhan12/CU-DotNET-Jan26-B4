using BonusCalculation;
using NUnit.Framework;
using System;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NormalHighPerformer_NoCap_NoPenalty()
        {
            var employee = new EmployeeBonus
            {
                BaseSalary = 500000m,
                PerformanceRating = 5,
                YearsOfExperience = 6,
                DepartmentMultiplier = 1.1m,
                AttendancePercentage = 95
            };

            var result = employee.NetAnnualBonus;

            Assert.AreEqual(123200.00m, result);
        }

        [Test]
        public void AttendanceBelow85_ShouldApplyPenalty()
        {
            var employee = new EmployeeBonus
            {
                BaseSalary = 400000m,
                PerformanceRating = 4,
                YearsOfExperience = 8,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 80
            };

            var result = employee.NetAnnualBonus;

            Assert.AreEqual(60480.00m, result);
        }

        [Test]
        public void BonusShouldBeCappedAt40Percent()
        {
            var employee = new EmployeeBonus
            {
                BaseSalary = 1000000m,
                PerformanceRating = 5,
                YearsOfExperience = 15,
                DepartmentMultiplier = 1.5m,
                AttendancePercentage = 95
            };

            var result = employee.NetAnnualBonus;

            Assert.AreEqual(280000.00m, result);
        }

        [Test]
        public void BonusUnder150K_ShouldApply10PercentTax()
        {
            var employee = new EmployeeBonus
            {
                BaseSalary = 300000m,
                PerformanceRating = 2,
                YearsOfExperience = 3,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 90
            };

            var result = employee.NetAnnualBonus;

            Assert.AreEqual(13500.00m, result);
        }

        [Test]
        public void Exact150KBoundary_ShouldApply10PercentTax()
        {
            var employee = new EmployeeBonus
            {
                BaseSalary = 600000m,
                PerformanceRating = 3,
                YearsOfExperience = 0,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 100
            };

            var result = employee.NetAnnualBonus;

            Assert.AreEqual(64800.00m, result);
        }

        [Test]
        public void BonusAbove300K_ShouldApply30PercentTax()
        {
            var employee = new EmployeeBonus
            {
                BaseSalary = 900000m,
                PerformanceRating = 5,
                YearsOfExperience = 11,
                DepartmentMultiplier = 1.2m,
                AttendancePercentage = 100
            };

            var result = employee.NetAnnualBonus;

            Assert.AreEqual(226800.00m, result);
        }

        [Test]
        public void InvalidRating_ShouldThrowException()
        {
            var employee = new EmployeeBonus
            {
                BaseSalary = 500000m,
                PerformanceRating = 6,
                YearsOfExperience = 5,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 95
            };

            Assert.Throws<InvalidOperationException>(() =>
            {
                var result = employee.NetAnnualBonus;
            });
        }

        [Test]
        public void ZeroSalary_ShouldReturnZero()
        {
            var employee = new EmployeeBonus
            {
                BaseSalary = 0m,
                PerformanceRating = 5,
                YearsOfExperience = 10,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 95
            };

            var result = employee.NetAnnualBonus;

            Assert.AreEqual(0.00m, result);
        }

        [Test]
        public void ShouldRoundToTwoDecimalPlaces()
        {
            var employee = new EmployeeBonus
            {
                BaseSalary = 555555m,
                PerformanceRating = 4,
                YearsOfExperience = 6,
                DepartmentMultiplier = 1.13m,
                AttendancePercentage = 92
            };

            var result = employee.NetAnnualBonus;

            Assert.AreEqual(118649.88m, result);
        }
    }
}