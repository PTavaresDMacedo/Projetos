using Receitas.Model;

namespace Receitas.Repository.Measures
{
    public interface IMeasureRepository
    {
        Measure Create (Measure measure);
        Measure Retrieve (int id);
        Measure Retrieve (string measureType);
        List<Measure> RetrieveAll ();
        Measure Update (Measure measure);
        void Delete (int id);
    }
}
