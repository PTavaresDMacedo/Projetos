using Receitas.Model;

namespace Receitas.Service.Measures
{
    public interface IMeasureService
    {
        Measure Create(Measure measure);
        Measure Retrieve(int id);
        Measure Retrieve(string measureType);
        List<Measure> RetrieveAll();
        Measure Update(Measure measure);
        void Delete(int id);
    }
}
