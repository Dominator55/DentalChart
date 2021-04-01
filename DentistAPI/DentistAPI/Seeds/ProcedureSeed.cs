using DentistAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DentistAPI.Seeds
{
    public class ProcedureSeed
    {
        private static readonly List<Procedure> Data = new List<Procedure>
        {
            new Procedure
            {
                Id = 1,
                Code = "00920",
                Name = "Ošetření stálého zubu fotokompozitní výplní",
                DisplayName = "White Filling"
            }
        };
        public static void Seed(ModelBuilder modelBuilder)
            => modelBuilder.Entity<Procedure>().HasData(Data);
    }
}
