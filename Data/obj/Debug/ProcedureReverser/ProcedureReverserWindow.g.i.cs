﻿#pragma checksum "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B5390CFBDEDF75AE6173723268B0A5FD20767B833EA8F81D11170BCF5C55268E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WorkProject.Main.ProcedureReverser;


namespace WorkProject.Main.ProcedureReverser {
    
    
    /// <summary>
    /// ProcedureReverserWindow
    /// </summary>
    public partial class ProcedureReverserWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox InputProcedure;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox OutputProcedure;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PasteButton;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CopyButton;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InvertButton;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox EditCheckBox;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label;
        
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
            System.Uri resourceLocater = new System.Uri("/WorkProject;component/procedurereverser/procedurereverserwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
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
            this.InputProcedure = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.OutputProcedure = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.PasteButton = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
            this.PasteButton.Click += new System.Windows.RoutedEventHandler(this.PasteButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CopyButton = ((System.Windows.Controls.Button)(target));
            
            #line 131 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
            this.CopyButton.Click += new System.Windows.RoutedEventHandler(this.CopyButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.InvertButton = ((System.Windows.Controls.Button)(target));
            
            #line 142 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
            this.InvertButton.Click += new System.Windows.RoutedEventHandler(this.InvertButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EditCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 153 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
            this.EditCheckBox.Checked += new System.Windows.RoutedEventHandler(this.EditCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 154 "..\..\..\ProcedureReverser\ProcedureReverserWindow.xaml"
            this.EditCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.EditCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Label = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

