   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   WindowChromeButtonStyle'   !System.Windows.Shell.WindowChrome �� Property �� Value  IconActiveBrush �� 
TargetType �� Padding �� Triggers ]� 
Conditions �� Property �� Value  ButtonMouseOverBrush " WindowChromeRestoreButtonStyle	 �� BasedOn
 �� Triggers �� Binding �� RelativeSource �� AncestorType �� Value   WindowChromeCloseButtonStyle % !CaptionCloseButtonsMouseOverBrush P� Property P� Value   CaptionCloseButtonsDownBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  &	        7  7  &	 b    7   &	 ?    7   7  7  �� 5      "  ��6   .�5   
   ��   �@  IsHitTestVisibleInChrome . 6B   �� 5   
    � ��
 ���� 6'   �� 5   
    � ��$ 44��6"   �� 5	   
    � ��$ Stretch=�6.   �� 5
   
    � ��8   6'   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� # z��6   #��z��5      ._�5      �� $��Center=�6+   $��Center=�5   +   5       5      ]� 5       5      �� 5   "    �@J�IsMouseOver . 6C   �� 5   "    �@J�IsMouseCaptured .  6G   ./�5      �� 8   � ��6;   5      5      5      5      �� 5!      "  ��6   8	   .�5$   
   ��  � ��$	 ��6$   
 5%   
   �� 5&       6   �� *WindowState+ �� " � 	Maximized5'      .a�5(      ��  � ��$	 ��6,   5)      5+      �� 5-      "  ��6   8	   .�50   
   ��  � ��$	 ��6$   
 51   
   ]� 52       53      �� 54       �@J�IsMouseOver . 67   �� 55       �@J�IsMouseCaptured .  6;   ./�57      ��  � ��8  6/   58      P� 5:       � �� . . �5<      ��  � ��8  6/   5=      5?      5@      