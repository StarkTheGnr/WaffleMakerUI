   M S B A M L   `   `   `  ����H  DWaffleMakerUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WaffleMakerUIWaffleMakerUI  5   	   !    WaffleMakerUI.PaymentScreen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   'localclr-namespace:WaffleMakerUI  5   	   -   5          � Title$  Your Receipt��5	   	   $	��800��6   $	��800��6+   .��5
      � .+�5   
   �� -   5         ��Name$ lblTitle��5      $��Your Receipt��6"   $��Center=�69   $��0,29,0,0q�6V   $	��Top=�6h   $��36(�6�   $
��Bold"�6�   �� 5   
   
���   �$��1q�6%   $��Center=�69   $	��164��6V   $��	0,120,0,0q�6c   $	��Top=�6v   $	��276��6�   ._�5      � $	��Top=�6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��5,10,0,0q�6   .+�5      �� -   5        $ lblWafflesCount��5      $��
Waffles x0��65   $��16(�6J   �� 5      -   5        $ lblChocolateCount��5      $��Chocolate x3��67   $��16(�6N   $y�Hidden=�6\   �� 5      -   5        $ lblTaxes��5      $��
Taxes(14%)��6.   $��16(�6C   $y�Hidden=�6Q   �� 5      -   5        $ lblTotal��5      $��0,15,0,0q�6.   $��Total��6@   $��18(�6P   $
��Bold"�6^   5      �� 5      $��5,10,0,0q�6   $��Right=�6/   $��1��6K   .+�5      �� -   5        $ lblWafflesPrice��5      $��0,0,20,0q�65   $��00 EGP��6G   $��16(�6X   �� 5      -   5        $ lblChocolatePrice��5      $��0,0,20,0q�67   $��15 EGP��6I   $��16(�6Z   $y�Hidden=�6h   �� 5      -	   5        $ lblTaxAmount��5      $��0,0,20,0q�62   $��6.3 EGP��6D   $��16(�6V   $y�Hidden=�6d   �� 5      -
   5        $ lblTotalPrice��5      $��	0,15,20,0q�63   $��00 EGP��6F   $��18(�6W   $
��Bold"�6e   5      5      5      �� 5    
   $��Center=�6   $��19��61   $��	0,219,0,0q�6=   $	��Top=�6P   $	��276��6h   !  FontAwesome.WPF.FontAwesome  5!   
      Icon$ Refresh=�6   $
��30px(�6(      Spin . $
��30px��6D   $
��30px��6Q   $��	0,474,0,0q�6_   $	��Top=�6r   $��Center=�6�   �� 5"   
   -   5         ��Name$ 	btnCancel��5"      $��Cancel Order��6$   $��Right=�6;   $��	0,0,10,10q�6W   $��Bottom=�6j   $	��160��6�   
�������$��74��6�   $��20(�6�   6�   �� 5#   
   -   5        $ lblDebug��5#      $��
ErrorCode:��6"   $
��Left=�67   $��	10,0,0,10q�6R   $��Bottom=�6e   � 5$   
   $��Center=�6   $��34��6,   $��	0,384,0,0q�68   $	��Top=�6K   $	��580��6c   .+�5%      �� -   5        $ lblDesc1��5%      $��
Please pay��6&   $��	10,-3,0,0q�6;   $	��Top=�6N   $��20(�6f   $
��Left=�6t   $	��103��6�   �� 5&      -   5        $ lblTotalPriceDesc��5&      $��	113,0,0,0q�6/   $��00 EGP��6B   $��18(�6S   $
��Bold"�6a   $��Italic$�6s   $
��Left=�6�   $	��Top=�6�   �� 5'      -   5        $ lblDesc2��5'      $2��,through the point of sale below your screen.��6&   $
��Left=�6]   $��
182,-3,0,0q�6x   $	��Top=�6�   $��20(�6�   5(      5*      5+      