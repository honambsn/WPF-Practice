   M S B A M L   `   `   `  ����H  DFile Explorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:File_ExplorerFile_Explorer  5   	   K*clr-namespace:File_Explorer.CustomControlsFile_Explorer.CustomControls  5   	   $    File_Explorer.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:File_Explorer     5   	   9cc*clr-namespace:File_Explorer.CustomControls     5   	   -   5          �Name$  
mainWindow��5   	    � Title$ 
MainWindow��5	   	   $	��782��5
   	   $
��1235��6   $	��760��5   	   $	��864��6    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5       
  Image0 �� 	UriSource 
 Image1 
 Image2 
 Image3 
 Image4 
 Image5��%D  &	        &	 ,     &	 X     &	 �     &	 �     &	 �     �� 5   
   $ ../Resources/0.jpg?�6%   �� 5   
   $ ../Resources/1.jpg?�6%   �� 5   
   $ ../Resources/2.jpg?�6%   �� 5   
   $ ../Resources/3.jpg?�6%   �� 5   
   $ ../Resources/4.jpg?�6%   �� 5   
   $ ../Resources/5.jpg?�6%   5      ��5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property �@�AllowsTransparency �� Value . 63   �� 5       �@�WindowStyle$
 None=�6,   �� 5       �@�UseLayoutRounding . 62   �� 5      &   System.Windows.Media.TextOptions �@ TextFormattingMode$ Ideal=�6?   �� 5       �@ TextRenderingMode$ 	ClearType=�6>   �� 5      '  !System.Windows.Shell.WindowChrome �@ WindowChrome 5         5!         CaptionHeight$ 32Q�5"      	   CornerRadius$	 0��5#      
   GlassFrameThickness$
 0q�5$         NonClientFrameEdges$
 None=�5%         ResizeBorderThickness$ 1q�5&         UseAeroCaptionButtons .  5'      5)      �� 5+       � �� 5,      �� 5-       �� 
TargetType" �6&   .R�5.      ��  ��Name$ 
RootBorder��6!     InactiveWindowBrush#��[ 5/   !   $��0q�50   !   #��z��51   !   ._�52      �  � RowDefinitions 53   "   �� 54   &   $
��Auto �64   �� 55   &   $��* �64    � ColumnDefinitions 58   "   �� 59   &   $	��280 �67   �� 5:   &   .+�5>   "   �  �Name$ TitleBarGrid��6'   $��0��5?   '   $��1��5@   '   $��32��5A   '   .+�5B   &   �� $��Title��60   $
��Left=�5C   0   $��Center=�5D   0   $
��30,0q�5E   0   #��z 5F   0     Window.TitleFontBrush#��[ 5G   0   $
��Bold"�5H   0   �� 5K   &   $��Right=�61    �� Orientation$ 
Horizontal=�5L   1   .+�5M   *   ��  ��Name$ MinimizeButton��61   -   5        $	����5O   1   $��Segoe MDL2 Assets)�5P   1   $��11(�5Q   1     WindowChromeButtonStyle#��[ 5R   1   �� 5S   *   $ MaximizeButton��61   -   5        $	����5U   1   $��Segoe MDL2 Assets)�5V   1   $��11(�5W   1    "	 WindowChromeRestoreButtonStyle#��[	 5X   1   �� 5Y   *   $ CloseButton��61   -   5        $	����5[   1   $��Segoe MDL2 Assets)�5\   1   $��11(�5]   1     
 WindowChromeCloseButtonStyle#��[
 5^   1   5_   '   5`   #   � 5d   "   $��2��6'   $��0��5e   '   ��5g   &   �� 5h   *   
ImageBrush�� �� ImageSource$ ../Resources/0.jpg��5i   6    j� Stretch$ UniformToFill=�5j   6    j� 
AlignmentX$ Right=�5k   6   .+�5m   &   �� $��Border��6-   ��5n   *   �� 5o   .    �� Color$ 	#ff343f3d��5p   1    �� Opacity$	 .65Q�5q   1   5s   '   5t   #   � 5u   "   $��2��5v   %   $��2��5w   %   .+�5x   &   �� .u�5y   *   �� 5z   '   5{   #   5}      5~       �� Triggers 5      :� 5�       :� RoutedEvent$ Loaded��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   T�  �� 
TargetName$ 
ImageBrush��5�   -    �� TargetProperty$ ImageSource�5�   -    g� Duration$ 0:0:35D�5�   -    g� RepeatBehavior$ Forever��5�   -   ..�5�   .   i�   R� Value#  [  6E   ! R� KeyTime$! 0:0:5��5�   E   i� 5�   .   #  [ 6E   $! 0:0:10��5�   E   i� 5�   .   #  [ 6E   $! 0:0:15��5�   E   i� 5�   .   #  [ 6E   $! 0:0:20��5�   E   i� 5�   .   #  [ 6E   $! 0:0:25��5�   E   i� 5�   .   #  [ 6E   $! 0:0:30��5�   E   5�   +   5�   '   5�   #   5�      P� 5�      " P� Property" �@�WindowState# P� Value$# 	Maximized=�6=   . �5�   "   �� $ �� 
TargetName$$ 
RootBorder��6)    � ��
 ���� 6X   �� 5�   "   $$ 
RootBorder��6)    �@��Padding$ 7q�6T   5�      5�      5�      5�      .��5�      �  5�   
   �� 5�      $	��280 �6   �� 5�      .+�5�      �  5�   
   �� 5�      $��* �6   �� 5�      $��95 �6   .+�5�   
   �� $��0��5�      $
��25,0q�5�      $
��Auto=�5�      $��Disabled=�5�      .��5�      ��  5�        NavFontBrush  DropShadowEffect��%�   '��       7  7  �� 5�      " ��6   .�5�      ��  � ��$ Center=�6>   �� 5�       � ��$
 Bold"�67   �� 5�       � ��8   67   �� 5�       �@J�Effect8  63   5�      5�      .+�5�      �� $��	Favorites��5�      �� 5�      $��0,0,0,17q�5�      .@�5�      7  1File_Explorer.CustomControls.DriveAndFolderButton  $��Games��5�       
 Folder%   Icon#% [ 5�      5�      5�      5�      5�      5�      5�      