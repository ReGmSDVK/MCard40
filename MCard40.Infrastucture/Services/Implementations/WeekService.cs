using MCard40.Infrastucture.Services.Interfaces;
using MCard40.Model.Entity;
using MCard40.Model.Interfaces;


namespace MCard40.Infrastucture.Services.Implementations
{
    public class WeekService : IWeekService
    {
        private readonly IRepository<Week, int> _repository;

        public WeekService(IRepository<Week, int> repository)
        {
            _repository = repository;
        }

        public void Add(Week week)
        {
            _repository.Create(week);
        }

        public Week Delete(int id)
        {
            var week = _repository.DeleteById(id);
            if (week == null)
            {
                return null;
            }

            return week;
        }

        public Week GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Week GetWeekDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var week = _repository.ReadById(id.Value);
            return week;
        }

        public Week Update(int id, Week patient)
        {
            throw new NotImplementedException();
        }
    }
}
