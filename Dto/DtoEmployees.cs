
namespace Dto
{
    using Newtonsoft.Json;
    public class DtoEmployees
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "contractTypeName")]
        public string ContractTypeName { get; set; }

        [JsonProperty(PropertyName = "roleId")]
        public string RoleId { get; set; }

        [JsonProperty(PropertyName = "roleName")]
        public string RoleName { get; set; }

        [JsonProperty(PropertyName = "roleDescription")]
        public string RoleDescription { get; set; }

        [JsonProperty(PropertyName = "hourlySalary")]
        public double HourlySalary { get; set; }

        [JsonProperty(PropertyName = "monthlySalary")]
        public double MonthlySalary { get; set; }

        public double CalculatedAnualSalary { get; set; }

    }
} 