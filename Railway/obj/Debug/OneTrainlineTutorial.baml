   M S B A M L   `   `   `  ����B  >Railway, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RailwayRailway  5      "    Railway.OneTrainlineTutorial   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Railway     5      $��	10,2,10,2q�5	        � RowDefinitions  5      �� 5   
   $��5 �6   6%   �� 5   
   $��60 �6   6&   �� 5   
   $��1 �6   6%   �� 5   
   $��* �6   6%   �� 5   
   $��5 �6   6%    � ColumnDefinitions 5      �� 5   
   $��5 �6   6'   �� 5   
   $	��94* �6   6)   �� 5   
   $��5 �6   6'   .+�5      �� 
�������
���   � �� CornerRadius$ 8��64   $��1q�6E   $��4��6Y   $��7��6m   6�   � 5      
���   �$��	30,0,30,0q�6   $��1��61   $��2��6A   � 5      -   5         �Name$ 	TitleGrid��5   (   $��1��6   $��1��6    5   
   �� 5      $��5 �6   6+   �� 5      $��70 �6   6,   �� 5      $��90 �6   6,   �� 5      $	��115 �6   6-   �� 5       $��5 �6   6+   �� 5!      $��* �6   6+   .+�5$   
   �� -   5         ��Name$ 
EditButton��5$      $
��Edit��6%   $��1��64   $��1��6D    � ToolTip$ Editing the trainline.��6j   ���	#FFFD9B00
�������6�   �� 5%   
   -   5        $ DeleteButton��5%      $��Delete��6'   $��2��68   $��1��6H   $ Deleting the trainline.��6p   ���	#FFFD9B00
�������6�   �� 5&   
   -   5        $ ViewMapButton��5&      $��View Map��6(   $��3��6;   $��1��6K   $0 *Grafical view of the trainline on the map.��6t   ���	#FFFD9B00
�������6�   �� 5'   
   -   5         ��Name$ TrainLineName��5'      $��1��6'   $��7��64   $��16(�6D   $��Center=�6R   $��Center=�6m   6�   5(      � 5)      -   5        $ StationsGrid��5)      $��3��6"   $��1��6/    5*   
   �� 5+      $	��30* �6   6-   �� 5,      $	��35* �6   6-   �� 5-      $	��35* �6   6-   �� 5.      $��0 �6   6+   50      51      