   M S B A M L   `   `   `  ����H  DFile Explorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:File_Explorer.CustomControlsFile_Explorer.CustomControls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   WindowChromeButtonStyle'   !System.Windows.Shell.WindowChrome �� Property �� Value  IconActiveBrush �� 
TargetType �� Padding �� Triggers ]� 
Conditions �� Property �� Value  ButtonMouseOverBrush " WindowChromeRestoreButtonStyle	 �� BasedOn
 �� Triggers �� Binding �� RelativeSource �� AncestorType �� Value   WindowChromeCloseButtonStyle % !CaptionCloseButtonsMouseOverBrush P� Property P� Value   CaptionCloseButtonsDownBrush7  1File_Explorer.CustomControls.DriveAndFolderButton  NavFontBrush � ColumnDefinitions  BorderBrush J� Opacity 
	 Folder �� Stretch 
 DropShadowEffect J� Effect�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      1cc*clr-namespace:File_Explorer.CustomControls  5      %�  &	        7  7  &	 b    7   &	 ?    7   7  7  '  �    7  7 	 �� 5      "  ��6   .�5   
   ��   �@  IsHitTestVisibleInChrome . 6B   �� 5	   
    � ��
 ���� 6'   �� 5
   
    � ��$ 44��6"   �� 5   
    � ��$ Stretch=�6.   �� 5   
    � ��8   6'   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� # z��6   #��z��5      ._�5      �� $��Center=�6+   $��Center=�5   +   5       5      ]� 5       5      �� 5   "    �@J�IsMouseOver . 6C   �� 5   "    �@J�IsMouseCaptured .  6G   ./�5      �� 8   � ��6;   5      5      5       5!      �� 5#      "  ��6   8	   .�5&   
   ��  � ��$	 ��6$   
 5'   
   �� 5(       6   �� *WindowState+ �� " � 	Maximized5)      .a�5*      ��  � ��$	 ��6,   5+      5-      �� 5/      "  ��6   8	   .�52   
   ��  � ��$	 ��6$   
 53   
   ]� 54       55      �� 56       �@J�IsMouseOver . 67   �� 57       �@J�IsMouseCaptured .  6;   ./�59      ��  � ��8  6/   5:      P� 5<       � �� . . �5>      ��  � ��8  6/   5?      5A      �� 5F      "   6   .�5G   
   ��  � ��8   6'   �� 5H   
    �@	�	GroupName$ 	DNFButton��6&   �� 5I   
    � ��$ 25��6&   �� 5J   
    � ��$	 100��6%   �� 5K   
    � ��$
 Left=�67   �� 5L   
    � ��$ Center=�65   �� 5M   
    � �� 5N      �� 5O      "  6"   .R�5P      � 
������  5R      �� 5S      $��47 �6/   �� 5T      $��* �6/   �� 5U      $
��Auto �6/   .+�5X      �� $��bgBorder��6!   $��3��5Y   !   #���  5Z   !   $��1q�5[   !   $ .2Q�5\   !   $y�	Collapsed=�5]   !   ._�5^      �� #���  6(   $ .2Q�5_   (   5`      F� 5b      $��0��5c      8�� $ Uniform=�5e      #���  5f      $��15��5g      $��20��5h      # � 
 5i      �� 5k      $��1��5l      #��z��5m      #��z��5n      # � 
 5o      �� 5r      $��UnPinButton��5s      $��2��5t      $��40��5u      #���  5v      $y�	Collapsed=�5w      5x      5y      5{      5|      5~      