   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5      B >Railway, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RailwayRailway 5      #   Railway.UpdateStationTutorial   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      bWPFRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5      'localclr-namespace:Railway     5        N� Title$  UpdateStationTutorial��5
        Railway.HelpProvider   HelpKey$ EditStation��5      .��5      � -   5         �Name$ updateStationGrid��5       � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $	��40* �6   �� 5      $��5* �6   �� 5      $	��80* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��8* �6   �� 5      $	��18* �6   �� 5      $	��20* �6   �� 5      $	��11* �6   �� 5      $	��11* �6   �� 5      $	��11* �6   �� 5      $	��15* �6   �� 5      $��3* �6   .+�5!   
   �� 
���   �$��1q�6%    �� CornerRadius$ 8��69   
������� J� Opacity$	 0.8Q�6]   $��1��6k   $��1��6{   $��7��6�   $��3��6�   � 5"   
   -   5        $ undoRedo��5"      $��1��6!   $��3��6.    5#      �� 5$      $	��42* �6#   �� 5%      $��3* �6#   �� 5&      $	��24* �6#   �� 5'      $��3* �6#   �� 5(      $	��24* �6#   �� 5)      $��3* �6#   �� 5*      $��30 �6#    5,      �� 5-      $	��15* �6    �� 5.      $	��85* �6    .+�50      �� -   5         ��Name$ undoUpdateStation��50      $
��Undo��60   $��1��6?   $��2��6L   ���	#FFFD9B00
�������6�     Railway.HelpButton  51        Railway.HelpButton   Click$ HelpButton_Click��6<   $��6��6   $��1��6/   6X   �� 52      -   5        $ redoUpdateStation��52      $
��Redo��60   $��1��6?   $��4��6L   ���	#FFFD9B00
�������6�   53      �� 54   
   $��Update station��6   $��10,0,0,0q�6)   $��1��6;   $��2��6K   
���   �$��20(�6k   $��Center=�6y   $
��Left=�6�   �� 55   
   -   5        $ updateStation��55      $��Center=�6(   $��Stretch=�6C   $��Update station��56      $��1��6&   $��7��66   $��16(�6C   ���	#FFFD9B00
�������$��10q�6{   �� 57   
   -   5        	 ��Name$	 station_name��57      $��1��6m   $��5��6~   
 �� TextWrapping$

 Wrap=�6�   $��10,0,0,0q�6�   $��Center=�6�    �� TextAlignment$ Justify=�6�   $��16(�6�   ��6O   �� *Station.Name+6�   �� 58   
   $��10,0,0,0q�6   $��1��6&   $��3��67   $��WrapWithOverflow=�6D   $I��CTo update a station press and drag pin you want to change location ��6d   
���   �$��16(�6�   '   !Microsoft.Maps.MapControl.WPF.Map  59   
   -   5          Name$
 mapa��59       J� 	AllowDrop . $��3��5;      $��1��5<      $��Center=�5=      $��Center=�5>      $��2��5?      $��6��5@      $��10q�5A      +   %Microsoft.Maps.MapControl.WPF.MapCore   	ZoomLevel$ 8Q�5C         CredentialsProviderT   NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$r lZ22NcVTmQLM7xdYB3JUH~2KTwUSVQ71smVR32aiHY7w~AgpJmZQy6EajKEtAjchqViLmh3PuMYWUtoYG8xreQEA7JeI_9fruGjOQcQTfCrdy 5G      $	��391��6�      Center 5B      �� *Station.Location+   Children. 5H      +   %Microsoft.Maps.MapControl.WPF.Pushpin  -   5          Name$ selectedPushpin��5H         Location 63   �� *Station.Location+ �� UpdateSourceTrigger$ PropertyChanged=� � ToolTip 5I      �� *Station.Name+$ PropertyChanged=�5J   ?   5K      �� 5L   
   $��Station name:��6   $��10,0,0,0q�6(   $��4��6:   $��1��6G   $��16(�6W   
���   �$��Center=�6y   $
��Left=�6�   5M      5N      