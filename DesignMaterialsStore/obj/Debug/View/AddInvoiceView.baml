   M S B A M L   `   `   `  ����O  KDesignMaterialsStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DesignMaterialsStore.ViewDesignMaterialsStore.View  5   	   O,clr-namespace:DesignMaterialsStore.ViewModelDesignMaterialsStore.ViewModel  5   	   .    (DesignMaterialsStore.View.AddInvoiceView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:DesignMaterialsStore.View     5   	   B	viewModel,clr-namespace:DesignMaterialsStore.ViewModel     5   	   -   5          � Title$  Ajouter une facture��5	   	   $	��580��6%   $
��1000��62    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency .  � Icon$ /Images/icon1.png��5   	    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property	 �� Value   LeftCell  LeftAlignedCheckBox  CheckBoxColumnHeader��%:  '        &	  �     &	     &	 R    �� 5   
   "  6   .�5      ��  � ��$
	 Left=�6;   �� 5       � ��	 �#4646466+   �� 5       � ��
	 �����6+   �� 5       � ��$	 13(�6)   5      �� 5   
   " ��6!   .�5      ��  � ��$
	 Left=�64   5      �� 5   
   " ��6,   .�5      ��  � ��$
	 Left=�64   5      �� 5!   
   "  6-   .�5"      ��  � ��$	 Center=�6;   �� 5#       � ��	 �#4646466+   �� 5$       � ��
	 �����6+   �� 5%       � ��$	 13(�6)   5&      5(      .��5*      �� 
 �� CornerRadius$
 12��6   ._�5,   
   �� $
 10��6   $��2q�5-      ��5.      �� 5/       �� 
StartPoint$	 0,0&�6&    �� EndPoint$
 1, 1&�67   .��50      �   winBorderColor1 � Color# [ 6#    � Offset$ 0Q�6L   � 51        winBorderColor2# [ 6#   $
 0.75Q�6L   � 52        winBorderColor3# [ 6#   $ 1Q�6L   53      ��56      �� 57        primaryBackColor1 �� Color# [ 6"   ._�5:      �  � RowDefinitions 5;      �� 5<      $��30 �6$   �� 5=      $��* �6$   �� 5>      $��90 �6$   .+�5B      � $��0��6    � ColumnDefinitions 5C      �� 5D      �� 5E      $��25 �6+   �� 5F      $��25 �6+   �� 5G      $��5 �6+   .+�5J      �� $��AJOUTER UNE FACTURE��6      plainTextColor1#��[ 5K       $��10(�5L         
Montserrat#��[ 5M       $��0��5N       $��Center=�5O       $��10 0 0 0q�5P       �� 5R      -   5         ��Name$ buttonMinimize��5R      $��0q�5S      $��-��5T      #��[ 5U      $��16(�5V      #��[ 5W       � Cursor$
 Hand��5X      $��1��5Y      ��5\      �� 5]      " ��6$   .�5^   "   ��  � ��	 �#7F7F7F6?    �� Triggers 5_   "   P� 5`   &    P� Property �@J�IsMouseOver P� Value . . �5a   *   ��  � ��	 �#A9A9A96G   5b   '   5d      ��5g      �� 5h       �� 
TargetType" ��6.   .R�5i   "   �� $��18��6)   $��18��64   $
 9��5j   )   #��z��5k   )   ._�5l   &   �� $��Center=�67   $��Center=�5m   7   5n   #   5o      5r      �� 5t      -   5        $ buttonClose��5t      $��0q�5u      $��x��5v      #��[ 5w      $��12(�5x      #��[ 5y      $
 Hand��5z      $��2��5{      ��5~      �� 5      " ��6$   .�5�   "   ��  � ��	 �#5454546?    5�   "   P� 5�   &    �@J�IsMouseOver . . �5�   *   ��  � ��	 �#8D8D8D6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $��18��6)   $��18��64   $
 9��5�   )   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      5�      � 5�      $��1��6   $��	0 20 40 0q�5�       5�      �� 5�      $	��425 �6+   �� 5�      $��* �6+   .+�5�      �� $��15q�6!   $	��250��5�       �� Orientation$ Vertical=�5�      .+�5�      �� $��Identifiant d'employé :��6    
�������$��13(�5�      #��[ 5�      $��0 20 0 0q�5�      �� 5�      -   5         ��Name$ TextBoxWorkerID��5�   "   $��13(�5�      $��Medium"�5�      #��[ 5�      #��[ 5�       �� 
CaretBrush
 �����
�������$��0,0,0,1q�5�      $��28��5�      $��Center=�5�      $��20,0,0,0q�5�      $��
0,-5, 0, 0q�5�      ��5�      �� *
WorkerID+ �� UpdateSourceTrigger$ PropertyChanged=�.��5�   @   ��5�      �� 5�   "   # [ 62   .��5�   2   5�      �� 5�      $��Nom de l'employé :��6    
�������$��13(�5�      #��[ 5�      $��0 20 0 0q�5�      �� 5�      -   5        $ TextBoxWorkerName��5�   "   $��13(�5�      $��Medium"�5�      #��[ 5�      #��[ 5�      
 �����
�������$��0,0,0,1q�5�      $��28��5�      $��Center=�5�      $��
0,-5, 0, 0q�5�      $��20,0,0,0q�5�      {�.  ��5�      �� *Worker.Name+$ PropertyChanged=�.��5�   0   ��5�      �� 5�   "   # [ 62   .��5�   2   5�      �� 5�      $��Identifiant de client :��6    
�������$��13(�5�      #��[ 5�      $��0 20 0 0q�5�      �� 5�      -   5        $ TextBoxClientID��5�   "   $��13(�5�      $��Medium"�5�      #��[ 5�      #��[ 5�      
 �����
�������$��0,0,0,1q�5�      $��28��5�      $��Center=�5�      $��20,0,0,0q�5�      $��
0,-5, 0, 0q�5�      ��5�      �� *
ClientID+$ PropertyChanged=�.��5�   @   ��5�      �� 5�   "   # [ 62   .��5�   2   5�      �� 5�      $��Nom du client :��6    
�������$��13(�5�      #��[ 5�      $��0 20 0 0q�5�      �� 5�      -   5        $ TextBoxClientName��5�   "   $��13(�5�      $��Medium"�5�      #��[ 5�      #��[ 5�      
 �����
�������$��0,0,0,1q�5�      $��28��5�      $��Center=�5�      $��
0,-5, 0, 0q�5�      $��20,0,0,0q�5�      {�.  ��5�      �� *Client.Name+$ PropertyChanged=�.��5�   0   ��5�      �� 5�   "   # [ 62   .��5�   2   5      �� 5     $��Date :��6    
�������$��13(�5     #��[ 5     $��0 20 0 0q�5     (  "System.Windows.Controls.DatePicker  5        SelectedDateFormat$
 Long=�6C      SelectedDate 6%   �� *Date+6_   �� 5	      	 plainTextColor2#��[	 5
      $��Center=�5      $��10(�5      $��Medium"�5      #��[ 5      $��0,30,0,0q�5      ��5	  $   �� *ErrorMessage+ �� Mode$ TwoWay=�$ PropertyChanged=�5      5     � 5     $��1��6    5     �� 5     $��50 �6,   �� 5     $��* �6,   .+�5     � $��0��6    5     �� 5  "   $��* �63   �� 5  "   $��* �63   .+�5!     �� $��0��6)   $ 
Horizontal=�5"  )   $��Center=�5#  )   $��Center=�5$  )   .+�5%  "   �� $��Prix :��6(   
�������$��13(�5'  !   #��[ 5(  !   $��0 6 0 0q�5)  !   �� 5*  "   -   5        $ TextBoxPrice��5*  *   $��13(�5,  %   $��Medium"�5-  %   #��[ 5.  %   #��[ 5/  %   
 �����
�������$��0,0,0,0q�52  %   $��28��53  %   $	��100��54  %   $��Center=�55  %   $��20,0,0,0q�56  %   $��	0,6, 0, 0q�57  %    � Language$ be-FR�58  %   {�.  ��5+  %   �� *Price+  �� StringFormat$  {0:C}��$ PropertyChanged=�.��59  7   ��5:  &   �� 5;  *   # [ 6:   .��5<  :   5=  #   5>     �� 5@     $��1��6)   $��Center=�5A  )   .+�5B  "   �� -	   5        $ buttonAddItemToInvoice��5B  )   $��0q�5D  %   $��Ajouter un article��5E  %   #��[ 5F  %   $��12(�5G  %   #��[ 5H  %   $
 Hand��5I  %   $��0,0,10,0q�5J  %   ��5C  %   �� *AddItemToInvoiceCommand+��5L  &   �� 5M  *   " ��60   .�5N  .   ��  � ��	 �#5454546K    5O  .   P� 5P  2    �@J�IsMouseOver . . �5Q  6   ��  � ��	 �#8D8D8D6S   5R  3   5T  +   ��5W  &   �� 5X  *   " ��6:   .R�5Y  .   �� $	��150��65   $��40��6A   $
 20��5Z  )   #��z��5[  )   ._�5\  2   �� $��Center=�6C   $��Center=�5]  7   5^  /   5_  +   5a  #   5b     5d     � 5g     $��1��6   .+�5h     &   System.Windows.Controls.DataGrid  -
   5        $��DataGridInvoiceItem��5h  '   !   AutoGenerateColumns! .  ��. 
������ $
��Auto=�5o  !   $
��Auto=�5p  !   "   CanUserAddRows" .  $��Center=�5r  !   #   SelectionUnit$# FullRow=�5s  !   $   RowBackground
$ �����%   GridLinesVisibility$
% None=�5u  !   &   CanUserDeleteRows& .  
������ $��Center=�5x  !   #��[ 5y  !   '   CanUserResizeColumns' . (   CanUserResizeRows( .  )   CanUserSortColumns) . *   CanUserReorderColumns* . $��13(�5~  !   $��0 10 0 0q�5  !   ��5i  !   �� *InvoiceItemCollection+$ TwoWay=�$ PropertyChanged=�+ �� SelectedItem+ 5j  !   �� *SelectedInvoiceItem+$ TwoWay=�,   Columns, 5�  "   0  *System.Windows.Controls.DataGridTextColumn  5�  &   ,  &System.Windows.Controls.DataGridColumn-   Header$- ID��69   .   Width5  /System.Windows.Controls.DataGridLengthConverter$. 30 6h   1  +System.Windows.Controls.DataGridBoundColumn/   ElementStyle#/ [  6s   0   
IsReadOnly0 . 1   Binding1 6E   �� 2 �� Path$2 Item.Id�6�     5�  &   $	- NOM��69   $. * 6k   #/ [  6u   0 . 1 6F   �� $2 	Item.Name�6�     5�  &   $
- PRIX��69   $	. 100 6�   #/ [  6�   0 . 1 6G   �� $2 
Item.Price�$  {0} €��6�     5�  &   $- 	QUANTITÉ��69   $. 90 6o   #/ [  6z   0 . 1 6K   �� $2 Quantity�6�     5�  &   $- TOTAL��69   $	. 100 6   #/ [  6�   0 . 1 6H   �� $2 Price�$  {0} €��6�   5�     5�     5�     5�     �� 5�     $��2��6   $ 
Horizontal=�5�     $��Center=�5�     $��Center=�5�     .+�5�     �� -   5        $ 	buttonAdd��5�     $��0q�5�     $��AJOUTER��5�     #��[ 5�     $��12(�5�     #��[ 5�     $
 Hand��5�     $��2��5�     $��10,0,0,0q�5�     ��5�     �� *AddInvoiceCommand+��5�     �� 5�     " ��6$   .�5�  "   ��  � ��	 �#5454546?    5�  "   P� 5�  &    �@J�IsMouseOver . . �5�  *   ��  � ��	 �#8D8D8D6G   5�  '   5�     ��5�     �� 5�     " ��6.   .R�5�  "   �� $	��150��6)   $��40��65   $
 20��5�  )   #��z��5�  )   ._�5�  &   �� $��Center=�67   $��Center=�5�  7   5�  #   5�     5�     5�     5�     5�     5�     5�     