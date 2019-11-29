﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "66E9F6F0615C51D931E7A20B3CDC8AB8EFFE9C05C0349AD63B3D5EFA33355017"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Order_Generator;
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


namespace Order_Generator {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DrawerHost mainDrawer;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton dataheaderRadio;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton datalinesRadio;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl dataheaderContent;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TBC;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox dataheaderTextBox;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loadBtn;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextBtn;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox datalineTextBox;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Order-Generator;component/mainwindow.xaml", System.UriKind.Relative);
            
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
            this.mainDrawer = ((MaterialDesignThemes.Wpf.DrawerHost)(target));
            return;
            case 2:
            
            #line 29 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.dataheaderBtnClicked);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 32 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.datalinesBtnClicked);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 37 "..\..\MainWindow.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Card_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dataheaderRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 65 "..\..\MainWindow.xaml"
            this.dataheaderRadio.Click += new System.Windows.RoutedEventHandler(this.dataheaderRdioClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.datalinesRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 70 "..\..\MainWindow.xaml"
            this.datalinesRadio.Click += new System.Windows.RoutedEventHandler(this.datalinesRdioClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 78 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.closeBtnClicked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dataheaderContent = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 9:
            this.TBC = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.dataheaderTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 104 "..\..\MainWindow.xaml"
            this.dataheaderTextBox.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.dataheaderTextBoxClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.loadBtn = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\MainWindow.xaml"
            this.loadBtn.Click += new System.Windows.RoutedEventHandler(this.loadBtnClick);
            
            #line default
            #line hidden
            return;
            case 12:
            this.nextBtn = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\MainWindow.xaml"
            this.nextBtn.Click += new System.Windows.RoutedEventHandler(this.nextBtnClick);
            
            #line default
            #line hidden
            return;
            case 13:
            this.datalineTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 108 "..\..\MainWindow.xaml"
            this.datalineTextBox.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.datalinesTextBoxClick);
            
            #line default
            #line hidden
            return;
            case 14:
            this.createBtn = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\MainWindow.xaml"
            this.createBtn.Click += new System.Windows.RoutedEventHandler(this.CreateBtn_OnClickBtnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

