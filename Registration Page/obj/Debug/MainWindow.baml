   M S B A M L   `   `   `  ����L  HRegistration Page, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Registration_Page.UserControlsRegistration_Page.UserControls  5   	   "    Registration_Page.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   5uc,clr-namespace:Registration_Page.UserControls  5   	     � Title$  
MainWindow��5	   	   $	��650��6   $
��1000��6)   
������  � WindowStyle$
 None=�6O    � WindowStartupLocation$ CenterScreen=�5
   	    � AllowsTransparency . .��5      �  � ColumnDefinitions 5   
   �� 5      $	��350 �6   �� 5      $��* �6   .+�5   
   �� ���#ffd500 �� Padding$ 30q�6&    �� CornerRadius$ 	25 0 0 25��63   ._�5      �� $��Center=�6   .+�5      �� $��/Images/img.png��6   $	��160��61   $	��160��6=   $��0 0 0 40q�6J   �� 5      $��Let's get you sign up��6    �� TextAlignment$ Center=�69   $��SemiBold"�6P   $��28(�6f   ���#3636366t   �� 5      $
��Wrap=�6   $��16(�60   $ Center=�6>   ���#363636$��	0 20 0 20q�6j   $E��?it should only take a couple of minutes to pair with your watch��6}   �� 5         buttonBlack#��[  6   .��5      "  FontAwesome.WPF.ImageAwesome     Icon$ 
AngleRight=�6&   $��25��68   $��25��6C   	   
Foreground	 �#ffd500$��3 0 0 0q�6d   5      5      5      �� 5!   
   -   5        $��1��5!      $ 20q�6!   ���#ffffff$ 	0 25 25 0��6C   ._�5"      � .+�5#      �� $��/Images/close.png��6   $��25��63   $��0 4 5 0q�6>     iconApp#��[ 6O   �� 5$      $��/Images/minimize.png��6   $��20��66   $��0 7 40 0q�6A   #��[ 6S   � 5&      $��Center=�6   $��Center=�64   $��0 10 0 0q�6O    5'      �� 5(      $	��150 �6+   �� 5)      $��* �6+   
 � RowDefinitions
 5,      �� 5-      $
��auto �6(   �� 5.      $
��auto �6(   �� 5/      $
��auto �6(   �� 50      $
��auto �6(   �� 51      $
��auto �6(   �� 52      $
��auto �6(   �� 53      $
��auto �6(   �� 54      $
��auto �6(   .+�57      �� $��0��6    $
��Name��6-     text#��[ 69   �� 58      $��1��6    $��Family��6-   #��[ 6;   �� 59      $��2��6    $��Gender��6-   #��[ 6;   �� 5:      $��3��6    $��Date of Birth��6-   #��[ 6B   �� 5;      $��4��6    $��Email��6-   #��[ 6:   �� 5<      $��5��6    $��Mobile��6-   #��[ 6;   �� 5=      $��6��6    $��
Membership��6-   #��[ 6?   .   (Registration_Page.UserControls.MyTextBox  5?      $��1��6#   $��0��63      Hint$ Karim��6@     5@      $��1��6#   $��1��63   $	 Hoo��6@     5B      $��1��6#   $��3��63   $ 
01/02/2000��6@     5C      $��1��6#   $��4��63   $ test@mail.com��6@     5D      $��1��6#   $��5��63   $ +123456��6@   �� 5F       �� Orientation$ 
Horizontal=�6!   $��1��6:   $��2��6J   $��0 10 q�6W   .+�5G      -   'Registration_Page.UserControls.MyOption     Icon$
 Male=�6&      Text$
 Male��62     5H      $ Female=�6&   $ Female��64   5I      �� 5K      $ 
Horizontal=�6!   $��1��6:   $��6��6J   $��0 10 q�6W   .+�5L        $ 
CreditCard=�6&   $ Classic��68     5M      $ 
CreditCard=�6&   $ Silver��68     5N      $ 
CreditCard=�6&   $
 Gold��68   5O      � 5Q      $��1��6   $��7��6+   $��0 40 0 0q�68    5R      �� 5S      $��* �6/   �� 5T      $��* �6/   .+�5W      �� $��Cancel��6!   $��0 0 10 0q�62     
buttonMain#��[ 6D   �� 5X      $
��Save��6!   $��10 0 0 0q�60   $��1��6B     buttonMainGreen#��[ 6R   5Y      5Z      5[      5\      5^      5_      