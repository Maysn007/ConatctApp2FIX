using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ContactApp2.Core.Messages;
using ContactApp2.Data.Models;
using ContactApp2.Data.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp2.Core.ViewModels;

public partial class ReportViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<int> _nums = new();

    public ObservableCollection<ReportModel> Data { get; set; }
    public string Name { get; private set; }
    public int Height { get; private set; }



    public Repository _repository { get; set;}

    public ReportViewModel(IRepository _repository)
    {
        this._repository = repository;
        var contacts = Repository.Get();
        

        var contactsWithMail = (from contact in contacts
                               where contact.Email != string.Empty
                               select contact).ToList();

        Data.Add(new ReportModel() { Description = "Contact", Number = contacts.Count() });
        Data.Add(new ReportModel() { Description = "mit Mail", Number = contactsWithMail.Count() });

        // listen for refresh
        WeakReferenceMessenger.Default.Register<RefreshMessage>(this, (r, m) =>
        {
            Data.Clear();

            this._repository = repository;
            var contacts = Repository.Get();


            var contactsWithMail = (from contact in contacts
                                    where contact.Email != string.Empty
                                    select contact).ToList();

            Data.Add(new ReportModel() { Description = "Contact", Number = contacts.Count() });
            Data.Add(new ReportModel() { Description = "mit Mail", Number = contactsWithMail.Count() });
        });

    }



}