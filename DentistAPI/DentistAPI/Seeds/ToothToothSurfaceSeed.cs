using System.Collections.Generic;
using DentistAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DentistAPI.Seeds
{
    public class ToothToothSurfaceSeed
    {
        public static List<ToothToothSurface> Data = new List<ToothToothSurface>
        {
            #region 1.kvadrant
            new ToothToothSurface{ToothId = 1, SurfaceId = 1},    //11 palatinální plocha
            new ToothToothSurface{ToothId = 1, SurfaceId = 3},    //11 distální plocha
            new ToothToothSurface{ToothId = 1, SurfaceId = 4},    //11 meziální plocha
            new ToothToothSurface{ToothId = 1, SurfaceId = 8},    //11 incizální hrana
            new ToothToothSurface{ToothId = 1, SurfaceId = 7},    //11 labiální plocha

            new ToothToothSurface{ToothId = 2, SurfaceId = 1},    //12 palatinální plocha
            new ToothToothSurface{ToothId = 2, SurfaceId = 3},    //12 distální plocha
            new ToothToothSurface{ToothId = 2, SurfaceId = 4},    //12 meziální plocha
            new ToothToothSurface{ToothId = 2, SurfaceId = 8},    //12 incizální hrana
            new ToothToothSurface{ToothId = 2, SurfaceId = 7},    //12 labiální plocha

            new ToothToothSurface{ToothId = 3, SurfaceId = 1},    //13 palatinální plocha
            new ToothToothSurface{ToothId = 3, SurfaceId = 3},    //13 distální plocha
            new ToothToothSurface{ToothId = 3, SurfaceId = 4},    //13 meziální plocha
            new ToothToothSurface{ToothId = 3, SurfaceId = 8},    //13 incizální hrana
            new ToothToothSurface{ToothId = 3, SurfaceId = 7},    //13 labiální plocha

            new ToothToothSurface{ToothId = 4, SurfaceId = 1},    //14 palatinální plocha
            new ToothToothSurface{ToothId = 4, SurfaceId = 3},    //14 distální plocha
            new ToothToothSurface{ToothId = 4, SurfaceId = 4},    //14 meziální plocha
            new ToothToothSurface{ToothId = 4, SurfaceId = 5},    //14 okluzní plocha
            new ToothToothSurface{ToothId = 4, SurfaceId = 2},    //14 bukální plocha

            new ToothToothSurface{ToothId = 5, SurfaceId = 1},    //15 palatinální plocha
            new ToothToothSurface{ToothId = 5, SurfaceId = 3},    //15 distální plocha
            new ToothToothSurface{ToothId = 5, SurfaceId = 4},    //15 meziální plocha
            new ToothToothSurface{ToothId = 5, SurfaceId = 5},    //15 okluzní plocha
            new ToothToothSurface{ToothId = 5, SurfaceId = 2},    //15 bukální plocha
        
            new ToothToothSurface{ToothId = 6, SurfaceId = 1},    //16 palatinální plocha
            new ToothToothSurface{ToothId = 6, SurfaceId = 3},    //16 distální plocha
            new ToothToothSurface{ToothId = 6, SurfaceId = 4},    //16 meziální plocha
            new ToothToothSurface{ToothId = 6, SurfaceId = 5},    //16 okluzní plocha
            new ToothToothSurface{ToothId = 6, SurfaceId = 2},    //16 bukální plocha

            new ToothToothSurface{ToothId = 7, SurfaceId = 1},    //17 palatinální plocha
            new ToothToothSurface{ToothId = 7, SurfaceId = 3},    //17 distální plocha
            new ToothToothSurface{ToothId = 7, SurfaceId = 4},    //17 meziální plocha
            new ToothToothSurface{ToothId = 7, SurfaceId = 5},    //17 okluzní plocha
            new ToothToothSurface{ToothId = 7, SurfaceId = 2},    //17 bukální plocha

            new ToothToothSurface{ToothId = 8, SurfaceId = 1},    //18 palatinální plocha
            new ToothToothSurface{ToothId = 8, SurfaceId = 3},    //18 distální plocha
            new ToothToothSurface{ToothId = 8, SurfaceId = 4},    //18 meziální plocha
            new ToothToothSurface{ToothId = 8, SurfaceId = 5},    //18 okluzní plocha
            new ToothToothSurface{ToothId = 8, SurfaceId = 2},    //18 bukální plocha
            #endregion

            #region 2.kvadrant
            new ToothToothSurface{ToothId = 9, SurfaceId = 1},    //21 palatinální plocha
            new ToothToothSurface{ToothId = 9, SurfaceId = 3},    //21 distální plocha
            new ToothToothSurface{ToothId = 9, SurfaceId = 4},    //21 meziální plocha
            new ToothToothSurface{ToothId = 9, SurfaceId = 8},    //21 incizální hrana
            new ToothToothSurface{ToothId = 9, SurfaceId = 7},    //21 labiální plocha
            
            new ToothToothSurface{ToothId = 10, SurfaceId = 1},    //22 palatinální plocha
            new ToothToothSurface{ToothId = 10, SurfaceId = 3},    //22 distální plocha
            new ToothToothSurface{ToothId = 10, SurfaceId = 4},    //22 meziální plocha
            new ToothToothSurface{ToothId = 10, SurfaceId = 8},    //22 incizální hrana
            new ToothToothSurface{ToothId = 10, SurfaceId = 7},    //22 labiální plocha

            new ToothToothSurface{ToothId = 11, SurfaceId = 1},    //23 palatinální plocha
            new ToothToothSurface{ToothId = 11, SurfaceId = 3},    //23 distální plocha
            new ToothToothSurface{ToothId = 11, SurfaceId = 4},    //23 meziální plocha
            new ToothToothSurface{ToothId = 11, SurfaceId = 8},    //23 incizální hrana
            new ToothToothSurface{ToothId = 11, SurfaceId = 7},    //23 labiální plocha

            new ToothToothSurface{ToothId = 12, SurfaceId = 1},    //24 palatinální plocha
            new ToothToothSurface{ToothId = 12, SurfaceId = 3},    //24 distální plocha
            new ToothToothSurface{ToothId = 12, SurfaceId = 4},    //24 meziální plocha
            new ToothToothSurface{ToothId = 12, SurfaceId = 5},    //24 okluzní plocha
            new ToothToothSurface{ToothId = 12, SurfaceId = 2},    //24 bukální plocha

            new ToothToothSurface{ToothId = 13, SurfaceId = 1},    //25 palatinální plocha
            new ToothToothSurface{ToothId = 13, SurfaceId = 3},    //25 distální plocha
            new ToothToothSurface{ToothId = 13, SurfaceId = 4},    //25 meziální plocha
            new ToothToothSurface{ToothId = 13, SurfaceId = 5},    //25 okluzní plocha
            new ToothToothSurface{ToothId = 13, SurfaceId = 2},    //25 bukální plocha
        
            new ToothToothSurface{ToothId = 14, SurfaceId = 1},    //26 palatinální plocha
            new ToothToothSurface{ToothId = 14, SurfaceId = 3},    //26 distální plocha
            new ToothToothSurface{ToothId = 14, SurfaceId = 4},    //26 meziální plocha
            new ToothToothSurface{ToothId = 14, SurfaceId = 5},    //26 okluzní plocha
            new ToothToothSurface{ToothId = 14, SurfaceId = 2},    //26 bukální plocha

            new ToothToothSurface{ToothId = 15, SurfaceId = 1},    //27 palatinální plocha
            new ToothToothSurface{ToothId = 15, SurfaceId = 3},    //27 distální plocha
            new ToothToothSurface{ToothId = 15, SurfaceId = 4},    //27 meziální plocha
            new ToothToothSurface{ToothId = 15, SurfaceId = 5},    //27 okluzní plocha
            new ToothToothSurface{ToothId = 15, SurfaceId = 2},    //27 bukální plocha

            new ToothToothSurface{ToothId = 16, SurfaceId = 1},    //28 palatinální plocha
            new ToothToothSurface{ToothId = 16, SurfaceId = 3},    //28 distální plocha
            new ToothToothSurface{ToothId = 16, SurfaceId = 4},    //28 meziální plocha
            new ToothToothSurface{ToothId = 16, SurfaceId = 5},    //28 okluzní plocha
            new ToothToothSurface{ToothId = 16, SurfaceId = 2},    //28 bukální plocha
            #endregion

            #region 3.kvadrant
            new ToothToothSurface{ToothId = 17, SurfaceId = 6},    //31 linguální plocha
            new ToothToothSurface{ToothId = 17, SurfaceId = 3},    //31 distální plocha
            new ToothToothSurface{ToothId = 17, SurfaceId = 4},    //31 meziální plocha
            new ToothToothSurface{ToothId = 17, SurfaceId = 8},    //31 incizální hrana
            new ToothToothSurface{ToothId = 17, SurfaceId = 7},    //31 labiální plocha

            new ToothToothSurface{ToothId = 18, SurfaceId = 6},    //32 linguální plocha
            new ToothToothSurface{ToothId = 18, SurfaceId = 3},    //32 distální plocha
            new ToothToothSurface{ToothId = 18, SurfaceId = 4},    //32 meziální plocha
            new ToothToothSurface{ToothId = 18, SurfaceId = 8},    //32 incizální hrana
            new ToothToothSurface{ToothId = 18, SurfaceId = 7},    //32 labiální plocha

            new ToothToothSurface{ToothId = 19, SurfaceId = 6},    //33 linguální plocha
            new ToothToothSurface{ToothId = 19, SurfaceId = 3},    //33 distální plocha
            new ToothToothSurface{ToothId = 19, SurfaceId = 4},    //33 meziální plocha
            new ToothToothSurface{ToothId = 19, SurfaceId = 8},    //33 incizální hrana
            new ToothToothSurface{ToothId = 19, SurfaceId = 7},    //33 labiální plocha

            new ToothToothSurface{ToothId = 20, SurfaceId = 6},    //34 linguální plocha
            new ToothToothSurface{ToothId = 20, SurfaceId = 3},    //34 distální plocha
            new ToothToothSurface{ToothId = 20, SurfaceId = 4},    //34 meziální plocha
            new ToothToothSurface{ToothId = 20, SurfaceId = 5},    //34 okluzní plocha
            new ToothToothSurface{ToothId = 20, SurfaceId = 2},    //34 bukální plocha

            new ToothToothSurface{ToothId = 21, SurfaceId = 6},    //35 linguální plocha
            new ToothToothSurface{ToothId = 21, SurfaceId = 3},    //35 distální plocha
            new ToothToothSurface{ToothId = 21, SurfaceId = 4},    //35 meziální plocha
            new ToothToothSurface{ToothId = 21, SurfaceId = 5},    //35 okluzní plocha
            new ToothToothSurface{ToothId = 21, SurfaceId = 2},    //35 bukální plocha
        
            new ToothToothSurface{ToothId = 22, SurfaceId = 6},    //36 linguální plocha
            new ToothToothSurface{ToothId = 22, SurfaceId = 3},    //36 distální plocha
            new ToothToothSurface{ToothId = 22, SurfaceId = 4},    //36 meziální plocha
            new ToothToothSurface{ToothId = 22, SurfaceId = 5},    //36 okluzní plocha
            new ToothToothSurface{ToothId = 22, SurfaceId = 2},    //36 bukální plocha

            new ToothToothSurface{ToothId = 23, SurfaceId = 6},    //37 linguální plocha
            new ToothToothSurface{ToothId = 23, SurfaceId = 3},    //37 distální plocha
            new ToothToothSurface{ToothId = 23, SurfaceId = 4},    //37 meziální plocha
            new ToothToothSurface{ToothId = 23, SurfaceId = 5},    //37 okluzní plocha
            new ToothToothSurface{ToothId = 23, SurfaceId = 2},    //37 bukální plocha

            new ToothToothSurface{ToothId = 24, SurfaceId = 6},    //38 linguální plocha
            new ToothToothSurface{ToothId = 24, SurfaceId = 3},    //38 distální plocha
            new ToothToothSurface{ToothId = 24, SurfaceId = 4},    //38 meziální plocha
            new ToothToothSurface{ToothId = 24, SurfaceId = 5},    //38 okluzní plocha
            new ToothToothSurface{ToothId = 24, SurfaceId = 2},    //38 bukální plocha
            #endregion

            #region 4.kvadrant
            new ToothToothSurface{ToothId = 25, SurfaceId = 6},    //41 linguální plocha
            new ToothToothSurface{ToothId = 25, SurfaceId = 3},    //41 distální plocha
            new ToothToothSurface{ToothId = 25, SurfaceId = 4},    //41 meziální plocha
            new ToothToothSurface{ToothId = 25, SurfaceId = 8},    //41 incizální hrana
            new ToothToothSurface{ToothId = 25, SurfaceId = 7},    //41 labiální plocha
        
            new ToothToothSurface{ToothId = 26, SurfaceId = 6},    //42 linguální plocha
            new ToothToothSurface{ToothId = 26, SurfaceId = 3},    //42 distální plocha
            new ToothToothSurface{ToothId = 26, SurfaceId = 4},    //42 meziální plocha
            new ToothToothSurface{ToothId = 26, SurfaceId = 8},    //42 incizální hrana
            new ToothToothSurface{ToothId = 26, SurfaceId = 7},    //42 labiální plocha

            new ToothToothSurface{ToothId = 27, SurfaceId = 6},    //43 linguální plocha
            new ToothToothSurface{ToothId = 27, SurfaceId = 3},    //43 distální plocha
            new ToothToothSurface{ToothId = 27, SurfaceId = 4},    //43 meziální plocha
            new ToothToothSurface{ToothId = 27, SurfaceId = 8},    //43 incizální hrana
            new ToothToothSurface{ToothId = 27, SurfaceId = 7},    //43 labiální plocha
        
            new ToothToothSurface{ToothId = 28, SurfaceId = 6},    //44 linguální plocha
            new ToothToothSurface{ToothId = 28, SurfaceId = 3},    //44 distální plocha
            new ToothToothSurface{ToothId = 28, SurfaceId = 4},    //44 meziální plocha
            new ToothToothSurface{ToothId = 28, SurfaceId = 5},    //44 okluzní plocha
            new ToothToothSurface{ToothId = 28, SurfaceId = 2},    //44 bukální plocha

            new ToothToothSurface{ToothId = 29, SurfaceId = 6},    //45 linguální plocha
            new ToothToothSurface{ToothId = 29, SurfaceId = 3},    //45 distální plocha
            new ToothToothSurface{ToothId = 29, SurfaceId = 4},  //45 meziální plocha
            new ToothToothSurface{ToothId = 29, SurfaceId = 5},    //45 okluzní plocha
            new ToothToothSurface{ToothId = 29, SurfaceId = 2},    //45 bukální plocha
        
            new ToothToothSurface{ToothId = 30, SurfaceId = 6},    //46 linguální plocha
            new ToothToothSurface{ToothId = 30, SurfaceId = 3},    //46 distální plocha
            new ToothToothSurface{ToothId = 30, SurfaceId = 4},    //46 meziální plocha
            new ToothToothSurface{ToothId = 30, SurfaceId = 5},    //46 okluzní plocha
            new ToothToothSurface{ToothId = 30, SurfaceId = 2},    //46 bukální plocha

            new ToothToothSurface{ToothId = 31, SurfaceId = 6},    //47 linguální plocha
            new ToothToothSurface{ToothId = 31, SurfaceId = 3},    //47 distální plocha
            new ToothToothSurface{ToothId = 31, SurfaceId = 4},    //47 meziální plocha
            new ToothToothSurface{ToothId = 31, SurfaceId = 5},    //47 okluzní plocha
            new ToothToothSurface{ToothId = 31, SurfaceId = 2},    //47 bukální plocha

            new ToothToothSurface{ToothId = 32, SurfaceId = 6},    //48 linguální plocha
            new ToothToothSurface{ToothId = 32, SurfaceId = 3},    //48 distální plocha
            new ToothToothSurface{ToothId = 32, SurfaceId = 4},    //48 meziální plocha
            new ToothToothSurface{ToothId = 32, SurfaceId = 5},    //48 okluzní plocha
            new ToothToothSurface{ToothId = 32, SurfaceId = 2}     //48 bukální plocha
            #endregion
        };
        public static void Seed(ModelBuilder modelBuilder)
           => modelBuilder.Entity<ToothToothSurface>().HasData(Data);
    }
}
