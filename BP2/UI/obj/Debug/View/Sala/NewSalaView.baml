   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UI.View.SalaUI.View.Sala  5   	       UI.View.Sala.NewSalaView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:UI.View.Sala     5   	     � Title$
  Sala��5      $	��200��6   $	��330��6    � 
ResizeMode$ NoResize=�6)    � WindowStartupLocation$ CenterScreen=�6?    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Triggers
 P� Property P� Value �� Padding J� SnapsToDevicePixels ��Name��%  '��       '�� �    '�� �    �� 5
      " ��6
   .�5      ��  � �� �#2727276"   �� 5       � ��
 �����6"   �� 5       �@J�SnapsToDevicePixels . 6+   �� 5       � �� 5      �� 5      " ��6   .R�5      �� $ 10��6   #��z��6!   ._�5   	   �� #��z��6   $��Center=�6>   $��Center=�6[   $��0,0,0,0q�6v   5   	   	 5      P� 5   	   
 � {� .  . �5   
   ��  � �� �#7777776'   5   
   5      5      5      �� 5      " ��6
   .�5      ��  � �� �#4747476"   �� 5        � ��
 �����6"   �� 5!       �@J�SnapsToDevicePixels . 6+   �� 5"       � �� 5#      �� 5$      " ��6   .R�5%      �� #��z��6   #��z��5&   	   #��z��5'   	   # z��5(   	    . $ 15��5*   	   ._�5+   	   �� #��z��6   ��. # z 5,   )   #��z��5-      5.   	   5/      51      52      �� 53      " ��6
   .�54      ��  � ��
 �����6"   �� 55       � ��
 �����6"   �� 56       � �� 57      �� 58      " ��6   .R�59      �� #��z��5:   	   #��z��5;   	   # z��5<   	   $ 10��5=   	   ._�5>   	   �� $ PART_ContentHost��6%   $��10, 5q�6   6%   5?   	   5A      5C      5D      5E      .��5F      � 
�������.+�5G      ��  �� Orientation$ Vertical=�6   $��5, 10q�6&   .+�5H      �� $ 
Horizontal=�6   .+�5I      �� $��Broj sedišta��6   $��30��6#   $��90��6/   $��10, 5q�6:   $��14(�6I   $��center=�5J   	   $��center=�6+   �� 5K      $	��190��6   $��35��6   $��Center=�6&    �� MaxLines$ 1��6H   $��15(�5L      $��1��6^   ��6   �� *Sala.Broj_sedista+ �� UpdateSourceTrigger$ PropertyChanged=�6^   5M      �� 5O      $ 
Horizontal=�6   .+�5P      �� $��
Pozorište��6   $��30��6    $��90��6,   $��10, 5q�67   $��14(�6F   $��center=�5Q   	   $��center=�6+   �� 5R      $	��190��6   $��32��6   $��Center=�6'   $��15(�6B   $��2��6P   ��5S   	   �� *	Pozorista+ �� SelectedItem 6+   �� *SelectedPozoriste+{�5T   	   �� *IsNew+��5U      �� 5V      .R�5W   	   �� $ 
Horizontal=�6   .+�5X   
   �� ��6   ��  �� Path$ ID_Pozorista��� 5Y   
   $	�� - ��6   �� 5Z   
   ��6   �� $ Naziv�5[   
   5\   	   5^      5_      �� 5a      $��40��6   $��
Dodaj salu��6   $��18(�6-   $��10, 5q�6;    �� 	IsDefault . ��5b      �� *AddSalaCommand+y�5c      �� 5d      $ IsNew�6    �� 	Converter 5e      �� 5f   	   5h      5j      �� 5l      $��40��6   $��Izmeni salu��6   $��18(�6.   $��10, 5q�6<    . ��5m      �� *EditSalaCommand+y�5n      �� 5o      $ IsEdit�6    5p      �� 5q   	   5s      5u      5v      5w      5x      