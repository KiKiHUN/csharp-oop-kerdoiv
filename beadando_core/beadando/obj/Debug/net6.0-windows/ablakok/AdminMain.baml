   M S B A M L   `   `   `  ����N  JIncidens Kérdőív, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:beadandobeadando  5   	       beadando.AdminMain   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.62.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:beadando     5   	   >c1/http://schemas.componentone.com/winfx/2006/xaml     5   	   -   5          �Name$  Ablak_admin��5   D    � Title$ Admin Panel��5	   	   $	��450��6   $	��733��6*    � WindowStartupLocation$ CenterScreen=�66   ${�False��6[   ��5
      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF8791B1��6    � Offset$	 0.1Q�6-   � 5      $ 	#FF6F85C5��6   $
 0.85Q�6-   5      .��5      � -   5         �Name$ MainGrid��5      .+�5   
   �� -   5         ��Name$ listbox1��5      $��Hidden=�6%   $y�Hidden=�6Z   $��70,27,10,21q�6n   ���	#FFB4B8C5$��Stretch=�6�   ��5      �� 5      .R�5      �� $��0,0,0,1q�6   
���   ���67   �� *ActualWidth+	 �� ElementName$	 listbox1��._�5      �� ��6    �� 5      5      5      �� 5   
   -   5        
 ��Name$
 InfoPNG��5      $y�Hidden=�6!   $
��Left=�65   $��32��6P   $��	10,58,0,0q�6\   $	��Top=�6o   $��34��6�   $��
/63830.png��6�   6�   �� 5   
   -   5        $
 
RefreshPNG��5      $y�Hidden=�6$   $
��Left=�68   $��32��6S   $��
10,106,0,0q�6_   $	��Top=�6s   $��34��6�   $��/img_321592.png��6�   6�   �� 5    
   -   5         ��Name$ canvas_Kutatas_edit_uj��5       $��0,98,0,0q�61   $y�Hidden=�6C   ���	#FFC3D8DA$	��298��6n   $	��532��6{    � UseLayoutRounding$
 True��6�   $	��Top=�6�   $��Center=�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5!      V� 5"      .~�5#      ��  �� ScaleY$ 1Q�6%    �� ScaleX$ 1Q�60   �� 5$      �� 5%      T� 5&      5'      .+�5)      �� $��Név:��6    �� Left$ 6��6#   
 �� Top$ 20��63   $
��Left=�6C   $��50��6^   $	��Top=�6j   $��66��6�   $��13(�6�   $
��Bold"�6�   $��Center=�6�   $��Center=�6�   
���   �6�   �� 5*      -   5         ��Name$ TB_nev��5*      $ 84��6&    �� TextWrapping$
 Wrap=�67   $�� ��6K   $ 26��6S   $	��380��6c   $��38��6o   $
��Left=�6{   $��Center=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $��15(�6�   
���   �6�   �� 5+      -   5         ��Name$ slider_elvart��5+      $ 13��6,   $	 116��6=   $	��451��6N    � Maximum$
 1000Q�6Z    � Minimum$ 1Q�6i   $
��Left=�6u   $��Center=�6�   $��19��6�    � SmallChange$ 1Q�6�    � Value$ 1Q�6�    �� IsSnapToTickEnabled$
 True��6�    � LargeChange$ 10Q�6  
���   �
���   ���6;  Z� 6Q  �� 5,      -	   5         ��Name$ elvartKitoltesekLB��5,      $��Elvárt kitöltések:��60   $ 15��6M   $ 84��6^   $��Center=�6n   $	��Top=�6�   $��13(�6�   $
��Bold"�6�   $	��115��6�   
���   �6�   �� 5-      -
   5        $ 	TX_elvart��5-      $	 146��6)   $
 Wrap=�6;   $�� ��6O   $ 85��6W   $��66��6g   $��17(�6s   $
��Bold"�6�   $
��Left=�6�   $��25��6�   $	��Top=�6�   
���   �6�   �� 5.      -   5         ��Name$ btn_edit_save��5.      $��Mentés��6,   $	 295��6=   $	 256��6O   $��32��6`   $��74��6l   $
��Left=�6w   $	��Top=�6�   
���   �6�   �� 5/      -   5        $��Mégsem��5/      $	 401��6&   $	 256��68   $��32��6I   $��75��6U   $
��Left=�6`   $��Center=�6{   
���   �6�   �� 50      -   5        $ kezdetLB��50      $��Kezdet:��6&   $ 13��68   $	 144��6I   
���   �6Z   �� 52      -   5        $ vegLB��52      $��Vég:��6#   $	 139��62   $	 144��6D   $
��Left=�6U   $	��Top=�6p   
���   �6�   �� 55      -   5         ��Name$ 	aktivalva��55      $��
Aktiválva��6*   $	 369��6>   $	 174��6P   $
��Left=�6a   $��17��6|   $	��Top=�6�   $	��102��6�   $ 0.5,0.5&�6�   
���   �z�56      V� 57      .~�58      �� $	 1.1Q�6)   $	 1.1Q�66   �� 59      �� 5:      T� 5;      5<      5>      �� 5?      -   5        $ DateTimePicker1��5?      $��84��6.   $	��135��6:   $
��Left=�6F   $��Center=�6a   $	 173��6|   $ 5��6�   .+�5@      (  "System.Windows.Controls.DatePicker  -   5          Name$ Kezdet_datum��5@      $ -4��63   $ 14��6D   $
��Left=�6T   $��33��6o   $	��Top=�6{   $	��142��6�   $ 0.5,0.5&�6�   
���   ���6�   Z� z�5A      V� 5B      .~�5C      �� $	 0.9Q�6-   $
 1.35Q�6:   �� 5D      �� 5E      T� 5F      5G      5I      �� 5J      -   5          ��Name$  
Kezdet_ora��5J      $ 52��6/   $��59��6?   $
��Left=�6J   $	��Top=�6e   $ 0.5,0.5&�6}   z�5K      V� 5L      .~�5M      �� $	 0.8Q�6-   $
 1.05Q�6:   �� 5N      �� 5O      T� 5P      5Q      5S      �� 5T      -   5        $  Kezdet_perc��5T      $ 67��60   $ 52��6A   $��59��6Q   $ 0.5,0.5&�6\   $
��Left=�6|   $	��Top=�6�   z�5U      V� 5V      .~�5W      �� $	 0.9Q�6-   $
 1.15Q�6:   �� 5X      �� 5Y      T� 5Z      5[      5]      �� 5^      $��:��6   $ 54��6$   $ 48��65   
���   �$
��Left=�6n   $	��Top=�6�   $��14��6�   $ 0.524,0.284&�6�   ��6E   Z� 6�   �� 5_      $��84��6   
���   �$	��130��67   $
��Left=�6C   $	��Top=�6^   5`      �� 5b      -   5        $ DateTimePicker2��5b      $��84��6.   $	��135��6:   $
��Left=�6F   $��Center=�6a   $	 173��6|   $	 145��6�   .+�5c        -   5        $ 	veg_datum��5c      $ -4��60   $ 14��6A   $
��Left=�6Q   $��33��6l   $	��Top=�6x   $	��142��6�   $ 0.5,0.5&�6�   
���   ���6�   Z� z�5d      V� 5e      .~�5f      �� $	 0.9Q�6-   $
 1.35Q�6:   �� 5g      �� 5h      T� 5i      5j      5l      �� 5m      -   5        $  veg_ora��5m      $ 52��6,   $��59��6<   $
��Left=�6G   $	��Top=�6b   $ 0.5,0.5&�6z   z�5n      V� 5o      .~�5p      �� $	 0.8Q�6-   $
 1.05Q�6:   �� 5q      �� 5r      T� 5s      5t      5v      �� 5w      -   5        $  veg_perc��5w      $ 67��6-   $ 52��6>   $��59��6N   $ 0.5,0.5&�6Y   $
��Left=�6y   $	��Top=�6�   z�5x      V� 5y      .~�5z      �� $	 0.9Q�6-   $
 1.15Q�6:   �� 5{      �� 5|      T� 5}      5~      5�      �� 5�      $��:��6   $ 54��6$   $ 48��65   
���   �$
��Left=�6n   $	��Top=�6�   $��14��6�   $ 0.524,0.284&�6�   ��6E   Z� 6�   �� 5�      $��84��6   
���   �$	��130��67   $
��Left=�6C   $	��Top=�6^   5�      �� 5�      -   5        $ 
WindowMode��5�      $�� ��6(   $	 484��63   $ 10��6E   5�      �� 5�   
   -   5        $ sidemenu��5�      $
��Left=�6#   $	��141��6>   $y�Visible=�6J   $	��434��6_   $	��Top=�6l   .+�5�      �� -   5        $ sidemenu_unfolded��5�      $��	0,0,657,0q�60   $y�Hidden=�6C   ���	#FF5A5959! J� OpacityMask! �	#FF565555$��Disabled=�6�   .+�5�      �� -   5        " ��Name$" hatter��5�      $	��434��6,   $	��150��69   $
��Left=�6E   $��Center=�6`   $��Disabled=�6{   ��5�      �� 5�      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5�      � $ 	#FF609AAD��6+   $
 0.03Q�6=   � 5�      $ 	#FF4359B3��6+   $ 0.973Q�6=   5�      5�      �� 5�      -   5        $ spacer_setter��5�      $�� ��6/   $��Center=�6:   $��Center=�6W   $��95��6r   $ 10��6}   $ 19��6�   �� 5�      -   5        $ 
buttonList��5�      $��Center=�6.   $	��Top=�6K   $	��110��6c   $��Disabled=�6�   $	��200��6�   ��6o   Z� ��6�   Z� ��6�   Z� ��5�      �� 5�      .R�5�      �� $��0,0,0,1q�6%   
���   ���6?   �� *ActualWidth+$	 spacer_setter��._�5�   "   �� ��6(   �� 5�      5�      .@�5�      �� -   5        $��Új kutatás��5�      $��82��62   $��34��6=   ���	#FF080000���	#FFC8D8DA6y   �� 5�      -   5        $ gomb1��5�      $��Összes kutatás��6,   $��84��6E   $��34��6P   $��11(�6\   
���   �
���   ����	#FFC8D8DA6�   �� 5�      -    5        $��Új kutatások��5�      $��83��64   $��34��6?   $��11(�6K   
���   ����	#FFC8D8DA6�   �� 5�      -!   5        $��Futó kutatások��5�      $��83��66   $��34��6A   $��11(�6M   
���   ����	#FFC8D8DA6�   �� 5�      -"   5        $��Volt kutatások��5�      $��83��66   $��34��6A   $��11(�6M   
���   ����	#FFC8D8DA6�   5�      �� 5�      -#   5        $ btn_back��5�      .+�5�      �� $��20��6   $	 117��6(   $ 11��6:   $��21��6J   $��/340.png��6U   $
��Left=�6g   $��Center=�6�   A� 5�      $
��Left=�6   $��26��69   
���   �$��Center=�6T   $��26��6o   $	 115��6z   $ 8��6�   5�      �� 5�      -$   5        $ sidemenu_line��5�      $�� ��6/   $	 147��6:   $
��Left=�6L   $��Center=�6g   $��3��6�   $	��434��6�   ���	#FFADADAD6�   5�      �� 5�      -%   5        $ sidemenu_folded��5�      $y�Hidden=�6.   .+�5�      �� -&   5        $��38��5�      $ 10��6$   $ 7��65   $��32��6D   $��/3388823.png��6O   6e   5�      5�      5�      5�      