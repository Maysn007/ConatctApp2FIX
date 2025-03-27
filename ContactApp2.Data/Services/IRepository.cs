using ContactApp2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp2.Data.Services;

public interface IRepository
{
    List<Contact> Get();

    bool Save(Contact c);
}
