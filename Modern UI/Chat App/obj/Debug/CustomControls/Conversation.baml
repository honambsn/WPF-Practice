   M S B A M L   `   `   `  ����C  ?Chat App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Chat_App.CustomControlsChat_App.CustomControls  5      9!clr-namespace:Chat_App.ViewModelsChat_App.ViewModels  6B   *    $Chat_App.CustomControls.Conversation   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Chat_App.CustomControls     5      8
viewmodels!clr-namespace:Chat_App.ViewModels     6B   $
��Auto��5      $
��Auto��6-     � DataContext  5	      #   Chat_App.ViewModels.ViewModel  5
   
    � 	Resources 5         MessageTextStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value  ItemTemplate �� 
TargetType	 ��Name
 �� Padding J� SnapsToDevicePixels � RowDefinitions � ColumnDefinitions ��Name 	 reply  IconButtonStyle �� Triggers �� 
TargetName P� Property P� Value��%�  &	        &	     7   7  7  �� 5   
   " ��6)   .�5      ��  � ��$ 15(�6)   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ 20q�6'   �� 5       � ��
 �   �6+   �� 5       � ��$ Center=�62   �� 5       � ��$
 Wrap=�6-    5      �� 5       6   �� *IsMessageReceived+ True6D   .a�5      ��  � �� 6-   �� *ReceivedMessage+5      �� 5       6   �� *IsMessageReceived+	 False6D   .a�5      ��  � �� 6-   �� *SentMessage+5      5      �� 5!   
   .R�5"      �� ��5#      �� 5$      " ��6   .�5%      ��  �@J�SnapsToDevicePixels . 6@   �� 5&       � ��$
 auto��63   �� 5'       � ��$	 4,1q�64   �� 5(       � ��$ 10q�63   �� 5)       � ��$ Center=�6G   �� 5*       � ��$ Center=�6E   �� 5+       � ��$ Center=�6>   �� 5,       � ��
 ���� 67   �� 5-       � ��$ 0q�6<   �� 5/       � �� 50      �� 51   "   " ��62   .R�52   &   �� $	 border��57   !   #��z��52   -   #��z��53   !   #��z��54   !   #
 z��55   !    . ._�59   *   �  5:   .   �� 5<   2   $
��Auto �6@   �� 5?   2   �� 5B   2   $
��Auto �6@   .+�5D   .   � $��1��5E   %    5F   2   �� 5H   6   $
��auto �6G   �� 5K   6   �� 5N   6   $
��auto �6G   .+�5R   2   �� $
��auto��69   $��1��5S   9   $��60��5T   -   $
��auto��5U   -   $��Center=�5V   -   ��5W   6   �� 5X   :   " ��6@   .�5Y   >   ��  �@��CornerRadius$ 
30 30 30 0��6]   �� 5Z   >    � �� �#dce1de6[   �� 5[   >    � ��$
 Left=�6d    5\   >   �� 5]   B    6N   �� *IsMessageReceived+	 False6t   .a�5^   F   ��  �@��CornerRadius$ 
30 30 0 30��6e   �� 5_   F    � �� �#49a0786c   �� 5`   F    � ��$ Right=�6l   5a   C   5c   ;   ._�5h   6   ]� $	��700��6@   .+�5i   :   �� 8��  6D   5j   7   5k   3   �� 5n   2   $ ReplyButton��5o   9   8�� $y�	Collapsed=�5p   -   $��2��5q   -   8�� 5r   -   5s   /   �� 5v   .   $��2��5w   %   ��5x   2   �� 5y   6   " ��6<   .�5z   :   ��  � ��$ Center=�6^   �� 5{   :    � ��$ 	0 10 20 0q�6S    5|   :   �� 5}   >    6J   �� *IsMessageReceived+ True6p   .a�5~   B   ��  � �� 6Y   �� *MsgReceivedOn+�� 5   B    � ��$
 Left=�6h   5�   ?   �� 5�   >    6J   �� *IsMessageReceived+	 False6p   .a�5�   B   ��  � �� 6Y   �� *	MsgSentOn+�� 5�   B    � ��$ Right=�6h   5�   ?   5�   7   5�   /   5�   +   5�   '    5�   &   �� 5�   *   $ False��6\    66   �� *IsMessageReceived+.a�5�   .   �� $ ReplyButton��65    � ��$ 0��6e   5�   +   P� 5�   *    �@J�IsMouseOver . . �5�   .   �� $ ReplyButton��65    � y�$ Visible=�6d   5�   +   5�   #   5�      5�      5�      5�      5�      .��5�      �  5�   
   �� 5�      $
��auto �6   �� 5�      .+�5�   
   �� -   5        $	 searchBoxBorder��5�      ���#dce1de �� CornerRadius$ 15��5�      $��1��5�      $��20q�5�      $��50��5�       +� FocusedElement 5�      ��  �� ElementName$ searchQuery��._�5�      �� -   5        $��searchQuery��5�      
������ $��0q�5�      $
��12,0q�5�      $��Search Text��5�      $��Center=�5�      $��Stretch=�5�      5�      �� 5�   
   
�������$��Disabled=�5�      $��1��66   .��5�      �� $��	15 0 0 0 q�5�      $��Disabled=�6$   #��[ 5�      ��5�      �� *Conversations+ �� UpdateSourceTrigger$ PropertyChanged=���5�      �� 5�      .R�5�      �� 5�      5�      5�      5�      5�      