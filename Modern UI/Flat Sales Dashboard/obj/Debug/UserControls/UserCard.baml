   M S B A M L   `   `   `  ����  Flat Sales Dashboard0    *Flat_Sales_Dashboard.UserControls.UserCard   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      g cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      -   5        $��userCard��5      .��5	      ��   �� CornerRadius$  10��6    �� Padding$ 3q�6   $
��0 10q�6+   ��5
   
   �� 5       �� 
TargetType" ��6    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5      ��  �� Property � �� �� Value �#f7f6f467   5      �� 5       �� Binding 6"   �� 	 �� ElementName$	 userCard��
 �� Path$
 IsActive� �� Value True6Z   .a�5      ��  � �� �#f7f6f467   5      5      ._�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��50��6   $��50��6    $  10��6,   $��0 0 10 0q�6>   ��5      �� 5       �� 
StartPoint$ 0.5, 0&�6*    �� EndPoint$ 0.5, 1&�6>   .��5      �  � Color$ #7cb8ff��6'    � Offset$ 0Q�67   � 5      $ #b2d3fe��6'   $ 1Q�67   5      ._�5!      �� $��38��6   $��38��6#   ��6/   �� $	 userCard��$
 Image�5"      �� 5$      .+�5%      �� $��SemiBold"�6   $��13(�62   ���#214865��6U   �� $	 userCard��$
 Title��� 5'      $ 
Horizontal=�6   $��0 5 0 0q�66   .+�5(      �� ���#7eb9ff$  50��62   $��20��6D   $��20��6O   ._�5)      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ 	ChevronUp=�60   $��Center=�6B   $��Center=�6]   $��8��6z   $��8��6�   ���#ffffff6�   5*      �� 5,      $
��10 0q�6!   .+�5-      �� $��Sales��6$   ���#fc967d$��10(�6F   �� 5.      ���#17405e$��11(�6m   ��6$   �� $	 userCard��$
 UpPrice�6m   5/      �� 52      ���#76728b$  50��62   $��20��6D   $��20��6O   ._�53        $ 	ChevronUp=�60   $��Center=�6B   $��Center=�6]   $��8��6z   $��8��6�   ���#ffffff6�   54      �� 56      $
��10 0q�6!   .+�57      �� $��Profit��6$   ���#fc967d$��10(�6G   �� 58      ���#17405e$��11(�6o   ��6$   �� $	 userCard��$
 	DownPrice�6o   59      5=      5>      5?      5@      5A      