   M S B A M L   `   `   `  ����B  >Railway, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RailwayRailway  5      d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF 5          Railway.AddingStation   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Railway     5      bWPFRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5        N� Title$  AddingStation��5
         Railway.HelpProvider   HelpKey$ 
AddStation��5      .��5      � -   5         �Name$ addingStationGrid��5       � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��30* �6   �� 5      $��5* �6   �� 5      $	��55* �6   �� 5      $��5* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��8* �6   �� 5      $	��18* �6   �� 5      $	��20* �6   �� 5      $	��11* �6   �� 5      $	��11* �6   �� 5      $	��11* �6   �� 5      $	��15* �6   �� 5      $��3* �6   .+�5    
   �� 
���   �$��1q�6%    �� CornerRadius$ 8��69   
������� J� Opacity$	 0.8Q�6]   $��1��6k   $��1��6{   $��7��6�   $��3��6�   � 5!   
   -   5        $ undoRedo��5!      $��1��6!   $��3��6.    5"      �� 5#      $	��42* �6#   �� 5$      $��3* �6#   �� 5%      $	��24* �6#   �� 5&      $��3* �6#   �� 5'      $	��24* �6#   �� 5(      $��3* �6#   �� 5)      $��30 �6#    5+      �� 5,      $	��15* �6    �� 5-      $	��85* �6    .+�5/      �� -   5         ��Name$ undoAddStation��5/      $
��Undo��6-   $��1��6<   $��2��6I   ���	#FFFD9B00
�������6�   �� 50      -   5        $ redoAddStation��50      $
��Redo��6-   $��1��6<   $��4��6I   ���	#FFFD9B00
�������6�      Railway.HelpButton  51         Railway.HelpButton   Click$ HelpButton_Click��6<   $��6��6   $��1��6/   6W   52      �� 53   
   $��Add station��6   $��10,0,0,0q�6&   $��1��68   $��2��6H   
���   �$��20(�6i   �� 54   
   $��Station name:��6   $��10,0,0,0q�6(   $��Center=�6:   $
��Left=�6U   $��1��6p   $��4��6�   
���   �$��16(�6�   �� 55   
   -   5        	 ��Name$	 station_name��55      
 �� 	MaxLength$
 20��6(   $��Center=�67   $��1��6R   $��5��6c    �� TextWrapping$
 Wrap=�6p   $��10,0,0,0q�6�    �� TextAlignment$ Justify=�6�   $��16(�6�    � ToolTip$. (Name of the new station you want to add.��6�   �� 56   
   $��
10,10,10,0q�6   $��1��6(   $��3��69   $��WrapWithOverflow=�6F   $-��'To add a station drag and drop the icon��6f   
���   �$��16(�6�   � 57   
   -   5        $ point��57      $��1��6   $��6��6.   $��1��6;    58      �� 59      $	��85* �6#   �� 5:      $	��15* �6#   .+�5<      �� $��Station pin:��6   $��0��6+   
���   �$��16(�6N   $��Center=�6\   $
��Left=�6w   $��10,0,0,0q�6�   A� 5=      -   5         A�Name$ LocationPoint��5?      $��1��5>   +   
���  ��$��Center=�5?   /   
���   �$��Center=�6[   $��15��6v   $��15��6�   5@      �� 5A   
   -   5        $ addStation_BTN��5A      $��16(�6)   $��Add new station��6P   $��1��6j   $��7��6z   ���	#FFFD9B00
�������$��10q�6�   $��Center=�6�   $��Stretch=�6�   '  !Microsoft.Maps.MapControl.WPF.Map  5B   
   -	   5          Name$
 mapa��5B       J� 	AllowDrop . $��3��5D      $��2��5E      $��Stretch=�5G      $��Stretch=�5H      $��6��5J      $��10q�5K      +  %Microsoft.Maps.MapControl.WPF.MapCore   	ZoomLevel$ 9Q�5L         Center<  6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ 44.785197, 20.668373 5M         CredentialsProviderT  NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$r lZ22NcVTmQLM7xdYB3JUH~2KTwUSVQ71smVR32aiHY7w~AgpJmZQy6EajKEtAjchqViLmh3PuMYWUtoYG8xreQEA7JeI_9fruGjOQcQTfCrdy 5O      5P      5Q      5R      