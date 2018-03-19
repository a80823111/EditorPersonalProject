using Library.Client.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Client.Repository
{
    public class DataRepository
    {
        public static dbPersonalEntities db = new dbPersonalEntities();

        public PersonalInfo GetSingle(int id)
        {
            PersonalInfo result = new PersonalInfo();
            try
            {
                if(id!=0)
                {
                    result = db.PersonalInfo
                               .Where(pi=>pi.id==id)
                               .FirstOrDefault();
                }
            }
            catch(Exception e)
            {

            }
            return result;
        }
        public List<PersonalInfo> GetList(string Condition)
        {
            List < PersonalInfo> result = new List<PersonalInfo>();
            try
            {

                result = db.PersonalInfo
                           .Where(
                                  pi=> pi.Name.Contains(Condition) 
                               || pi.Address.Contains(Condition)
                               || pi.Email.Contains(Condition)
                               || pi.PhoneNumber.Contains(Condition))
                           .OrderByDescending(pi=>pi.id)
                           .ToList();
                
            }
            catch (Exception e)
            {

            }
            return result;
        }
        public void InsertUpdate(PersonalInfo input)
        {
            PersonalInfo data = new PersonalInfo();
            try
            {
                if(input.id != 0)
                {
                    data = db.PersonalInfo
                           .Where(pi => pi.id == input.id)
                           .FirstOrDefault();
                    data.Name = input.Name;
                    data.Address = input.Address;
                    data.Email = input.Email;
                    data.PhoneNumber = input.PhoneNumber;
                }
                else
                    db.PersonalInfo.Add(input);

                db.SaveChanges();

            }
            catch (Exception e)
            {

            }
        }

        public void Delete(int id)
        {
            try
            {
                db.PersonalInfo
                    .Remove(
                        db.PersonalInfo
                          .Where(pi => pi.id == id)
                          .FirstOrDefault()
                        );

                db.SaveChanges();

            }
            catch (Exception e)
            {

            }
        }


    }
}
