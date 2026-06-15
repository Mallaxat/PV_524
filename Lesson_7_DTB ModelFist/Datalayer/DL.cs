using Lesson_7_DTB_ModelFist.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations.Model;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7_DTB_ModelFist.Datalayer
{
    public class DL
    {
        public static string ConnectionString { get; set; } = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;
       public static class Customer
        {
            public static List<CustomerModels> All()
            {
                using (var db = new PV_524_CompanyDB_LapkinaEntities())
                {

                    List<CustomerModels> customers = new List<CustomerModels>();
                    var res = db.stp_CustomerALL().ToList();
                    foreach (var item in res)
                    {
                        CustomerModels tmp = new CustomerModels();
                        tmp.ID = item.id;
                        tmp.FirstName = item.FirstName;
                        tmp.LastName = item.LastName;
                        tmp.DateOfBirth = item.DateOfBirth;
                        customers.Add(tmp);
                    }
                    return customers;


                }
            }

            public static CustomerModels ByID(int _id)
            {
                using (var db = new PV_524_CompanyDB_LapkinaEntities())
                {
                    CustomerModels tmp = new CustomerModels();
                    var res = db.stp_CustomerByID(_id).First();
                    tmp.ID = res.id;
                    tmp.LastName = res.LastName;
                    tmp.FirstName = res.FirstName;
                    tmp.DateOfBirth = res.DateOfBirth;
                    return tmp;
                }
            }

            public static int CustomerAdd(CustomerModels tmp)
            {
                using (var db = new PV_524_CompanyDB_LapkinaEntities())
                {
                    /*                 tmp = new CustomerModels();
                                     var res = db.stp_CustomerAdd(firstName: tmp.ToString(), lastName: tmp.ToString(), dateOfBirth: Convert.ToDateTime(tmp), new ObjectParameter("Result", 0));
                                     tmp.ID = res;
                                     tmp.FirstName = res.ToString();
                                     tmp.LastName = res.ToString();
                                     tmp.DateOfBirth = Convert.ToDateTime(res);
                                     return res;*/

                    ObjectParameter new_Cust_Id = new ObjectParameter("CustomerID", 0);
                    db.stp_CustomerAdd(firstName: tmp.FirstName,
                        lastName: tmp.LastName, dateOfBirth: tmp.DateOfBirth, customerID: new_Cust_Id);
                    return (int)new_Cust_Id.Value;
                }
            }

            public static int Delete(int id)
            {
                using (var db = new PV_524_CompanyDB_LapkinaEntities())
                {
                    var res = db.stp_CustomerDelete();
                }

            }
        }



    }



}
