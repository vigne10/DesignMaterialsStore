   M S B A M L   `   `   `  ����O  KDesignMaterialsStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DesignMaterialsStore.ViewDesignMaterialsStore.View  5      O,clr-namespace:DesignMaterialsStore.ViewModelDesignMaterialsStore.ViewModel  5      +    %DesignMaterialsStore.View.InvoiceView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:DesignMaterialsStore.View     5      B	viewModel,clr-namespace:DesignMaterialsStore.ViewModel     5        � 	Resources  5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value   LeftCell  LeftAlignedCheckBox  CheckBoxColumnHeader��%:  '        &	  �     &	     &	 R    �� 5   
   "  6   .�5      ��  � ��$
 Left=�6;   �� 5       � �� �#4646466+   �� 5       � ��
 �����6+   �� 5       � ��$ 13(�6)   5      �� 5   
   " ��6!   .�5      ��  � ��$
 Left=�64   5      �� 5   
   " ��6,   .�5      ��  � ��$
 Left=�64   5      �� 5   
   "  6-   .�5      ��  � ��$ Center=�6;   �� 5       � �� �#4646466+   �� 5       � ��
 �����6+   �� 5       � ��$ 13(�6)   5      5!      .��5$      � ���#464646 � RowDefinitions 5%   
   �� 5&      $��* �6   �� 5'      $��90 �6   .+�5*   
   � $��0��6   .+�5,      &   System.Windows.Controls.DataGrid  -   5        $��DataGridInvoice��5,         AutoGenerateColumns .  ��. 
������ $
��Auto=�53      $
��Auto=�54         CanUserAddRows .  $
��Left=�56         SelectionUnit$ FullRow=�57         RowBackground
 �����	   GridLinesVisibility$
	 None=�59      
   CanUserDeleteRows
 .  
������ $
��Left=�5<        
Montserrat#��[ 5=         CanUserResizeColumns .    CanUserResizeRows .     CanUserSortColumns .    CanUserReorderColumns . $��13(�5B      $��0 0 0 0q�5C      ��5-      �� *InvoiceCollection+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5.      �� *SelectedInvoice+$ TwoWay=�   Columns 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6S   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  6_      
IsReadOnly .    Binding 65   ��  �� Path$ Id�6�     5G      $ EMPLOYÉ��6)   $ * 6a   # [  6k    .  6:   �� $ Worker.Name�6�     5H      $ CLIENT��6)   $ * 6`   # [  6j    .  69   �� $ Client.Name�6�     5I      $
 DATE��6)   $ * 6p   # [  6z    .  67   �� $
 Date� �� StringFormat$ 
dd/MM/yyyy��6�     5J      $
 PRIX��6)   $ * 6n   # [  6x    .  67   �� $ Price�$ {0} €��6�   5L      5M      � 5O   
   $��1��6   .+�5P      �� -   5         ��Name$ 	buttonAdd��5P      $��0q�5R   %   $��Ajouter une facture��5S   %     plainTextColor1#��[ 5T   %   $��12(�5U   %   #��[ 5V   %    � Cursor$
 Hand��5W   %   $��0,0,0,0q�5X   %   ��5Q   %   �� *AddInvoiceCommand+��5Z      �� 5[      " ��6   .�5\      ��  � �� �#54545467    �� Triggers 5]      P� 5^       P� Property �@J�IsMouseOver P� Value . . �5_   "   ��  � �� �#8D8D8D6?   5`      5b      ��5e      �� 5f       �� 
TargetType" ��6&   .R�5g      �� $	��150��6!   $��40��6-     �� CornerRadius$  20��5h   )   #��z��5i   )   ._�5j      �� $��Center=�6/   $��Center=�5k   7   5l      5m      5o      5p      5r      5u      