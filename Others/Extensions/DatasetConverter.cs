using System.Data;
using TicetPortal.Models;

namespace TicetPortal.Others.Extensions
{
    public static class DatasetConverter
    {
        public static List<Person>GetPersonAsList(this DataSet Dataset)
        {
           return (from DataRow dr in Dataset.Tables[0].Rows select new Person(dr["FirstName"].ToString(), dr["LastName"].ToString(), dr["PhoneNumber"].ToString(), dr["Type of phone"].ToString())).ToList();
        }
        public static DataTable  GetPersonAsDataTable(this DataSet Dataset)
        {
            return Dataset.Tables[0];
        }
    }
}
