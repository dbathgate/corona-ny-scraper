using System.Threading.Tasks;
using CoronaNyScaper.Model;

namespace CoronaNyScaper.Repository
{
    public interface INyDataRepository
    {
        Task<NyData> Get();
    }
}