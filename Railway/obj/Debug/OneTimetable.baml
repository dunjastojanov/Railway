   M S B A M L   `   `   `  ����B  >Railway, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RailwayRailway  5          Railway.OneTimetable   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Railway     5      $��10q�5        � RowDefinitions  5	      �� 5
   
   $��5 �6   6%   �� 5   
   $��50 �6   6&   �� 5   
   $��32 �6   6&   �� 5   
   $��1 �6   6%   �� 5   
   $��* �6   6%   �� 5   
   $��10 �6   6&    � ColumnDefinitions 5      �� 5   
   $��5 �6   6'   �� 5   
   $	��94* �6   6)   �� 5   
   $��5 �6   6'   .+�5      �� 
�������
���   � �� CornerRadius$ 8��64   $��1q�6E   $��5��6Y   $��2��6j   6�   � 5      $��1��6   $��3��6   $��	30,0,30,0q�6(   $y�Visible=�6;   
���   �6e   � 5      -   5         �Name$ GridButtons��5   (   $��1��6   $��1��6    5   
   �� 5      $	��15* �6   6-   �� 5      $	��15* �6   6-   �� 5      $	��30* �6   6-   �� 5      $	��30* �6   6-   .+�5   
   �� -   5         ��Name$ 
EditButton��5   3    � ToolTip$ Editing the timetable.��6   $��Stretch=�6G   $��Center=�6e   $
��Edit��6�   ���	#FFFD9B00
�������$��5q�6�   6�   �� 5    
   -   5        $ DeleteButton��5    3   $ Deleting the timetable.��6   $��Stretch=�6I   $��Center=�6g   $��Delete��6�   $��1��6�   ���	#FFFD9B00
�������$��5q�6�   6�   � 5!   
   $��2��6    5"      �� 5#      $	��30* �6#   �� 5$      $	��70* �6#   .+�5&      �� $��Name:��6   $��Stretch=�6$   $��Center=�6B   $��16(�6]   �� 5'      -   5         ��Name$ TimeTableName��5'      $��1��6+   $��Stretch=�6;   $��Center=�6Y   $��16(�6t   5(      � 5)   
   $��3��6    5*      �� 5+      $	��30* �6#   �� 5,      $	��70* �6#   .+�5.      �� $��Train:��6   $��Stretch=�6%   $��Center=�6C   $��16(�6^   �� 5/      -   5        $ 	TrainName��5/      $��1��6'   $��Stretch=�67   $��Center=�6U   $��16(�6p   50      51      � 52      $��2��6   $��1��6    53   
   �� 54      $	��10* �6   �� 55      $
��100* �6   .+�57   
   �� $��Days:��6   $��Stretch=�6    $��Center=�6>   $��16(�6Y   �� 58   
   -   5        $ 	DaysLabel��58      $��1��6#   $��Stretch=�63   $��Center=�6Q   $��16(�6l   59      � 5:      -   5        $ StationsGrid��5:      $��4��6"   $��1��6/    5;   
   �� 5<      $	��10* �6   6-   �� 5=      $	��40* �6   6-   �� 5>      $	��10* �6   6-   �� 5?      $	��40* �6   6-     5A   
   �� 5B      $��30 �6   6*   .+�5D   
   �� $��0��6   $��1��6   $��Classic route:��6-   
���   �$��16(�6Y   6i   �� 5E   
   $��0��6   $��0��6   $��Time:��6-   
���   �$��16(�6P   6`   �� 5F   
   $��0��6   $��2��6   $��Time:��6-   
���   �$��16(�6P   6`   �� 5G   
   $��0��6   $��3��6   $��Return route:��6-   
���   �$��16(�6X   6h   5H      5I      