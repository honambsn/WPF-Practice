   M S B A M L   `   `   `  ����F  BFitness App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Fitness_App.UserControlsFitness_App.UserControls  5      '    !Fitness_App.UserControls.InfoCard   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Fitness_App.UserControls     5      c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      -   5        $��infoCard��5	      .��5      � -   5          �Name$
  grid��5      $	��8 0q�6   .+�5   
   ��  �� CornerRadius$ 20��6   ���#7163ba$��60��68   $��60��6C   $	��Top=�6O   $��	0 -30 0 0q�6g    K� ZIndex$ 1��6{    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#      ShadowDepth$ 3Q�63      Opacity$	 0.3Q�6C      	Direction$	 270Q�6Q      Color$ #7163ba��6a   ._�5      .  (MahApps.Metro.IconPacks.PackIconMaterial  $��30��6U   $��30��6`   
�������$��Center=�6   $��Center=�6�   	   Kind	 6$   �� 
 �� ElementName$
 infoCard�� �� Path$
 Icon�6�   5      �� 5   
   -   5         ��Name$ border��5      $��1q�6!   ���#7163ba$ 20��6K   $��-5q�6]   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � y� �� Value$ 	Collapsed=�63    �� Triggers 5      �� 5       �� Binding 6&   �� $

 grid��$ IsMouseOver� �� Value True6]   .a�5      ��  � y�$ Visible=�6;   5      �� 5!       6&   �� $
 infoCard��$ IsActive� True6^   .a�5"      ��  � y�$ Visible=�6;   5#      5%      5'      �� 5*   
   
�������$ 20��6$    �� Padding$ 10q�66   ._�5+      �� .+�5-      ��    
dotsButton#��[  6   .��5.        $	 DotsVertical=�6,   5/      �� 52      ���#5d5382$��16(�6c   $
��Bold"�6q   $��Center=�6�   $��0 10 0 0q�6�   ��6   �� $
 infoCard��$ Title�6�   �� 53      ���#958ead$��Center=�6b   $��0 5 0 0q�6   ��6   �� $
 infoCard��$
 Desc�6   � 56      $	��7 0q�6    � ColumnDefinitions 57      �� 58      $��* �6+   �� 59      $��* �6+   .+�5<      �� $��Progress��6    ���#62598660   �� 5=      ���#625986$��1��6l    �� TextAlignment$ Right=�6|   ��6    �� $
 infoCard��$ 
Percentage�6|   5>      �� 5A        SliderStyle1#���  6    �� IsSelectionRangeEnabled .  �� SelectionEnd 6_   �� $
 infoCard��$ Value�� 5D      $��6 3 6 0q�6    5E      �� 5F      $
��auto �6+   �� 5G      $��* �6+   .+�5J      �� ���#958ead$��Center=�65   $��11(�6P   ��6^   �� $
 infoCard��$ 
BottomText��� 5K      $��1��6Q   $��Right=�6a     
cardButton#��[ 6}   ��6   �� $
 infoCard��$
 Days�6}   5L      5N      5O      5R      5S      