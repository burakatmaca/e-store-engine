using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace E_Store.Engine.Service
{
    public interface IService<TItem, TItemDetail, TItemList>
        where TItem : class
        where TItemDetail : class
        where TItemList : class
    {
        Task<IEnumerable<TItem>> List(CancellationToken cancellationToken);
        Task<TItemList> List(int page, int pageSize, CancellationToken cancellationToken);
        Task<TItemDetail> Get(Guid id, CancellationToken cancellationToken);
        Task<bool> Add(TItemDetail data, CancellationToken cancellationToken);
        Task<bool> Update(Guid id, TItemDetail data, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
    }
}
