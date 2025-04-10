using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ContactApp2.Core.Messages;
using ContactApp2.Data.Models;
using ContactApp2.Data.Services;
using System.Collections.ObjectModel;

namespace ContactApp2.Core.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _firstname = string.Empty;

    [ObservableProperty]
    private string _lastname = string.Empty;

    [ObservableProperty]
    private string _phone = string.Empty;

    IRepository _repository;

    private bool IstLoaded = false;

    [ObservableProperty]
    private Contact? _selectedContact = null;

    partial void OnSelectedContactChanged(Contact? value)
    {
        this.ShowDetails = true;
    }

    [ObservableProperty]
    private bool _showDetails = false;
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
    private void Toggle()
    {
        this.ShowDetails = !this.ShowDetails;
    }

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
    [RelayCommand]
    void RemoveContact(Contact contact)
    {
        var result = _repository.Delete(contact);
        this.SelectedContact = null;
        this.ShowDetails = false;

        if (result)
        {
            Contacts.Remove(contact);
            WeakReferenceMessenger.Default.Send(new RefreshMessage("refresh"));
        }
    }
    public void Clear()
    {
        _repository.Clear();
    }
}
