   M S B A M L   `   `   `  ����C  ?WpfAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfAdminWpfAdmin  5   	       WpfAdmin.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfAdmin     5   	     � Title$  LoginWindow��5   	   $	��350��6   $	��400��6*   .��5	      � $��20,20q�6    � ColumnDefinitions 5
   
   �� 5      $	��120 �6   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Gebruikersnaam *: ��6   $��	0,90,0,10q�6-   �� 5   
   -   5         ��Name$ txtLogin��5   "   $��1��6   $��	0,90,0,10q�64   $��5q�6G   �� 5   
   $��1��6   $��Wachtwoord *: ��6   �� 5   
   -   5        $ txtPassword��5   /   $��1��6   $��1��6"   $��0,0,0,10q�6D   $��5q�6V   �� 5   
   -   5         ��Name$ btnLogin��5   .   $��1��6   $��2��6!   $��Login��6@   $��10,0,0,0q�6P   $
��10,5q�6b   $��Bottom=�6q   6�   5      5      