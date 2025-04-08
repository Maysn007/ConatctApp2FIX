using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ContactApp2.Core.Messages;
using ContactApp2.Data.Models;
using ContactApp2.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp2.Core.ViewModels;

public partial class AddViewModel : ObservableObject
{
    [ObservableProperty]
    private string _firstname = string.Empty;

    [ObservableProperty]
    private string _lastname = string.Empty;

    [ObservableProperty]
    private string _phone = string.Empty;

    IRepository _repository;

    public AddViewModel(IRepository repository)
    {
        _repository = repository;
    }

    [RelayCommand]
    void Save()
    {
        Contact c = new Contact(this.Firstname, this.Lastname, this.Phone);

        var result = _repository.Save(c);

        if (result)
        {
            WeakReferenceMessenger.Default.Send(new AddContactMessage(c));
            {
                this.Firstname = string.Empty;
                this.Lastname = string.Empty;
                this.Phone = string.Empty;
            }
        }
    }

    
}
