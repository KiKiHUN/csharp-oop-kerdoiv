   M S B A M L   `   `   `  ���� C  ?beadando, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:beadandobeadando      beadando.AdminMain   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.62.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:beadando     >c1/http://schemas.componentone.com/winfx/2006/xaml     -     �Name$  Ablak_admin�� � Title$ 	AdminMain��$	��450��$	��733�� � WindowStartupLocation$ CenterScreen=�${�False������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF8791B1�� � Offset$	 0.1Q�� $ 	#FF6F85C5��$
 0.85Q�.��� -    �Name$ MainGrid��.+��� -    ��Name$ listbox1��$��Hidden=�$y�Hidden=�$��70,27,10,21q����	#FFB4B8C5���� .R��� $��0,0,0,1q�
���   ����� *ActualWidth+	 �� ElementName$	 listbox1��._��� ���� �� -   
 ��Name$
 InfoPNG��$y�Hidden=�$
��Left=�$��32��$��	10,58,0,0q�$	��Top=�$��34��$��
/63830.png���� -   $
 
RefreshPNG��$y�Hidden=�$
��Left=�$��32��$��
10,106,0,0q�$	��Top=�$��34��$��/img_321592.png���� -    ��Name$ canvas_Kutatas_edit_uj��$��0,98,0,0q�$y�Hidden=����	#FFC3D8DA$	��298��$	��532�� � UseLayoutRounding$
 True��$	��Top=�$��Center=� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~���  �� ScaleY$ 1Q� �� ScaleX$ 1Q��� �� T� .+��� $��Név:�� �� Left$ 6��
 �� Top$ 20��$
��Left=�$��50��$	��Top=�$��66��$��13(�$
��Bold"�$��Center=�$��Center=�
���   ��� -    ��Name$ TB_nev��$ 84�� �� TextWrapping$
 Wrap=�$�� ��$ 26��$	��380��$��38��$
��Left=�$��Center=�$ �� HorizontalScrollBarVisibility$
 Auto=�$��15(�
���   ��� -    ��Name$ slider_elvart��$ 13��$	 116��$	��451�� � Maximum$
 1000Q� � Minimum$ 1Q�$
��Left=�$��Center=�$��19�� � SmallChange$ 1Q� � Value$ 1Q� �� IsSnapToTickEnabled$
 True�� � LargeChange$ 10Q�
���   �
���   ���Z� �� -	    ��Name$ elvartKitoltesekLB��$��Elvárt kitöltések:��$ 15��$ 84��$��Center=�$	��Top=�$��13(�$
��Bold"�$	��115��
���   ��� -
   $ 	TX_elvart��$	 146��$
 Wrap=�$�� ��$ 85��$��66��$��17(�$
��Bold"�$
��Left=�$��25��$	��Top=�
���   ��� -    ��Name$ btn_edit_save��$��Mentés��$	 295��$	 256��$��32��$��74��$
��Left=�$	��Top=�
���   ��� -   $��Mégsem��$	 401��$	 256��$��32��$��75��$
��Left=�$��Center=�
���   ��� -   $ kezdetLB��$��Kezdet:��$ 13��$	 144��
���   ��� -   $ vegLB��$��Vég:��$	 139��$	 144��$
��Left=�$	��Top=�
���   ��� -    ��Name$ 	aktivalva��$��
Aktiválva��$	 369��$	 174��$
��Left=�$��17��$	��Top=�$	��102��$ 0.5,0.5&�
���   �z�V� .~��� $	 1.1Q�$	 1.1Q��� �� T� �� -   $ DateTimePicker1��$��84��$	��135��$
��Left=�$��Center=�$	 173��$ 5��.+�(  "System.Windows.Controls.DatePicker  -     Name$ Kezdet_datum��$ -4��$ 14��$
��Left=�$��33��$	��Top=�$	��142��$ 0.5,0.5&�
���   ���Z� z�V� .~��� $	 0.9Q�$
 1.35Q��� �� T� �� -     ��Name$  
Kezdet_ora��$ 52��$��59��$
��Left=�$	��Top=�$ 0.5,0.5&�z�V� .~��� $	 0.8Q�$
 1.05Q��� �� T� �� -   $  Kezdet_perc��$ 67��$ 52��$��59��$ 0.5,0.5&�$
��Left=�$	��Top=�z�V� .~��� $	 0.9Q�$
 1.15Q��� �� T� �� $��:��$ 54��$ 48��
���   �$
��Left=�$	��Top=�$��14��$ 0.524,0.284&���Z� �� $��84��
���   �$	��130��$
��Left=�$	��Top=��� -   $ DateTimePicker2��$��84��$	��135��$
��Left=�$��Center=�$	 173��$	 145��.+�  -   $ 	veg_datum��$ -4��$ 14��$
��Left=�$��33��$	��Top=�$	��142��$ 0.5,0.5&�
���   ���Z� z�V� .~��� $	 0.9Q�$
 1.35Q��� �� T� �� -   $  veg_ora��$ 52��$��59��$
��Left=�$	��Top=�$ 0.5,0.5&�z�V� .~��� $	 0.8Q�$
 1.05Q��� �� T� �� -   $  veg_perc��$ 67��$ 52��$��59��$ 0.5,0.5&�$
��Left=�$	��Top=�z�V� .~��� $	 0.9Q�$
 1.15Q��� �� T� �� $��:��$ 54��$ 48��
���   �$
��Left=�$	��Top=�$��14��$ 0.524,0.284&���Z� �� $��84��
���   �$	��130��$
��Left=�$	��Top=��� -   $ 
WindowMode��$�� ��$	 484��$ 10���� -   $ sidemenu��$
��Left=�$	��141��$y�Visible=�$	��434��$	��Top=�.+��� -   $ sidemenu_unfolded��$��	0,0,657,0q�$y�Hidden=����	#FF5A5959! J� OpacityMask! �	#FF565555$��Disabled=�.+��� -   " ��Name$" hatter��$	��434��$	��150��$
��Left=�$��Center=�$��Disabled=����� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF609AAD��$
 0.03Q�� $ 	#FF4359B3��$ 0.973Q��� -   $ spacer_setter��$�� ��$��Center=�$��Center=�$��95��$ 10��$ 19���� -   $ 
buttonList��$��Center=�$	��Top=�$	��110��$��Disabled=�$	��200����Z� ��Z� ��Z� ���� .R��� $��0,0,0,1q�
���   ����� *ActualWidth+$	 spacer_setter��._��� ���� .@��� -   $��Új kutatás��$��82��$��34�����	#FF080000���	#FFC8D8DA�� -   $ gomb1��$��Összes kutatás��$��84��$��34��$��11(�
���   �
���   ����	#FFC8D8DA�� -    $��Új kutatások��$��83��$��34��$��11(�
���   ����	#FFC8D8DA�� -!   $��Futó kutatások��$��83��$��34��$��11(�
���   ����	#FFC8D8DA�� -"   $��Volt kutatások��$��83��$��34��$��11(�
���   ����	#FFC8D8DA�� -#   $ btn_back��.+��� $��20��$	 117��$ 11��$��21��$��/340.png��$
��Left=�$��Center=�A� $
��Left=�$��26��
���   �$��Center=�$��26��$	 115��$ 8���� -$   $ sidemenu_line��$�� ��$	 147��$
��Left=�$��Center=�$��3��$	��434�����	#FFADADAD�� -%   $ sidemenu_folded��$y�Hidden=�.+��� -&   $��38��$ 10��$ 7��$��32��$��/3388823.png��