   M S B A M L   `   `   `  ����E  ALogin Page, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Login_Page
Login_Page  5   	       Login_Page.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Login_Page     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � AllowsTransparency . 
������  � Title$ 
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��1.5* �6   .+�5   
   �� -   5        $��/Images/close.png��5      $��1��6+    K� ZIndex$ 1��6;      imgClose#��[  6d   �� 5   
    �� CornerRadius$ 
10 0 10 10��6   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      � 	 � Color$	 #3aa9ad��6#   
 � Offset$
 0Q�63   � 5      $	 #3aa9a1��6#   $
 0Q�63   5      ._�5      � .+�5      �� .+�5      �  � Points �    -1��� ;X�����#4eb1866:   � 5      ' �    �� �� ���� ��
�����#4eb1866?   A� 5      $��
50 400 0 0q�6   $��20��62   $��20��6=   ���#4eb1866I   5       �� 5"      $��Center=�6   .+�5#      �� $��Sign Up��6      	titleText#��[ 6/   �� 5$      $@��:Enter your personal info and create new account to join us��6      
normalText#��[ 6b    J� Opacity$	 0.8Q�6�   $��20 30q�6�   �� 5%      $��Sign Up��6    
 button#��[ 6/   5&      5'      5(      �� 5*   
   -   5        ���#ffffff$��1��5*   &   $ 	0 10 10 0��66   ._�5+      �� $��Center=�6   .+�5,      �� $��Sign in to App��6   #��[ 62   ���#3ab19b6V   �� 5.       �� Orientation$ 
Horizontal=�6   $
��0 20q�66   $��Center=�6D   .+�5/      ��   buttonCircle#��[ 6   .��50      �� $��/Images/google.png��6    $��20��6<   $��20��6G   51      �� 53      #��[ 6   .��54      �� $��/Images/facebook.png��6    $��20��6>   $��20��6I   55      �� 57      #��[ 6   .��58      �� $��/Images/linkedin.png��6    $��20��6>   $��20��6I   59      5:      �� 5<      $��or use your email info: ��6   #��[ 6<   ���#878787$��	0 10 0 15q�6u   �� 5>      $��1q�6   ���#acb0af$
��70 7q�6C   $ 5��6Q   ._�5?      � $	��7 9q�6    5@      �� 5A      $
��auto �6/   �� 5B      $��* �6/   .+�5E      �� $��/Images/Email.png��6    $��20��6;   �� 5F      -   5         ��Name$ 	textEmail��5F   $   $��Email��6W     textHint#��[ 6d   �� 5G      -   5        $��txtEmail��5G   "     textBox#��[ 6U   5H      5I      �� 5K      ���#ACB0AF$��1q�6/   $
��70 7q�6C   $ 5��6Q   ._�5L      � $	��7 9q�6    5M      �� 5N      $
��auto �6/   �� 5O      $��* �6/   .+�5R      �� $��/Images/Lock.png��6    $��20��6:   �� 5S      -   5        $ textPassword��5S   $   $��Password��6]   #��[ 6m   G� 5T      -   5         G�Name$ passwordBox��5T   &   #��[ 6i   5V      5W      �� 5Y      -   5        $��Sign In��5Y        
mainButton#��[ 6A   5[      5\      5]      5^      5_      