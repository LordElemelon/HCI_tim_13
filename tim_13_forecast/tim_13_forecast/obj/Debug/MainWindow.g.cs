﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AEB0270447712E29CEB98A853C07F007EFE0575F"
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
using WPFTextBoxAutoComplete;
using tim_13_forecast;
using tim_13_forecast.models;


namespace tim_13_forecast {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 152 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox searchBox;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button favouriteB;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Temperatura;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Humidity;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Wind;
        
        #line default
        #line hidden
        
        
        #line 222 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label City;
        
        #line default
        #line hidden
        
        
        #line 224 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Overview;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CurTemp;
        
        #line default
        #line hidden
        
        
        #line 233 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton favouriteNO;
        
        #line default
        #line hidden
        
        
        #line 241 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton favouriteYES;
        
        #line default
        #line hidden
        
        
        #line 257 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Day1;
        
        #line default
        #line hidden
        
        
        #line 258 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Day2;
        
        #line default
        #line hidden
        
        
        #line 259 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Day3;
        
        #line default
        #line hidden
        
        
        #line 260 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Day5;
        
        #line default
        #line hidden
        
        
        #line 261 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Day4;
        
        #line default
        #line hidden
        
        
        #line 264 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Detailed_View;
        
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
            System.Uri resourceLocater = new System.Uri("/tim_13_forecast;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.searchBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 152 "..\..\MainWindow.xaml"
            this.searchBox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.ComboBox_TextChanged));
            
            #line default
            #line hidden
            
            #line 153 "..\..\MainWindow.xaml"
            this.searchBox.DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
            
            #line default
            #line hidden
            
            #line 153 "..\..\MainWindow.xaml"
            this.searchBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.searchBox_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 158 "..\..\MainWindow.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.favouriteB = ((System.Windows.Controls.Button)(target));
            
            #line 176 "..\..\MainWindow.xaml"
            this.favouriteB.Click += new System.Windows.RoutedEventHandler(this.FavClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button1 = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.Temperatura = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Humidity = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Wind = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.City = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.Overview = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.CurTemp = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.favouriteNO = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 237 "..\..\MainWindow.xaml"
            this.favouriteNO.Checked += new System.Windows.RoutedEventHandler(this.favourite_Checked);
            
            #line default
            #line hidden
            
            #line 238 "..\..\MainWindow.xaml"
            this.favouriteNO.Unchecked += new System.Windows.RoutedEventHandler(this.favourite_Checked);
            
            #line default
            #line hidden
            return;
            case 13:
            this.favouriteYES = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 245 "..\..\MainWindow.xaml"
            this.favouriteYES.Checked += new System.Windows.RoutedEventHandler(this.favourite_Unchecked);
            
            #line default
            #line hidden
            
            #line 246 "..\..\MainWindow.xaml"
            this.favouriteYES.Unchecked += new System.Windows.RoutedEventHandler(this.favourite_Unchecked);
            
            #line default
            #line hidden
            return;
            case 14:
            this.Day1 = ((System.Windows.Controls.Button)(target));
            
            #line 257 "..\..\MainWindow.xaml"
            this.Day1.Click += new System.Windows.RoutedEventHandler(this.Day1_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.Day2 = ((System.Windows.Controls.Button)(target));
            
            #line 258 "..\..\MainWindow.xaml"
            this.Day2.Click += new System.Windows.RoutedEventHandler(this.Day2_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.Day3 = ((System.Windows.Controls.Button)(target));
            
            #line 259 "..\..\MainWindow.xaml"
            this.Day3.Click += new System.Windows.RoutedEventHandler(this.Day3_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.Day5 = ((System.Windows.Controls.Button)(target));
            
            #line 260 "..\..\MainWindow.xaml"
            this.Day5.Click += new System.Windows.RoutedEventHandler(this.Day5_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.Day4 = ((System.Windows.Controls.Button)(target));
            
            #line 261 "..\..\MainWindow.xaml"
            this.Day4.Click += new System.Windows.RoutedEventHandler(this.Day4_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.Detailed_View = ((System.Windows.Controls.Button)(target));
            
            #line 264 "..\..\MainWindow.xaml"
            this.Detailed_View.Click += new System.Windows.RoutedEventHandler(this.Detailed_View_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

