using Bzs.Utility;
using BzsHomePage.Data;
using BzsHomePage.Db.Abstractions;
using BzsHomePage.Db.Services;
using LiteDB;
using Microsoft.Extensions.Options;

namespace BzsHomePage.Db;

public class DbFactory
{
    private LiteDatabase? _db;
    private readonly DbOptions _options;
    public ConnectionString ConnectionString { get; private set; }

    public DbFactory(IOptions<DbOptions> options)
    {
        _options = options.Value;
        ConnectionString = GetConnectionString();
    }

    private ConnectionString GetConnectionString()
    {
        var p = new BzsPath(_options.ConnectionString);
        p.CreateDirectory();
        return new ConnectionString($"Filename={p.AsPosix()};Connection=direct;");
    }

    private void CreateCustomMapping()
    {
        // BsonMapper.Global.RegisterType<SubstituteFileInfo>
        // (
        //     serialize: (ctx) => SubstituteInfoSerializer.SerializeSubstituteInfo(ctx).ToString(),
        //     deserialize: (bson) =>
        //     {
        //         var json = bson.AsString;
        //         var obj = SubstituteInfoSerializer.DeserializeSubstituteInfo(json.AsMemory());
        //         ArgumentNullException.ThrowIfNull(obj);
        //         return obj;
        //     }
        // );
    }


    private void EnsureCreateCollections(LiteDatabase db)
    {
        // Ensure create collections here.
        HomePageCurd.EnsureCollectionCreated(db);
    }


    /// <summary>
    /// Ensure create database. 
    /// </summary>
    /// <returns></returns>
    public void EnsureCreateDb()
    {
        var db = new LiteDatabase(ConnectionString);
        EnsureCreateCollections(db);
        CreateCustomMapping();
        _db = db;
    }

    public LiteDatabase CreateDbContext()
    {
        if (_db is null)
            throw new Exception("Database not created. ");
        return _db;
    }
}