using McKing.Model;
using McKing.Repository.Interface;
using McKing.Service.Interface;

namespace McKing.Service.Implementation
{
    public class MeasureService : IService<Measure, int>
    {
        private readonly IRepository<Measure, int> _repository;

        public MeasureService(IRepository<Measure, int> repository)
        {
            this._repository = repository;
        }

        public Measure Create(Measure measure)
        {
            return _repository.Create(measure);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Measure Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Measure> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Measure Update(Measure measure)
        {
            return _repository.Update(measure);
        }
    }
}
