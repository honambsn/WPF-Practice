   M S B A M L   `   `   `  ����I  EFiles Explorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Files_ExplorerFiles_Explorer  5   	   K*clr-namespace:File_Explorer.CustomControlsFile_Explorer.CustomControls  5   	   ;"clr-namespace:Files_Explorer.ViewsFiles_Explorer.Views  5   	   E'clr-namespace:Files_Explorer.PropertiesFiles_Explorer.Properties  5	   	   C&clr-namespace:Files_Explorer.ViewModelFiles_Explorer.ViewModel  5
   	   %    Files_Explorer.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Files_Explorer     5   	   9cc*clr-namespace:File_Explorer.CustomControls     5   	   4views"clr-namespace:Files_Explorer.Views     5   	   8prop'clr-namespace:Files_Explorer.Properties     5	   	   <	viewmodel&clr-namespace:Files_Explorer.ViewModel     5
   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5   	   -   5          �Name$  
mainWindow��5   	    � Title$ 
MainWindow��5   	   $	��782��5   	   $
��1235��6   $	��760��5   	   $	��864��6    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      (   "Files_Explorer.ViewModel.ViewModel  5   
   6     � 	Resources 5       
  Image0 �� 	UriSource 
 Image1 
 Image2 
 Image3 
 Image4 
 Image5��%D  &	        &	 ,     &	 X     &	 �     &	 �     &	 �     �� 5   
   $ ../Resources/0.jpg?�6%   �� 5   
   $ ../Resources/1.jpg?�6%   �� 5   
   $ ../Resources/2.jpg?�6%   �� 5   
   $ ../Resources/3.jpg?�6%   �� 5   
   $ ../Resources/4.jpg?�6%   �� 5   
   $ ../Resources/5.jpg?�6%   5      ��5!      �� 5"   
    �� 
TargetType" �6   .�5#      ��  �� Property �@�AllowsTransparency �� Value . 63   �� 5$       �@�ShowActivated . 6.   �� 5%       �@�WindowStyle$
 None=�6,   �� 5&       �@�UseLayoutRounding . 62   �� 5'      &   System.Windows.Media.TextOptions �@ TextFormattingMode$ Ideal=�6?   �� 5(       �@ TextRenderingMode$ 	ClearType=�6>   �� 5)      '  !System.Windows.Shell.WindowChrome �@ WindowChrome 5*        5+      	   CaptionHeight$	 32Q�5,      
   CornerRadius$
 0��5-         GlassFrameThickness$ 0q�5.         NonClientFrameEdges$
 None=�5/         ResizeBorderThickness$ 1q�50         UseAeroCaptionButtons .  51      53      �� 55       � �� 56      �� 57       �� 
TargetType" �6&   .R�58      ��  ��Name$ 
RootBorder��6!     InactiveWindowBrush#��[ 59   !   $��0q�5:   !   #��z��5;   !   ._�5<      �  � RowDefinitions 5=   "   �� 5>   &   $
��Auto �64   �� 5?   &   $��* �64    � ColumnDefinitions 5B   "   �� 5C   &   $	��280 �67   �� 5D   &   .+�5H   "   �  �Name$ TitleBarGrid��6'   $��0��5I   '   $��1��5J   '   $��32��5K   '   .+�5L   &   �� $��Title��60   $
��Left=�5M   0   $��Center=�5N   0   $
��30,0q�5O   0   #��z 5P   0     Window.TitleFontBrush#��[ 5Q   0   $
��Bold"�5R   0   �� 5U   &   $��Right=�61    �� Orientation$ 
Horizontal=�5V   1   .+�5W   *   ��  ��Name$ MinimizeButton��61   -   5        $	����5Y   1   $��Segoe MDL2 Assets)�5Z   1   $��11(�5[   1     WindowChromeButtonStyle#��[ 5\   1   �� 5]   *   $ MaximizeButton��61   -   5        $	����5_   1   $��Segoe MDL2 Assets)�5`   1   $��11(�5a   1    "	 WindowChromeRestoreButtonStyle#��[	 5b   1   �� 5c   *   $ CloseButton��61   -   5        $	����5e   1   $��Segoe MDL2 Assets)�5f   1   $��11(�5g   1     
 WindowChromeCloseButtonStyle#��[
 5h   1   5i   '   5j   #   � 5n   "   $��2��6'   $��0��5o   '   ��5q   &   �� 5r   *   
ImageBrush�� �� ImageSource$ ../Resources/0.jpg��5s   6    j� Stretch$ UniformToFill=�5t   6    j� 
AlignmentX$ Right=�5u   6   .+�5w   &   �� $��Border��6-   ��5x   *   �� 5y   .    �� Color$ 	#ff343f3d��5z   1    �� Opacity$	 .65Q�5{   1   5}   '   5~   #   � 5   "   $��2��5�   %   $��2��5�   %   .+�5�   &   �� .u�5�   *   �� 5�   '   5�   #   5�      5�       �� Triggers 5�      P� 5�       P� Property �@�IsActive P� Value .  . �5�   "   ��  �@J�Effect 5�   &   -  'System.Windows.Media.Effects.BlurEffect  5�   *      
KernelType$ Gaussian=�65      Radius$ 5Q�5�   5       RenderingBias$  Quality=�5�   5   5�   #   5�      :� 5�      ! :� RoutedEvent$! Loaded��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   T� " �� 
TargetName$" 
ImageBrush��5�   -   # �� TargetProperty$# ImageSource�5�   -   $ g� Duration$$ 0:0:35D�5�   -   % g� RepeatBehavior$% Forever��5�   -   ..�5�   .   i� & R� Value#& [  6E   ' R� KeyTime$' 0:0:5��5�   E   i� 5�   .   #& [ 6E   $' 0:0:10��5�   E   i� 5�   .   #& [ 6E   $' 0:0:15��5�   E   i� 5�   .   #& [ 6E   $' 0:0:20��5�   E   i� 5�   .   #& [ 6E   $' 0:0:25��5�   E   i� 5�   .   #& [ 6E   $' 0:0:30��5�   E   5�   +   5�   '   5�   #   5�      P� 5�       �@�WindowState$ 	Maximized=�6=   . �5�   "   �� ( �� 
TargetName$( 
RootBorder��6)    � ��
 ���� 6X   �� 5�   "   $( 
RootBorder��6)    �@��Padding$ 7q�6T   5�      �� 5�      ) �� Value$
) True��6p   * �� Binding* 6*   �� *
DarkMode+(  "Files_Explorer.Properties.Settings+   Default, �� Source#, Z+ .a�5�   "   ��  � �� �#2020206?   �� 5�   "   $( Title��6)    � �� �#ffffff6R   �� 5�   "   $( MinimizeButton��6)     MenuHeader.Static# [ 6[    � ���� 5�   "   $( CloseButton��6)   # [ 6X    � ��5�      5�      5�      5�      .��5�      �  5�   
   �� 5�      $	��280 �6   �� 5�      .+�5�   
   �  5�      �� 5�      $��* �6    �� 5�      $��95 �6    .+�5�      �� $��0��5�      $
��25,0q�5�      $
��Auto=�5�      $��Disabled=�5�      .��5�      ��  5�        NavFontBrush  DropShadowEffect  NavFolderDataTemplate7   1File_Explorer.CustomControls.DriveAndFolderButton-   Content. �� UpdateSourceTrigger/   Icon0 �� ElementName1   UnPinCommand��%*  '��       7  7  &	 �     �� 5�      " ��6    .�5�      ��  � ��$ Center=�6B   �� 5�       � ��$
 Bold"�6;   �� 5�       � ��8   6;   �� 5�       �@J�Effect8  67   5�      �� 5�      .R�5�        $��0,5,0,0q�5�   !   - 5�   !   �� *Name+$. PropertyChanged=�/ 5�   !   �� *
FileIcon+$. PropertyChanged=���5�   !   �� *!DataContext.GetFilesListCommand+$0 
mainWindow����5�   !   �� 1 5�   !   �� *(&DataContext.UnPinFavoriteFolderCommand+$0 
mainWindow��5�      5�      5�      .+�5�      �� ��5�      �� 5�      " ��6$   2 �� Triggers2 5�   "   �� 5�   &   * 62   �� *FavoriteFolders.Count+$. PropertyChanged=�) 05�   O   .a�5�   *   ��  � y�$ 	Collapsed=�6G   5�   '   �� 5�   &   * 62   �� *FavoriteFolders.Count+$. PropertyChanged=�) 5�   O   Z� .a�5�   *   ��  � y�$ 	Collapsed=�6G   5�   '   5�      .+�5�      �� $��	Favorites��6$   �� 5�      #��[ 5�      $��0,0,0,17q�5�      ��5�      �� *FavoriteFolders+$. PropertyChanged=�5�      5�      �� 5      $��Remote��5     �� 5     #��[ 6#   ��5  #   �� *RemoteFolders+$. PropertyChanged=��� 5     $��	Libraries��6    $��0,17,0,0q�5      �� 5	     #��[ 6#   ��5
  #   �� *LibraryFolders+$. PropertyChanged=��� 5     $��Devices��6    $��0,17,0,0q�5      �� 5     #��[ 6#   ��5  #   �� *ConnectedDevices+$. PropertyChanged=�5     5     �� 5     $��1��5     $��0��5     .+�5       $
- User��5       User#/ [ 5     $
��10,5q�5     ��5     �� * OpenUserProfileSettingsCommand+  5     $- Settings��5       Settings#/ [ 5     $
��10,5q�5     ��5      �� *OpenSettingsCommand+5!     5"     � 5&  
   $��1��5'     $��10,0,0,0q�5(      5)     �� 5*     $��38 �6    �� 5,     $
��auto �6    �� 5.     $��50 �6    �� 50     �� 52     $
��auto �6    .+�57     �  58     �� 59     �� 5:     $
��auto �6'   .+�5=     �� $ 
Horizontal=�5>     $
��Left=�5?     $��Center=�5@     .+�5A     	� -   5        3 	�Name$3 HomeTabButton��5B     $
��Home��5C     4 d� 	IsChecked$
4 TrueY�5D       MenuHeaderRadioButtonStyle#���  5E     	� 5G     -   5        $3 ViewTabButton��5H     $��Computer��5I     #���  5J     	� 5L     $
��View��5M     #���  5N     d� 5P     -   5        5 d�Name$!5 ToggleExpandCollapseSubMenu��5Q     $��10(�5R      # ExpandCollapseToggleButtonStyle#���  5S     5T     �� 5W     $��1��5X     $ 
Horizontal=�5Y     $��Right=�5Z     $��Center=�5[     .+�5\     �� -   5        6 ��Name$6 	SearchBox��5^     $
��12,0q�5]       SearchBoxStyle#���  5_     .��6B   7 J� InputBindings7 5`     �� 5a     
8 �� Key$8 Escape��5b  !   9 �� Command9 5c  !   �� *!CancelSearchFileOrFolderCommand+.��5d  1   5e     �� 5g      	 Share#��[ 5h     $��20(�5i     $��44��5j       ButtonWithIconStyle#���  5k     d� 5m     -	   5        $��44��5n     $��15(�5p      " DarkLightModeToggleButtonStyle#���  5r     4 5o     �� *
DarkMode+: �� Mode$: TwoWay=�#, Z+ 5r     5s     5t     � 5x     $��1��6   $
��Left=�5y      5z     4   .Files_Explorer.Views.BoolToVisibilityConverter  BoolToVisibilityConverter��%   &	         5{     66   5|     .+�5}     �� -
   5        ; ��Name$; FileOperationsPanel��5~     $
��Left=�5     $
��10,0q�5�     y�5�     �� *	IsChecked+< �� 	Converter#< [ $!0 ToggleExpandCollapseSubMenu����5�     �� 5�     .R�5�     �� $ 
Horizontal=�5�  !   5�     ��5�     �� 5�     .R�5�     4  .File_Explorer.CustomControls.SubMenuIconButton    SubMenuIconButtonStyle#��[ 5�  !   =   Icon= 5�  !   �� *Icon+��5�  !   �� *Name+��5�  !   �� *)'DataContext.SubMenuFileOperationCommand+$0 
mainWindow����5�  !   �� 5�     ��5�     �� 5�     " ��6    .�5�     ��  � �� 6<   �� *HomeTabSubMenuCollection+$. PropertyChanged=�2 5�     �� 5�  "   * 6.   �� *	IsChecked+$0 ViewTabButton��) True5�  .   .a�5�  &   ��  � �� 6D   �� *ViewTabSubMenuCollection+$. PropertyChanged=�5�  #   5�     5�     5�     � 5�     $��2��5�     $��3,0,0,0q�5�      5�     �� 5�     $��50 �6'   �� 5�     $��50 �6'   �� 5�     $��50 �6'   �� 5�     $��* �6'   .+�5�     ��   Back#��[ 5�     $��16(�5�     $��Center=�5�     ��5�     �� *GoToPreviousDirectoryCommand+��5�     �� 5�     " ��6    > �� BasedOn#> [ 5�      2 5�     �� 5�  "   * 6.   �� *	CanGoBack+$. PropertyChanged=�	) False5�  .   .a�5�  &   ��  � {� .  6B   5�  #   5�     5�     �� 5�     $��1��5�       Forward#��[ 5�     $��16(�5�     $��Center=�5�     ��5�     �� *GoToFowardDirectoryCommand+��5�     �� 5�     " ��6    #> [ 5�  !   2 5�     �� 5�  "   * 6.   �� *CanGoFoward+$. PropertyChanged=�	) False5�  -   .a�5�  &   ��  � {� .  6B   5�  #   5�     5�     �� 5�     $��2��5�       Up#��[ 5�     $��20(�5�     $��Center=�5�     ��5�     �� *GoToParentDirectoryCommand+��5�     �� 5�     " ��6    #> [ 5�  !   2 5�     �� 5�  "   * 6.   �� *IsAtRootDirectory+$. PropertyChanged=�) True5�  .   .a�5�  &   ��  � {� .  6B   5�  #   5�     5�     �� 5�     -   5        $��
AddressBar��5�     $��3��5�     $��Stretch=�5�     $
��12,0q�5�       AddressBarTextBoxStyle#��[ 5�     ��5�     �� *CurrentDirectory+$. PropertyChanged=�.��5�  E   7 5�     �� 5�     $8 Enter��6%   9 5�  %   �� *NavigateToPathCommand+? �� CommandParameter? 5�  %   �� *Text+$0 
AddressBar��.��5�  -   5�     5�     �� 5�     -   5        @ ��Name$@ ListViewControl��5�     $��3��5�     
������ $��0,0,7,5q�5     $��Disabled=�5     $
��Auto=�5     $��0q�5     A �� SelectionMode$A Extended=�5       TileViewItemStlye#��[ 5     B �� SelectedItemB 5     �� $: OneWay=���5     �� *NavigatedFolderFiles+$. PropertyChanged=�*	  $Microsoft.Xaml.Behaviors.InteractionC 	  TriggersC 5	     +
  %Microsoft.Xaml.Behaviors.EventTrigger
  5     D 
  	EventName$D SelectionChanged��6%   *  $Microsoft.Xaml.Behaviors.TriggerBaseE   Actions.E 5     2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  F   CommandF 5     �� *GetFilesListCommand+G   CommandParameterG 5     �� *SelectedItem+$0 ListViewControl��5     
  5     $D MouseDoubleClick��6%   .E 5       F 5     �� *GetFilesSizeCommand+G 5     �� *SelectedItem+$0 ListViewControl��5     5     ]� 5     $��4��6   $��25��5     ��.   5     ��%�   '��       7  �� 5     " ��6   .�5     ��  � �� �#20202067   2 5      �� 5!     * 6*   �� *
DarkMode+#, Z+ ) True5"  *   .a�5#  "   ��  � ��8   5$  )   5%     5'     5(     .+�5*     �� $
��Left=�5+     $
��12,0q�5,     $ 
Horizontal=�5-     $��Center=�5.     .+�5/     �� �� 50     �6   �� *Items.Count+$0 ListViewControl��$: OneWay=�$. PropertyChanged=� �� 51     $�items��6    �� 52     $�|��6    �� 53     �6   �� *SelectedItems.Count+$0 ListViewControl��$: OneWay=�$. PropertyChanged=� �� 54     .�6   ��55     �� 56  "   " ��6(   .�57  )   ��  � �$ items selected��6@   2 58  &   �� 59  *   * 66   �� *SelectedItems.Count+$0 ListViewControl��$: OneWay=�$. PropertyChanged=�) 16�   .a�5:  .   ��  � �$ item selected��6E   5;  +   �� 5=  *   * 66   �� *SelectedItems.Count+$0 ListViewControl��$: OneWay=�$. PropertyChanged=�) 06�   .a�5>  .   ��  � �$ item selected��6E   5?  +   5A  #   .�5B  )   5C      �� 5D     �6   �� *SelectedFolderDetails+$. PropertyChanged=�5E     5F     �� 5G     $��Right=�6   $
��12,0q�5H     $��Center=�5I     .+�5J     �� �� 5K     $�Total Disk Space:��6    �� 5L     �6   �� *	DriveSize+$. PropertyChanged=�5M     5N     5O     5R     5S     5T     