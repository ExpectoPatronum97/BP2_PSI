   M S B A M L   `   `   `  ���� =  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI      UI.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     "localclr-namespace:UI       � Title$	  BP2��$	��450��$	��730�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� J� InputBindings �� 
 �� Key$ F1�� �� CommandParameter$ 	Pozorista�� �� Command �� *NavigationCommand+�� $ F2��$ 	Predstave�� �� *NavigationCommand+�� $ F3��$
 Sale�� �� *NavigationCommand+�� $ F4��$ Karte�� �� *NavigationCommand+�� $ F5��$ Glumci�� �� *NavigationCommand+�� $ F6��$ 
Scenaristi�� �� *NavigationCommand+�� $ F7��$ Gledaoci�� �� *NavigationCommand+�� $ F8��$ Loyalty�� �� *NavigationCommand+ � 	Resources    BlackButton �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value��%P  &	        �� " ��.��� 	 � ��
 �#272727�� 	 � ��

 ������� 	 �@J�SnapsToDevicePixels
 . �� 	 � ��
 �� " ��.R��� $ 10��#��z��._��� #��z��$��Center=�$��Center=�$��0,-4,0,0q� P�  � {� .  . ��� 	 � ��
 �#777777P�  �@J�IsMouseOver . . ��� 	 � ��

 �����.��� 
���OO/� � RowDefinitions �� $��35 ��� $��35 ��� $
��Auto �.+�� $��0��
�����p�.+�o� $��30��$��Center=�$
��Left=�$��3q�
������ 
�������.@�m� $��Pozorišta (F1)��$��15(� m� CommandParameter$ 	Pozorista�� m� Command �� *NavigationCommand+�� $��10��m� $��Predstave (F2)��$��15(�$ 	Predstave�� �� *NavigationCommand+�� $��10��m� $��	Sale (F3)��$��15(�$
 Sale�� �� *NavigationCommand+�� $��10��m� $��
Karte (F4)��$��15(�$ Karte�� �� *NavigationCommand+m� $��Glumci (F5)��$��15(�$ Glumci�� �� *NavigationCommand+�� $��10��� $��1��
�����p�.+�o� $��30��$��Center=�$
��Left=�$��3q�
������ 
�������.@�m� $��Scenaristi (F6)��$��15(�$ 
Scenaristi�� �� *NavigationCommand+�� $��10��m� $��Gledaoci (F7)��$��15(�$ Gledaoci�� �� *NavigationCommand+�� $��10��m� $��Loyalty članovi (F8)��$��15(�$ Loyalty�� �� *NavigationCommand+�� $��10��� $��2��$��5q�.+��� |�. ���� *CurrentViewModel+