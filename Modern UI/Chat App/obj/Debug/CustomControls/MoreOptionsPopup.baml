   M S B A M L   `   `   `  ����C  ?Chat App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Chat_App.CustomControlsChat_App.CustomControls  5      .    (Chat_App.CustomControls.MoreOptionsPopup   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Chat_App.CustomControls     5      -   5          >�Name$  moreOptionsPopup��5      $��20q�5       � 	Resources 5A       �� 
TargetType �� Property �� Value �� ElementName �� 
TargetType �� CornerRadius � ColumnDefinitions
	 � Tag
 �� Triggers P� Property P� Value��%(  '��       7F��� 5B   
   " ��6   .�5C      ��  � ��$ 40��6'   �� 5D       � ��
 ���� 6+   �� 5E       � �� 6(   �� *!DataContext.PopupOptionsCommand+$ _this���� 5F       � �� 61   �� �� 5G       � �� 5H      �� 5I      " ��6&   .R�5J      �� $ 5��6!   #��z��62   ._�5K      �  5L   "   �� 5M   &   $��40 �67   �� 5N   &   .+�5P   "   F� #��z	 6'   8��  5Q   '   �� 5R   "   $��0 0 10 0q�6,   $��1��6>   $
��Left=�5S   ,   $��Center=�5T   ,   #��z��5U   ,   #��z��5V   ,   5W      5X      
 5Y      P� 5Z       �@J�IsMouseOver . . �5[   "   ��  � �� �#dce1de6?   5\      P� 5]       � �� . . �5^   "   ��  � �� �#dce1de6?   5_      5a      5c      5d      5e      .��5g      �� $ 5��6   
������� J� Effect 5h   
   3  -System.Windows.Media.Effects.DropShadowEffect  5i         
BlurRadius$ 25Q�6      ShadowDepth$ 5Q�6/      	Direction$	 270Q�6?      Color$ #dce1de��6O   ._�5l   
   �� $��10q�6   ��6#   �� *WindowMoreOptionsMenuList+��5m      �� 5n      .R�5o      �� 	 6   �� *Icon+��62   �� *
MenuText+5p      5r      5s      5t      