   M S B A M L   `   `   `  ����C  ?Chat App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Chat_AppChat_App  5          Chat_App.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      (localclr-namespace:Chat_App     5        �� 	Resources  5       �� MergedDictionaries �� Source   MouseEnterAnimation g� 
SpeedRatio �� TargetProperty	 W� To  MouseLeaveAnimation �� 
TargetType �� Property �� Value	 �� Triggers
 �� Binding �� RelativeSource �� AncestorType �� Value N� EnterActions N� ExitActions  IconButtonStyle �� 
TargetType  ToggleIconButtonStyle  ScrollThumbs �Name ��Name �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton  �� Angle�� 5   
    5	      �� 5
      $ /assets/icons.xaml?�6%   %  &	        &	 �     'F�     7   7  7   7  &	 Z    7F�&	 �    7F�&	 p    '�� �    �� 5      $ 5Q�65   .��5      W� $ Height�6"   $ 22X�6E   W� 5      $ Width�6"   $ 22X�6D   5      �� 5      $ 5Q�65   .��5      W� $ Height�6"   $ 20X�6E   W� 5      $ Width�6"   $ 20X�6D   5      �� 5      " F�6   .�5      ��  � ��$ 20��6+   �� 5        � ��$ 20��6*   �� 5!       �@��Stretch$ Uniform=�6,   �� 5"       � ��$ Center=�68   �� 5#       � ��$ Center=�66   �� 5$       � ��
 �   �6)   	 5'      �� 5*      
 6"   �� *IsMouseOver+ �� " �� True6�    5+      �� 5,      8��  6.    5.      �� 5/      8�� 6.   51      �� 53      
 6"   �� *IsMouseOver+ �� " d� True6�    54      �� 55      8�� 6.    57      �� 58      8�� 6.   5:      5<      �� 5>      " ��6,   .�5?      ��  � ��
 ���� 6/   �� 5@       � ��$ 0q�64   �� 5A       � ��$ 50��6+   �� 5B       � ��$ 50��6*   �� 5C       � �� 5D      �� 5E      " ��6*   .R�5F      �� #��z��5G   !   ._�5H   "   F� #��z��5I   %   #��z��5J   %   #��z��5K   %   #��z��5L   %   8��  5M   %   5N      5O      5Q      5R      �� 5T      " d�62   .�5U      ��  � ��
 ���� 6/   �� 5V       � ��$ 0q�64   �� 5W       � ��$ 50��6+   �� 5X       � ��$ 50��6*   �� 5Y       � �� 5Z      �� 5[      " d�6*   .R�5\      �� #��z��5]   !   ._�5^   "   F� #��z��5_   %   #��z��5`   %   #��z��5a   %   #��z��5b   %   8��  5c   %   5d      5e      5g      5h      �� 5l      " n�6)   .�5m      ��  � �� 5n      �� 5o      " n�6*   .R�5p      � $
 Grid��6#   .+�5q   "   �� $��Stretch=�5r   %   $��Stretch=�5s   %   $
��Auto��5t   %   $
��Auto��5u   %   
������ 5v   %   �� 5w   "   $ 
Rectangle1��5x   %   $ 5��5y   %   $��Stretch=�5z   %   $��Stretch=�5{   %   $
��Auto��5|   %   $
��Auto��5}   %   #��z��5~   %   5       5�      P� 5�   "    �@�Tag$ 
Horizontal��69   . �5�   &   �� $ 
Rectangle1��6-    � ��$
 Auto��6V   �� 5�   &   $ 
Rectangle1��6-    � ��$ 7��6W   5�   #   5�      5�      5�      �� 5�      " ��6/   .�5�      ��  �@��IsFlicksEnabled .  6;   �� 5�       � ��
 �����6/   �� 5�       � ��
 ���� 6/   �� 5�       � ��$ 10��6*   �� 5�       � �� 5�      �� 5�      " ��6*   .R�5�      � $ GridRoot��5�   !   $��8��5�   !   #��z��5�   !    5�   "   �� 5�   &   .+�5�   "   ]� $ 
PART_Track��5�   %   $��0��5�   %   ��. |�.   5�   &   n� 5�   *   $ Thumb��5�   -   #��z��5�   -   #���  5�   -    5�   &   �� 5�   *   $ PageUp��5�   -   $��ScrollBar.PageUpCommand��5�   -   $ 0Q�5�   -   |�.  5�   -    5�   &   �� 5�   *   $ PageDown��5�   -   $��ScrollBar.PageDownCommand��5�   -   $ 0Q�5�   -   |�.  5�   -   5�   #   5�       5�      P� 5�   "    � {� .  . �5�   &   �� $ Thumb��6-    � y�$ 	Collapsed=�5�   -   5�   #   P� 5�   "    �@��Orientation$ 
Horizontal=�6A   . �5�   &   �� $ GridRoot��6-    �@�LayoutTransform 5�   *   �� 5�   .   $	  -90Q�6>   5�   '   �� 5�   &   $ 
PART_Track��6-    �@�LayoutTransform 5�   *   �� 5�   .   $	  -90Q�6>   5�   '   �� 5�   &    � ��$
 Auto��6>   �� 5�   &    � ��$ 12��6?   �� 5�   &   $ Thumb��6-    �@�Tag$ 
Horizontal��6O   �� 5�   &   $ PageUp��6-    � ��$ ScrollBar.PageLeftCommand��6T   �� 5�   &   $ PageDown��6-    � ��$ ScrollBar.PageLeftCommand��6V   5�   #   5�      5�      5�      5�      5�      