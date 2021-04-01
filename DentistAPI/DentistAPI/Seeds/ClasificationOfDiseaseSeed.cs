using DentistAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DentistAPI.Seeds
{
    public class ClassificationOfDiseaseSeed
    {
        private static readonly List<ClassificationOfDisease> Data = new List<ClassificationOfDisease>
        {
            new ClassificationOfDisease
            {
                Id = 1,
                Code = "K02",
                Name = "Zubní kaz",
                DisplayName = "Decay"
            }
        };
        public static void Seed(ModelBuilder modelBuilder)
            => modelBuilder.Entity<ClassificationOfDisease>().HasData(Data);
    }
}
