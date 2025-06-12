using LiteDB;

namespace BzsHomePage.Db.Abstractions;

internal interface IDbService
{
    static virtual string CollectionName => throw new NotImplementedException();

    static virtual void EnsureCollectionCreated(LiteDatabase db) => throw new NotImplementedException();
}