﻿#pragma checksum "..\..\..\MainViews\SideView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BCF3E4597AE7B4A58883B5492ADA47C44B234C24"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TotalCommander;


namespace TotalCommander.MainViews {
    
    
    /// <summary>
    /// SideView
    /// </summary>
    public partial class SideView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\MainViews\SideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\MainViews\SideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox mainPath;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\MainViews\SideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\MainViews\SideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\MainViews\SideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Disc;
        
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
            System.Uri resourceLocater = new System.Uri("/TotalCommander;component/mainviews/sideview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainViews\SideView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 8 "..\..\..\MainViews\SideView.xaml"
            ((TotalCommander.MainViews.SideView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Side_loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listView = ((System.Windows.Controls.ListView)(target));
            
            #line 15 "..\..\..\MainViews\SideView.xaml"
            this.listView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.OpenDirectory);
            
            #line default
            #line hidden
            return;
            case 3:
            this.mainPath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\MainViews\SideView.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.button2_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.back = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\MainViews\SideView.xaml"
            this.back.Click += new System.Windows.RoutedEventHandler(this.back_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Disc = ((System.Windows.Controls.ComboBox)(target));
            
            #line 32 "..\..\..\MainViews\SideView.xaml"
            this.Disc.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Disc_SelectedIndexChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

