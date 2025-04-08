using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

    [ObservableProperty]
    private int _output = 0;

    public ReportViewModel()
    {
        _nums.Add(1);
        _nums.Add(2);
        _nums.Add(3);
        _nums.Add(4);
        _nums.Add(5);
    }
    [RelayCommand]
    void SetOutput(int zahl)
    {
        this.Output = 20;
    }

}