using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp2.Data.Models;

public class Contact
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; }

    public Contact(string firstname, string lastname, string phone)
    {
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.Phone = phone; 
    }

    public override string ToString()
    {
        return Firstname + " " + Lastname;
    }
}
