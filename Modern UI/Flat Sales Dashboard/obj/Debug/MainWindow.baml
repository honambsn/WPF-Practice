   M S B A M L   `   `   `  ����O  KFlat Sales Dashboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Flat_Sales_DashboardFlat_Sales_Dashboard  5   	   U/clr-namespace:Flat_Sales_Dashboard.UserControls!Flat_Sales_Dashboard.UserControls  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	   	   %    Flat_Sales_Dashboard.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   g cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   0local"clr-namespace:Flat_Sales_Dashboard   5   	   :uc/clr-namespace:Flat_Sales_Dashboard.UserControls   5   	   @lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf   5	   	     � Title$  
MainWindow��5   	   $	��780��6   $
��1280��6)    � AllowsTransparency .  � WindowStyle$
 None=�6P    � WindowStartupLocation$ CenterScreen=�5   	   
������  � 	Resources 5         BoolToVisConverter��%   &	        �� 5   
   6'   5      .��5      �� -   5         �� CornerRadius$ 25��5       �� Padding$ 20q�6   ���#f7f7f4._�5   
   �  � ColumnDefinitions 5      �� 5      $	��220 �6#   �� 5      $��* �6#   �� 5      $	��260 �6#    � RowDefinitions 5      �� 5      $	��120 �6    �� 5      $	��130 �6    �� 5      $��* �6    .+�5!      �� $��3��6   $ 25��6&   ��5"      �� 5#      .��5$      � 	 � Color$	 #fb7154��6'   
 � Offset$
 0Q�67   � 5%      $	 #fb7154��6'   $	
 0.8Q�67   5&      ._�5)      �� .+�5+      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��	0 30 0 10q�6W   .+�5,      � .+�5-      �� ���#ffffff$��35��6:   $��35��6E   $ 50��6Q   �� 5/      $��35��6%   $��35��60   ���#ffffff$��3q�6R   $ 50��6f    J� Effect 50   "   3  -System.Windows.Media.Effects.DropShadowEffect  51   &      
BlurRadius$ 10Q�67      Opacity$	 0.3Q�6G   ._�55   "   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ SendOutline=�68   $��15��6K   $��15��6V   ���#fb7154$��Center=�6w   $��Center=�6�   $��3 0 0 2q�6�    � LayoutTransform 56   &   �� 57   *    �� Angle$	 -45Q�6:   59   #   5;      5<      �� 5?      $
��Data��6$   ���#ffffff$��30(�6E   $��10 0 0 3q�6S    5@        5A   "   $ 10Q�63   $	 0.3Q�6C   5C      5D      �� 5H      $
��Main��6      	menuTitle#��[ 6,   �� 5J        
menuButton#��[ 6   ���#f7f6f4���#fb7657.��5K      �� $ 
Horizontal=�6%   .+�5L        $
 Home=�64     menuButtonIcon#��[ 6@   �� 5M      $��	Dashboard��6(     menuButtonText#��[ 69   5N      5O      �� 5Q      #��[ 6   .��5R      �� $ 
Horizontal=�6%   .+�5S        $ ClipboardTextPlayOutline=�64   #��[ 6T   �� 5T      $��Leaderboard��6(   #��[ 6;   5U      5V      �� 5X      #��[ 6   .��5Y      �� $ 
Horizontal=�6%   .+�5Z        $ ClipboardFileOutline=�64   #��[ 6P   �� 5[      $��Spredsheets��6(   #��[ 6;   5\      5]      �� 5_      #��[ 6   .��5`      �� $ 
Horizontal=�6%   .+�5a        $ AccountCheckOutline=�64   #��[ 6O   �� 5b      $��Administration��6(   #��[ 6>   5c      5d      �� 5f      #��[ 6   .��5g      �� $ 
Horizontal=�6%   .+�5h        $ BasketPlusOutline=�64   #��[ 6M   �� 5i      $��Sales��6(   #��[ 65   5j      5k      �� 5m      #��[ 6   .��5n      �� $ 
Horizontal=�6%   .+�5o        $ ProgressCheck=�64   #��[ 6I   �� 5p      $��Schedule��6(   #��[ 68   5q      5r      �� 5t      $
��Help��6    #��[ 6,   �� 5v      #��[ 6   .��5w      �� $ 
Horizontal=�6%   .+�5x        $ MessageSettingsOutline=�64   #��[ 6R   �� 5y      $��Messages��6(   #��[ 68   5z      5{      �� 5}      #��[ 6   .��5~      �� $ 
Horizontal=�6%   .+�5        $ 
CogOutline=�64   #��[ 6F   �� 5�      $��Settings��6(   #��[ 68   5�      5�      �� 5�      #��[ 6   .��5�      �� $ 
Horizontal=�6%   .+�5�        $ PhonePausedOutline=�64   #��[ 6N   �� 5�      $��Support��6(   #��[ 67   5�      5�      5�      5�      �� 5�      $��1��6   $��
20 0 20 20q�6&     whiteBorder#��[ 6:   ._�5�      � .+�5�      �� $ 
Horizontal=�6!   $
��Left=�6:   .+�5�      �� $��50��6!   $��50��6,   $ 10��68   $��5 0 20 0q�6J   ��5�      �� 5�   "   .��5�   &   � $	 #fb7456��63   $
 0Q�6C   � 5�   &   $	 #fa5654��63   $
 1Q�6C   5�   #   ._�5�      �� $��40��6$   $��40��6/   $��/Images/u4.png��6;   5�      �� 5�      $��Center=�6%   .+�5�      �� $��Hello, Team��6(   $��26(�6;   $
��Bold"�6I     	titleText#��[ 6[   �� 5�      $��Have A Nice Day��6(   ���#6c879a$��0 3 0 0q�6T   5�      5�      � 5�      $	��300��6   $��Right=�6'   .+�5�      �� $
��15 0q�6$   $��Center=�62   ���#868686 K� ZIndex$ 1��6b   $��Search here ...��6s    J� IsHitTestVisible .  y�6�   ��  �� ElementName$ textBoxSearch�� �� Path$ Text.Length� �� 	Converter# [  �� 5�      -   5         ��Name$ textBoxSearch��5�   "     searchTextBox#��[ 69     5�      $ Magnify=�60   $��15��6?   $��15��6J   ���#ff6d46$��0 0 15 0q�6k   $��Right=�6}   $��Center=�6�   5�      5�      5�      � 5�      $��1��6   $��1��6#   $
��10 0q�60    5�      �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   .+�5�      0   *Flat_Sales_Dashboard.UserControls.InfoCard  $��0��6      Title$ Sales��6.      SubTitle$% Compared To ($23456 Last Month)��6<      Amount$ 1��6g      Image$ /Images/sale.png��6r     5�      $��1��6   $ Purchase��6.   $$ Compared To ($1256 Last Month)��6?   $ 8��6i   $ /Images/purchase.png��6t     5�      $��2��6   $ Return��6.   $% Compared To ($73456 Last Month)��6=   $ 5��6h   $ /Images/return.png��6s   5�      �� 5�      $��1��6   $��2��6%   #��[ 62   $��
20 20 20 0q�6W   ._�5�      � $
��15 5q�6   .+�5�      �� $��Sales Figures��6    #��[ 65   /   )Flat_Sales_Dashboard.UserControls.Legends  5�      $��Right=�6!   $	��Top=�6=   $��0 8 10 0q�6U   #  LiveCharts.Wpf.CartesianChart  5�      $��1��6)   $��	5 40 0 60q�66   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 None=�6I      DataTooltip 5�      #  LiveCharts.Wpf.DefaultTooltip  5�      
���  �����#ffffff   
BulletSize$ 10Q�6W    J� Opacity$	 0.7Q�6g       AxisX  5�        LiveCharts.Wpf.Axis  !   
Foreground! �#90a3b2"   
ShowLabels" . #   	Separator# 5�   "   	  LiveCharts.Wpf.Separator	  5�   &   $ 	  StrokeThickness$$ 0Q�64   % 	  Step$% 2Q�6I   5�      &   AxisY& 5�        ! �#90a3b2" . '   MinValue$' 40Q�6N   (   MaxValue$	( 350Q�6\   # 5�   "   	  5�   &   $$ 0Q�64   5�      )   Series) 5�      
  LiveCharts.Wpf.LineSeries
    LiveCharts.Wpf.Series*   Fill
* ���� +   StrokeThickness$+ 3Q�6@   , 
  PointGeometrySize$, 0Q�6T   -   Values;  5LiveCharts.Wpf.Converters.NumericChartValuesConverter$,- &50,120,110,160,150,180,120,170,165,180 5�   -   .   Stroke. 5�   "   �� 5�   &   .��5�   *   � $	 #ffffff��67   $

 0.06Q�6G   � 5�   *   $	 #2889fc��67   $	
 0.5Q�6G   � 5�   *   $	 #ffffff��67   $

 0.93Q�6G   5�   '   5�      
  5�      
* ���� $+ 3Q�6@   $, 0Q�6T   $-- '170,240,200,220,220,270,200,260,220,240 5�   -   . 5�   "   �� 5�   &   .��5�   *   � $	 #ffffff��67   $

 0.06Q�6G   � 5�   *   $	 #fe6c47��67   $	
 0.5Q�6G   � 5�   *   $	 #ffffff��67   $	
 0.9Q�6G   5�   '   5�      5�      � 5�      $��Bottom=�6   $
��10 0q�66   .+�5�        $ Information=�60   ���#f966546C   �� 5�      $
��Wrap=�6$   $��30 0 0 0q�68   / �� 
LineHeight$/ 18��6J   ���#b7b7b7$����Net Sales, Found on the income statement are used to calculate this ration Return and refunds must be backed out of total sales to measure the truly measure the firms assets ability to generate sales.��5�   $   5�      5�      5�      � 5      $��2��6   $��3��6#    5     �� 5     $
��auto �6$   �� 5     $��* �6$   .+�5     �� #��[ 6   ._�5     �� .+�5	     �� $��
Sales List��6$   #��[ 66   �� 5
       secondaryText#��[ 6$   $
��Wrap=�6K   $
��0 10q�6_   $A��;This is the sales data with the most revenue for this month��5  $   0   *Flat_Sales_Dashboard.UserControls.UserCard  5     0   Title$0 Ho Nam��6&   1   IsActive1 . 2   UpPrice$2 8182$��6E   3   	DownPrice$
3 $337��6U   4   Image$4 /Images/u1.png��6f     5     $0 Nam Ho��6&   $2 1212$��65   $3 6423$��6E   $4 /Images/u3.png��6W     5     $0 Nam Nam��6&   $2 9192$��66   $3 8953$��6F   $4 /Images/u1.png��6X   5     5     �� 5     #��[ 6   $��0 20 0 0q�6>   $��1��6P   ._�5     � .+�5     �� $��Sales Report��6$   #��[ 68     5     $��1��6-   $��	0 40 0 30q�6:   $
 None=�6M    5       5  "   ���#0074ff���#ffffff$ .8Q�6_     5!  "     ! �#90a3b2" . # 5"  &   	  5#  *   $$ 0Q�68   $% 1Q�6L   5%  #   & 5)  "     ! �#90a3b2" . $' 0Q�6R   $( 8Q�6_   # 5*  &   	  5+  *   $$ 0Q�68   $% 2Q�6L   5-  #   ) 51  "   !  LiveCharts.Wpf.ColumnSeries  $- 	6.5,3,6,5 63   5   MaxColumnWidth$5 10Q�6F   * 52  &   �� 53  *   .��54  .   � $	 #2888fc��6;   $
 0Q�6K   � 55  .   $	 #ffffff��6;   $
 1Q�6K   56  +   58  #     5:  "   $- 7.5,5,4,5.5 63   $5 10Q�6H   * 5;  &   �� 5<  *   .��5=  .   � $	 #ff6f4d��6;   $
 0Q�6K   � 5>  .   $	 #ffffff��6;   $
 1Q�6K   5?  +   5A  #   5D       5G     $��Center=�6%   $��Bottom=�6B   5H     5J     5K     5L     5M     5N     