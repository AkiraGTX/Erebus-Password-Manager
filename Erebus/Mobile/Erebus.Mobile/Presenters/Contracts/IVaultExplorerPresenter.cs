﻿using Erebus.Core.Mobile.Contracts;
using Erebus.Mobile.ViewModels;
using Erebus.Mobile.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebus.Mobile.Presenters.Contracts
{
    public interface IVaultExplorerPresenter : IPresenter
    {
        void OnSearch(string searchText);
        void OnEntryItemSelected(EntryListItem entryListItem);
    }
}
