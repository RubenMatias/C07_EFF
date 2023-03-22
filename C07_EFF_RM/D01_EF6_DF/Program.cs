using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;

namespace D01_EF6_DF
{
    public class Program
    {
        static void Main(string[] args)
        {

            #region 1. Declarar o contexto de bd

            var db = new NorthwindEntities();

            #endregion

            #region 2. Usar o contexto de bd

            using (db)  //instancia, usa e depois destroi
            {
                #region Nova region(1)

                Region region01 = new Region();
                Region region02 = new Region();
                Region region03 = new Region();

                region01.RegionID = 5;
                region01.RegionDescription = "Norte";

                region02.RegionID = 6;
                region02.RegionDescription = "Centro";

                region03.RegionID = 7;
                region03.RegionDescription = "Sul";

                db.Region.Add(region01);
                db.Region.Add(region02);
                db.Region.Add(region03);

                int countRows = db.SaveChanges();

                Utility.WriteTitle("Region");

                Utility.WriteMessage($"{countRows} regiões inseridas.", "", "\n\n");

                //listar com Linq as regiões (id-description)

                var queryRegion = db.Region.Select(r => r).OrderBy(r => r.RegionID).ToList();

                queryRegion.ForEach(r => Utility.WriteMessage($"{r.RegionID} - {r.RegionDescription}", "", "\n\n"));

                #endregion


                #region Novo Territory da Region (n)

                Territories territories01 = new Territories();
                Territories territories02 = new Territories();
                Territories territories03 = new Territories();
                Territories territories04 = new Territories();

                territories01.TerritoryID = "00001";
                territories01.TerritoryDescription = "Espinho";
                territories01.RegionID = 5;

                territories02.TerritoryID = "00002";
                territories02.TerritoryDescription = "Leiria";
                territories02.RegionID = 6;

                territories03.TerritoryID = "00003";
                territories03.TerritoryDescription = "Beja";
                territories03.RegionID = 7;

                db.Territories.Add(territories01);
                db.Territories.Add(territories02);
                db.Territories.Add(territories03);

                int countTerritories = db.SaveChanges();

                Utility.WriteTitle("Territory");

                Utility.WriteMessage($"{countTerritories} territories inseridos.", "", "\n\n");

                var queryTerritory = db.Territories.Select(t => t).OrderBy(t => t.TerritoryID).ToList();

                queryTerritory.ForEach(t => Utility.WriteMessage($"{t.TerritoryID}: {t.RegionID} -  {t.TerritoryDescription}","","\n\n"));

                #endregion

                #region Acrescentar novo funcionário

                EmployeeTerritories employeeTerritory01 = new EmployeeTerritories();
                Employees employee01 = new Employees();

                territories04.TerritoryID = "00004";
                territories04.TerritoryDescription = "Vila Nova de Gaia";
                territories04.RegionID = 5;

                db.Territories.Add(territories04);


                employeeTerritory01.TerritoryID = "00004";


                

                // employee01.EmployeeID = ?; não é necessário 
                employee01.FirstName = "Rúben";
                employee01.LastName = "Matias";

                int countNewEmployee = db.SaveChanges();

                Utility.WriteTitle("New Employee");

                // var newEmployee = db.Employees.GroupJoin()


                #endregion
















            }


            #endregion

            Utility.TerminateConsole();

        }
    }
}
