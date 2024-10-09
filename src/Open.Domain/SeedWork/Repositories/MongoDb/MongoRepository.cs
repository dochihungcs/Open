using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Open.Domain.SeedWork.Repositories.MongoDb;

public class MongoRepository<TDocument> : IMongoRepository<TDocument>
{
    private readonly string _connectionString;
    private readonly string _databaseName;

    private MongoDbContext? _context;

    public MongoDbContext Context
    {
        get
        {
            if (_context == null)
            {
                _context = new MongoDbContext(_connectionString, _databaseName);
            }

            return _context;
        }
    }

    private IMongoCollection<TDocument>? _collection;

    public IMongoCollection<TDocument> Collection
    {
        get
        {
            if (_collection == null)
            {
                _collection = Context.GetCollection<TDocument>();
            }

            return _collection;
        }
    }

    private IMongoClient? _client;

    public virtual IMongoClient Client
    {
        get
        {
            if (_client == null)
            {
                _client = Context.OriginClient;
            }

            return _client;
        }
    }


    public MongoRepository(IServiceProvider provider) : this(provider, string.Empty, string.Empty)
    {
    }

    public MongoRepository(IServiceProvider provider, string? connectionString, string? databaseName)
    {
        var settings = provider.GetRequiredService<IOptionsMonitor<MongoSettings>>();
        _connectionString = string.IsNullOrEmpty(connectionString)
            ? settings.CurrentValue.ConnectionString
            : connectionString;
        _databaseName = string.IsNullOrEmpty(databaseName) ? settings.CurrentValue.DatabaseName : databaseName;
    }

    public IClientSessionHandle GetSession()
    {
        return Client.StartSession();
    }

    public Task<IClientSessionHandle> GetSessionAsync()
    {
        return Client.StartSessionAsync();
    }

    public void InsertMany(IClientSessionHandle session, IEnumerable<TDocument> documents,
        InsertManyOptions? options = null)
    {
        if (session == null)
        {
            throw new Exception("Session required!");
        }

        InsertManyAsync(session, documents, options).GetAwaiter().GetResult();
    }

    public Task InsertManyAsync(IClientSessionHandle session, IEnumerable<TDocument> documents,
        InsertManyOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("Session required!");
        }

        return Collection.InsertManyAsync(session, documents, options, cancellationToken);
    }

    public void InsertOne(IClientSessionHandle session, TDocument document, InsertOneOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        Collection.InsertOneAsync(session, document, options, cancellationToken).GetAwaiter().GetResult();
    }

    public Task InsertOneAsync(IClientSessionHandle session, TDocument document, InsertOneOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return Collection.InsertOneAsync(session, document, options, cancellationToken);
    }

    public UpdateResult UpdateMany(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        UpdateDefinition<TDocument> update, UpdateOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return UpdateManyAsync(session, filter, update, options, cancellationToken).GetAwaiter().GetResult();
    }

    public Task<UpdateResult> UpdateManyAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        UpdateDefinition<TDocument> update, UpdateOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return UpdateManyAsync(session, filter, update, options, cancellationToken);
    }

    public UpdateResult UpdateOne(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        UpdateDefinition<TDocument> update, UpdateOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return UpdateOneAsync(session, filter, update, options, cancellationToken).GetAwaiter().GetResult();
    }

    public Task<UpdateResult> UpdateOneAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        UpdateDefinition<TDocument> update, UpdateOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return Collection.UpdateOneAsync(session, filter, update, options, cancellationToken);
    }

    public ReplaceOneResult ReplaceOne(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        TDocument replacement, ReplaceOptions options, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return ReplaceOneAsync(session, filter, replacement, options, cancellationToken).GetAwaiter().GetResult();
    }

    public Task<ReplaceOneResult> ReplaceOneAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        TDocument replacement, ReplaceOptions options, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return Collection.ReplaceOneAsync(session, filter, replacement, options, cancellationToken);
    }

    public DeleteResult DeleteMany(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        DeleteOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return DeleteManyAsync(session, filter, options, cancellationToken).GetAwaiter().GetResult();
    }

    public Task<DeleteResult> DeleteManyAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        DeleteOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return Collection.DeleteManyAsync(session, filter, options, cancellationToken);
    }

    public DeleteResult DeleteOne(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        DeleteOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return DeleteOneAsync(session, filter, options, cancellationToken).GetAwaiter().GetResult();
    }

    public Task<DeleteResult> DeleteOneAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        DeleteOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return Collection.DeleteOneAsync(session, filter, options, cancellationToken);
    }

    public IFindFluent<TDocument, TDocument> Find(FilterDefinition<TDocument> filter, FindOptions? options = null)
    {
        return Collection.Find(filter, options);
    }

    public Task<IAsyncCursor<TProjection>> FindAsync<TProjection>(FilterDefinition<TDocument> filter,
        FindOptions<TDocument, TProjection>? options = null, CancellationToken cancellationToken = default)
    {
        return Collection.FindAsync(filter, options, cancellationToken);
    }

    public TProjection FindOneAndDelete<TProjection>(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        FindOneAndDeleteOptions<TDocument, TProjection>? options = null, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return FindOneAndDeleteAsync(session, filter, options, cancellationToken).GetAwaiter().GetResult();
    }

    public Task<TProjection> FindOneAndDeleteAsync<TProjection>(IClientSessionHandle session,
        FilterDefinition<TDocument> filter, FindOneAndDeleteOptions<TDocument, TProjection>? options = null,
        CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return Collection.FindOneAndDeleteAsync(session, filter, options, cancellationToken);
    }

    public TProjection FindOneAndReplace<TProjection>(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        TDocument replacement, FindOneAndReplaceOptions<TDocument, TProjection>? options = null,
        CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return FindOneAndReplaceAsync(session, filter, replacement, options, cancellationToken).GetAwaiter()
            .GetResult();
    }

    public Task<TProjection> FindOneAndReplaceAsync<TProjection>(IClientSessionHandle session,
        FilterDefinition<TDocument> filter, TDocument replacement,
        FindOneAndReplaceOptions<TDocument, TProjection>? options = null, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return Collection.FindOneAndReplaceAsync(session, filter, replacement, options, cancellationToken);
    }

    public TProjection FindOneAndUpdate<TProjection>(IClientSessionHandle session, FilterDefinition<TDocument> filter,
        UpdateDefinition<TDocument> update, FindOneAndUpdateOptions<TDocument, TProjection>? options = null,
        CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return FindOneAndUpdateAsync(session, filter, update, options, cancellationToken).GetAwaiter().GetResult();
    }

    public Task<TProjection> FindOneAndUpdateAsync<TProjection>(IClientSessionHandle session,
        FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update,
        FindOneAndUpdateOptions<TDocument, TProjection>? options = null, CancellationToken cancellationToken = default)
    {
        if (session == null)
        {
            throw new Exception("session required!");
        }

        return Collection.FindOneAndUpdateAsync(session, filter, update, options, cancellationToken);
    }


    public long CountDocuments(FilterDefinition<TDocument> filter, CountOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        return CountDocumentsAsync(filter, options, cancellationToken).GetAwaiter().GetResult();
    }

    public Task<long> CountDocumentsAsync(FilterDefinition<TDocument> filter, CountOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        return Collection.CountDocumentsAsync(filter, options, cancellationToken);
    }
}
