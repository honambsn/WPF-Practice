   M S B A M L   `   `   `  ����I  EFiles Explorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Files_Explorer.ViewsFiles_Explorer.Views  5   	   +    %Files_Explorer.Views.PropertiesDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Files_Explorer.Views     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5   	   -   5        $��PropertyDialog��5   	   $	��210��5	   	   $	��363��6     � WindowStyle$
  None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterOwner=�5   	    � AllowsTransparency . 
������  � 	Resources 5       �� 
TargetType �� Property �� Value��%�   'F�       �� 5   
   " F�6   .�5      ��  � �� �#2020205      �� 5       � ��$ 10q�5      5      5      .��5      �� $��1q�6   
���   �._�5   
   �  � RowDefinitions 5      �� 5      $��32 �6    �� 5      .+�5"      � 
�������	 J� Opacity$	 .6Q�5#      *  $Microsoft.Xaml.Behaviors.Interaction
   Triggers
 5$      +  %Microsoft.Xaml.Behaviors.EventTrigger  5%         	EventName$ 	MouseDown��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5&      4  .Microsoft.Xaml.Behaviors.Core.CallMethodAction     
MethodName$ DragMove��6_      TargetObject 6-   ��  �� ElementName$ renameDialog��6_   5'      5)      �� 5+       �� Orientation$ 
Horizontal=�5,      $
��10,0q�5-      .+�5.      F�  �� Stretch$ Uniform=�50      ��5.      �� *Icon+$ PropertyDialog����5/      �� *
FontSize+$ PropertyDialog��50      �� 52       J� IsHitTestVisible .  $��SemiBold"�54      $	��5,0q�55      $
��Left=�57      $��Center=�58      ��56      �� *
FileName+$ PropertyDialog��58      59      �� 5;      -   5         ��Name$ CloseButton��5;      $	����5<         SegoeMDL2Assets#��[  5=      $��11(�5>      $��Right=�5?       �� IsCancel .    WindowChromeCloseButtonStyle#��[ 5A      
 5C        5D      $ Click��6%   . 5E        $ Close��6-    5F   2   �� $ renameDialog��5G      5I      �� 5K      $��1��5L        Window.Background.Static#��[ 5M      $	 .5Q�5N      � 5P      $��1��6    � ColumnDefinitions 5Q      �� 5R      $
��Auto �6'   $��84��64   �� 5S      .+�5V      F� $ Uniform=�5X      ��5W      �� *Icon+ �� UpdateSourceTrigger$ PropertyChanged=�$ PropertyDialog�� 
 Folder �� TargetNullValue# [ 5X      � 5Z      $��1��5[      $��10,0,0,0q�5\       5]      �� 5^      $��80 �6+   �� 5_       5b      �� 5c      �� 5d      �� 5e      �� 5f      �� 5g      �� 5h      �� 5i      �� 5j      .+�5m      �� $��Name:��5n      �� 5o      $��1��5p      ��5q      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5t      $��1��5u      $��File Extension:��5v      �� 5w      $��1��5x      $��1��5y      ��5z      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5|      $��2��5}      $��	Location:��5~      �� 5      $��1��5�      $��2��5�      ��5�      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5�      $��3��5�      $��Size:��5�      �� 5�      $��1��5�      $��3��5�      ��5�      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5�      $��4��5�      $��Created On:��5�      �� 5�      $��1��5�      $��4��5�      ��5�      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5�      $��5��5�      $��Nodified On:��5�      �� 5�      $��1��5�      $��5��5�      ��5�      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5�      $��6��5�      $��Accessed On:��5�      �� 5�      $��1��5�      $��6��5�      ��5�      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5�      $��7��5�      $��Attributes:��5�      �� 5�      $��7��5�      $��1��5�      $ 
Horizontal=�5�      $��Center=�5�      .+�5�      �� $��	Read-Only��5�      ��5�      �� *
Foreground+$ PropertyDialogk�� d� 	IsChecked 5�      �� *
IsReadOnly+ �� Mode$ OneWay=�$ PropertyDialog���� 5�      $��Hidden��5�      ��5�      �� *
Foreground+$ PropertyDialogk�� 5�      �� *
IsHidden+$ OneWay=�$ PropertyDialog��5�      5�      5�      5�      5�      5�      