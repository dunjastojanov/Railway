﻿#pragma checksum "..\..\UpdateStation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "39CE1FFC02D70DF99044807E3A0621FF84B3252DAD6E803D0BEF12FF1B2B727C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Maps.MapControl.WPF;
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
    /// UpdateStation
    /// </summary>
    public partial class UpdateStation : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\UpdateStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid updateStationGrid;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\UpdateStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid undoRedo;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\UpdateStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button undoUpdateStation;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\UpdateStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button redoUpdateStation;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\UpdateStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateStation;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\UpdateStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox station_name;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\UpdateStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Maps.MapControl.WPF.Map mapa;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\UpdateStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Maps.MapControl.WPF.Pushpin selectedPushpin;
        
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
            System.Uri resourceLocater = new System.Uri("/Railway;component/updatestation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UpdateStation.xaml"
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
            this.updateStationGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.undoRedo = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.undoUpdateStation = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\UpdateStation.xaml"
            this.undoUpdateStation.Click += new System.Windows.RoutedEventHandler(this.UndoButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.redoUpdateStation = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\UpdateStation.xaml"
            this.redoUpdateStation.Click += new System.Windows.RoutedEventHandler(this.RedoButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.updateStation = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\UpdateStation.xaml"
            this.updateStation.Click += new System.Windows.RoutedEventHandler(this.updateStation_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.station_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.mapa = ((Microsoft.Maps.MapControl.WPF.Map)(target));
            
            #line 65 "..\..\UpdateStation.xaml"
            this.mapa.MouseMove += new System.Windows.Input.MouseEventHandler(this.mapa_MouseMove);
            
            #line default
            #line hidden
            
            #line 66 "..\..\UpdateStation.xaml"
            this.mapa.Drop += new System.Windows.DragEventHandler(this.mapa_Drop);
            
            #line default
            #line hidden
            
            #line 67 "..\..\UpdateStation.xaml"
            this.mapa.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.mapa_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.selectedPushpin = ((Microsoft.Maps.MapControl.WPF.Pushpin)(target));
            
            #line 71 "..\..\UpdateStation.xaml"
            this.selectedPushpin.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Pushpin_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

