   M S B A M L   `   `   `  ����I  EFiles Explorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Files_Explorer.ViewsFiles_Explorer.Views  5   	   E'clr-namespace:Files_Explorer.PropertiesFiles_Explorer.Properties  5   	   +    %Files_Explorer.Views.PropertiesDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Files_Explorer.Views     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5   	   2prop'clr-namespace:Files_Explorer.Properties  5   	   -   5        $��PropertyDialog��5   	   $	��210��5
   	   $	��363��6     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterOwner=�5   	    � AllowsTransparency . 
������  � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers	 �� Binding(  "Files_Explorer.Properties.Settings
   Default �� Source �� Value   IconActiveBrush��%�   'F�       7   �� 5   
   " F�6   .�5      ��  � �� �#2020205      �� 5       � ��$ 10q�5       5      �� 5      	 6   �� *
DarkMode+# Z
  True6d   .a�5      ��  � ��8   6-   5      5      5      .��5       �� $��1q�6   
���   �._�5"   
   �  � RowDefinitions 5#      �� 5$      $��32 �6    �� 5%      .+�5(      � 
������� J� Opacity$ .6Q�5)      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5*      +  %Microsoft.Xaml.Behaviors.EventTrigger  5+         	EventName$ 	MouseDown��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5,      4  .Microsoft.Xaml.Behaviors.Core.CallMethodAction     
MethodName$ DragMove��6_      TargetObject 6-   ��  �� ElementName$ renameDialog��6_   5-      5/      �� 51       �� Orientation$ 
Horizontal=�52      $
��10,0q�53      .+�54      F�  �� Stretch$ Uniform=�56      ��54      �� *Icon+$ PropertyDialog����55      �� *
FontSize+$ PropertyDialog��56      �� 58       J� IsHitTestVisible .  $��SemiBold"�5:      $	��5,0q�5;      $
��Left=�5=      $��Center=�5>      ��5<      �� *
FileName+$ PropertyDialog��5>      5?      �� 5A      -   5         ��Name$ CloseButton��5A      $	����5B        SegoeMDL2Assets#��[ 5C      $��11(�5D      $��Right=�5E       �� IsCancel .    WindowChromeCloseButtonStyle#��[ 5G       5I        5J      $ Click��6%   . 5K        $ Close��6-    5L   2   �� $ renameDialog��5M      5O      �� 5Q      $��1��5R        Window.Background.Static#��[ 5S      $ .5Q�5T      � 5V      $��1��6    � ColumnDefinitions 5W      �� 5X      $
��Auto �6'   $��84��64   �� 5Y      .+�5\      F� $ Uniform=�5^      ��5]      �� *Icon+ �� UpdateSourceTrigger$ PropertyChanged=�$ PropertyDialog�� 
 Folder �� TargetNullValue# [ 5^      � 5`      $��1��5a      $��10,0,0,0q�5b       5c      �� 5d      $��80 �6+   �� 5e       5h      �� 5i      �� 5j      �� 5k      �� 5l      �� 5m      �� 5n      �� 5o      �� 5p      .+�5s      �� $��Name:��5t      �� 5u      $��1��5v      ��5w      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5z      $��1��5{      $��File Extension:��5|      �� 5}      $��1��5~      $��1��5      ��5�      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5�      $��2��5�      $��	Location:��5�      �� 5�      $��1��5�      $��2��5�      ��5�      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5�      $��3��5�      $��Size:��5�      �� 5�      $��1��5�      $��3��5�      ��5�      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5�      $��4��5�      $��Created On:��5�      �� 5�      $��1��5�      $��4��5�      ��5�      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5�      $��5��5�      $��Nodified On:��5�      �� 5�      $��1��5�      $��5��5�      ��5�      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5�      $��6��5�      $��Accessed On:��5�      �� 5�      $��1��5�      $��6��5�      ��5�      �� *
FileName+$ PropertyChanged=�$ PropertyDialog���� 5�      $��7��5�      $��Attributes:��5�      �� 5�      $��7��5�      $��1��5�      $ 
Horizontal=�5�      $��Center=�5�      .+�5�      �� $��	Read-Only��5�      ��5�      �� *
Foreground+$ PropertyDialogk�� d� 	IsChecked 5�      �� *
IsReadOnly+ �� Mode$ OneWay=�$ PropertyDialog���� 5�      $��Hidden��5�      ��5�      �� *
Foreground+$ PropertyDialogk�� 5�      �� *
IsHidden+$ OneWay=�$ PropertyDialog��5�      5�      5�      5�      5�      5�      