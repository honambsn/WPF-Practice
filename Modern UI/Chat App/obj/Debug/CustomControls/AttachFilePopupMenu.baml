   M S B A M L   `   `   `  ����C  ?Chat App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Chat_App.CustomControlsChat_App.CustomControls  5      1    +Chat_App.CustomControls.AttachFilePopupMenu   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Chat_App.CustomControls     5        � 	Resources  5	       �� 
TargetType �� Property �� Value �� ElementName �� 
TargetType �� CornerRadius � RowDefinitions �� Stretch
	 � Tag
 �� TextAlignment �� Triggers P� Property P� Value��%N  '��       7F��� 5
   
   " ��6   .�5      ��  � ��$
 Auto��6'   �� 5       � ��$ SemiBold"�6+   �� 5       � ��
 ���� 6+   �� 5       � �� 6(   �� *!DataContext.PopupOptionsCommand+$ _this���� 5       � �� 61   �� �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 20��5      #��z��5      ._�5      � $��20q�6#    5   "   �� 5   &   �� 5   &   $
��Auto �64   .+�5   "   � .+�5   &   A� $��80��5   %   $��80��5   %   $��2��5    %   $ Uniform=�5"   %   ��5!   %   �� *BorderStroke+��5#   %   �� *Fill+F� 5%   &   #��z	 5'   )   8��  ��5&   )   �� *BorderStroke+5(   )   5)   #   �� 5,   "   $��1��5-   %   $��Center=�5.   %   $��Center=�5/   %   #��z��50   %   $
 Center=�51   %   #��z��52   %   53      54       55      P� 56       �@J�IsMouseOver . . �58   "   ��  � �� �#Dce1de6?   59      P� 5:       � �� . . �5<   "   ��  � �� �#Dce1de6?   5=      5?      5A      5B      5C      .��5E      �� $ 20��5F   	   
������� J� Effect 5I   
   3  -System.Windows.Media.Effects.DropShadowEffect  5J         
BlurRadius$ 25Q�5K         ShadowDepth$ 5Q�5L         	Direction$	 270Q�5M         Color$ #dce1de��5N      ._�5Q   
   �� $��10q�5R      ��5S      �� *AttachmentOptionsMenuList+��5T      �� 5U      .R�5V      A�  A� Rows$ 2��6"    A� Columns$ 3��6+   5W      ��5Y      �� 5Z      .R�5[      �� 	 5\      �� *Icon+��5]      �� *
MenuText+5^      5`      5a      5b      