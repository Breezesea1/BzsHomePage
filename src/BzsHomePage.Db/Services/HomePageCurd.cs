using BzsHomePage.Db.Abstractions;
using BzsHomePage.Db.Entities;
using LiteDB;

namespace BzsHomePage.Db.Services;

public class HomePageCurd : IDbService
{
    public static string CollectionName => "homePages";
    private readonly ILiteCollection<HomePageEntity> _entities;


    public HomePageCurd(DbFactory factory)
    {
        _entities = factory.CreateDbContext().GetCollection<HomePageEntity>(CollectionName);
    }

    public static void EnsureCollectionCreated(LiteDatabase db)
    {
        var cols = db.GetCollection<HomePageEntity>(CollectionName);
        cols.EnsureIndex(x => x.Id);
    }

    public HomePageEntity? GetByName(string name)
    {
        return _entities.FindOne(x => x.Name == name);
    }

    public HomePageEntity? GetById(int id)
    {
        return _entities.FindById(id);
    }

    public int Insert(HomePageEntity entity)
    {
        entity.Id = 0;
        return _entities.Insert(entity);
    }

    public IEnumerable<HomePageEntity> GetAll()
    {
        return _entities.FindAll();
    }

    public bool Update(HomePageEntity newEntity)
    {
        return _entities.Update(newEntity);
    }

    public bool Delete(HomePageEntity entity)
    {
        return _entities.Delete(entity.Id);
    }
}