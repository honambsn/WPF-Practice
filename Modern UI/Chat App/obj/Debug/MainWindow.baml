   M S B A M L   `   `   `  ����C  ?Chat App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Chat_AppChat_App  5   	   A%clr-namespace:Chat_App.CustomControlsChat_App.CustomControls  6.       Chat_App.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Chat_App     5   	   @customcontrols%clr-namespace:Chat_App.CustomControls     6.   -   5          �Name$  
mainWindow��5   	    � AllowsTransparency . 
������ $��15(�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ Chat App��5   	   $	��768��6   $
��1250��6'    � WindowStyle$
 None=�5   	    � Icon$ /Assets/Icon/icon.ico��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         ContactInfoButonStyle �� 
TargetType	 �� Property
 �� Value  ContactInfoButtonTemplate �� 
TargetType � ColumnDefinitions j� Stretch �� ImageSource �� TargetNullValue �� UpdateSourceTrigger �� FallbackValue��%�  &	        &	 �     �� 5   
   " ��6.   .�5      �� 	 � ��

 ���� 6+   �� 5      	 � ��

 ���� 6,   �� 5      	 � ��$
 0q�60   5      �� 5   
   " ��6<   .R�5      �� #��z��6   #��z��6?   #��z��5      ._�5      � $��Center=�6    5      �� 5      $��75 �6+   �� 5"      .+�5%      A� $��40��6   $��40��6*   ��5&      �� 5'      $ UniformToFill=�5*   )    5'   )   �� *ContactPhoto+$ /Assets/assets/img2.jpg��$ PropertyChanged=�$ /Assets/assets/img2.jpg��5*   )   5,      � 5.      $��1��6   .+�5/      �� �� 51      $��20(�52   "   $
��Bold"�60   �51   "   �� *ContactName+$ PropertyChanged=�$ Contact Name��$ Contact Name��52   0   �� 53      �� 56      $��15(�6�   �6"   �� *
LastSeen+$ PropertyChanged=�$ 	Last Seen��$ 	Last Seen��6�   57      58      59      5:      5;      5<      .��5?      ��  �� CornerRadius$ 20��6   
�������._�5@   
   � $��0,2,0,-2q�6    � RowDefinitions 5A      �� 5B      $
��Auto �6    �� 5C       5E      �� 5F      $
��Auto �6#   �� 5G      �� 5H      $
��Auto �6#   .+�5L      �� -   5        ���#49a078$ 	20,20,0,0��5L   *   $��3��6C   $��0, -5, 0, -5q�6t   ._�5M      � .+�5N      �� $
��Left=�5O       $
��15,0q�6;   $��Center=�6I   
�������$��22(�5P   3   $
��Bold"�6A   ��5N       �� *Title+ �� ElementName$ 
mainWindow��5P   A   �� 5S       �� Orientation$ 
Horizontal=�6!   $��Right=�6:   $
��10,0q�6V   .+�5T      �� -   5         ��Name$ btnMinimize��5T   !     minimize#��[ 66     IconButtonStyle#��[ 6Z   6�   �� 5V      -   5        $ btnMaximize��5V   !     maximize#��[ 66   #��[ 6Z   6�   �� 5X      -   5        $ btnClose��5X   !    	 close#��[ 63   #��[ 6T   
���  ��6�   5Y      5Z      5[      � 5^      $��1��6   $	��406��6     5_      �� 5`      $
��Auto �6$   �� 5a      $
��Auto �6$   �� 5b      $
��Auto �6$   �� 5c      .+�5g      � $
��15,0q�6   $��75��6%    5h      �� 5i      $
��auto �6+   �� 5j      �� 5k      $��40 �6+   �� 5l      $��40 �6+   .+�5o      �� $��Chats��6    $
��Left=�6-   $��Center=�6H   $��20(�6c   $��SemiBold"�6q   �� 5r      -   5        $ btnChatSearchButton��5r   -   $��2��6    
 search#��[ 6J   #��[ 6l   d� 5u      -   5         d�Name$ btnMoreOptions��5u   #   $��3��6;     more#��[ 5v   #     ToggleIconButtonStyle#��[ 5w   #   5x      �� 5{      -   5         ��Name$ searchBoxBorder��5{   1   $��20q�6   $��50��6%   $ 15��6J   ���#dce1de$��1��6q    +� FocusedElement 5|      �� $ searchQuery��._�5      �� -	   5        $��searchQuery��5      $
��12,0q�61   
������ $��0q�6Y   $��Search text��6m   $��Center=�5�      $��Stretch=�6@   5�      *   $Chat_App.CustomControls.StatusThumbs  5�      $��2��6.   &    Chat_App.CustomControls.ChatList  5�      $��3��6*   5�      � 5�      $��1��6   $��1��6#    5�      �� 5�      $
��Auto �6$   �� 5�      �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   .+�5�      � $��Center=�6   $��75��62   $��0,5,5,0q�6>    5�      �� 5�      �� 5�      $��50 �6+   �� 5�      $��50 �6+   �� 5�      $��50 �6+   �� 5�      $��50 �6+   .+�5�      �� #��[ 6   #��[  5�      �� 5�      $��1��6   #��[ 6-    	 	videocall#��[	 6V   �� 5�      $��2��6   #��[ 6-    
 call#��[
 6V   �� 5�      $��3��6   #��[ 6-   #��[ 6V   d� 5�      $��4��6#   #��[ 5�   #   #��[ 5�   #   5�      *   $Chat_App.CustomControls.Conversation  5�      $��1��6.   � 5�      $��3��6   .+�5�      �� ���#dce1de$ 15��62   $��50��6D   $
��15,8q�6P   ._�5�      �  5�      �� 5�   "   �� 5�   "   $
��auto �63   .+�5�      �� -
   5         ��Name$ 
MessageBox��5�   !   
������ $
��12,0q�5�   !   $��0q�5�   !   $��Center=�5�   !   $��Stretch=�5�   !   ��5�   !   �� *MessageText+.��6>   5�      �� 5�      $��1��6)   $ 
Horizontal=�69   .+�5�   "   �� -   5        $ AttachButton��5�   %    
 attach#��[ 5�   %   #��[ 5�   %   �� 5�   "   -   5        $ SendMsgButton��5�   %     send#��[ 5�   %   #��[ 5�   %   5�      5�      5�      5�      5�      )   #Chat_App.CustomControls.ContactInfo  5�      -   5          Name$ ContactInfoScreen��5�   )   $��1��6D   $��2��6Q   5�      5�      5�      