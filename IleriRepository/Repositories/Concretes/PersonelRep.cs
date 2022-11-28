using IleriRepository.Context;
using IleriRepository.Core;
using IleriRepository.Data;
using IleriRepository.DTO;
using IleriRepository.Repositories.Abstracts;

namespace IleriRepository.Repositories.Concretes
{
    public class PersonelRep<T> : BaseRepository<Personel>, IPersonelRep where T : class
    {
        public PersonelRep(MyContext db) : base(db)
        {
        }

        public string FullName(Personel p)
        {
            return p.FullName();
        }

        public List<string> GetAddress(Personel p)
        {
            return p.GetAddress();
        }

        public int GetAge(Personel p)
        {
            return p.GetAge();
        }

        public List<PersonelDepList> ListbyDepartment()
        {
            return Set().Select(x => new PersonelDepList
            {
                Id = x.Id,
                Department = x.Department.DepartmentName,
                FullName = x.Name + " " + x.Surname,
                ImgUrl = x.ImgUrl
            }).OrderBy(x => x.Department).ToList();
        }

        public List<PersonelGradeList> ListbyGrade()
        {
            return Set().Select(x => new PersonelGradeList
            {
                Id = x.Id,
                Grade = x.Grade.GradeName,
                GradeId = x.GradeId,
                FullName = x.Name + " " + x.Surname,
                ImgUrl = x.ImgUrl
            }).OrderBy(x => x.GradeId).ToList();
        }
    }
}
