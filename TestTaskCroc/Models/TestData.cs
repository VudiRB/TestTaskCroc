using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestTaskCroc.Models
{
    public static class TestData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PGDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PGDbContext>>()))
            {
                if (context.Cars.Any())
                {
                    return;
                }

                context.Cars.AddRange(
                    new Cars()
                    {
                        Brand = "Ford",
                        Model = "Focus",
                        GovNumber = "Т747ММ777",
                        TypeOfGearShiftBox = Constants.GearShiftBox.Mechanic,
                        EngineVolume = 1.6m,
                        EngineForce = 105,
                        DepreciationCoef = 1.01m,
                        InsuranceCoef = 1.02m,
                        MaintenanceCoef = 1.03m,
                        CarCost = 1000000,
                        DateOfPurchase = DateTime.Parse("2015-2-12")
                    },
                    new Cars()
                    {
                        Brand = "Kia",
                        Model = "Rio",
                        GovNumber = "Т767ММ777",
                        TypeOfGearShiftBox = Constants.GearShiftBox.Automatic,
                        EngineVolume = 1.6m,
                        EngineForce = 145,
                        DepreciationCoef = 1.01m,
                        InsuranceCoef = 1.02m,
                        MaintenanceCoef = 1.03m,
                        CarCost = 900000,
                        DateOfPurchase = DateTime.Parse("2014-2-12")
                    },
                    new Cars()
                    {
                        Brand = "Kia",
                        Model = "Soul",
                        GovNumber = "Т749ММ777",
                        TypeOfGearShiftBox = Constants.GearShiftBox.Automatic,
                        EngineVolume = 1.6m,
                        EngineForce = 145,
                        DepreciationCoef = 1.01m,
                        InsuranceCoef = 1.02m,
                        MaintenanceCoef = 1.03m,
                        CarCost = 1100000,
                        DateOfPurchase = DateTime.Parse("2014-5-12")
                    },
                    new Cars()
                    {
                        Brand = "Nissan",
                        Model = "X-Trail",
                        GovNumber = "Т147ММ777",
                        TypeOfGearShiftBox = Constants.GearShiftBox.Automatic,
                        EngineVolume = 1.6m,
                        EngineForce = 149,
                        DepreciationCoef = 1.03m,
                        InsuranceCoef = 1.05m,
                        MaintenanceCoef = 1.07m,
                        CarCost = 1600000,
                        DateOfPurchase = DateTime.Parse("2016-5-12")
                    },
                    new Cars()
                    {
                        Brand = "Audi",
                        Model = "A6",
                        GovNumber = "Т777ММ777",
                        TypeOfGearShiftBox = Constants.GearShiftBox.Automatic,
                        EngineVolume = 2.0m,
                        EngineForce = 200,
                        DepreciationCoef = 1.1m,
                        InsuranceCoef = 1.15m,
                        MaintenanceCoef = 1.19m,
                        CarCost = 3100000,
                        DateOfPurchase = DateTime.Parse("2017-5-12")
                    }
                );
                
                
                if (context.Workers.Any())
                {
                    return;
                }

                context.Workers.AddRange(
                    new Workers()
                    {
                        FullName = "Иванов Иван Иванович",
                        Birthday  = DateTime.Parse("2068-5-12"),
                        PassportNumber = "4444 333333"
                    },
                    new Workers()
                    {
                        FullName = "Петров Иван Иванович",
                        Birthday  = DateTime.Parse("2064-5-12"),
                        PassportNumber = "4444 777333"
                    },
                    new Workers()
                    {
                        FullName = "Сидоров Иван Иванович",
                        Birthday  = DateTime.Parse("2069-5-12"),
                        PassportNumber = "4444 555333"
                    },
                    new Workers()
                    {
                        FullName = "Несидоров Иван Иванович",
                        Birthday  = DateTime.Parse("2067-5-12"),
                        PassportNumber = "4444 444333"
                    },
                    new Workers()
                    {
                        FullName = "Непетров Иван Иванович",
                        Birthday  = DateTime.Parse("2065-5-12"),
                        PassportNumber = "4444 555555"
                    }
                    
                );
                context.SaveChanges();
            }
        }
    }
}