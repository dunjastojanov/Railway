   M S B A M L   `   `   `  ����B  >Railway, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RailwayRailway  5      !    Railway.ReadStationTutorial   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Railway     5        N� Title$  ReadStationTutorial��5	         Railway.HelpProvider   HelpKey$ ReadStation��5
       � 	Resources 5       �� 
TargetType �� Property �� Value��%\  'N�       '��      '�� �    �� 5   
   " N�6   �� 5   
   " ��6   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � �� �	#FFFD9B006+   �� 5       � �� �	#FFFD9B006,   �� 5       � �� �#ffffff6+   �� 5       � ��$ 2q�6(   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 16(�6)   �� 5       � ��$ 	20,0,20,0q�6(   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��$ 16(�6)   5      5       .��5"      � -   5         �Name$
 grid��5"       � RowDefinitions 5#   
   �� 5$      $��60 �6   �� 5%      $��* �6   .+�5'   
   � $��0��6    � ColumnDefinitions 5(      �� 5)      $	��28* �6#   �� 5*      $	��27* �6#   �� 5+      $��5 �6#   �� 5,      $	��16* �6#   �� 5-      $��5 �6#   �� 5.      $	��18* �6#   �� 5/      $��5* �6#   .+�51      �� -   5        	 ��Name$	 AddNewStation��51   2   
 � ToolTip$
 Adding new station��6   $��1��6I   $��0��6Y   $��Add New Station��6f   6�   �� 52      -   5        $	 UndoStations��52   P   $6
 0Undo operation which undoes your previous action��6   $��3��6f   $
��Undo��6v   6�   �� 53      -   5        $	 RedoStations��53   P   $6
 0Redo operation which redoes your previous action��6   $��5��6f   $
��Redo��6v   $��0,5,20,5q�6�   6�      Railway.HelpButton  54         Railway.HelpButton   Click$ HelpButton_Click��6/   $��6��6   6J   55      �� 56   
   $��1��6   .��57      �� .+�58      � -   5        $ ReadStationsGrid��58       59      �� 5:      $��35 �6(   5<      5=      5>      5?      5@      