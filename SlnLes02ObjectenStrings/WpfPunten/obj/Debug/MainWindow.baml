   M S B A M L   `   `   `  ����D  @WpfPunten, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfPunten	WpfPunten  5   	       WpfPunten.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfPunten     5   	     � Title$  Punten��5   	   $	��450��6   $	��455��6%   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��369* �6   �� 5      $	��52* �6   .+�5   
   �� $��Naam:��6   $
��Left=�6    $��	16,27,0,0q�6;   $	��Top=�6N   $��14(�6f   �� 5   
   $��Punt (op 100):��6   $
��Left=�6)   $��	16,58,0,0q�6D   $	��Top=�6W   $��14(�6o   �� 5   
   -   5         ��Name$ txtNaam��5      $
��Left=�6#   $��23��6>   $��
138,33,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   6�   �� 5   
   -   5        $ txtPunt��5      $
��Left=�6#   $��23��6>   $��
138,64,0,0q�6J   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   6�   �� 5   
   -   5         ��Name$ btnToevoegen��5      $��	Toevoegen��6'   $
��Left=�6;   $��
276,32,0,0q�6V   $	��Top=�6j   $	��145��6�   $��55��6�   $��14(�6�   {�.  6�   �� 5   
   $��
Filter op:��6   $
��Left=�6%   $��
16,115,0,0q�6@   $	��Top=�6T   $��14(�6l   �� 5   
   -   5        $ 	txtFilter��5      $
��Left=�6%   $��23��6@   $��
85,121,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��336��6�   6�   �� 5   
   -   5         ��Name$ ListBoxPunten��5      $
��Left=�6)   $	��198��6D   $��
16,171,0,0q�6Q   $	��Top=�6e   $	��405��6}   6�   �� 5   
   -   5        $ btnVerwijder��5      $��	Verwijder��6'   $
��Left=�6;   $��16,5,0,0q�6V   $��1��6h   $	��Top=�6u   $	��405��6�   $��14(�6�   {�.  6�   5      5      