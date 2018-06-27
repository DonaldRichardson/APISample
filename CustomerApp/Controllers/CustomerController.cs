using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerApp.Formatters;
using CustomerApp.Models;

namespace CustomerApp.Controllers
{
    public class CustomerController : ApiController
    {
        //static readonly ICustomerRepository repository = new CustomerRepository();

        //public IEnumerable<Customer> GetAllCustomers()
        //{
        //    return repository.GetAll();
        //}

        //public Customer GetCustomer(string customerID)
        //{
        //    Customer customer = repository.Get(customerID);
        //    if (customer == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return customer;
        //}

        //public IEnumerable<Customer> GetCustomersByCountry(string country)
        //{
        //    return repository.GetAll().Where(
        //        c => string.Equals(c.Country, country, StringComparison.OrdinalIgnoreCase));
        //}

        [HttpPost]
        public HttpResponseMessage PostCustomer([FromBody] string message)
        {
            IXmldocs returndoc = null;
            XmlExtractor xtract = new XmlExtractor();

            XmlExtractor.DocType doctype = xtract.DetectType(message);

            string cleanstring = xtract.CleanText(message);

            string xmlstring = xtract.ParseText(cleanstring);
            switch (doctype)
            {
                case XmlExtractor.DocType.Expense:
                    returndoc =  (IXmldocs)xtract.GetXMLDocument<Expense>(xmlstring);
                    break;
                case XmlExtractor.DocType.Reservation:
                    returndoc = (Reservation)xtract.GetXMLDocument<Reservation>(xmlstring);
                    break;
                default:
                    break;
            }
           
            var response = Request.CreateResponse(HttpStatusCode.Created, returndoc);

            return response;
        }
        //[AcceptVerbs("POST","PUT")]
        //public void PutProduct(string customerID, Customer customer)
        //{
        //    customer.CustomerID = customerID;
        //    if (!repository.Update(customer))
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //}

        //public void DeleteProduct(string customerID)
        //{
        //    Customer customer = repository.Get(customerID);
        //    if (customer == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    repository.Remove(customerID);
        //}
    }
}