﻿#pragma checksum "..\..\..\..\ablakok\eredmenyWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "789570A38B95FFA25C74541439D7900F3F46F315"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ScottPlot;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using beadando.ablakok;


namespace beadando.ablakok {
    
    
    /// <summary>
    /// eredmenyWindow
    /// </summary>
    public partial class eredmenyWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\ablakok\eredmenyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox szures_kerdesre;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\ablakok\eredmenyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox szures_kitoltokre;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\ablakok\eredmenyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_valaszto;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\ablakok\eredmenyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas_chart;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\ablakok\eredmenyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ScottPlot.WpfPlot diagram;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/beadando;component/ablakok/eredmenywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ablakok\eredmenyWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.szures_kerdesre = ((System.Windows.Controls.CheckBox)(target));
            
            #line 11 "..\..\..\..\ablakok\eredmenyWindow.xaml"
            this.szures_kerdesre.Checked += new System.Windows.RoutedEventHandler(this.szures_kerdesre_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.szures_kitoltokre = ((System.Windows.Controls.CheckBox)(target));
            
            #line 12 "..\..\..\..\ablakok\eredmenyWindow.xaml"
            this.szures_kitoltokre.Checked += new System.Windows.RoutedEventHandler(this.szures_kitoltokre_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.combo_valaszto = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\..\..\ablakok\eredmenyWindow.xaml"
            this.combo_valaszto.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.combo_valaszto_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.canvas_chart = ((System.Windows.Controls.Canvas)(target));
            return;
            case 5:
            this.diagram = ((ScottPlot.WpfPlot)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

