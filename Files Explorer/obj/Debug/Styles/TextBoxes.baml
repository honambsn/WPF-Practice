   M S B A M L   `   `   `  ����I  EFiles Explorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Files_Explorer.PropertiesFiles_Explorer.Properties  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   CommonTextBoxStyle  �� 
TargetType �� Property �� Value  SearchBox.Static-   'System.Windows.Input.KeyboardNavigation �� Triggers �� Binding(  "Files_Explorer.Properties.Settings   Default �� Source �� Value  SearchBoxStyle �� BasedOn	 �� 
TargetType
 ��Name � ColumnDefinitions �� Padding ��Name F�Name  SearchingIcon J� RenderTransformOrigin �� Stretch �� Angle :� RoutedEvent g� RepeatBehavior �� TargetProperty W� From	 W� To 
 Search �� 	IsDefault  ButtonWithIconStyle �� RelativeSource �� Mode �� AncestorType �� Triggers �� UpdateSourceTrigger �� 
TargetName P� Property P� Value  SearchBox.Active  AddressBarTextBoxStyle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      0prop'clr-namespace:Files_Explorer.Properties  5      %�  &	        7  7  &	 +    7   7  &	 w
    7   7  7  7  7  �� 5      "  ��5      .�5   
   ��  � ��
 ���� 6'   �� 5	   
    � ��$ 1q�6,   �� 5
   
    � ��# �  6(   �� 5   
    � ��# �  6'   �� 5   
    �@  TabNavigation$
 None=�6=   �� 5   
    � ��$ 28��6#   �� 5   
    � ��$
 Left=�67   �� 5   
    � ��$ Center=�65    5   
   �� 5       6   �� *
DarkMode+# Z  True5      .a�5      ��  � ��8   6/   �� 5       � ��8  60   �� 5       �@��SelectionBrush
 �����63   5      5      �� 5      "  ��5      8   .�5   
   ��  � ��$	 200��6"   �� 5   
    �@�FocusVisualStyle 6-   Z� �� 5   
    �@��PanningMode$ VerticalFirst=�65   �� 5    
    � �� 5!      �� 5"      "	 ��6"   .R�5#      �� $
 Border��6   #��z��5$      #��z��5%      #��z��5&      ._�5'      �  5(      �� 5)   "   �� 5*   "   $��25 �63   �� 5+   "   $��25 �63   .+�5.      �� $��PlaceHolder��6(   #��z��5/   (   $��Search��50   (   $	 7,0q�51   (   #��z��52   (   $y�	Collapsed=�53   (   �� 54      $ PART_ContentHost��56   !   $��0��55   !   $	��5,0q�57   !   |�.  $��Hidden=�59   !   $��Hidden=�5:   !   F� 5<      $ SearchInProgressIndicator��5=   !   #���  5>   !   #��z��5?   !   $ 0.5,0.5&�5@   !   $��1��5A   !   $ Uniform=�5B   !   $��15��5C   !   $y�	Collapsed=�5D   !   z�5E   "   �� 5F   &   $ 0Q�66   ��5H   "   �� 5I   &   "  F�6,    5J   *   :� 5K   .   $ Loaded��6;   .[�5L   2   �� .��5M   6   �� $ Forever��6A   .��5N   :   W� $4 .(Path.RenderTransform).(RotateTransform.Angle)�6J   $ 0X�5O   M   $	 360X�5P   M   5Q   7   5R   3   5S   /   5U   '   5W      �� 5Y      $��1��5Z   !   #��z��5[   !   #���  5\   !    . 8�� ��5]   !   �� *'%DataContext.SearchFileOrFolderCommand+ �� $ FindAncestor=�" ���5^   !   �� *Text+ �� *TemplatedParent+5`   !   5a      5b       5c      �� 5e      $
 true��6n    6&   �� *IsInSearchMode+$ PropertyChanged=�.a�5f      �� $ SearchInProgressIndicator��5g   !    � y�$ Visible=�5h   7   5i      P� 5j       � ��$  ��62   . �5k      �� $ PlaceHolder��6%    � y�$ Visible=�6T   5l      P� 5m       �@J�IsKeyboardFocused . . �5n      �� # �  6<    � ��5o      P� 5p       � {� .  . �5r      �� $ Border��6%    �@J�Opacity$	 .56Q�6L   5s      P� 5t       �@J�IsMouseOver . . �5v      �� # �  6<    � ���� 5w      # �  6;    � ��5x      5z      5|      5}      �� 5      "  ��5�      8   .�5�   
   ��  � ��$ 15(�6%   �� 5�   
    � ��$ 28��6&   �� 5�   
    � ��$	 200��6%   �� 5�   
    �@��SelectionBrush �#2020206+   �� 5�   
    � �� 5�      �� 5�      "	 ��5�      .R�5�      �� #��z��6   #��z��5�      #��z��5�      ._�5�      �� $ PART_ContentHost��5�      $	��5,0q�5�      |�.  $��Hidden=�5�      $��Hidden=�5�      5�       5�      P� 5�       �@J�	IsFocused . . �5�      �� 8   � ��6<   �� 5�       � ��$ 2q�6@   �� 5�      8   � ��6;   5�      P� 5�       �@J�IsMouseOver . . �5�      �� 8   � ��6<   �� 5�      8   � ��6;   5�      5�      5�      5�      5�      