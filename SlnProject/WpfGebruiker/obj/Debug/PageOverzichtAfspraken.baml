   M S B A M L   `   `   `  ����G  CWpfGebruiker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfGebruikerWpfGebruiker  5      )    #WpfGebruiker.PageOverzichtAfspraken   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:WpfGebruiker     5        N� Title$  PageOverzichtAfspraken��5	      .��5      � $��20,20q�6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      �� 5      .+�5   
   	� -   5         	�Name$ RadioAlleAfspraken��5      $��Alle afspraken��62   $
��Left=�6K   $��0,0,0,0q�6f   $��14(�6w    	� 	GroupName$ 	Afspraken��6�   6�   	� 5   
   -   5        $ RadioToekomstigeAfspraken��5      $��1��69   $!��Enkel toekomstige afspraken��6I   $
��Left=�6o   $��0,0,0,0q�6�   $	��Top=�6�   $��14(�6�   $ 	Afspraken��6�   6�   �� 5   
   -   5         ��Name$ ListBoxAfspraken��5      $��2��6,   $
��Left=�6@   $	��200��6[   $��0,10,0,0q�6h   $��1��6z   $��2��6�   $��Center=�6�   $	��370��6�   $��Visible=�6�   6�   �� 5   
   $��Reden van consultatie:��6   $
��Left=�61   $��0,5,0,0q�6L   $��3��6]   $	��Top=�6j   $��14(�6�   �� 5   
   -   5         ��Name$ lblRedenConsultatie��5      $��1��61   $
��Left=�6A   $��0,5,0,0q�6\   $��3��6m   $	��Top=�6z   $��14(�6�   $��Italic$�6�   $	��200��6�   �� 5   
   -   5         ��Name$ btnAnnuleren��5      $��	Annuleren��6'   $��2��6;   $
��Left=�6K   $��	20,0,0,10q�6f   $��1��6y   $��Bottom=�6�   $	��130��6�   $��36��6�   $
��Bold"�6�   $��14(�6�   6�   �� 5   
   -   5        $ btnNieuweAfspraak��5      $��Nieuwe afspraak��6,   $��2��6F   $
��Left=�6V   $��	20,10,0,0q�6q   $��2��6�   $	��Top=�6�   $	��130��6�   $��36��6�   $
��Bold"�6�   $��14(�6�   6�   5      5      