   M S B A M L   `   `   `  ����D  @Design TV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Design_TV.PagesDesign_TV.Pages  5   	       Design_TV.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   g cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   *Pageclr-namespace:Design_TV.Pages   5   	   $	��720��5   	   $
��1280��6   $	��650��6#   $	��700��62     � AllowsTransparency  .  � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.   
������  � Icon$ /Assets/Icon.ico��5   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6      ResizeBorderThickness$ 5q�6)   .��5      �� -   5         �� CornerRadius$ 5��5      ��5   
   �� 5       �� 
StartPoint$ 0.5,0&�6"   	 �� EndPoint$	 0.5,1&�65   .��5      � 
 � Color$
 #2e3967��6   � 5      $
 #192559��6    � Offset$	 1.0Q�6/   5      ._�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6    .+�5#      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��	0 15 15 0q�6N   .+�5$      �� -   5         ��Name$ timeTextBlock��5$      $��05:34��63   ���#fdf9f6$��28(�6U   $��Center=�6c   �� 5&      $
��13 0q�6   $��Center=�6+   .+�5'      �� -   5        $ dateTextBlock��5'       ���#f8fefa$��10(�6L   �� 5(      -   5        $ dayTextBlock��5(       ���#f8fefa$��10(�6K   5)      .  (MahApps.Metro.IconPacks.PackIconMaterial  5+         Kind$
 Wifi=�6(   ���#fdf9f6$��25��6I   $��25��6T   $��Center=�6`   5,      �� 5/      -   5         ��Name$ 
backButton��5/         
backButton#��[  6B   .��50        $ 	ArrowLeft=�6(   $��25��69   $��25��6D   51      �� 54      -   5        $��	titleText��54   (   $��Settings��6     	pageTitle#��[ 69   �� 57      -   5         ��Name$ 	container��57      $��2��62   ��58      "   Design_TV.Pages.Setting_Page  59      5;      5<      5=      5>      