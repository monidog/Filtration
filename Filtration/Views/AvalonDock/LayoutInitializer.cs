﻿using Xceed.Wpf.AvalonDock.Layout;

namespace Filtration.Views.AvalonDock
{
    class LayoutInitializer : ILayoutUpdateStrategy
    {
        public bool BeforeInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableToShow, ILayoutContainer destinationContainer)
        {
            //AD wants to add the anchorable into destinationContainer
            //just for test provide a new anchorablepane 
            //if the pane is floating let the manager go ahead
            LayoutAnchorablePane destPane = destinationContainer as LayoutAnchorablePane;
            if (destinationContainer != null &&
                destinationContainer.FindParent<LayoutFloatingWindow>() != null)
                return false;

            //if (anchorableToShow.ContentId == "SectionBrowserTool")
            //{
            //    var toolsPane = layout.Descendents().OfType<LayoutAnchorablePane>().FirstOrDefault(d => d.Name == "SectionBrowserPane");
            //    if (toolsPane != null)
            //    {
            //        anchorableToShow.CanHide = false;
            //        toolsPane.Children.Add(anchorableToShow);
            //        return true;
            //    }
            //}

            //if (anchorableToShow.ContentId == "BlockGroupBrowserTool")
            //{
            //    var toolsPane = layout.Descendents().OfType<LayoutAnchorablePane>().FirstOrDefault(d => d.Name == "BlockGroupBrowserPane");
            //    if (toolsPane != null)
            //    {
            //        anchorableToShow.CanHide = false;
            //        toolsPane.Children.Add(anchorableToShow);
            //        return true;
            //    }
            //}



            return false;

        }


        public void AfterInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableShown)
        {
        }


        public bool BeforeInsertDocument(LayoutRoot layout, LayoutDocument anchorableToShow, ILayoutContainer destinationContainer)
        {
            return false;
        }

        public void AfterInsertDocument(LayoutRoot layout, LayoutDocument anchorableShown)
        {

        }
    }
}