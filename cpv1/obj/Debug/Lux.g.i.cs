﻿#pragma checksum "..\..\Lux.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "933BEDF78C2CD25E85537652108D89490AC09C93B6B146DD74E7ED66780652B2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using cpv1;


namespace cpv1 {
    
    
    /// <summary>
    /// Lux
    /// </summary>
    public partial class Lux : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\Lux.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RentLux;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Lux.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBoxLux;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Lux.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid LuxGrid;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Lux.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackLux;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Lux.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteLux;
        
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
            System.Uri resourceLocater = new System.Uri("/cpv1;component/lux.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Lux.xaml"
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
            
            #line 9 "..\..\Lux.xaml"
            ((cpv1.Lux)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RentLux = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Lux.xaml"
            this.RentLux.Click += new System.Windows.RoutedEventHandler(this.RentLux_Click);
            
            #line default
            #line hidden
            
            #line 15 "..\..\Lux.xaml"
            this.RentLux.Loaded += new System.Windows.RoutedEventHandler(this.RentLux_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SearchBoxLux = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.LuxGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.BackLux = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\Lux.xaml"
            this.BackLux.Click += new System.Windows.RoutedEventHandler(this.BackLux_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeleteLux = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Lux.xaml"
            this.DeleteLux.Click += new System.Windows.RoutedEventHandler(this.DeleteLux_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
