   M S B A M L   `   `   `  ���� =  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:UI.View.PozoristeUI.View.Pozoriste  %    UI.View.Pozoriste.PozoristeView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:UI.View.Pozoriste     |�.   J� InputBindings  �� 
 �� Key$	 F12�� �� Command �� *RefreshCommand+ � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers	 P� Property
 P� Value��%  '��       �� " ��.���  � ��
 ���� ��  � ��
 �������  � �� �� " ��.R��� #��z��
�������$��1q�._��� $��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ���  � ��
 � d �P� 	 � {�
 .  . ���  � ��
 �����.��� 
������  +� FocusedElement ��  �� ElementName$
 grid��.+���  �� Orientation$ 
Horizontal=�$��50��$
��Left=�$	��Top=�$��10, 0q�.+��� $��Dodaj pozorište��$��30��$	��120��$��14(����� *NewPozoristeCommand+�� $��10��$y�Hidden=��� $��Izmeni pozorište��$��30��$	��140��$��14(����� *UpdateManufacturerCommand+�� $��10��$y�Hidden=��� $��Obriši pozorište��$��30��$	��140��$��14(����� *DeleteManufacturerCommand+�� $��10��$y�Hidden=��� $��Osveži (F12)��$��30��$	��140��$��14(����� *RefreshCommand+&   System.Windows.Controls.DataGrid  -   $
��grid��$
��Left=�$	��290��$��	10,50,0,0q�$	��Top=�$	��645��$   HorizontalScrollBarVisibility$
 Auto=�   CanUserResizeColumns .     
IsReadOnly .    SelectionMode$ Single=�   CanUserReorderColumns .     CanUserResizeRows .     AutoGenerateColumns .     GridLinesVisibility$
 None=�   HeadersVisibility$ Column=����� *	Pozorista+ �� UpdateSourceTrigger$ PropertyChanged=���Z�  �� SelectedItem �� *SelectedManufacturer+$ PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ID_Pozorista+   ElementStyle �� " ��.���  � ��$ Center=���  �@��Padding$ 3q���  � ��$ 14(�  $ Ulica��$	 140  �� *Ulica+ �� " ��.���  � ��$ Center=���  � ��$ 14(�  $ Mesto��$	 140  �� *Mesto+ �� " ��.���  � ��$ Center=���  � ��$ 14(�  $ Naziv��$ *  �� *Naziv+ �� " ��.���  � ��$ Center=���  � ��$ 14(�