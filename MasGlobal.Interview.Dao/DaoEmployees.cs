
namespace Dao
{
    using Dto;
    using MasGlobal.Interview.Interfaces;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Configuration;
    public class DaoEmployees : IDaoEmployees
    {
        public List<DtoEmployees> GetEmployees()
        {
            var json = new WebClient().DownloadString(WebConfigurationManager.AppSettings["UrlRestApi"]);
            return JsonConvert.DeserializeObject<List<DtoEmployees>>(json);
        }
    }
}
