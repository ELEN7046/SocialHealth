using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using MySql.Data.MySqlClient;
using System.ServiceModel.Web;

namespace SocialHealth
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Health" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Health.svc or Health.svc.cs at the Solution Explorer and start debugging.
    public class Health : IHealth
    {
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "gethealthprofiles")]
        List<HealthProfile> IHealth.getHealthProfiles()
        {
            List<HealthProfile> healthprofiles = new List<HealthProfile>();
            string connectionString = "Server=winmysqls03.cpt.wa.co.za;Port=3307;Uid=wits01;Pwd=Pr0ject;Database=waronpoverty;";
            using (MySqlConnection connection = new MySqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                string sql;
                sql = "SELECT * FROM tbl_7046provincedistrictlocalhealthneeds ";
                   // + "Order by Year, Province, District, LocalMunicipality, Needs, HaveDifficulty, HavePermanentDifficulty";
                command.CommandText = sql;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HealthProfile healthpf = new HealthProfile();
                    healthpf.Year = Convert.ToInt32(reader["Year"]);
                    healthpf.Province = Convert.ToString(reader["Province"]);
                    healthpf.District = Convert.ToString(reader["District"]);
                    healthpf.LocalMunicipality = Convert.ToString(reader["LocalMunicipality"]);
                    healthpf.Needs = Convert.ToString(reader["Needs"]);
                    healthpf.HaveDifficulty = Convert.ToString(reader["HaveDifficulty"]);
                    healthpf.HavePermanentDifficulty = Convert.ToString(reader["HavePermanentDifficulty"]);
                    healthpf.UsesChronicMedication = Convert.ToString(reader["UsesChronicMedication"]);
                    healthpf.UsesAid = Convert.ToString(reader["UsesAid"]);
                    healthpf.NeedHealthService = Convert.ToString(reader["NeedHealthService"]);
                    healthpf.FemaleHealthNeeds = Convert.ToString(reader["FemaleHealthNeeds"]);
                    healthpf.value = Convert.ToString(reader["TotalNeedsCount"]);
                    //healthpf.link = "getHealthProfilesByYearProvince/" + Convert.ToString(reader["Year"]) + "/" + Convert.ToString(reader["Province"]);
                    healthpf.id = getProvinceCode(Convert.ToString(reader["Province"]));
                    healthprofiles.Add(healthpf);
                }

                healthprofiles.ToList();
                connection.Close();
                //var jsonSerialiser = new JavaScriptSerializer();
                //var json = jsonSerialiser.Serialize(healthprofiles);

                //string result = Newtonsoft.Json.JsonConvert.SerializeObject(healthprofiles, Newtonsoft.Json.Formatting.None);

                return healthprofiles;

            }
        }

        [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "gethealthprofilesbyyear/{Year}")]
        List<HealthProfile> IHealth.getHealthProfilesByYear(string Year)
        {
            List<HealthProfile> healthprofiles = new List<HealthProfile>();
            string connectionString = "Server=winmysqls03.cpt.wa.co.za;Port=3307;Uid=wits01;Pwd=Pr0ject;Database=waronpoverty;";
            using (MySqlConnection connection = new MySqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                string sql;
                sql = "SELECT * FROM tbl_7046provincedistrictlocalhealthneeds where year = " + Year;
                   
                command.CommandText = sql;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HealthProfile healthpf = new HealthProfile();
                    healthpf.Year = Convert.ToInt32(reader["Year"]);
                    healthpf.Province = Convert.ToString(reader["Province"]);
                    healthpf.District = Convert.ToString(reader["District"]);
                    healthpf.LocalMunicipality = Convert.ToString(reader["LocalMunicipality"]);
                  
                    healthprofiles.Add(healthpf);
                }

                healthprofiles.ToList();
                connection.Close();
                //var jsonSerialiser = new JavaScriptSerializer();
                //var json = jsonSerialiser.Serialize(healthprofiles);

                //string result = Newtonsoft.Json.JsonConvert.SerializeObject(healthprofiles, Newtonsoft.Json.Formatting.None);

                return healthprofiles;

            }
        }
        [WebInvoke(Method = "GET",
 ResponseFormat = WebMessageFormat.Json,
 BodyStyle = WebMessageBodyStyle.Bare,
  UriTemplate = "gethealthprofilesbyprovince/{Province}")]
        List<HealthProfile> IHealth.getHealthProfilesByProvince(string Province)
        {
            List<HealthProfile> healthprofiles = new List<HealthProfile>();
            string connectionString = "Server=winmysqls03.cpt.wa.co.za;Port=3307;Uid=wits01;Pwd=Pr0ject;Database=waronpoverty;";
            using (MySqlConnection connection = new MySqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                string sql;
                sql = "SELECT * FROM tbl_7046provincedistrictlocalhealthneeds where province = '" + Province +"'";

                command.CommandText = sql;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HealthProfile healthpf = new HealthProfile();
                    healthpf.Year = Convert.ToInt32(reader["Year"]);
                    healthpf.Province = Convert.ToString(reader["Province"]);
                    healthpf.District = Convert.ToString(reader["District"]);
                    healthpf.LocalMunicipality = Convert.ToString(reader["LocalMunicipality"]);                 
                    healthprofiles.Add(healthpf);
                }

                healthprofiles.ToList();
                connection.Close();
                //var jsonSerialiser = new JavaScriptSerializer();
                //var json = jsonSerialiser.Serialize(healthprofiles);

                //string result = Newtonsoft.Json.JsonConvert.SerializeObject(healthprofiles, Newtonsoft.Json.Formatting.None);

                return healthprofiles;

            }
        }

        string getProvinceCode(string Province)
        {
            string code = "";
            switch (Province)
            {
                case "Eastern Cape":
                    code = "05";
                    break;
                case "Free State":
                    code = "03";
                    break;
                case "Gauteng":
                    code = "06";
                    break;
                case "Northern Cape":
                    code = "08";
                    break;
                case "Western Cape":
                    code = "11";
                    break;
                case "North West":
                    code = "10";
                    break;
                case "Mpumalanga":
                    code = "07";
                    break;
                case "Kwazulu-Natal":
                    code = "02";
                    break;
                case "Limpopo":
                    code = "09";
                    break;
            }

            return code;
        }

    }
}
