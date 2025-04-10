using ContactApp2.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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


        if (File.Exists(file))
        {
            this._rootElement = XElement.Load(_file);
        }
        else
        {
            this._rootElement = XElement.Load("contacts");
        }


    }


    public List<Contact> Get()
    {
        var contacts = from contact in this._rootElement.Descendants("contact")
                       select new Contact(
                           contact.Attribute("firstname")?.Value ?? "",
                           contact.Attribute("lastname")?.Value ?? "",
                           contact.Attribute("phone")?.Value ?? ""
                       )
                       { Email = contact.Attribute("email")?.Value ?? "" };

        this._contacts = contacts.ToList();

        return this._contacts;
    }

    public bool Save(Contact c)
    {
        try
        {
            var contactElement = new XElement("contact");

            var firstnameAttribute = new XAttribute("firstname", c.Firstname);
            contactElement.Add(firstnameAttribute);

            var lastnameAttribute = new XAttribute("lastname", c.Lastname);
            contactElement.Add(lastnameAttribute);

            var phoneAttribute = new XAttribute("phone", c.Phone);
            contactElement.Add(phoneAttribute);


            this._rootElement.Add(contactElement);

            this._rootElement.Save(this._file);

            return true;
        }

        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Delete(Contact c)
    {
        try
        {
            var contactElement = this._rootElement.Elements("contact")
                .FirstOrDefault(x => x.Attribute("firstname")?.Value == c.Firstname &&
                                     x.Attribute("lastname")?.Value == c.Lastname &&
                                     x.Attribute("phone")?.Value == c.Phone);
            if (contactElement != null)
            {
                contactElement.Remove();
                this._rootElement.Save(this._file);
                return true;
            }
            else
            {
                return false;

            }
        }

        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }
    public bool Clear()
    {
        try
        {
            this._rootElement.RemoveAll();
            this._rootElement.Save(this._file);
            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
