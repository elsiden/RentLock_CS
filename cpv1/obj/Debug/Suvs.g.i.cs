﻿#pragma checksum "..\..\Suvs.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8957262EB1FD30D33BB85E3BF73BCFB1F2D58533E00E1B8BE82AF993546E2ECB"
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
    /// Suvs
    /// </summary>
    public partial class Suvs : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\Suvs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RentSuvs;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Suvs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBoxSuvs;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Suvs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SuvsGrid;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Suvs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackSuvs;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Suvs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteSuvs;
        
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
            System.Uri resourceLocater = new System.Uri("/cpv1;component/suvs.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Suvs.xaml"
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
            
            #line 9 "..\..\Suvs.xaml"
            ((cpv1.Suvs)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RentSuvs = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Suvs.xaml"
            this.RentSuvs.Click += new System.Windows.RoutedEventHandler(this.RentSuvs_Click);
            
            #line default
            #line hidden
            
            #line 14 "..\..\Suvs.xaml"
            this.RentSuvs.Loaded += new System.Windows.RoutedEventHandler(this.RentSuvs_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SearchBoxSuvs = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.SuvsGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.BackSuvs = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\Suvs.xaml"
            this.BackSuvs.Click += new System.Windows.RoutedEventHandler(this.BackSuvs_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeleteSuvs = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\Suvs.xaml"
            this.DeleteSuvs.Click += new System.Windows.RoutedEventHandler(this.DeleteSuvs_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

