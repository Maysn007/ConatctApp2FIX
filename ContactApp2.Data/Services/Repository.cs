using ContactApp2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactApp2.Data.Services;

public class Repository : IRepository
{
    string _file;
    List<Contact> _contacts;
    XElement _rootElement;

    public Repository(string file)
    {
        this._file = file;
        this._rootElement = XElement.Load(_file);
    }


    public List<Contact> Get()
    {
        var contacts = from contact in this._rootElement.Descendants("contact")
                       select new Contact(
                           contact.Attribute("firstname")?.Value ?? "",
                           contact.Attribute("lastname")?.Value ?? "",
                           contact.Attribute("phone")?.Value ?? ""
                       ) { Email = contact.Attribute("email")?.Value ?? "" };
        
        this._contacts = contacts.ToList();

        return this._contacts;
    }
}
