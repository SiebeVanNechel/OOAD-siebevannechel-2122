   M S B A M L   `   `   `  ����D  @WpfDokter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfDokter	WpfDokter  5   	       WpfDokter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfDokter     5   	     � Title$  
MainWindow��5   	   $	��550��6   $	��600��6)   .��5	      � .+�5
   
   �� .@�5      �� $��Mijn agenda��6   $	��140��6+   $
��Bold"�67   $��14(�6I   .��5      � $��20,20q�6    � ColumnDefinitions 5      �� 5      $
��auto �6+   �� 5       � RowDefinitions 5      �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      .+�5      �� $��Kies een datum: ��6   $
��Left=�67   $��Normal"�6R   &   System.Windows.Controls.Calendar  5      -   5          Name$ Calendar��5      $��1��61   $	��175��6>   $	��210��6K   $
��Left=�6W   6r   �� 5      -   5         ��Name$ lblAfsprakenVoor��5      $��Afspraken voor ��66   $��2��6P   $
��Left=�6]   $��Normal"�6x   �� 5      -   5         ��Name$ ListBoxDagAfspraken��5      $
��Left=�6;   $	��100��6V   $��3��6c   $	��350��6p   $��Normal"�6|   $��Visible=�6�   6�   �� 5      -   5         ��Name$ btnAnnuleren��5      $��	Annuleren��63   $��10,0,0,0q�6G   $��3��6Y   $��1��6f   $
��Left=�6v   $	��Top=�6�   $	��158��6�   $��36��6�   $
��Bold"�6�   $��14(�6�   6�   �� 5      $��Reden van consultatie:��6   $
��Left=�6=   $��4��6X   $	��Top=�6e   $��14(�6}   $��Normal"�6�   �� 5      -   5        $ lblRedenConsultatie��5      $�� ��69   $
��Left=�6E   $��	160,0,0,0q�6`   $��4��6s   $	��Top=�6�   $��14(�6�   $��Normal"�6�   $��Italic$�6�   5      5       �� 5!      $��
Patiënten��6   $	��140��6)   $
��Bold"�65   $��14(�6G   .��5"       � -   5          �Name$ frmMain��5"        � Source$" PageOverzichtPatiënten.xaml?�6)   $	��550��6N   $��5q�6[   $��Stretch=�6f   $	��Top=�6�   
�������	  � NavigationUIVisibility$	 Hidden=�6�   6�   5#      5$      5%      5&      