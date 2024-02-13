using Commons.Xml.Relaxng;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoRider.Core.Services.Interfaces;
using MotoRider.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using RabbitMQ.Client;
using Newtonsoft.Json;

namespace MotoRider.API.Rest.Controllers
{
    [Authorize]
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            IEnumerable<Customer> customers = _customerService.GetCustomers();

            if (customers is null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer customer = _customerService.GetCustomer(id);

            if (customer is null) return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public ActionResult Post(Customer customer)
        {
            string customerXml = SerializeCustomerToXml(customer);

            XmlReader xmlReader = new XmlTextReader(customerXml, XmlNodeType.Document, null);

            XmlReader rngGrammar = new XmlTextReader("Validation\\customer.rng");

            using RelaxngValidatingReader rngValidationReader = new(xmlReader, rngGrammar);

            try
            {
                while (!rngValidationReader.EOF)
                {
                    rngValidationReader.Read();
                }

                bool isSuccess = _customerService.InsertCustomer(customer);

                if (!isSuccess)
                {
                    throw new Exception();
                }

                SendMessageToRabbitMqServer(customer);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private static void SendMessageToRabbitMqServer(Customer customer)
        {
            string message = JsonConvert.SerializeObject(customer);
            byte[] data = Encoding.UTF8.GetBytes(message);
            Startup.RmqModel.BasicPublish("", "Customers", null, data);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Customer customer)
        {
            string customerXml = SerializeCustomerToXml(customer);

            XmlReader xmlReader = new XmlTextReader(customerXml, XmlNodeType.Document, null);

            XmlReader rngGrammar = new XmlTextReader("Validation\\customer.rng");

            using RelaxngValidatingReader rngValidationReader = new(xmlReader, rngGrammar);

            try
            {
                while (!rngValidationReader.EOF)
                {
                    rngValidationReader.Read();
                }

                bool isSuccess = _customerService.UpdateCustomer(id, customer);

                if (!isSuccess)
                {
                    throw new Exception();
                }

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private static string SerializeCustomerToXml(Customer customer)
        {
            StringBuilder sb = new();

            sb.Append("<Customer>");

            sb.Append("<FirstName>");
            sb.Append(customer.FirstName);
            sb.Append("</FirstName>");

            sb.Append("<LastName>");
            sb.Append(customer.LastName);
            sb.Append("</LastName>");

            sb.Append("<PhoneNumber>");
            sb.Append(customer.PhoneNumber);
            sb.Append("</PhoneNumber>");

            sb.Append("</Customer>");

            return sb.ToString();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _customerService.DeleteCustomer(id);

            if (!isSuccess) return BadRequest();

            return Ok();
        }
    }
}
