using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerApp.Models
{
    //public class CustomerRepository : ICustomerRepository
    //{
    //    //public IEnumerable<Customer> GetAll()
    //    //{
    //    //    List<Customer> customers = new List<Customer>();
    //    //    string query = string.Format("SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax] FROM [Northwind].[dbo].[Customers]");

    //    //    using (SqlConnection con =
    //    //            new SqlConnection("your connection string"))
    //    //    {
    //    //        using (SqlCommand cmd = new SqlCommand(query, con))
    //    //        {
    //    //            con.Open();
    //    //            SqlDataReader reader = cmd.ExecuteReader();

    //    //            while (reader.Read())
    //    //            {
    //    //                Customer customer = new Customer();
    //    //                customer.CustomerID = reader.GetString(0);
    //    //                customer.CompanyName = reader.GetString(1);
    //    //                customer.ContactName = reader.GetString(2);
    //    //                customer.ContactTitle = reader.GetString(3);
    //    //                customer.Address = reader.GetString(4);
    //    //                customer.City = reader.GetString(5);

    //    //                if (reader.GetValue(6) != null)
    //    //                {
    //    //                    customer.Region = reader.GetValue(6).ToString();
    //    //                }
    //    //                else
    //    //                {
    //    //                    customer.Region = string.Empty;    
    //    //                }

    //    //                if (reader.GetValue(7) != null)
    //    //                {
    //    //                    customer.PostalCode = reader.GetValue(7).ToString();
    //    //                }
    //    //                else
    //    //                {
    //    //                    customer.PostalCode = string.Empty;
    //    //                }

    //    //                customer.Country = reader.GetString(8);
    //    //                customer.Phone = reader.GetString(9);

    //    //                if(reader.GetValue(10) != null)
    //    //                {
    //    //                    customer.Fax = reader.GetValue(10).ToString() ;   
    //    //                }
    //    //                else
    //    //                {
    //    //                    customer.Fax = string.Empty;   
    //    //                }

    //    //                customers.Add(customer);
    //    //            }
    //    //            con.Close(); 
    //    //        }
    //    //    }
    //    //    return customers.ToArray();
    //    //}

    //    public IEnumerable<Customer> GetAll()
    //    {
    //        List<Customer> customers = new List<Customer>();
    //        customers.Add(new Customer { CompanyName = "first" });
    //        customers.Add(new Customer { CompanyName = "second" });
    //        return customers.ToArray();
    //    }
    //    public Customer Get(string customerID)
    //    {
    //        Customer customer = new Customer { CompanyName = customerID.ToString() };
    //        //string query = string.Format(" SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax] FROM [Northwind].[dbo].[Customers] " +
    //        //    "  WHERE CustomerID LIKE '%"+ customerID + "%'");

    //        //using (SqlConnection con =
    //        //        new SqlConnection("your connection string"))
    //        //{
    //        //    using (SqlCommand cmd = new SqlCommand(query, con))
    //        //    {
    //        //        con.Open();
    //        //        SqlDataReader reader = cmd.ExecuteReader();

    //        //        while (reader.Read())
    //        //        {
    //        //            customer.CustomerID = reader.GetString(0);
    //        //            customer.CompanyName = reader.GetString(1);
    //        //            customer.ContactName = reader.GetString(2);
    //        //            customer.ContactTitle = reader.GetString(3);
    //        //            customer.Address = reader.GetString(4);
    //        //            customer.City = reader.GetString(5);

    //        //            if (reader.GetValue(6) != null)
    //        //            {
    //        //                customer.Region = reader.GetValue(6).ToString();
    //        //            }
    //        //            else
    //        //            {
    //        //                customer.Region = string.Empty;
    //        //            }

    //        //            if (reader.GetValue(7) != null)
    //        //            {
    //        //                customer.PostalCode = reader.GetValue(7).ToString();
    //        //            }
    //        //            else
    //        //            {
    //        //                customer.PostalCode = string.Empty;
    //        //            }

    //        //            customer.Country = reader.GetString(8);
    //        //            customer.Phone = reader.GetString(9);

    //        //            if (reader.GetValue(10) != null)
    //        //            {
    //        //                customer.Fax = reader.GetValue(10).ToString();
    //        //            }
    //        //            else
    //        //            {
    //        //                customer.Fax = string.Empty;
    //        //            }

    //        //        }
    //        //        con.Close(); 
    //        //    }
    //        //}
    //        return customer;
    //    }

    //    public Customer Add(Customer item)
    //    {

    //        Customer customer = new Customer { CompanyName = "first" };
    //        return item;
    //    }

    //    public bool Remove(string customerID)
    //    {
            

    //        return true;
    //    }

    //    public bool Update(Customer item)
    //    {
    //        return true;
    //    }
    //}
}