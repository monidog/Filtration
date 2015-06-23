﻿using System.ComponentModel;
using System.Windows.Media;

namespace Filtration.Models
{
    internal interface IItemFilterBlockItem : INotifyPropertyChanged
    {
        string PrefixText { get; }
        string OutputText { get; }
        string DisplayHeading { get; }
        string SummaryText { get; }
        Color SummaryBackgroundColor { get; }
        Color SummaryTextColor { get; }
        int MaximumAllowed { get; }
        int SortOrder { get; }
    }
}
