   M S B A M L   `   `   `  ����B  >Railway, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RailwayRailway  5           Railway.OneStationTutorial   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Railway     5      $��10q�5   8     � RowDefinitions  5	      �� 5
   
   $��5 �6   6%   �� 5   
   $��45 �6   6&   �� 5   
   $��1 �6   6%   �� 5   
   $��40 �6   6&   �� 5   
   $��5 �6   6%    � ColumnDefinitions 5      �� 5   
   $��5 �6   6'   �� 5   
   $	��88* �6   6)   �� 5   
   $��5 �6   6'   .+�5      �� 
�������
���   �$��1q�64   $��3��6H   $��5��6\    �� CornerRadius$ 8��6m   6�   � 5      $��2��6   $��1��6   
���   �$��	30,0,30,0q�6;   � 5      -   5         �Name$ 	TitleGrid��5   (   $��1��6   $��1��6    5   
   �� 5      $��5 �6   6+   �� 5      $��* �6   6+   �� 5      $��5 �6   6+   �� 5      $��* �6   6+   �� 5      $��5 �6   6+   .+�5   
   � $��1��6    5       �� 5!      $	��30* �6#   61   �� 5"      $	��30* �6#   61   �� 5#      $	��30* �6#   61   .+�5%      �� -   5         ��Name$ 
EditButton��5%      $
��Edit��6*   $��0��69   $��1��6I    � ToolTip$ Editing the station.��6o   ���	#FFFD9B00
�������$��Center=�6�   6�   �� 5&      -   5        $ DeleteButton��5&      $��Delete��6+   $��1��6<   $��1��6L   $ Deleting the station.��6t   ���	#FFFD9B00
�������$��Center=�6�   6�   5'      �� 5)   
   -   5         ��Name$ 	NameLabel��5)      $��5,0,0,0q�6#   $��2��64   $��3��6A   
���   �$��Center=�6d   $
��Left=�6   6�   5*      � 5+      -   5        $ NumbersGrid��5+      $��3��6!   $��1��6.    5,   
   �� 5-      $��5 �6   6+   �� 5.      $��* �6   6+   �� 5/      $��* �6   6+   �� 50      $��5 �6   6+   .+�52   
   �� -   5        $ LatitudeLabel��52       $��1��6   $��5,0,0,0q�67   $��
Latitude: ��6H   
���   �6r   �� 53   
   -   5        $ LongitudeLabel��53       $��2��6   $��5,0,0,0q�68   $��Longitude: ��6I   
���   �6t   54      55      