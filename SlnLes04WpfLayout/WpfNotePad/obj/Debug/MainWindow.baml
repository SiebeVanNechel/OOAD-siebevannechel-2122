   M S B A M L   `   `   `  ����E  AWpfNotePad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfNotePad
WpfNotePad  5   	       WpfNotePad.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WpfNotePad     5   	     � Title$  Wpf Notepad��5   	   $	��450��6   $	��800��6*   .��5	      � .+�5
   
   ]� .+�5      o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� $	��New��6   m� 5      -   5         m�Name$ btnOpenMenuItem��5      $��Open...��68   6I   m� 5      -   5        $ btnSave��5      $
��Save��60   {�.  6P   m� 5      -   5        $ 	btnSaveAs��5      $��Save _As...��62   {�.  6Y   �� 5      m� 5      -   5        $ btnExitMenu��5      $
��Exit��64   6B   5      m� 5      $
��Edit��6   .@�5      m� -   5        $ btnCut��5      $	��Cut��6/   {�.  6N   m� 5      -   5        $ btnCopy��5      $
��Copy��60   {�.  6P   m� 5      -   5        $ btnPaste��5      $��Paste��61   {�.  6R   5      m� 5      $��_Help��6   .@�5      m� -   5        $��_About��5      6/   5      5      �� 5      $��Bottom=�6   .@�5      �� -	   5         ��Name$ lblChars��5      $��	#chars: 0��6*   $
��10,2q�6>   5       �� 5"      $
��Left=�6    �� SelectedIndex$ 0��6/   .@�5#      �� -
   5         ��Name$ 	Tabheader��5#      $��Untitled��6-   $��0q�6?   $
��10,5q�6J   .��5$      �� -   5         ��Name$ txtInput��5$      $��10q�60    �� TextWrapping$
 Wrap=�6=    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�6f   6�   5%      5&      5'      5(      5)      