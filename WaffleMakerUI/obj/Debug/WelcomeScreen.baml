   M S B A M L   `   `   `  ����H  DWaffleMakerUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WaffleMakerUIWaffleMakerUI  5   	   !    WaffleMakerUI.WelcomeScreen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WaffleMakerUI     5   	   -   5          � Title$  Make your order��5   	   $	��800��6!   $	��800��6.   $	��800��6:   $	��800��6I   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��205* �6   �� 5      $
��191* �6    � RowDefinitions 5   
   �� 5      $
��166* �6   �� 5      $
��603* �6   .+�5   
   � -   5         �Name$ gridChocolateMain��5      $	��508��6*   $	��634��69   $��	0,18,51,0q�6I   $��1��6\   $��1��6i   $��Right=�6y   $	��262��6�   $	��317��6�   $	��Top=�6�    5      �� 5      $
��187* �6    �� 5      $
��130* �6    .+�5      � $��34,10,22,28q�6   $��1��6(    5      �� 5      $	��14* �6'   �� 5      $��5* �6'   �� 5      $	��14* �6'   .+�5      �� -   5         ��Name$ btnChocolatePlus��5      
�������$��48(�6F   .��5      �� $��+��6    $��0, -3, 0, 0q�6)   5      �� 5       -   5        $ btnChocolateMinus��5       
�������$��48(�6G   $��2��6u   .��5!      �� $��-��6    $��0, -3, 0, 0q�6)   5"      5$      �� 5%      -   5         ��Name$ lblChocolate��5%      $&�� How many of them with Chocolate?��6*   $	��Top=�6V   $��16(�6n   $
��Left=�6|   $	��262��6�   $��0,10,0,0q�6�   �� 5&      
���   �$��1q�6)   $��
34,46,22,5q�6=   ���	#FFE0E0E0._�5'      �� -   5        $ lblChocolateNum��5'      $��0��61   $��Center=�6=   $��Center=�6a   $��Center=�6�   $��Center=�6�   $��48(�6�   $
��Auto��6�   5(      �� 5)      -   5        $ lblChocolatePrice��5)      $��10.99 EGP each��6/   $��Right=�6H   $��0,0,22,5q�6d   $��Bottom=�6v   5*      � 5+   
   -   5        $ gridWaffleMain��5+      $	��508��6'   $	��634��66   $��	51,18,0,0q�6F   $
��Left=�6Y   $	��254��6t   $	��317��6�   $	��Top=�6�   $��1��6�    5,      �� 5-      $
��187* �6    �� 5.      $
��130* �6    .+�50      �� -	   5        $ 
lblWaffles��50      $��Number of Waffles:��6(   $
��Left=�6E   $��	10,10,0,0q�6`   $��16(�6s   $��31��6�   $	��Top=�6�   �� 51      
���   �$��1q�6)   $��
34,46,22,5q�6=   ���	#FFE0E0E0._�52      �� -
   5        $ lblWaffleNum��52      $��0��6.   $��Center=�6:   $��Center=�6^   $��Center=�6�   $��Center=�6�   $��48(�6�   $
��Auto��6�   53      �� 54      -   5        $ lblWafflePrice��54      $��10.99 EGP each��6,   $��Right=�6E   $��0,0,22,5q�6a   $��Bottom=�6s   � 55      $��34,13,22,25q�6   $��1��6(    56      �� 57      $	��14* �6'   �� 58      $��5* �6'   �� 59      $	��14* �6'   .+�5;      �� -   5        $ btnWafflesMinus��5;      
�������$��48(�6E   $��2��6q   .��5<      �� $��-��6    $��0, -3, 0, 0q�6)   5=      �� 5>      -   5        $ btnWafflesPlus��5>      
�������$��48(�6D   .��5?      �� $��+��6    $��0, -3, 0, 0q�6)   5@      5A      5B      �� 5C   
   -   5        $ lblHello��5C      $��Hello!��6"   $
��Left=�63   $��0,20,0,0q�6U   $	��Top=�6g   $��30(�6   $��Center=�6�   $��2��6�   �� 5D   
   -   5        $ lblOrder��5D      $��Please enter your order��6"   $
��Left=�6D   $��Center=�6f   $	��Top=�6�   $��30(�6�   $
��Auto��6�   $��0,65,0,0q�6�   $��2��6�   �� 5E   
   -   5        $ 
btnConfirm��5E      $��Confirm Order��6%   $��	0,0,0,115q�6=   ���	#FFFF3939$��20(�6g   $��Center=�6u   $	��170��6�   $��80��6�   $��Bottom=�6�   $��1��6�   $��2��6�   �� 5F   
   -   5        $ btnAdmin��5F      $��Admin��6#   $��Right=�63   $��	0,0,10,10q�6O   $��Bottom=�6b   $	��105��6}   $��38��6�   ���	#FFDDF796$��1��6�   $��1��6�   5G      5H      