

namespace DDD.NetCore.Domain.Goods
{
    public interface IGoodsRepository
    {
        Goods Find(int id);
    }
}