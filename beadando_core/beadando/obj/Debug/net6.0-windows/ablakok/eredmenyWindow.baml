   M S B A M L   `   `   `  ����N  JIncidens Kérdőív, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:beadando.ablakokbeadando.ablakok  5   	   U QScottPlot.WPF, Version=4.1.62.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aa<.clr-namespace:ScottPlot;assembly=ScottPlot.WPF	ScottPlot 5   	   %    beadando.ablakok.eredmenyWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:beadando.ablakok     5   	   D	ScottPlot.clr-namespace:ScottPlot;assembly=ScottPlot.WPF     5   	     � Title$  Statisztika��5	   	   $	��396��6   $	��469��6*    � WindowStartupLocation$ CenterOwner=�66    � 
ResizeMode$ CanMinimize=�6Z    � WindowStyle$ 
ToolWindow=�6s   ��5
      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF8791B1��6    � Offset$	 0.1Q�6-   � 5      $ 	#FF6F85C5��6   $
 0.85Q�6-   5      .��5      � .+�5   
   �� -   5         ��Name$ szures_kerdesre��5      $��
Kérdésre��6,   $
��Left=�6?   $��	36,10,0,0q�6Z   $	��Top=�6m   6�   �� 5   
   -   5        $ szures_kitoltokre��5      $��Kitöltőkre��6.   $
��Left=�6C   $��	36,30,0,0q�6^   $	��Top=�6q   6�   �� 5   
   -   5        	 ��Name$	 combo_valaszto��5      $
��Left=�6+   $��
155,14,0,0q�6F   $	��Top=�6Z   $	��272��6r   $��27��6~   6�   �� 5   
   -   5        
 ��Name$
 canvas_chart��5      $��	0,50,60,0q�6'   $	��320��6:   $	��Top=�6G   $��Right=�6_   $	��326��6{   .+�5        ScottPlot.WpfPlot  -   5          Name$ diagram��5       �� Left$ 10��6'   
 �� Top$ 10��68   $��Center=�6H   $	��271��6e   $	��Top=�6r   $	��306��6�   5      5      5      