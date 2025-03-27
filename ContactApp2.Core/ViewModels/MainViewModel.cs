﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ContactApp2.Core.Messages;
using ContactApp2.Data.Models;
using ContactApp2.Data.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp2.Core.ViewModels;

public partial class MainViewModel : ObservableObject
{
    IRepository _repository;
    private bool IstLoaded = false;

    [ObservableProperty]
    private Contact? _selectedContact = null;
    public MainViewModel(IRepository repository)
    {
        _repository = repository;

        // listen for message
        WeakReferenceMessenger.Default.Register<AddContactMessage>(this, (r, m) =>
        {
            System.Diagnostics.Debug.WriteLine(r);
            System.Diagnostics.Debug.WriteLine(m.Value);

            Contacts.Add(m.Value);

            /*
            Contacts.Clear();

            var contacts = _repository.Get();
            foreach (var contact in contacts)
            {
                System.Diagnostics.Debug.WriteLine(contact);
                Contacts.Add(contact);
            }
            */
        });
    }

    [ObservableProperty]
    ObservableCollection<Contact> _contacts = new();

    [RelayCommand]
    void Load()
    {
        if (this.IstLoaded)
        {
            var contacts = _repository.Get();


            foreach (var contact in contacts)
            {
                System.Diagnostics.Debug.WriteLine(contact);
                Contacts.Add(contact);
            }
            this.IstLoaded = !this.IstLoaded;

        }
    }
}
