using System;
using System.Collections.Generic;
using DentistAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DentistAPI.Seeds
{
    public class ToothSeed
    {
        private static readonly List<Tooth> Data = new List<Tooth>
        {
            #region 1. kvadrant
            new Tooth
            {
                Id = 1,
                Localization = "11",
                Deciduous = false
            },
            new Tooth
            {
                Id = 2,
                Localization = "12",
                Deciduous = false
            },
            new Tooth
            {
                Id = 3,
                Localization = "13",
                Deciduous = false
            },
            new Tooth
            {
                Id = 4,
                Localization = "14",
                Deciduous = false
            },
            new Tooth
            {
                Id = 5,
                Localization = "15",
                Deciduous = false
            },
            new Tooth
            {
                Id = 6,
                Localization = "16",
                Deciduous = false
            },
            new Tooth
            {
                Id = 7,
                Localization = "17",
                Deciduous = false
            },
            new Tooth
            {
                Id = 8,
                Localization = "18",
                Deciduous = false
            },
            #endregion

            #region 2. kvadrant
            new Tooth
            {
                Id = 9,
                Localization = "21",
                Deciduous = false
            },
            new Tooth
            {
                Id = 10,
                Localization = "22",
                Deciduous = false
            },
            new Tooth
            {
                Id = 11,
                Localization = "23",
                Deciduous = false
            },
            new Tooth
            {
                Id = 12,
                Localization = "24",
                Deciduous = false
            },
            new Tooth
            {
                Id = 13,
                Localization = "25",
                Deciduous = false
            },
            new Tooth
            {
                Id = 14,
                Localization = "26",
                Deciduous = false
            },
            new Tooth
            {
                Id = 15,
                Localization = "27",
                Deciduous = false
            },
            new Tooth
            {
                Id = 16,
                Localization = "28",
                Deciduous = false
            },
            #endregion

            #region 3. kvadrant
            new Tooth
            {
                Id = 17,
                Localization = "31",
                Deciduous = false
            },
            new Tooth
            {
                Id = 18,
                Localization = "32",
                Deciduous = false
            },
            new Tooth
            {
                Id = 19,
                Localization = "33",
                Deciduous = false
            },
            new Tooth
            {
                Id = 20,
                Localization = "34",
                Deciduous = false
            },
            new Tooth
            {
                Id = 21,
                Localization = "35",
                Deciduous = false
            },
            new Tooth
            {
                Id = 22,
                Localization = "36",
                Deciduous = false
            },
            new Tooth
            {
                Id = 23,
                Localization = "37",
                Deciduous = false
            },
            new Tooth
            {
                Id = 24,
                Localization = "38",
                Deciduous = false
            },
            #endregion 

            #region 4. kavadrant
            new Tooth
            {
                Id = 25,
                Localization = "41",
                Deciduous = false
            },
            new Tooth
            {
                Id = 26,
                Localization = "42",
                Deciduous = false
            },
            new Tooth
            {
                Id = 27,
                Localization = "43",
                Deciduous = false
            },
            new Tooth
            {
                Id = 28,
                Localization = "44",
                Deciduous = false
            },
            new Tooth
            {
                Id = 29,
                Localization = "45",
                Deciduous = false
            },
            new Tooth
            {
                Id = 30,
                Localization = "46",
                Deciduous = false
            },
            new Tooth
            {
                Id = 31,
                Localization = "47",
                Deciduous = false
            },
            new Tooth
            {
                Id = 32,
                Localization = "48",
                Deciduous = false
            }
            #endregion
        };
        public static void AddRelationships()
        {
            foreach(Tooth tooth in Data)
            {
                List<ToothToothSurface> toothToothSurfaces = ToothToothSurfaceSeed.Data.FindAll(tts=>tts.ToothId == tooth.Id);
                tooth.ToothToothSurface = toothToothSurfaces;
                foreach(ToothToothSurface toothToothSurface in toothToothSurfaces)
                {
                    toothToothSurface.Tooth = tooth;
                }

            }
         }
        public static void Seed(ModelBuilder modelBuilder)
            => modelBuilder.Entity<Tooth>().HasData(Data);
    }
}
