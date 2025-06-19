using LiteDB;
using System.ComponentModel.DataAnnotations;

namespace BzsHomePage.Db.Entities;

public class HomePageEntity
{
    [BsonId] public required int Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Unique site name required.")]
    public required string Name { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Private IP name required.")]
    public required string PrivateIpAddr { get; set; }
    public string? PublicIpAddr { get; set; }
}