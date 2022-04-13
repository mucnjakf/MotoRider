using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoRider.Core.Services.Interfaces;
using MotoRider.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace MotoRider.API.Rest.Controllers
{
    [Authorize]
    [Route("api/motorcycle")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMotorcycleService _motorcycleService;

        private bool _error = false;

        public MotorcycleController(IMotorcycleService motorcycleService)
        {
            _motorcycleService = motorcycleService ?? throw new ArgumentNullException(nameof(motorcycleService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Motorcycle>> Get()
        {
            IEnumerable<Motorcycle> motorcycles = _motorcycleService.GetMotorcycles();

            if (motorcycles is null)
            {
                return NotFound();
            }

            return Ok(motorcycles);
        }

        [HttpGet("{id}")]
        public ActionResult<Motorcycle> Get(int id)
        {
            Motorcycle motorcycle = _motorcycleService.GetMotorcycle(id);

            if (motorcycle is null) return NotFound();

            return Ok(motorcycle);
        }

        [HttpPost]
        public ActionResult Post(XmlElement motorcycleXml)
        {
            try
            {
                XmlDocument xmlDocument = motorcycleXml.OwnerDocument;
                xmlDocument.AppendChild(motorcycleXml);
                xmlDocument.Schemas.Add("http://schemas.datacontract.org/2004/07/MotoRider.Shared.Models", "Validation\\motorcycle.xsd");

                ValidationEventHandler validationEventHandler = new(XmlValidationEventHandler);

                xmlDocument.Validate(XmlValidationEventHandler);

                if (_error)
                {
                    throw new Exception();
                }

                Motorcycle motorcycle = DeserializeMotorcycleXml(xmlDocument);

                bool isSuccess = _motorcycleService.InsertMotorcycle(motorcycle);

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

        private void XmlValidationEventHandler(object sender, ValidationEventArgs e)
        {
            _error = false;
        }

        private Motorcycle DeserializeMotorcycleXml(XmlDocument xmlDocument)
        {
            DataContractSerializer serializer = new(typeof(Motorcycle));
            MemoryStream stream = new();

            xmlDocument.Save(stream);
            stream.Position = 0;

            return (Motorcycle)serializer.ReadObject(stream);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, XmlElement motorcycleXml)
        {
            try
            {
                XmlDocument xmlDocument = motorcycleXml.OwnerDocument;
                xmlDocument.AppendChild(motorcycleXml);
                xmlDocument.Schemas.Add("http://schemas.datacontract.org/2004/07/MotoRider.Shared.Models", "Validation\\motorcycle.xsd");

                ValidationEventHandler validationEventHandler = new(XmlValidationEventHandler);

                xmlDocument.Validate(XmlValidationEventHandler);

                if (_error)
                {
                    throw new Exception();
                }

                Motorcycle motorcycle = DeserializeMotorcycleXml(xmlDocument);

                bool isSuccess = _motorcycleService.UpdateMotorcycle(id, motorcycle);

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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _motorcycleService.DeleteMotorcycle(id);

            if (!isSuccess) return BadRequest();

            return Ok();
        }
    }
}
