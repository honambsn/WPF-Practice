   M S B A M L   `   `   `  ����  
Smart Home"    Smart_Home.UserControls.Card   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $
��card��5      .��5	      ��   �� CornerRadius$  25��6    �� Padding$ 20q�6   $	��150��6,   $��Stretch=�69    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 1Q�6      
BlurRadius$ 20Q�6/      Opacity$	 0.5Q�6?   ��5   
   �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$	 150��6*   	 �� Triggers	 5      �� 5      
 �� Binding
 6"   ��  �� ElementName$ toggle�� �� Path$ 	IsChecked� �� Value True6Y   .a�5      ��  � �� �#3256f167   5      �� 5      
 6"   �� $ toggle��$ 	IsChecked�	 False6Y   .a�5      ��  � �� �#efefee67   5      �� 5      
 6"   �� $
 card��$ IsHorizontal� True6Z   .a�5      ��  � ��$	 190��62   5      �� 5       
 6"   �� $
 card��$ IsHorizontal�	 False6Z   .a�5!      ��  � ��$	 150��62   5"      5%      ._�5(   
   � .+�5)      �� $��SemiBold"�6   $	��Top=�6.   $
��Left=�6F   $��0 5 0 0q�6a   ��5*      �� 5+      " ��6   	 5,      �� 5-      
 6*   �� $ toggle��$ 	IsChecked� True6a   .a�5.   "   ��  � ��$ On��69   �� 5/   "    � �� �#ffffff6?   50      �� 52      
 6*   �� $ toggle��$ 	IsChecked�	 False6a   .a�53   "   ��  � ��$	 Off��69   �� 54   "    � �� �#3256f16?   55      57      59      �� 5;      -   5         ��Name$ toggle��5;      $��Right=�6'    d� 	IsChecked 6C   �� $
 card��$ 	IsChecked���5=      �� 5>      " ��6      toggleButton �� BasedOn# [  62   .�5?      ��  � ��$	 Top=�6?   	 5A      �� 5B      
 6*   �� $
 card��$ IsHorizontal� True6b   .a�5D   "   ��  � ��$ Center=�6F   5E      �� 5G      
 6*   �� $
 card��$ IsHorizontal�	 False6b   .a�5I   "   ��  � ��$	 Top=�6F   5J      5L      5N      �� 5P      $��Center=�6   $��40��6/   $��40��6:   $
��Left=�6F   ��5Q      �� 5R      " ��6   	 5S      �� 5T      
 6*   �� $ toggle��$ 	IsChecked� True6a   .a�5V   "   ��  � �� 6;   �� $
 card��$ ImageOn�5W      �� 5Y      
 6*   �� $ toggle��$ 	IsChecked�	 False6a   .a�5[   "   ��  � �� 6;   �� $
 card��$ ImageOff�5\      5_      5a      �� 5c      $��Bottom=�6F   $��SemiBold"�6a   ��6   �� $
 card��$ Title���5d      �� 5e      " ��6   	 5f      �� 5g      
 6*   �� $ toggle��$ 	IsChecked� True6a   .a�5h   "   ��  � �� �#ffffff6?   5i      �� 5k      
 6*   �� $ toggle��$ 	IsChecked�	 False6a   .a�5l   "   ��  � �� �#2f2c376?   5m      5o      5q      5r      5t      5u      