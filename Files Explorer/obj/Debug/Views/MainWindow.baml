   M S B A M L   `   `   `  ����I  EFiles Explorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Files_ExplorerFiles_Explorer  5   	   K*clr-namespace:File_Explorer.CustomControlsFile_Explorer.CustomControls  5   	   ;"clr-namespace:Files_Explorer.ViewsFiles_Explorer.Views  5   	   E'clr-namespace:Files_Explorer.PropertiesFiles_Explorer.Properties  5	   	   %    Files_Explorer.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Files_Explorer     5   	   9cc*clr-namespace:File_Explorer.CustomControls     5   	   4views"clr-namespace:Files_Explorer.Views     5   	   8prop'clr-namespace:Files_Explorer.Properties     5	   	   -   5          �Name$  
mainWindow��5   	    � Title$ 
MainWindow��5   	   $	��782��5   	   $
��1235��6   $	��760��5   	   $	��864��6    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5       
  Image0 �� 	UriSource 
 Image1 
 Image2 
 Image3 
 Image4 
 Image5��%D  &	        &	 ,     &	 X     &	 �     &	 �     &	 �     �� 5   
   $ ../Resources/0.jpg?�6%   �� 5   
   $ ../Resources/1.jpg?�6%   �� 5   
   $ ../Resources/2.jpg?�6%   �� 5   
   $ ../Resources/3.jpg?�6%   �� 5   
   $ ../Resources/4.jpg?�6%   �� 5   
   $ ../Resources/5.jpg?�6%   5      ��5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property �@�AllowsTransparency �� Value . 63   �� 5       �@�WindowStyle$
 None=�6,   �� 5       �@�UseLayoutRounding . 62   �� 5      &   System.Windows.Media.TextOptions �@ TextFormattingMode$ Ideal=�6?   �� 5        �@ TextRenderingMode$ 	ClearType=�6>   �� 5!      '  !System.Windows.Shell.WindowChrome �@ WindowChrome 5"        5#         CaptionHeight$ 32Q�5$      	   CornerRadius$	 0��5%      
   GlassFrameThickness$
 0q�5&         NonClientFrameEdges$
 None=�5'         ResizeBorderThickness$ 1q�5(         UseAeroCaptionButtons .  5)      5+      �� 5-       � �� 5.      �� 5/       �� 
TargetType" �6&   .R�50      ��  ��Name$ 
RootBorder��6!     InactiveWindowBrush#��[ 51   !   $��0q�52   !   #��z��53   !   ._�54      �  � RowDefinitions 55   "   �� 56   &   $
��Auto �64   �� 57   &   $��* �64    � ColumnDefinitions 5:   "   �� 5;   &   $	��280 �67   �� 5<   &   .+�5@   "   �  �Name$ TitleBarGrid��6'   $��0��5A   '   $��1��5B   '   $��32��5C   '   .+�5D   &   �� $��Title��60   $
��Left=�5E   0   $��Center=�5F   0   $
��30,0q�5G   0   #��z 5H   0     Window.TitleFontBrush#��[ 5I   0   $
��Bold"�5J   0   �� 5M   &   $��Right=�61    �� Orientation$ 
Horizontal=�5N   1   .+�5O   *   ��  ��Name$ MinimizeButton��61   -   5        $	����5Q   1   $��Segoe MDL2 Assets)�5R   1   $��11(�5S   1     WindowChromeButtonStyle#��[ 5T   1   �� 5U   *   $ MaximizeButton��61   -   5        $	����5W   1   $��Segoe MDL2 Assets)�5X   1   $��11(�5Y   1    "	 WindowChromeRestoreButtonStyle#��[	 5Z   1   �� 5[   *   $ CloseButton��61   -   5        $	����5]   1   $��Segoe MDL2 Assets)�5^   1   $��11(�5_   1     
 WindowChromeCloseButtonStyle#��[
 5`   1   5a   '   5b   #   � 5f   "   $��2��6'   $��0��5g   '   ��5i   &   �� 5j   *   
ImageBrush�� �� ImageSource$ ../Resources/0.jpg��5k   6    j� Stretch$ UniformToFill=�5l   6    j� 
AlignmentX$ Right=�5m   6   .+�5o   &   �� $��Border��6-   ��5p   *   �� 5q   .    �� Color$ 	#ff343f3d��5r   1    �� Opacity$	 .65Q�5s   1   5u   '   5v   #   � 5w   "   $��2��5x   %   $��2��5y   %   .+�5z   &   �� .u�5{   *   �� 5|   '   5}   #   5      5�       �� Triggers 5�      :� 5�       :� RoutedEvent$ Loaded��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   T�  �� 
TargetName$ 
ImageBrush��5�   -    �� TargetProperty$ ImageSource�5�   -    g� Duration$ 0:0:35D�5�   -    g� RepeatBehavior$ Forever��5�   -   ..�5�   .   i�   R� Value#  [  6E   ! R� KeyTime$! 0:0:5��5�   E   i� 5�   .   #  [ 6E   $! 0:0:10��5�   E   i� 5�   .   #  [ 6E   $! 0:0:15��5�   E   i� 5�   .   #  [ 6E   $! 0:0:20��5�   E   i� 5�   .   #  [ 6E   $! 0:0:25��5�   E   i� 5�   .   #  [ 6E   $! 0:0:30��5�   E   5�   +   5�   '   5�   #   5�      P� 5�      " P� Property" �@�WindowState# P� Value$# 	Maximized=�6=   . �5�   "   �� $ �� 
TargetName$$ 
RootBorder��6)    � ��
 ���� 6X   �� 5�   "   $$ 
RootBorder��6)    �@��Padding$ 7q�6T   5�      5�      5�      5�      .��5�      �  5�   
   �� 5�      $	��280 �6   �� 5�      .+�5�   
   �  5�      �� 5�      $��* �6    �� 5�      $��95 �6    .+�5�      �� $��0��5�      $
��25,0q�5�      $
��Auto=�5�      $��Disabled=�5�      .��5�      ��  5�        NavFontBrush  DropShadowEffect��%�   '��       7  7  �� 5�      " ��6    .�5�      ��  � ��$ Center=�6B   �� 5�       � ��$
 Bold"�6;   �� 5�       � ��8   6;   �� 5�       �@J�Effect8  67   5�      5�      .+�5�      �� $��	Favorites��5�      �� 5�      $��0,0,0,17q�5�      .@�5�      7  1File_Explorer.CustomControls.DriveAndFolderButton  $��Games��5�   !    
 Folder%   Icon#% [ 5�   !   $��0,5,0,0q�5�   !   5�      �� 5�      $��Remote��5�      �� 5�      $��0,0,0,17q�5�      .@�5�        $��OneDrive��62     OneDrive#% [ 5�   2   $��0,5,0,0q�5�   2     5�      $��Google Drive��62     GoogleDrive#% [ 5�   2   $��0,5,0,0q�5�   2     5�      $��Dropbox��62     Dropbox#% [ 5�   2   $��0,5,0,0q�5�   2   5�      �� 5�      $��	Libraries��6    $��0,17,0,0q�5�       �� 5�      .@�5�        $��Desktop��62     DesktopFolder#% [ 5�   2   $��0,5,0,0q�5�   2     5�      $��	Documents��62     DocumentsFolder#% [ 5�   2   $��0,5,0,0q�5�   2     5�      $��	Downloads��62     DownloadsFolder#% [ 5�   2   $��0,5,0,0q�5�   2     5�      $��Pictures��62     PicturesFolder#% [ 5�   2   $��0,5,0,0q�5�   2     5�      $��Videos��62     VideosFolder#% [ 5�   2   $��0,5,0,0q�5�   2     5�      $��Music��62     MusicsFolder#% [ 5�   2   $��0,5,0,0q�5�   2   5�      �� 5�      $��Devices��6    $��0,17,0,0q�5�       �� 5�      .@�5�        $��Local Disk (C:)��62    
 CDrive#% [ 5�   2   $��0,5,0,0q�5�   2     5�      $��Local Disk (D:)��62     NormalDrive#% [ 5�   2   $��0,5,0,0q�5�   2     5�      $��Local Disk (E:)��62   #% [ 5�   2   $��0,5,0,0q�5�   2   5�      5�      5      �� 5     $��1��5     $��0��5     .+�5       $
��User��5       User#% [ 5     $
��10,5q�5       5
     $��Settings��5       Settings#% [ 5     $
��10,5q�5     5     5     � 5  
   $��1��5     $��10,0,0,0q�5      5     �� 5     $��38 �6    �� 5     $
��auto �6    �� 5     $��50 �6    �� 5     �� 5     $
��auto �6    .+�5$     �  5%     �� 5&     �� 5'     $
��auto �6'   .+�5*     �� $ 
Horizontal=�5+     $
��Left=�5,     $��Center=�5-     .+�5.     	� $
��Home��5/     & d� 	IsChecked$
& TrueY�50       MenuHeaderRadioButtonStyle#���  51     	� 53     $��Computer��54     #���  55     	� 57     $
��View��58     #���  59     d� 5;     -   5        ' d�Name$!' ToggleExpandCollapseSubMenu��5<     $��10(�5=      # ExpandCollapseToggleButtonStyle#���  5>     5?     �� 5B     $��1��5C     $ 
Horizontal=�5D     $��Right=�5E     $��Center=�5F     .+�5G     �� -   5        ( ��Name$( 	SearchBox��5I     $
��12,0q�5H       SearchBoxStyle#���  5J     �� 5L      	 Share#��[ 5M     $��20(�5N     $��44��5O       ButtonWithIconStyle#���  5P     d� 5R     -   5        $��44��5S     $��15(�5U      "  DarkLightModeToggleButtonStyle#���   5W     & 5T     �� *
DarkMode+) �� Mode$) TwoWay=�(  "Files_Explorer.Properties.Settings*   Default+ �� Source#+ Z* 5W     5X     5Y     � 5]     $��1��6   $
��Left=�5^      5_     4   .Files_Explorer.Views.BoolToVisibilityConverter ! BoolToVisibilityConverter��%   &	!         5`     66   5a     .+�5b     �� -   5        , ��Name$, FileOperationsPanel��5c     $
��Left=�5d     $
��10,0q�5e     y�5f     �� *	IsChecked+- �� 	Converter#- [! . �� ElementName$!. ToggleExpandCollapseSubMenu����5g     �� 5h     .R�5i     �� $ 
Horizontal=�5j  !   5k     .@�5n     4  .File_Explorer.CustomControls.SubMenuIconButton  $	��Cut��5o      " Cut/   Icon#/ [" 5p      # SubMenuIconButtonStyle#��[# 5q       5s     $	��Pin��5t      $ Pin#/ [$ 5u     #��[# 5v       5x     $
��Copy��5y      % Copy#/ [% 5z     #��[# 5{       5}     $��Paste��5~      	& Paste#/ [& 5     #��[# 5�       5�     $��Delete��5�      
' Delete#/ [' 5�     #��[# 5�       5�     $��Rename��5�      
( Rename#/ [( 5�     #��[# 5�       5�     $��	NewFolder��5�      ) 	NewFolder#/ [) 5�     #��[# 5�       5�     $��FileSettings��5�      * FileSettings#/ [* 5�     #��[# 5�     5�     5�     � 5�     $��3��5�     5�     5�     5�     5�     