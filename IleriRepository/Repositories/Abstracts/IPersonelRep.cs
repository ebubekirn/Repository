using IleriRepository.Core;
using IleriRepository.Data;
using IleriRepository.DTO;

namespace IleriRepository.Repositories.Abstracts
{
    public interface IPersonelRep : IBaseRepository<Personel>
    {
        public int GetAge(Personel p);
        public string FullName(Personel p);
        List<string> GetAddress(Personel p);
        List<PersonelGradeList> ListbyGrade();
        List<PersonelDepList> ListbyDepartment();
    }
}
