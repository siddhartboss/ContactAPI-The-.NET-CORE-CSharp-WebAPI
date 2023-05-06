using ContactAPI.Data;
using ContactAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsAPIController : Controller
    {
        private readonly ContactApiDbContext _contactApiDbContext;
        public ContactsAPIController(ContactApiDbContext contactApiDbContext)
        {
            _contactApiDbContext = contactApiDbContext;
        }

        [HttpGet]
        public IActionResult GetContact()
        {
            //var data = _contactApiDbContext.contactModel.ToList();
            //return View();
            return Ok(_contactApiDbContext.contactModel.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetSingleContact([FromRoute] Guid id)
        {
            var searchContact = _contactApiDbContext.contactModel.Find(id);
            if (searchContact != null)
            {
                return Ok(searchContact);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult AddContact(AddContactModel contactModel)
        {
            var contactData = new ContactModel()
            {
                Id = Guid.NewGuid(),
                Name = contactModel.Name,
                Email = contactModel.Email,
                Phone = contactModel.Phone,
                Address = contactModel.Address
            };

            _contactApiDbContext.contactModel.Add(contactData);
            _contactApiDbContext.SaveChanges();
            return Ok(contactData);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateContact([FromRoute] Guid id , UpdateContactModel updateContactModel)
        {
            var searchContact = _contactApiDbContext.contactModel.Find(id);
            if (searchContact != null)
            {
                searchContact.Name = updateContactModel.Name;
                searchContact.Email = updateContactModel.Email;
                searchContact.Phone = updateContactModel.Phone;
                searchContact.Address = updateContactModel.Address;

                _contactApiDbContext.SaveChanges();

                return Ok(searchContact);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact([FromRoute] Guid id)
        {
            var searchContact = _contactApiDbContext.contactModel.Find(id);
            if (searchContact != null)
            {
                _contactApiDbContext.contactModel.Remove(searchContact);
                _contactApiDbContext.SaveChanges();
                return Ok(searchContact);
            }
            return NotFound();
        }
    }
}
