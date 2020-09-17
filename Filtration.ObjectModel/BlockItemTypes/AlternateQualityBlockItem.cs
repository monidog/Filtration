using System.Windows.Media;
using Filtration.ObjectModel.BlockItemBaseTypes;
using Filtration.ObjectModel.Enums;

namespace Filtration.ObjectModel.BlockItemTypes
{
    public sealed class AlternateQualityBlockItem : BooleanBlockItem
    {
        public AlternateQualityBlockItem()
        {
        }

        public AlternateQualityBlockItem(bool booleanValue) : base(booleanValue)
        {
        }

        public override string PrefixText => "Alternate Quality";
        public override string DisplayHeading => "Alternate Quality";
        public override Color SummaryBackgroundColor => Colors.GreenYellow;
        public override Color SummaryTextColor => Colors.Black;
        public override BlockItemOrdering SortOrder => BlockItemOrdering.AlternateQuality;
    }
}
