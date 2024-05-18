using RunGroupWebApp.Models;

namespace RunGroupWebApp.Interface
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetById(int id);
        Task<IEnumerable<Race>> GetAllRacesByCity(string city);
        bool Add(Race club);
        bool Update(Race club);
        bool Delete(Race club);
        bool Save();
    }
}
