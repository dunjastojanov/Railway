﻿#pragma checksum "..\..\AddTrainlineTutorial.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "18BAEAD3F1B4094AF06ED45E77D6AA1F019D96724540EBD8E8B60E0136D712A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Railway;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Railway {
    
    
    /// <summary>
    /// AddTrainlineTutorial
    /// </summary>
    public partial class AddTrainlineTutorial : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 52 "..\..\AddTrainlineTutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AddTrainRouteGrid;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\AddTrainlineTutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AddStationGrid;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\AddTrainlineTutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StationComboBox;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\AddTrainlineTutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AddTrainRoutePanel;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\AddTrainlineTutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer AddedStationsInfoScrollView;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\AddTrainlineTutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel AddedStationsInfoStackPanel;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\AddTrainlineTutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AddedStationsInfoGrid;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\AddTrainlineTutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ConformationGrid;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\AddTrainlineTutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Railway;component/addtrainlinetutorial.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddTrainlineTutorial.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AddTrainRouteGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.AddStationGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.StationComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 85 "..\..\AddTrainlineTutorial.xaml"
            this.StationComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Add_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddTrainRoutePanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.AddedStationsInfoScrollView = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 6:
            this.AddedStationsInfoStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.AddedStationsInfoGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.ConformationGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.saveButton = ((System.Windows.Controls.Button)(target));
            
            #line 122 "..\..\AddTrainlineTutorial.xaml"
            this.saveButton.Click += new System.Windows.RoutedEventHandler(this.saveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

