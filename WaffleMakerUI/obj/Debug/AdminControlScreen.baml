   M S B A M L   `   `   `  ����H  DWaffleMakerUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WaffleMakerUIWaffleMakerUI  5   	   &     WaffleMakerUI.AdminControlScreen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WaffleMakerUI     5   	     � Title$  Administrator Panel��5   	   $	��788��6%   $	��800��62   .��5	      � .+�5
   
   �� -   5         ��Name$ btnBack��5
      $
��Left=�6"   $	��Top=�6=   ��6U   Z� ��6k   Z� .��5      �� -   5         ��Name$ imgBack��5      $
��Left=�6%   $��62��6@   $	��Top=�6L   $��66��6d   $��Back-Arrow-Icon-PNG.png��6o   5      �� 5   
   -   5         ��Name$ lblTitle��5      $��Admin Panel��6"   $��Center=�68   $��0,57,0,0q�6U   $	��Top=�6g   $��36(�6   $
��Bold"�6�   �� 5   
   -   5        $ 
lblWarning��5      $N��H*If you are not the machine administrator, please press the Back button.��6$   $��Center=�6w   $��	0,104,0,0q�6�   $	��Top=�6�   $��16(�6�   $��Italic$�6�   �� 5   
   -   5        $ 
btnConfirm��5      $��Confirm Changes��6%   $��Center=�6?   $��	0,469,0,0q�6\   $	��Top=�6o   $	��200��6�   $��95��6�   
�������$��20(�6�   6�   �� 5   
   -   5        $ 
btnDiscard��5      $��Discard Changes��6%   $��Center=�6?   $��	0,602,0,0q�6\   $	��Top=�6o   $	��200��6�   $��95��6�   
�������$��20(�6�   6�   � 5   
   $��	0,267,0,0q�6   $��Center=�6"   $	��Top=�6?   .+�5      �� -   5        $ lblWafflePrice��5      $��Waffle Price:��6,   $
��Left=�6D   $��	116,0,0,0q�6_   $	��Top=�6r   $��24(�6�   �� 5      -   5        $ lblChocolatePrice��5      $��Added Chocolate Price:��6/   $
��Left=�6P   $��0,82,0,0q�6k   $	��Top=�6}   $��24(�6�   �� 5      -	   5         ��Name$ txtWafflePrice��5      $
��Left=�6.   $��43��6I   $��	286,1,0,0q�6U    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��267��6�   $��24(�6�   �� 5      -
   5        $ txtChocolatePrice��5      $
��Left=�61   $��43��6L   $��
286,81,0,0q�6X   $
 Wrap=�6l   $	��Top=�6�   $	��267��6�   $��24(�6�   5      �� 5   
   -   5        $ lblError��5      $y�Hidden=�6"   $4��.Something went wrong. Please check your input.��66   $��Center=�6o   $��	0,422,0,0q�6�   $	��Top=�6�   
���  ��$��20(�6�   5      5      