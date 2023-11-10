using Receitas.Model;
using Receitas.Repository.Measures;

namespace Receitas.Service.Measures
{
    public class MeasureService : IMeasureService
    {
        private readonly IMeasureRepository _measureRepository;
        public MeasureService(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
        }

        public Measure Create(Measure measure)
        {
            return _measureRepository.Create(measure);
        }

        public void Delete(int id)
        {
            _measureRepository.Delete(id);
        }

        public Measure Retrieve(int id)
        {
            return _measureRepository.Retrieve(id);
        }

        public Measure Retrieve(string measureType)
        {
            return _measureRepository.Retrieve(measureType);
        }

        public List<Measure> RetrieveAll()
        {
            return _measureRepository.RetrieveAll();
        }

        public Measure Update(Measure measure)
        {
            return _measureRepository.Update(measure);
        }
    }
}
