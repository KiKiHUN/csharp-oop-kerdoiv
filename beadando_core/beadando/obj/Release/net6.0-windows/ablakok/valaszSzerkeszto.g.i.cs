﻿#pragma checksum "..\..\..\..\ablakok\valaszSzerkeszto.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DE38807B0E025B858C1A1167273B060798C68B5F"
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
    /// valaszSzerkeszto
    /// </summary>
    public partial class valaszSzerkeszto : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\ablakok\valaszSzerkeszto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ValaszList;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\ablakok\valaszSzerkeszto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_uj;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\ablakok\valaszSzerkeszto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_megsem;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\ablakok\valaszSzerkeszto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas CANVAS_valasz_edit_uj;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\ablakok\valaszSzerkeszto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TX_kerdes;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\ablakok\valaszSzerkeszto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_edit_save;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\ablakok\valaszSzerkeszto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label windowMode;
        
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
            System.Uri resourceLocater = new System.Uri("/beadando;component/ablakok/valaszszerkeszto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ablakok\valaszSzerkeszto.xaml"
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
            this.ValaszList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.BTN_uj = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\ablakok\valaszSzerkeszto.xaml"
            this.BTN_uj.Click += new System.Windows.RoutedEventHandler(this.BTN_uj_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BTN_megsem = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\ablakok\valaszSzerkeszto.xaml"
            this.BTN_megsem.Click += new System.Windows.RoutedEventHandler(this.BTN_megsem_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CANVAS_valasz_edit_uj = ((System.Windows.Controls.Canvas)(target));
            return;
            case 5:
            this.TX_kerdes = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btn_edit_save = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\ablakok\valaszSzerkeszto.xaml"
            this.btn_edit_save.Click += new System.Windows.RoutedEventHandler(this.valasz_edit_uj_mentes);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 16 "..\..\..\..\ablakok\valaszSzerkeszto.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.valasz_edit_Megsem_click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.windowMode = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
