   M S B A M L   `   `   `  ����  Music Player+    %Music_Player.UserControls.PopularSong   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5        $��popularSong��5      .��5      �� -   5          ��Name$  border��5       �� CornerRadius$ 30��6    �� Padding$ 10q�6/   $	��0 7q�6<   ��5   
   �� 5       �� 
TargetType" ��6   .�5	      ��  �� Property � �� �� Value �#ecf4f06/    �� Triggers 5
      P� 5       P� Property �@J�IsMouseOver P� Value . . �5      ��  � �� �#03b76967   5      �� 5      	 �� Binding	 6"   �� 
 �� ElementName$
 popularSong�� �� Path$ IsActive� �� Value True6]   .a�5      ��  � �� �#03b76967   5      5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $	��180 �6#   �� 5      $��* �6#   .+�5      A� $��40��6   $��40��6!   $��0 0 20 0q�6-   ��5      �� 5        j� Stretch$ UniformToFill=�6]    �� ImageSource 6!   �� $
 popularSong��$ Image�6]   5#      �� 5%      $��16(�6M   $��SemiBold"�6[   $��1��6q   $��Center=�6�   $��0 0 0 2q�6�   ��6   �� $
 popularSong��$ Title���5&      �� 5'      " ��6   .�5(      ��  � �� �#787c7a67    5*      �� 5+      	 6*   �� $
 border��$ IsMouseOver� True6c   .a�5,   "   ��  � ��
 �����6?   5-      �� 5/      	 6*   �� $
 popularSong��$ IsActive� True6e   .a�50   "   ��  � ��
 �����6?   51      53      55      �� 57      $��14(�6L   $��SemiBold"�6Z   $��2��6p   $��Center=�6�   $��0 0 20 2q�6�   $��Right=�6�   ��6   �� $
 popularSong��$
 Time�59      5:      5;      5<      