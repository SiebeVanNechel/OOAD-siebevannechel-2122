   M S B A M L   `   `   `  ����D  @WpfDokter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfDokter	WpfDokter  5           WpfDokter.PageEditPatiënt   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:WpfDokter     5        N� Title$  PageEditPatiënt��5	      .��5      � -   5         � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� -   5         ��Name$ ImgFotoPatient��5      $��Img/DefaultAvatar.png��6(   $��Center=�6G   $��2��6d   $	��150��6x   $��0,0,0,0q�6�   $	��Top=�6�   $	��150��6�   �� 5   
   $��
Voornaam: ��6   $��1��6%   $��Center=�62   $��Right=�6M   $��Normal"�6i   $��14(�6}   �� 5   
   $��Familienaam: ��6   $��2��6(   $��Center=�65   $��Right=�6P   $��Normal"�6l   $��14(�6�   �� 5   
   $��
Geslacht: ��6   $��3��6%   $��Center=�62   $��Right=�6M   $��Normal"�6i   $��14(�6}   �� 5   
   $��Geboortedatum: ��6   $��4��6*   $��Center=�67   $��Right=�6R   $��Normal"�6n   $��14(�6�   �� 5   
   $��Email: ��6   $��5��6"   $��Center=�6/   $��Right=�6J   $��Normal"�6f   $��14(�6z   �� 5    
   $��Gsm: ��6   $��6��6    $��Center=�6-   $��Right=�6H   $��Normal"�6d   $��14(�6x   �� 5"   
   -   5         ��Name$ txtVoornaam��5"      $��1��6'   $��1��64   $��Center=�6D   $
��Left=�6_   $��Normal"�6z   $��14(�6�   $
��0,11q�6�   $	��200��6�   �� 5#   
   -   5        $ txtFamilienaam��5#      $��2��6*   $��1��67   $��Center=�6G   $
��Left=�6b   $��Normal"�6}   $��14(�6�   $
��0,11q�6�   $	��200��6�   �� 5$   
   -   5         ��Name$ lblEmail��5$      $��5��6"   $��1��6/   $��Center=�6?   $
��Left=�6Z   $��Normal"�6u   $��14(�6�   $
��0,11q�6�   $	��250��6�   �� 5%   
   -   5        $ lblGsm��5%      $��6��6    $��1��6-   $��Center=�6=   $
��Left=�6X   $��Normal"�6s   $��14(�6�   $
��0,11q�6�   $	��200��6�   �� 5&   
   -   5         ��Name$ btnTerug��5&      $��7��6#   $��Terug��60   $	��Top=�6@   $
��Left=�6X   $	��100��6t   $��36��6�   $
��Bold"�6�   $��14(�6�   $��10,0,0,0q�6�   6�   �� 5'   
   -   5        $ 
btnOpslaan��5'      $��7��6%   $��Opslaan��62   $	��Top=�6D   $��Right=�6\   $	��100��6y   $��36��6�   $
��Bold"�6�   $��14(�6�   $��10,0,0,0q�6�   6�   	� 5(   
   -	   5         	�Name$ RadioMan��5(      $	��Man��6(   $��1��66   $
��Left=�6F   $��3��6a   $��Center=�6n   $��14(�6�    	� 	GroupName$ Geslacht��6�   	� 5)   
   -
   5        $ 
RadioVrouw��5)      $��Vrouw��6*   $��1��6:   $
��Left=�6J   $��3��6e   $��Center=�6r   $��14(�6�   $ Geslacht��6�   $��80,0,0,0q�6�   (  "System.Windows.Controls.DatePicker  5*   
   -   5        	  Name$	 DatePickerGeboortedatum��5*      $��1��66   $
��Left=�6F   $��4��6a   $��Center=�6n   $	��200��6�   6�   5+      5,      