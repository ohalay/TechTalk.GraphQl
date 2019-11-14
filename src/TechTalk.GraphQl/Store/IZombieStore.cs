using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.GraphQl.Store.Models;

namespace TechTalk.GraphQl.Store
{
    public interface IZombieStore<TStoreModel>
        where TStoreModel : IIdentifier
    {
        ValueTask<TStoreModel> Get(Guid key);

        ValueTask<IReadOnlyCollection<TStoreModel>> GetAll();

        void Add(TStoreModel model);

        IObservable<TStoreModel> Stream { get; }
    }
}