   M S B A M L   `   `   `  ����H  DWaffleMakerUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WaffleMakerUIWaffleMakerUI  5   	       WaffleMakerUI.AdminScreen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WaffleMakerUI     5   	   -   5          � Title$  Administrator Login��5   	   $	��794��6%   $	��800��62   .��5	      � .+�5
   
   �� -   5         ��Name$ lblPass��5
      $'��!Please enter your admin password:��6!   $
��Left=�6M   $��
81,259,0,0q�6h   $	��Top=�6|   $��24(�6�   �� 5   
   -   5        $ 
lblWarning��5      $X��R*If you are not an admin or you came here by mistake, please press the back button��6$   $
��Left=�6�   $��
81,228,0,0q�6�   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   G� 5   
   -   5         G�Name$ txtPass��5      $
��Left=�6'   $��184,306,0,0q�6B   $	��Top=�6W   $	��320��6o   $��24(�6{   �� 5   
   -   5        $
��Left=�5      $	��Top=�6,   ��6D   Z� ��6Z   Z� .��5      �� -   5         ��Name$ imgBack��5      $
��Left=�6%   $��62��6@   $	��Top=�6L   $��66��6d   $��Back-Arrow-Icon-PNG.png��6o   5      �� 5   
   -   5         ��Name$ btnBack��5      $��Back to Welcome Screen��6"   $��Right=�6C   $��	0,0,10,10q�6_   $��Bottom=�6r   $	��203��6�   $��74��6�   
�������$��16(�6�    J� RenderTransformOrigin$ 0.571,0.568&�6�   6�   �� 5   
   -   5        $ btnLogin��5      $��Login as Admin��6#   $��Center=�6<   $��	0,385,0,0q�6Y   $	��Top=�6l   $	��158��6�   $��66��6�   
�������$��16(�6�   $ 0.571,0.568&�6�   6�   �� 5   
   -	   5        $ lblError��5      $.��(Password is incorrect. Please try again!��6"   $��Center=�6U   $��	0,456,0,0q�6r   $	��Top=�6�   $��16(�6�   
���  ��$y�Hidden=�6�   5      5      