   M S B A M L   `   `   `  ����C  ?Discover, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DiscoverDiscover  5   	   A%clr-namespace:Discover.MVVM.ViewModelDiscover.MVVM.ViewModel  5   	       Discover.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Discover     5   	   ;	viewModel%clr-namespace:Discover.MVVM.ViewModel     5   	     � Title$  
MainWindow��5	   	   $	��600��6   $	��920��6)    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6   
������  � AllowsTransparency .  � Icon$% /Assets/icons8-discover-100.png��5   	    � DataContext 5      +  %Discover.MVVM.ViewModel.MainViewModel  5   
   .��5      �� ���#272537 �� CornerRadius$ 20��6"   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5       � RowDefinitions 5      �� 5      $��75 �6    �� 5      .+�5      �� $��Elysian��6   $��Center=�6'   $
��Left=�6B   
�������$��22(�6p   $��20 0 0 0q�6~   $��/Fonts/#Poppins)�6�   �� 5      $��1��6   .+�5       	� $
��Home��6   $��50��6-   
�������$��14(�6L      MenuButtonTheme#��[  6Z   	 d� 	IsChecked$
	 TrueY�6�   ��6�   �� *HomeViewCommand+	� 5"      $��	Discovery��6   $��50��62   
�������$��14(�6Q   #��[  6_   ��6�   �� *DiscoveryViewCommand+	� 5$      $��Featured��6   $��50��61   
�������$��14(�6P   #��[  6^   ��6�   �� *FeaturedViewCommand+� 5&      $	��365��6    5'      �� 5(      $	��310 �6(   �� 5)      $��* �6(   .+�5,      �� $��1��6!   .+�5-      	� $
��Exit��6&   $��50��65   
�������$��14(�6T   #��[  6b   $��0 5 0 0q�6�   ��6�   �� *ExitCommand+5.      5/      50      �� 52      $	��250��6   $��40��6"   $��Center=�6.   $
��Left=�6P   $��5q�6k   $��1��6v     MordernTextbox#��[ 6�   �� 54      $��1��6   $��1��55      $��
10 0 10 10q�56      ��57      �� *CurrentView+58      5;      5<      