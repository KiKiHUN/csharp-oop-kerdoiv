   M S B A M L   `   `   `  ����N  JIncidens Kérdőív, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:beadandobeadando  5   	       beadando.UserMain   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.62.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:beadando     5   	     � Title$  Incidens Kérdőívek��5   	   $	��450��6$   $	��800��61    � WindowStartupLocation$ CenterScreen=�6=   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF8791B1��6    � Offset$	 0.1Q�6-   � 5      $ 	#FF6F85C5��6   $
 0.85Q�6-   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��13* �6   �� 5      $	��37* �6   .+�5   
   �� -   5         ��Name$ kutataslista��5      $y�Hidden=�6(   $��2��6g   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ 	#FF156D7F��6#   � 5      $ 	#FF1BA0B9��6#   $ 0.967Q�65   5      ��5      �� 5      .R�5      �� $��0,0,0,1q�6   
���   ���67   �� *ActualWidth+ �� ElementName$ listbox1��._�5      �� ��6    �� 5      5       5"      �� 5#   
   -   5        	 ��Name$	 CANVAS_Kitolto��5#      $y�Hidden=�6)   $��2��6=   ��5$      �� 5%      $ 0.5,1&�6&   $ 0.5,0&�67   .��5&      � $ 	#FF156D7F��6#   � 5'      $ 	#FF1BA0B9��6#   $ 0.967Q�65   5(      .+�5*      �� -   5        
 ��Name$
 	TX_Kerdes��5*      $�� ��6'    �� Left$ 88��62   
 �� Top$ 47��6C   $	��135��6S   $	��624��6`   $��22(�6l   $��Center=�6z   $��Center=�6�   �� 5+      -   5         ��Name$ 
box_valasz��5+      $	 124��6+   $	 229��6=   $	��552��6N   $��49��6Z   ���	#FF61F9F6
���   �
���   �6�   �� 5,      -   5         ��Name$
 Back��5,      $��<-��6#   $	 338��63   $	 344��6E   $��Center=�6V   $��36��6s   $��Center=�6   $��20(�6�   ���	#FF61F9F6���	#FF4C34346�   �� 5-      -   5        $
 Next��5-      $��->��6#   $	 436��63   $	 344��6E   $��36��6V   $
��Left=�6b   $��Center=�6}   $��20(�6�   ���	#FF61F9F6���	#FF4C34346�   �� 5.      -   5        $ Megsem��5.      $��Mégsem��6%   $	 703��66   $	 349��6H   $��36��6Y   $��59��6e   ���	#FF4C3434���	#FFD876766�   �� 5/      -   5        $ Bekuld��5/      $
��Bead��6%   $	 617��64   $	 349��6F   $��36��6W   $��59��6c   $
��Left=�6n   $��Center=�6�   ���	#FF48CA98���	#FF4C34346�   �� 50      -	   5        $
 pageCounter��50      $	��x/y��6)   $	 369��67   $	 345��6I   $��18(�6Z   $
��Left=�6h   $	��Top=�6�   $��62��6�   $��Center=�6�   $��Center=�6�   52      53      54      