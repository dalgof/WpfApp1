   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.ValidWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � SizeToContent$  WidthAndHeight=�5   	    � Title$ 
MainWindow��5	   	    � 	Resources 5
         WpfApp1.MyDataSource   Ods  ValidationTemplate  TextBoxInError �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value	 �� Self
 �� RelativeSource �� Path��%m  &	        &	      &	 �       5   
   6   �� 5   
   .R�5      ]� .+�5      �� 
���  ��$��20(�6-   !6>   �� 5      5      5      �� 5   
   " ��6'    5      P� 5       �@=�HasError$
 true��69   . �5      ��  �@�ToolTip 5      �� #
 Z	 $) #(Validation.Errors)[0].ErrorContent�5      5      5      .��5       �  � ColumnDefinitions 5!   
   �� 5"      �� 5#      �� 5$       � RowDefinitions 5&   
   �� 5'      �� 5(      �� 5)      �� 5*      �� 5+      .+�5.   
   �� $��0��5/      $��2��6   $��20(�50      $��8q�6   $H��BEnter a number between 21-130 or there will be a validation error:��51      �� 53   
   $��0��6   $��1��6    $��15(�6-   $��2q�6;    �� Target 54      ��  �� ElementName$ textBox1��.��64   1/TextBox with _custom ErrorTemplate and ToolTip:6e   �� 55   
   -   5        $��textBox1��55      $��50��6"   $��15(�6-    =� ErrorTemplate# [ 56      #��[ 57      $��1��58      $��1��6   $��2q�6+   .��66   ��59      �� 5:      $	 Age�6    �� Source# [  6%    �� UpdateSourceTrigger$ PropertyChanged=�5;       �� ValidationRules 5<         WpfApp1.AgeRangeRule  5=      
   Min$ 1��6-   
   Max$	 255��65   5?      .��5@      5A      �� 5C   
   $��2��6   $��0��6   $��15(�6-   $��2q�6;    5D      �� $ textBox2��.��60   &$TextBox with _default ErrorTemplate:6V   �� 5E   
   -   5        $��textBox2��5E      $��50��6"   $��15(�6-   $��2��5F      $��1��6   $��2q�6+   .��66   ��5G      �� 5H      $
 Age2�6   # [  6&   $ PropertyChanged=�5I       5J        5K      $ 1��6-   $	 255��65   5M      .��5N      5O      5f      5g      