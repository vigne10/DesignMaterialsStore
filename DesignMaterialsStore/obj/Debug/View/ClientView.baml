   M S B A M L   `   `   `  ����O  KDesignMaterialsStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DesignMaterialsStore.ViewDesignMaterialsStore.View  5      *    $DesignMaterialsStore.View.ClientView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:DesignMaterialsStore.View     5        � 	Resources  5
      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value   LeftCell  LeftAlignedCheckBox  CheckBoxColumnHeader��%:  '        &	  �     &	     &	 R    �� 5   
   "  6   .�5      ��  � ��$
 Left=�6;   �� 5       � �� �#4646466+   �� 5       � ��
 �����6+   �� 5       � ��$ 13(�6)   5      �� 5   
   " ��6!   .�5      ��  � ��$
 Left=�64   5      �� 5   
   " ��6,   .�5      ��  � ��$
 Left=�64   5      �� 5   
   "  6-   .�5      ��  � ��$ Center=�6;   �� 5       � �� �#4646466+   �� 5       � ��
 �����6+   �� 5       � ��$ 13(�6)   5      5      .��5!      � ���#464646 � RowDefinitions 5"   
   �� 5#      $��* �6   �� 5$      $��90 �6   .+�5'   
   � $��0��6   .+�5)      &   System.Windows.Controls.DataGrid  -   5        $��DataGridClient��5)         AutoGenerateColumns .  ��. 
������ $
��Auto=�50      $
��Auto=�51         CanUserAddRows .  $
��Left=�53         SelectionUnit$ FullRow=�54         RowBackground
 �����	   GridLinesVisibility$
	 None=�56      
   CanUserDeleteRows
 .  
������ $
��Left=�59        
Montserrat#��[ 5:         CanUserResizeColumns .    CanUserResizeRows .     CanUserSortColumns .    CanUserReorderColumns . $��13(�5?      $��0q�5@      ��5*      �� *ClientsCollection+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5+      �� *SelectedClient+$ TwoWay=�   Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6S   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  6_      
IsReadOnly .    Binding 65   ��  �� Path$ Id�6�     5D      $	 NOM��6)   $ * 6V   # [  6`    .  66   �� $
 Name�6�     5E      $ PRÉNOM��6)   $ * 6\   # [  6f    .  69   �� $ Surname�6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5F      $ ACTIF��6-   $	 100 6^    .    HeaderStyle# [ 6|    6<   �� $ Active�6|   5H      5I      � 5K   
   $��1��6   .+�5L      �� -   5         ��Name$ 	buttonAdd��5L      $��0q�5N   %   $��Ajouter un client��5O   %     plainTextColor1#��[ 5P   %   $��12(�5Q   %   #��[ 5R   %    � Cursor$
 Hand��5S   %   $��0,0,0,0q�5T   %   ��5M   %   �� *AddClientCommand+��5V      �� 5W      " ��6   .�5X      ��  � �� �#54545467    �� Triggers 5Y      P� 5Z       P� Property �@J�IsMouseOver P� Value . . �5[   "   ��  � �� �#8D8D8D6?   5\      5^      ��5a      �� 5b       �� 
TargetType" ��6&   .R�5c      �� $	��150��6!   $��40��6-     �� CornerRadius$  20��5d   )   #��z��5e   )   ._�5f      �� $��Center=�6/   $��Center=�5g   7   5h      5i      5k      5l      5n      5q      