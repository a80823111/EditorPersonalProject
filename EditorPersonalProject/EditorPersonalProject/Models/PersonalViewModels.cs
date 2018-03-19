using Library.Client.db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EditorPersonalProject.Models
{
    public class IndexViewModels
    {
        public PersonalViewModels DefaultSingle { get; set; }
        public List<PersonalInfo> List { get; set; }
        public string SearchCondition { get; set; }

    }
    public class PersonalViewModels
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "地址")]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "電子信箱")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "電話號碼")]
        public string PhoneNumber { get; set; }
    }
    public class ModelToViewModels
    {
        public static PersonalViewModels PersonalInfoToViewModels(PersonalInfo Model)
        {
            PersonalViewModels result = new PersonalViewModels();
            try
            {
                result.id = Model.id;
                result.Name = Model.Name;
                result.Address = Model.Address;
                result.Email = Model.Email;
                result.PhoneNumber = Model.PhoneNumber;
            }
            catch (Exception e)
            {

            }
            return result;
        }
    }
    public class ViewModelToModel
    {
        public static PersonalInfo PersonalViewModelsToModel(PersonalViewModels Model)
        {
            PersonalInfo result = new PersonalInfo();
            try
            {
                result.id = Model.id;
                result.Name = Model.Name;
                result.Address = Model.Address;
                result.Email = Model.Email;
                result.PhoneNumber = Model.PhoneNumber;
            }
            catch (Exception e)
            {

            }
            return result;
        }
    }

}