﻿#pragma checksum "..\..\..\View\EditInvoiceItemView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4CF16CF0E5E71CD41CEAB1D7E8D08A8F38B8C73F78916EFFA3653DFAB6E2AC52"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using DesignMaterialsStore.CustomControls;
using DesignMaterialsStore.View;
using DesignMaterialsStore.ViewModel;
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


namespace DesignMaterialsStore.View {
    
    
    /// <summary>
    /// EditInvoiceItemView
    /// </summary>
    public partial class EditInvoiceItemView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\View\EditInvoiceItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonMinimize;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\View\EditInvoiceItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxId;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\View\EditInvoiceItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxName;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\View\EditInvoiceItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxDescription;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\..\View\EditInvoiceItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPrice;
        
        #line default
        #line hidden
        
        
        #line 233 "..\..\..\View\EditInvoiceItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxQuantity;
        
        #line default
        #line hidden
        
        
        #line 259 "..\..\..\View\EditInvoiceItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDelete;
        
        #line default
        #line hidden
        
        
        #line 293 "..\..\..\View\EditInvoiceItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSave;
        
        #line default
        #line hidden
        
        
        #line 327 "..\..\..\View\EditInvoiceItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/DesignMaterialsStore;component/view/editinvoiceitemview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\EditInvoiceItemView.xaml"
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
            
            #line 16 "..\..\..\View\EditInvoiceItemView.xaml"
            ((DesignMaterialsStore.View.EditInvoiceItemView)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.buttonMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\View\EditInvoiceItemView.xaml"
            this.buttonMinimize.Click += new System.Windows.RoutedEventHandler(this.buttonMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TextBoxId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TextBoxDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TextBoxPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TextBoxQuantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.buttonDelete = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.buttonSave = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.buttonCancel = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
