   M S B A M L   `   `   `  ����C  ?WpfApp17, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfApp17WpfApp17  5   	       WpfApp17.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfApp17     5   	     � Title$  
MainWindow��5   	   $��Stretch=�6   $��Stretch=�68    � 	Resources 5
       �� 
TargetType   btnTemplate �� Triggers P� Property P� Value �� Property �� Value �� Color  
triggerBtn	 �� 
TargetType
 �� Triggers��%w  &	        &	 �     �� 5   
   " ��6    5      P� 5       � �� . . �5      ��  � �� 5      �� 5      $ GreenYellow��6.   5      5      5      �� 5   
   "	 ��6#   .�5      ��  � ��
 �/���6+   
 5      P� 5       �@J�IsStylusDirectlyOver . . �5      ��  � ��
 � � �63   5      5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $
��0.4* �6   �� 5#      $
��3.6* �6   .+�5%   
   �� $��0��6   $��Stretch=�6"   ���	#FFB2B6DE.+�5&      �  � ColumnDefinitions 5'      �� 5(      $��* �6'   �� 5)      $��* �6'   �� 5*      $��* �6'   .+�5,      �� $	��200��6   $	��160��6$   $a��[C:/Users/Chetan.Parmar/Desktop/testinformation/LineManagerInterface/Resources/cassioli1.png��62   $
��Left=�6�   $	��Top=�6�   $��0��6�   �� 5-      -   5         ��Name$ titleTxt��5-      $��ConnectedApp��6,   $��1��6@   $
��Bold"�6P   
�������$��40(�6w   ���	#FFB2B6DE$��0q�6�   $��Center=�6�   $��0,5,0,0q�6�   5.      50      �� 51   
   -   5         ��Name$ 
loginPanel��51      $��1��6)   $��Stretch=�66   
�������.+�52      �� -   5        $ usernameTxt��52      $�� ��6+   $��Center=�63   $��50��6N   $	��300��6Z   $��	0,300,0,0q�6f   $��Center=�6y   $��Center=�6�   $��18(�6�   $��Gentium Book Basic)�6�   $
��Bold"�6�   �� 53      -   5        $ passwordTxt��53      $�� ��6+   $
��Bold"�63   $��Center=�6E   $��50��6`   $	��300��6l   $��	0,20,0,10q�6x   $��Center=�6�   $��Center=�6�   $��18(�6�   $��Gentium Book Basic)�6�   �� 54      -   5         ��Name$ focus��54      $��Login��6$   $��50��65   $��75��6A   $
��Bold"�6L   ���	#FF7BE6A2���	#FF7BE6A2$��Center=�6�   $��0,20,0,0q�6�   $��Center=�6�   $��Center=�6�   $��16(�6  $��Gentium Book Basic)�6#   J� RenderTransformOrigin$ 0.5,0.5&�6C  z�55      V� 56      .~�57      �� �� 58      �� 59      T� 5:       T� X$ 10Q�6-   T� 5;       T� Y$ 10Q�6-   5<       J� Effect 5>      3  -System.Windows.Media.Effects.DropShadowEffect  5?         Color$ 	#FFC9C9C9��6'   5A      5B      �� 5D   
   -   5        $ resPanel��5D      $��Stretch=�6'   $��Stretch=�6E   $y�Hidden=�6a   $��1��6u   .+�5E      �� -   5         ��Name$ responseTxt��5E      $
��Bold"�6-   $��Stretch=�6@   $��Stretch=�6\   6|   5F      5H      5I      