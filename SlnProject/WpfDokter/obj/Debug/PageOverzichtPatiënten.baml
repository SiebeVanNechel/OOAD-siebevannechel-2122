   M S B A M L   `   `   `  ����D  @WpfDokter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfDokter	WpfDokter  5      '    !WpfDokter.PageOverzichtPatiënten   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:WpfDokter     5        N� Title$  PageOverzichtPatiënten��5	      .��5      � -   5        $��20,20q�5       � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   �� 5      .+�5   
   �� $��Zoeken: ��6   $��Center=�6#   $
��Left=�6>   $��Normal"�6Y   $��14(�6m   �� 5   
   -   5         ��Name$ txtPatientZoeken��5      $
��Left=�6,   $��Center=�6G   $��23��6b   $��60,0,0,0q�6n   $	��200��6�   $��14(�6�   �� 5   
   -   5         ��Name$ btnPatientZoeken��5      $��Zoeken��6+   $��1��6<   $
��Left=�6L   $��Center=�6g   $	��158��6�   $��36��6�   $
��Bold"�6�   $��14(�6�   $��10,0,0,0q�6�   6�   �� 5   
   -   5         ��Name$ ListBoxPatienten��5      $
��Left=�6,   $	��200��6G   $��0,0,0,0q�6T   $��1��6e   $��1��6r   $	��Top=�6�   $	��350��6�   6�   �� 5   
    �� Orientation$ Vertical=�6   $��1��6.   $��1��6;   .+�5      �� -   5        $ btnInfoPatient��5      $
��Info��6-   $��Center=�6<   $	��158��6Z   $��36��6f   $
��Bold"�6r   $��14(�6�   $��10,0,0,0q�6�   {�.  6�   �� 5      -   5        $ btnEditPatient��5      $
��Edit��6-   $��Center=�6<   $	��158��6Z   $��36��6f   $
��Bold"�6r   $��14(�6�   $��10,0,0,0q�6�   {�.  6�   �� 5      -   5        $ btnDeletePatient��5      $��Delete��6/   $��Center=�6@   $	��158��6^   $��36��6j   $
��Bold"�6v   $��14(�6�   $��10,0,0,0q�6�   {�.  6�   5      5      5      