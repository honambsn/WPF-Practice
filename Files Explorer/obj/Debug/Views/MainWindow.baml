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
RootBorder��6)    �@��Padding$ 7q�6T   5�      5�      5�      5�      .��5�      �  5�   
   �� 5�      $	��280 �6   �� 5�      .+�5�   
   �  5�      �� 5�      $��* �6    �� 5�      $��95 �6    .+�5�      �� $��0��5�      $
��25,0q�5�      $
��Auto=�5�      $��Disabled=�5�      .��5�      ��  5�        NavFontBrush  DropShadowEffect  NavFolderDataTemplate7   1File_Explorer.CustomControls.DriveAndFolderButton)   Content* �� UpdateSourceTrigger+   Icon, �� ElementName-   UnPinCommand��%*  '��       7  7  &	 �     �� 5�      " ��6    .�5�      ��  � ��$ Center=�6B   �� 5�       � ��$
 Bold"�6;   �� 5�       � ��8   6;   �� 5�       �@J�Effect8  67   5�      �� 5�      .R�5�        $��0,5,0,0q�5�   !   ) 5�   !   �� *Name+$* PropertyChanged=�+ 5�   !   �� *
FileIcon+$* PropertyChanged=���5�   !   �� *!DataContext.GetFilesListCommand+$, 
mainWindow����5�   !   �� - 5�   !   �� *(&DataContext.UnPinFavoriteFolderCommand+$, 
mainWindow��5�      5�      5�      .+�5�      �� ��5�      �� 5�      " ��6$   . �� Triggers. 5�   "   �� 5�   &   / �� Binding/ 62   �� *FavoriteFolders.Count+$* PropertyChanged=�0 �� Value0 05�   O   .a�5�   *   ��  � y�$ 	Collapsed=�6G   5�   '   �� 5�   &   / 62   �� *FavoriteFolders.Count+$* PropertyChanged=�0 5�   O   Z� .a�5�   *   ��  � y�$ 	Collapsed=�6G   5�   '   5�      .+�5�      �� $��	Favorites��6$   �� 5�      #��[ 5�      $��0,0,0,17q�5�      ��5�      �� *FavoriteFolders+$* PropertyChanged=�5�      5�      �� 5�      $��Remote��5�      �� 5�      #��[ 6#   ��5�   #   �� *RemoteFolders+$* PropertyChanged=��� 5      $��	Libraries��6    $��0,17,0,0q�5      �� 5     #��[ 6#   ��5  #   �� *LibraryFolders+$* PropertyChanged=��� 5     $��Devices��6    $��0,17,0,0q�5      �� 5     #��[ 6#   ��5  #   �� *ConnectedDevices+$* PropertyChanged=�5	     5
     �� 5     $��1��5     $��0��5     .+�5       $
) User��5       User#+ [ 5     $
��10,5q�5     ��5     �� * OpenUserProfileSettingsCommand+  5     $) Settings��5       Settings#+ [ 5     $
��10,5q�5     ��5     �� *OpenSettingsCommand+5     5     � 5  
   $��1��5      $��10,0,0,0q�5!      5"     �� 5#     $��38 �6    �� 5%     $
��auto �6    �� 5'     $��50 �6    �� 5)     �� 5+     $
��auto �6    .+�50     �  51     �� 52     �� 53     $
��auto �6'   .+�56     �� $ 
Horizontal=�57     $
��Left=�58     $��Center=�59     .+�5:     	� -   5        1 	�Name$1 HomeTabButton��5;     $
��Home��5<     2 d� 	IsChecked$
2 TrueY�5=       MenuHeaderRadioButtonStyle#���  5>     	� 5@     -   5        $1 ViewTabButton��5A     $��Computer��5B     #���  5C     	� 5E     $
��View��5F     #���  5G     d� 5I     -   5        3 d�Name$!3 ToggleExpandCollapseSubMenu��5J     $��10(�5K      # ExpandCollapseToggleButtonStyle#���  5L     5M     �� 5P     $��1��5Q     $ 
Horizontal=�5R     $��Right=�5S     $��Center=�5T     .+�5U     �� -   5        4 ��Name$4 	SearchBox��5W     $
��12,0q�5V       SearchBoxStyle#���  5X     �� 5Z      	 Share#��[ 5[     $��20(�5\     $��44��5]       ButtonWithIconStyle#���  5^     d� 5`     -	   5        $��44��5a     $��15(�5c      " DarkLightModeToggleButtonStyle#���  5e     2 5b     �� *
DarkMode+5 �� Mode$5 TwoWay=�(  "Files_Explorer.Properties.Settings6   Default7 �� Source#7 Z6 5e     5f     5g     � 5k     $��1��6   $
��Left=�5l      5m     4   .Files_Explorer.Views.BoolToVisibilityConverter  BoolToVisibilityConverter��%   &	         5n     66   5o     .+�5p     �� -
   5        8 ��Name$8 FileOperationsPanel��5q     $
��Left=�5r     $
��10,0q�5s     y�5t     �� *	IsChecked+9 �� 	Converter#9 [ $!, ToggleExpandCollapseSubMenu����5u     �� 5v     .R�5w     �� $ 
Horizontal=�5x  !   5y     ��5|     �� 5}     .R�5~     4  .File_Explorer.CustomControls.SubMenuIconButton    SubMenuIconButtonStyle#��[ 5�  !   :   Icon: 5  !   �� *Icon+��5�  !   �� *Name+��5�  !   �� *)'DataContext.SubMenuFileOperationCommand+$, 
mainWindow����5�  !   �� 5�     ��5�     �� 5�     " ��6    .�5�     ��  � �� 6<   �� *HomeTabSubMenuCollection+$* PropertyChanged=�. 5�     �� 5�  "   / 6.   �� *	IsChecked+$, ViewTabButton��0 True5�  .   .a�5�  &   ��  � �� 6D   �� *ViewTabSubMenuCollection+$* PropertyChanged=�5�  #   5�     5�     5�     � 5�     $��2��5�     $��3,0,0,0q�5�      5�     �� 5�     $��50 �6'   �� 5�     $��50 �6'   �� 5�     $��50 �6'   �� 5�     $��* �6'   .+�5�     ��   Back#��[ 5�     $��16(�5�     $��Center=�5�     ��5�     �� *GoToPreviousDirectoryCommand+��5�     �� 5�     " ��6    ; �� BasedOn#; [ 5�      . 5�     �� 5�  "   / 6.   �� *	CanGoBack+$* PropertyChanged=�	0 False5�  .   .a�5�  &   ��  � {� .  6B   5�  #   5�     5�     �� 5�     $��1��5�       Forward#��[ 5�     $��16(�5�     $��Center=�5�     ��5�     �� *GoToFowardDirectoryCommand+��5�     �� 5�     " ��6    #; [ 5�  !   . 5�     �� 5�  "   / 6.   �� *CanGoFoward+$* PropertyChanged=�	0 False5�  -   .a�5�  &   ��  � {� .  6B   5�  #   5�     5�     �� 5�     $��2��5�       Up#��[ 5�     $��20(�5�     $��Center=�5�     ��5�     �� *GoToParentDirectoryCommand+��5�     �� 5�     " ��6    #; [ 5�  !   . 5�     �� 5�  "   / 6.   �� *IsAtRootDirectory+$* PropertyChanged=�0 True5�  .   .a�5�  &   ��  � {� .  6B   5�  #   5�     5�     �� 5�     -   5        $��
AddressBar��5�     $��3��5�     $��Stretch=�5�     $
��12,0q�5�       AddressBarTextBoxStyle#��[ 5�     ��5�     �� *CurrentDirectory+$* PropertyChanged=�.��5�  E   < J� InputBindings< 5�     �� 5�     
= �� Key$= Enter��6%   > �� Command> 5�  %   �� *NavigateToPathCommand+? �� CommandParameter? 5�  %   �� *Text+$, 
AddressBar��.��5�  -   5�     5�     �� 5�     -   5        @ ��Name$@ ListViewControl��5�     $��3��5�     
������ $��0,0,7,5q�5�     $��Disabled=�5�     $
��Auto=�5�     $��0q�5�     A �� SelectionMode$A Extended=�5�     B �� SelectedItemB 5�     �� $5 OneWay=���5�     �� *NavigatedFolderFiles+$* PropertyChanged=�*	  $Microsoft.Xaml.Behaviors.InteractionC 	  TriggersC 5�     +
  %Microsoft.Xaml.Behaviors.EventTrigger
  5�     D 
  	EventName$D SelectionChanged��6%   *  $Microsoft.Xaml.Behaviors.TriggerBaseE   Actions.E 5�     2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  F   CommandF 5�     �� *GetFilesListCommand+G   CommandParameterG 5      �� *SelectedItem+$, ListViewControl��5     
  5     $D MouseDoubleClick��6%   .E 5       F 5     �� *GetFilesSizeCommand+G 5     �� *SelectedItem+$, ListViewControl��5     5     ]� 5     $��4��6   $��25��5     ��.   5     ��%X   '��       �� 5     " ��6   .�5     ��  � �� �#20202067   5     5     .+�5     �� $
��Left=�5     $
��12,0q�5     $ 
Horizontal=�5     $��Center=�5     .+�5     �� �� 5     �6   �� *Items.Count+$, ListViewControl��$5 OneWay=�$* PropertyChanged=� �� 5     $�items��6    �� 5     $�|��6    �� 5     �6   �� *SelectedItems.Count+$, ListViewControl��$5 OneWay=�$* PropertyChanged=� �� 5     .�6   ��5      �� 5!  "   " ��6(   .�5"  )   ��  � �$ items selected��6@   . 5#  &   �� 5$  *   / 66   �� *SelectedItems.Count+$, ListViewControl��$5 OneWay=�$* PropertyChanged=�0 16�   .a�5%  .   ��  � �$ item selected��6E   5&  +   �� 5(  *   / 66   �� *SelectedItems.Count+$, ListViewControl��$5 OneWay=�$* PropertyChanged=�0 06�   .a�5)  .   ��  � �$ item selected��6E   5*  +   5,  #   .�5-  )   5.      �� 5/     �6   �� *SelectedFolderDetails+$* PropertyChanged=�50     51     �� 52     $��Right=�6   $
��12,0q�53     $��Center=�54     .+�55     �� $��999.9Gb��56     57     58     5;     5<     5=     