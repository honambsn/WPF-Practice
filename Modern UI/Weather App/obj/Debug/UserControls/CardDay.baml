   M S B A M L   `   `   `  ����F  BWeather App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Weather_App.UserControlsWeather_App.UserControls  5      &     Weather_App.UserControls.CardDay   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Weather_App.UserControls     5      -   5        $��cardDay��5      .��5	      ��   �� CornerRadius$  10��6   $��85��6    �� Padding$ 10q�6*   $��0 0 10 0q�67   $��1q�6I   ��5
   
   �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 �����6/   �� 5       � �� �#e9e9e960    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5      ��  � �� �#03a9f468   5      5      ._�5   
   �� .+�5      ��  �� TextAlignment$ Center=�6G   $��14(�6^   $��SemiBold"�6l   ��6   �� 	 �� Path$		 Day�
 �� ElementName$
 cardDay��6l   �� 5      $��30��6H   $��	0 10 0 10q�6S   ��6   �� $	 Source�$
 cardDay��6S   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� $ Center=�6N   $��SemiBold"�6e   $��0 0 8 0q�6{   ��6   �� $	 MaxNum�$
 cardDay��6{   �� 5      $ Center=�6N   $��SemiBold"�6e   ���#a7a7a7��6   �� $	 MinNum�$
 cardDay��6{   5      5      5      5       