   M S B A M L   `   `   `  ����C  ?WpfTimer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfTimerWpfTimer  5   	       WpfTimer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfTimer     5   	     � Title$  Timer��5   	   $	��300��6   $	��400��6$   .��5	      � -   5         �Name$ window��5	      .+�5
   
   �� -   5         ��Name$ btnStart��5
      $��START��6#   $
��Left=�63   $��	27,50,0,0q�6N   $	��Top=�6a   $��75��6y   $��16(�6�   6�   �� 5   
   -   5        $ btnStop��5      $
��STOP��6"   $
��Left=�61   $��	27,91,0,0q�6L   $	��Top=�6_   $��75��6w   $��16(�6�   {�.  6�   �� 5   
   -   5        $ btnReset��5      $��RESET��6#   $
��Left=�63   $��
27,132,0,0q�6N   $	��Top=�6b   $��75��6z   $��16(�6�    J� RenderTransformOrigin$ 0.513,-0.628&�6�   {�.  6�   �� 5   
   -   5         ��Name$ lblTijd��5      $�� ��6!   $
��Left=�6,   $��
219,77,0,0q�6G   $	��Top=�6[   $��35(�6s   $	��165��6�   �� 5   
   $
��Left=�6   $	��100��6,   $	��Top=�69   $	��191��6Q   $��161,161,0,0q�6]   .+�5      �� -   5         ��Name$ 
rctMinuten��5      ���	#FFF4F4F5$
��Left=�6=   $	��100��6X   
���   �$	��Top=�6t   $��60��6�   $ 0.5,0.5&�6�    �� Left$	 106��6�    �� Bottom$ 0��6�   6�   �� 5      -   5        $ rctSeconden��5      ���	#FFF4F4F5$
��Left=�6>   $	��100��6Y   
���   �$	��Top=�6u   $��60��6�   $ 0.5,0.5&�6�   $ 32��6�   $ 0��6�   6�   5      5      5      