using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using FussballProj.Core.Services;
using FussballProj.Lib; 

namespace FussballProj.Core.ViewModels
{
    
    public partial class MainViewModel(IRepository repository, IAlertService alertService) : ObservableObject
    {
        public static void Main(String[] args)
        {

        }
    }
}
