   M S B A M L   `   `   `  ����G  CCalendar App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Calendar_App.UserControlsCalendar_App.UserControls  5      $    Calendar_App.UserControls.Item   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      3local'clr-namespace:Calendar_App.UserControls  5      -   5        $
��item��5      .��5
      � $��30 10q�6     � ColumnDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   "  FontAwesome.WPF.ImageAwesome  $��20��6G   $��20��6R   $	��top=�6^      
Foreground �#f1f1f1$��0 3 0 0q�6�      Icon 6   ��  �� Path$
 Icon� �� ElementName$
 item��6�   �� 5   
   $��1��6   $
��10 0q�6%   .+�5      �� $��16(�6   ��6&   �� $ Color�$
 item����6Z   �� $ Title�$
 item���� 5       �� Orientation$ 
Horizontal=�6   $��0 5 0 0q�62   .+�5        $��2��6"   $��12��6c   $��12��6n    62   �� $ IconBell�$
 item�� 6z   �� $ Color�$
 item���� 5      $��12(�6   $��8 0 0 0q�6�   ��6*   �� $ Color�$
 item����6]   �� $
 Time�$
 item��6�   5      5      d� 5   
   -   5         d�Name$ btnMenu��5      $��2��6(   ��5      �� 5       �� 
TargetType" d�6"   .R�5         $ 	EllipsisV=�6&   $��16��67   $��16��6B    �#f1f1f1��5!      �� 5"       �� 
TargetType"  6$   	 �� Triggers	 5#   "   P� 5$   &   
 P� Property
 �@J�IsMouseOver P� Value . . �5%   *   ��  �� Property � z� �� Value 5&   .   �� 5'   2    �� ScaleX$	 1.2Q�6A    �� ScaleY$	 1.2Q�6N   5)   +   5*   '   5,      5/      50      52      � 54   
    � AllowsTransparency .  � 	StaysOpen .  $
��Left=�6�    � VerticalOffset$ 30��6�    � HorizontalOffset$ 15��6�   ��6   �� *	IsChecked+$ btnMenu�� � PlacementTarget 6n   �� $ btnMenu��.��55      �� 
������� �� CornerRadius$ 5��6(    �� Padding$	 0 4q�69   ._�56      �� .+�57      *   $Calendar_App.UserControls.MenuButton     Icon$ Check=�6'      Caption$ Check��64     58      $ 	BellSlash=�6'   $
 Mute��68     59      $ Pencil=�6'   $
 Edit��65     5:      $ Trash=�6'   $ Delete��64   5;      5<      5=      5>      5?      