   M S B A M L   `   `   `  ����O  KDesignMaterialsStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DesignMaterialsStore.ViewDesignMaterialsStore.View  5   	   O,clr-namespace:DesignMaterialsStore.ViewModelDesignMaterialsStore.ViewModel  5   	   (    "DesignMaterialsStore.View.MainView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:DesignMaterialsStore.View     5   	   B	viewModel,clr-namespace:DesignMaterialsStore.ViewModel     5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	     � Title$  Materials Store��5
   	   $	��700��6!   $
��1300��6.    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency .  � Icon$ /Images/icon1.png��5   	    � DataContext 5      2   ,DesignMaterialsStore.ViewModel.MainViewModel  5   
    � 	Resources 5       �� DataType2   ,DesignMaterialsStore.ViewModel.HomeViewModel(   "DesignMaterialsStore.View.HomeView2   ,DesignMaterialsStore.ViewModel.ItemViewModel(   "DesignMaterialsStore.View.ItemView5   /DesignMaterialsStore.ViewModel.InvoiceViewModel+   %DesignMaterialsStore.View.InvoiceView4   .DesignMaterialsStore.ViewModel.WorkerViewModel*	   $DesignMaterialsStore.View.WorkerView4
   .DesignMaterialsStore.ViewModel.ClientViewModel*   $DesignMaterialsStore.View.ClientView��%w  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5#      *, +)(�� �     5'      *,
 +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5         5!      �� 5#   
   "  6   .R�5$      	  5%      �� 5'   
   " 
 6   .R�5(        5)      5+      .��5-      ��  �� CornerRadius$ 10��6   $��1q�5.      ��50   
   �� 51      	 �� 
StartPoint$		 0,0&�6"   
 �� EndPoint$

 1, 1&�63   .��52      �    winBorderColor1 � Color# [  6    � Offset$ 0Q�6H   � 53        winBorderColor2# [ 6   $
 0.75Q�6H   � 54        winBorderColor3# [ 6   $ 1Q�6H   55      ._�58   
   �  � ColumnDefinitions 5:      �� 5<      $	��270 �6#   �� 5>      $��* �6#   .+�5B      �� $ 	10,0,0,10��6   $��0��5C      ��5E      �� 5F      $		 0,0&�6*   $
 1, 0.7&�6;   .��5G      �   secondaryBackColor1# [ 6'   $ 0Q�6T   � 5H        secondaryBackColor2# [ 6'   $ 1Q�6T   5I      ._�5L      �� .+�5O      ��  �� Orientation$ 
Horizontal=�6!   $��35��5P   !   $��
15,25,0,40q�5Q   !   .+�5R      �� $��/Images/icon1.png��6    �� 5S      $��MATERIALS STORE��6$     plainTextColor1#��[ 5T   $   $��20(�5U   $     
Montserrat#��[ 5V   $   $��Medium"�5W   $   $��Center=�5X   $   $��10,0,0,0q�5Y   $   5[      	� 5^        
menuButton#��[ 6"    
 color1
 � Tag# [ 5_   "    d� 	IsChecked$
 TrueY�5`   "   ��5a   "   �� *ShowHomeViewCommand+.��5b      �� $ 
Horizontal=�6%   .+�5c      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�6+    	 menuButtonIcon#��[	 67   �� 5d      $��Accueil��6(    
 menuButtonText#��[
 67   5e      5f      	� 5h      #��[ 6"    
 color2# [ 5i   "   ��5j   "   �� *ShowInvoiceViewCommand+.��5k      �� $ 
Horizontal=�6%   .+�5l        $ FileInvoiceDollar=�6+   #��[	 6D   �� 5m      $��Factures��6(   #��[
 68   5n      5o      	� 5q      #��[ 6"    
 color3# [ 5r   "   ��5s   "   �� *ShowItemViewCommand+.��5t      �� $ 
Horizontal=�6%   .+�5u        $ CartShopping=�6+   #��[	 6?   �� 5v      $��Articles��6(   #��[
 68   5w      5x      	� 5z      -   5        #��[ 5z   "    
 color4# [ 5{   "   ��5|   "   �� *ShowClientViewCommand+.��5}      �� $ 
Horizontal=�6%   .+�5~        $ Users=�6+   #��[	 68   �� 5      $��Clients��6(   #��[
 67   5�      5�      	� 5�      #��[ 6"    
 color6# [ 5�   "   ��5�   "   �� *ShowWorkerViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ 	Briefcase=�6+   #��[	 6<   �� 5�      $��	Employés��6(   #��[
 68   5�      5�      5�      5�      �� 5�      $ 	0,10,10,0��6   $��1��5�      ��5�      �� 5�      $		 1,1&�6*   $	
 0,0&�6;   .��5�      �   primaryBackColor1# [ 6'   $ 0Q�6R   � 5�        primaryBackColor2# [ 6'   $ 1Q�6R   5�      ._�5�      �  � RowDefinitions 5�      �� 5�      $��25 �6(   �� 5�      $��35 �6(   �� 5�      $��* �6(   .+�5�      �� -   5         ��Name$ pnlControlBar��5�   !   $��0��5�   !   $ 
Horizontal=�5�   !   $��RightToLeft=�5�   !   
������ $��0,0,5,0q�5�   !   .+�5�      �� -   5         ��Name$ btnClose��5�   !     controlButton#��[ 5�   !   # [ 5�   !   .��5�        $ Xmark=�6+     controlButtonIcon#��[ 68   5�      �� 5�      -   5        $ btnMaximize��5�   !   #��[ 5�   !    
 color8# [ 5�   !   .��5�        $ Square=�6+   #��[ 69   5�      �� 5�      -   5        $ btnMinimize��5�   !   #��[ 5�   !   # [ 5�   !   .��5�        $ WindowMinimize=�6+   $��12��6A   #��[ 6L   5�      5�      � 5�      $��1��6    5�      �� 5�      �� 5�      .+�5�      �� $��0��6%   $ 
Horizontal=�5�   %   $��Center=�5�   %   .+�5�        $��20��5�   +   $��20��5�   +     titleColor1   
Foreground# [ 5�   +   $��	35,0,10,0q�5�   +    5�   +   �� *Icon+5�   +   �� 5�      #��[ 5�   (   $��16(�5�   (   #��[ 5�   (   $��Medium"�5�   (   $��Center=�5�   (   ��5�   (   �� *	Caption+5�   (   5�      �� 5�      $��1��6%   $ 
Horizontal=�5�   %   $��RightToLeft=�5�   %   $��Center=�5�   %   $��0,0,10,0q�5�   %   .+�5�      ��   
iconButton#��[ 6%   # [ 5�   %   .��5�   "     $ 	AngleDown=�6/   $��12��5�   /   $��12��6;     iconButtonIcon#��[ 5�   /   5�      �� 5�      #��[ 5�   (   #��[ 5�   (   $��12(�5�   (   $��Center=�5�   (   ��5�   (   �� *" CurrentWorkerAccount.DisplayName+5�   (   5�      5�      �� 5�      $��2��5�   %   $��25q�5�   %   ��5�   %   �� *CurrentChildView+5�   %   5�      5�      5      5     5     