﻿using Erebus.Core.Mobile.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebus.Mobile.Presenters.Contracts
{
    public interface IConfigurationPresenter : IPresenter
    {
        void OnSelectedApplicationModeChange();
        void OnSave();
    }
}
