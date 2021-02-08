using DentistAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DentistAPI.Seeds
{
    public class ToothSurfaceSeed
    {
        private static readonly List<ToothSurface> Data = new List<ToothSurface>
        {
            new ToothSurface
            {
                Id = 1,
                Name = "Palatinální plocha"
            },
            new ToothSurface
            {
                Id = 2,
                Name = "Bukální plocha"
            },
            new ToothSurface
            {
                Id = 3,
                Name = "Distální plocha"
            },
            new ToothSurface
            {
                Id = 4,
                Name = "Meziální plocha"
            },
            new ToothSurface
            {
                Id = 5,
                Name = "Okluzní plocha"
            },
            new ToothSurface
            {
                Id = 6,
                Name = "Linguální plocua"
            },
            new ToothSurface
            {
                Id = 7,
                Name = "Labiální plocha"
            },
            new ToothSurface
            {
                Id = 8,
                Name = "Incizální hrana"
            },
        };
        public static void AddRelationships()
        {
            foreach (ToothSurface toothSurface in Data)
            {
                List<ToothToothSurface> toothToothSurfaces = ToothToothSurfaceSeed.Data.FindAll(tts => tts.SurfaceId == toothSurface.Id);
                toothSurface.ToothToothSurface = toothToothSurfaces;
                foreach (ToothToothSurface toothToothSurface in toothToothSurfaces)
                {
                    toothToothSurface.Surface = toothSurface;
                }

            }
        }
        public static void Seed(ModelBuilder modelBuilder)
               => modelBuilder.Entity<ToothSurface>().HasData(Data);
    }
}
