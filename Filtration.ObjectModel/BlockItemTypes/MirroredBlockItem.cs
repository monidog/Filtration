using System.Windows.Media;
using Filtration.ObjectModel.BlockItemBaseTypes;
using Filtration.ObjectModel.Enums;

namespace Filtration.ObjectModel.BlockItemTypes
{
    public sealed class MirroredBlockItem : BooleanBlockItem
    {
        public MirroredBlockItem()
        {
        }

        public MirroredBlockItem(bool booleanValue) : base(booleanValue)
        {
        }

        public override string PrefixText => "Mirrored";
        public override string DisplayHeading => "Mirrored";
        public override Color SummaryBackgroundColor => Colors.DarkRed;
        public override Color SummaryTextColor => Colors.White;
        public override BlockItemOrdering SortOrder => BlockItemOrdering.Mirrored;
    }
}
