   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp1.BehaviorsWpfApp1.Behaviors  5	   	   A%clr-namespace:WpfApp1.ValidationRulesWpfApp1.ValidationRules  5   	   b ^Microsoft.VisualBasic.Core, Version=10.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aaGclr-namespace:Microsoft.VisualBasic;assembly=Microsoft.VisualBasic.CoreMicrosoft.VisualBasic 5   	       WpfApp1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   'bclr-namespace:WpfApp1.Behaviors  5	   	   -v%clr-namespace:WpfApp1.ValidationRules  5   	   Pi1Gclr-namespace:Microsoft.VisualBasic;assembly=Microsoft.VisualBasic.Core  5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   
������� � Icon$, &/WpfApp1;component/Resources/shape.ico��6L    � 	Resources 5         InputErrorStyle �� 
TargetType �� BasedOn �� Triggers ]� 
Conditions �� Property �� Value	 �� Property
 �� Value � DataContext �� RelativeSource��%w  &	        7���� 5   
   " ��6(   8    5      ]� 5       5      �� 5       �@=�HasError$
 True��6C   ./�5      �� 	 �@�ToolTip
 5      _� 5       6&   �� *PlacementTarget+ �� *Self+.��5   "   �� .+�5   &   �� ��60   �� *%#(Validation.Errors)[0].ErrorContent+5   #   5      5      5      5!      5"      .��5#      �  � RowDefinitions 5$   
   �� 5%      $	��57* �6   �� 5&      $��5* �6   .+�5*   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��2��6K   .+�5,      �� -   5        $��30��5,      $	��100��6"   
�������$��Center=�6A   $��Center=�6e   $��24(�6�   
�������$��2q�6�   $��5,0,0,0q�6�    �� 	MaxLength$ 3��6�     ValidationTemplate =� ErrorTemplate# [ 6�   .��6=  .  (System.Windows.Interactivity.Interaction   	Behaviors 5.      (  "WpfApp1.Behaviors.TextBoxMoveFocus  5/      2  ,WpfApp1.Behaviors.TextBoxMoveFocus_textinput  50      .��51   +   ��53      �� 54       �� Path$
 Num1�6    �� ValidationRules 55      2   ,WpfApp1.ValidationRules.NumberValidationRule  56         MinValue$ 1��65      MaxValue$	 255��6B   58      .��59       5;      �� 5=      
�������$��30��6/   $��24(�6;   $��.��6I   �� 5?      $��30��6   $	��100��6"   
�������$��Center=�6A   $��Center=�6e   $��24(�6�   
�������$��2q�6�   $ 3��6�   .��6�    5@        5A        5B      .��5C   +   5E      �� 5G      
�������$��30��6+   $��24(�67   $��.��6E   �� 5I      $��30��6   $	��100��6"   
�������$��Center=�6A   $��Center=�6e   $��24(�6�   
�������$��2q�6�   $ 3��6�   .��6�    5J        5K        5L      .��5N   +   5P      �� 5R      
�������$��30��6+   $��24(�67   $��.��6E   �� 5T      $��30��6   $	��100��6"   
�������$��Center=�6A   $��Center=�6e   $��24(�6�   
�������$��2q�6�   $��0,0,10,0q�6�   $ 3��6�   .��6�    5U        5V        5W      .��5Y   +   5[      5^      �� 5`   
   -   5        $��MainText��5`   l   
���/kU�$	��200��6.   $��30��6:   $��300,302,300,67q�6F   $��24(�6^   $|�False��6|   �� 5b   
   -   5        $��50��5b      $��350,367,0,17q�6   
���   �$��2��6Z   $
��Left=�6k   $	��100��6�   5c      5d      