﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Erebus.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            var test = Erebus.Resources.StringResources.Actions;
            InitializeComponent();
            label.Text = new Erebus.Core.Implementations.ClockProvider().GetNow().ToString();
        }
    }
}
