   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:UI.View.PredstavaUI.View.Predstava  5      %    UI.View.Predstava.PredstavaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:UI.View.Predstava     5        J� InputBindings  5	      �� 5
      
 �� Key$	 F12��6    �� Command 6   �� *RefreshCommand+ � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers	 P� Property
 P� Value��%�  '��       �� 5      " ��6
   .�5      ��  � ��
 ���� 6"   �� 5       � ��
 �����6"   �� 5       � �� 5      �� 5      " ��6   .R�5      �� #��z��6   
�������$��1q�6M   ._�5   	   �� $��Center=�6   $��Center=�67   5   	   5      5       5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  � ��
 � d �6$   5      P� 5      	 � {�
 .  . �5      ��  � ��
 �����6$   5      5!      5"      .��5#      � 
������  +� FocusedElement 6!   ��  �� ElementName$
 grid��.+�5$      ��  �� Orientation$ 
Horizontal=�6   $��50��6(   $
��Left=�64   $	��Top=�6O   $��10, 0q�6g   .+�5%      �� $��Dodaj predstavu��6   $��30��6&   $	��120��62   $��14(�6>   ��5&      �� *NewPredstavaCommand+�� 5'      $��10��6   $y�Hidden=�6   �� 5(      $��Izmeni predstavu��6   $��30��6'   $	��140��63   $��14(�6?   ��5)      �� *UpdatePredstavaCommand+�� 5*      $��10��6   $y�Hidden=�6   �� 5+      $��Obriši predstavu��6   $��30��6'   $	��140��63   $��14(�6?   ��5,      �� *DeletePredstavaCommand+�� 5-      $��10��6   $y�Hidden=�6   �� 5.      $��Osveži (F12)��6   $��30��6#   $	��140��6/   $��14(�6;   ��5/      �� *RefreshCommand+50      &   System.Windows.Controls.DataGrid  53      -   5        $
��grid��53      $
��Left=�6   $	��290��64   $��	10,50,0,0q�6A   $	��Top=�6T   $	��645��6l   $   HorizontalScrollBarVisibility$
 Auto=�54         CanUserResizeColumns .     
IsReadOnly .    SelectionMode$ Single=�6[      CanUserReorderColumns .     CanUserResizeRows .     AutoGenerateColumns .     GridLinesVisibility$
 None=�55   [      HeadersVisibility$ Column=�57      ��56      �� *	Predstave+ �� UpdateSourceTrigger$ PropertyChanged=���6N   Z�  �� SelectedItem 57   "   �� *SelectedPredstava+$ PropertyChanged=�  58      d� 59       d� Gesture$ LeftDoubleClicka�6    6-   �� *ShowPozoristaCommand+   Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *ID_Predstave+   ElementStyle 5>      �� 5?      " ��6   .�5@   	   ��  � ��$ Center=�6-   �� 5A   	    �@��Padding$ 3q�6#   �� 5B   	    � ��$ 14(�6$   5C   	   5E        5F      $ Naziv��6   $	 300 6C    6)   �� *Naziv+ 5G      �� 5H      " ��6   .�5I   	   ��  � ��$ Center=�6-   �� 5J   	    �@��Padding$ 3q�6#   �� 5K   	    � ��$ 14(�6$   5L   	   5N        5O      $ Trajanje��6   $ * 6H    6+   �� *
Trajanje+ 5P      �� 5Q      " ��6   .�5R   	   ��  � ��$ Center=�6-   �� 5S   	    �@��Padding$ 3q�6#   �� 5T   	    � ��$ 14(�6$   5U   	   5W      5[      5\      5]      