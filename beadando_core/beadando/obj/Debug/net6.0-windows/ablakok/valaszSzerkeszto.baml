   M S B A M L   `   `   `  ����N  JIncidens Kérdőív, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:beadando.ablakokbeadando.ablakok  5   	   '    !beadando.ablakok.valaszSzerkeszto   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.62.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:beadando.ablakok     5   	     � Title$  Válaszok módisítása��5   	   $	��450��6%   $	��800��62    � WindowStartupLocation$ CenterScreen=�6>   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF8791B1��6    � Offset$	 0.1Q�6-   � 5      $ 	#FF6F85C5��6   $
 0.85Q�6-   5      .��5      � .+�5   
   �� -   5         ��Name$ 
ValaszList��5      $��54,52,54,19q�6Q   ��5      �� 5      .R�5      �� $��0,0,0,1q�6   
���   ���67   �� *ActualWidth+ �� ElementName$ listbox1��._�5      �� ��6    �� 5      5      5      �� 5   
   -   5         ��Name$ BTN_uj��5      $	��Új��6!   $
��Left=�6.   $��	78,10,0,0q�6I   $	��Top=�6\   $	��115��6t   $��32��6�   6�   �� 5   
   -   5        $ 
BTN_megsem��5      $��	Bezárás��6%   $
��Left=�67   $��
631,10,0,0q�6R   $	��Top=�6f   $	��115��6~   $��32��6�   6�   �� 5   
   -   5        	 ��Name$	 CANVAS_valasz_edit_uj��5      $��189,186,133,136q�60   $y�Hidden=�6I   ���	#FF10999C.+�5      �� -   5        
 ��Name$
 	TX_kerdes��5       �� Left$ 10��6)    �� TextWrapping$
 Wrap=�6:   $�� ��6N   
 �� Top$ 10��6V   $	��436��6f   $��37��6r   $ �� HorizontalScrollBarVisibility$
 Auto=�6~   $��15(�6�   
���   �$��Center=�6�   $��Center=�6�   ���	#FFD0E1E26�   �� 5      -   5        $ btn_edit_save��5      $��Mentés��6,   $	 284��6=   $ 53��6O   $��32��6_   $��74��6k   
���   �$
��Left=�6�   $	��Top=�6�   �� 5      -   5        $��Mégsem��5      $	 371��6&   $ 53��68   $��32��6H   $��75��6T   
���   �$
��Left=�6�   $	��Top=�6�   �� 5      -   5         ��Name$ 
windowMode��5      $�� ��6(   $ 21��63   $ 69��6D   5       �� 5!   
   $��Válaszok szerkesztése��6   $��Center=�60   $��0,8,0,0q�6M   $	��Top=�6^   $��36��6v   $	��252��6�   $��22(�6�   $��Center=�6�   $��Center=�6�   5#      5$      