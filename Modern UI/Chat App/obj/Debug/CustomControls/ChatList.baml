   M S B A M L   `   `   `  ����C  ?Chat App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Chat_App.CustomControlsChat_App.CustomControls  5      9!clr-namespace:Chat_App.ViewModelsChat_App.ViewModels  6B   &     Chat_App.CustomControls.ChatList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Chat_App.CustomControls     5      7	viewmodel!clr-namespace:Chat_App.ViewModels     6B   -   5          >�Name$  _Chats��5      $	��406��5       � 	Resources 5	         ChatButtonItemTemplate 	� 	GroupName �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius	 �� Padding
 J� SnapsToDevicePixels � RowDefinitions � ColumnDefinitions j� Stretch �� ImageSource �� FallbackValue �� TargetNullValue �� UpdateSourceTrigger �� Triggers �� Binding �� RelativeSource �� AncestorType �� Value A� Columns 
 pinned  IconButtonStyle �� ElementName  archive  mute 	 trash��%�	  &	        7  7  7  7  7  7  7  7  �� 5
   
   .R�5      	� $ 
ChatButton��6   ��5      �� 5      " d�6   .�5      ��  �@J�SnapsToDevicePixels . 6@   �� 5       � ��$ 80��66   �� 5       � ��$ 10q�64   �� 5       � ��$ Center=�6G   �� 5       � ��$ Center=�6>   �� 5       � ��
 ���� 67   �� 5       � ��$ 0q�6<   �� 5       � �� 64   �� *ContactName+�� 5       � �� 6=   �� *ContactName+�� 5       � �� 64   �� *ContactName+�� 5       � �� 5      �� 5   "   " d�62   .R�5   &   �� $ border��5   Y   #��z��5   -   #��z��6a   #��z��5   -   $ 20��6i   #	 z��5   -   
 . ._�5!   *   �  5"   .   �� 5#   2   $
��Auto �6@   �� 5$   2   $
��Auto �6@   .+�5(   .   � $��0��63    5)   2   �� 5+   6   $
��auto �6G   �� 5.   6   �� 51   6   $
��auto �6G   .+�54   2   A� $��50��6:   $��50��6E   ��55   6   �� 57   :   $ UniformToFill=�6E    58   E   �� *ContactPhoto+$ /assets/6.jpg��$ /assets/6.jpg��$ PropertyChanged=�5:   3   � 5>   2   $��1��67   $
��20,0q�6G    5?   6   �� 5@   :   $
��Auto �6H   �� 5A   :   $
��Auto �6H   .+�5D   6   �� $��20(�6]   ��6@   �� *ContactName+��5E   :   �� 5F   >   " ��6D   .�5G   B   ��  � ��$ SemiBold"�6_    5H   B   �� 5I   F    6R   �� *IsMouseOver+ �� " d� True6�   .a�5J   J   ��  � ��$
 Bold"�6g   5L   G   5N   ?   5P   7   �� 5R   6   $��1��6@   ��6M   �� *	Message+��5S   :   �� 5T   >   " ��6D   .�5U   B   ��  � ��$ Normal"�6_    5V   B   �� 5W   F    6R   �� *IsMouseOver+ �� " d� True6�   .a�5X   J   ��  � ��$ SemiBold"�6g   5Z   G   5\   ?   5^   7   5_   3   � 5c   2   $��2��67   .+�5d   6   �� $��Right=�6c   ��6@   �� *LatestMessageTime+6c   5e   3   �� 5f   2   $��Bottom=�6<   $��.5q�6W   
�������$��2��5g   V   $��1��6j   5h   /   � 5m   .   $��1��63   $
��auto��6@    5n   2   �� 5o   6   $��50 �6G   �� 5p   6   .+�5r   2   A� $ 4��6>   $��1��6J   .+�5s   6   �� 8��  8�� ��5t   =   �� *DataContext.PinChatCommand+$ _Chats����5u   =   �� �� 5v   6   8�� 8�� 6`   �� 5w   6   8�� 8�� 6]   �� 5x   6   8�� 8�� 6^   5y   3   5z   /   5}   +   5   '   5�   #   5�      5�      5�      5�      5�      .��5�      �� $��Disabled=�6   .��5�   
   � $��25,15q�6   .+�5�      �� .+�5�      ��  �� Orientation$ 
Horizontal=�6   .+�5�      F� 
���   �#��[ 6(   $��1��6G   
���   �6[   �� 5�      $
��10,0q�6    $��Pinned Chats��6.   $��SemiBold"�6B   $��Center=�5�       5�      �� 5�      #��[  5�      $
��0,15q�5�      ��5�      �� *FilteredPinnedChats+ � DataContext 5�      #   Chat_App.ViewModels.ViewModel  5�      5�      �� 5�      $ 
Horizontal=�6   .+�5�      F� 
���   �  allchats#��[ 6(   �� 5�      $
��10,0q�6    $��	All Chats��6.   $��SemiBold"�6?   $��Center=�5�      5�      �� 5�      #��[  5�      $
��0,15q�5�      ��5�      �� *FilteredChats+ 5�        5�      5�      5�      5�      5�      5�      