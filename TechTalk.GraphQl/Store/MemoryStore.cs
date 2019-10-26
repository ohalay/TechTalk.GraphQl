using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using TechTalk.GraphQl.Store.Models;

namespace TechTalk.GraphQl.Store
{
    public class MemoryStore<TStoreModel> : IZombieStore<TStoreModel> where TStoreModel : IIdentifier
    {
        private readonly ConcurrentDictionary<Guid, TStoreModel> _store = new ConcurrentDictionary<Guid, TStoreModel>();
        private readonly ISubject<TStoreModel> _stream = new Subject<TStoreModel>();

        public ValueTask<TStoreModel> Get(Guid key)
        {
            return _store.TryGetValue(key, out var value)
                ? new ValueTask<TStoreModel>(value)
                : throw new KeyNotFoundException();
        }

        public ValueTask<IReadOnlyCollection<TStoreModel>> GetAll()
        {
            return new ValueTask<IReadOnlyCollection<TStoreModel>>(_store.Values.ToArray());
        }

        public void Add(TStoreModel model)
        {
            if (!_store.TryAdd(model.Id, model))
            {
                throw new ArithmeticException();
            }

            _stream.OnNext(model);
        }

        public IObservable<TStoreModel> Stream => _stream.AsObservable();
    }
}