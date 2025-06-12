using LiteDB;

namespace BzsHomePage.Db.Entities;

public class HomePageEntity
{
    [BsonId] public required int Id { get; set; }
    public required string Name { get; set; }
    public required string PrivateIpAddr { get; set; }
    public string? PublicIpAddr { get; set; }
}