   M S B A M L   `   `   `  ����H  DBuscadorIndex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BuscadorIndexBuscadorIndex  5   	       BuscadorIndex.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:BuscadorIndex     5   	   -   5          � Title$  Buscador��5   	   $��463.091��6   $��566.818��6+   .��5	      � .+�5
   
   �� -   5        $��BuscarTexto��5
      $
��Left=�6&   $��23��6B   $��	10,30,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��434��6�   �� 5   
   -   5        $��BuscarBoton��5      $��Buscar��6$   $
��Left=�65   $��
449,30,0,0q�6P   $	��Top=�6d   $��85��6|   $��23��6�   6�   �� 5   
   -   5        $��DiscosCombo��5      $
��Left=�6&   $��	10,58,0,0q�6A   $	��Top=�6T   $	��120��6l   �� 5   
   -   5        $��ListaBusqueda��5      $
��Left=�6(   $	��269��6C   $��	10,85,0,0q�6P   $	��Top=�6c   $	��539��6{    �� View 5      �� 5      .P�5      �� $��Nombre��6%    �� Width$	 150��65    �� CellTemplate 5      �� 5      .R�5   "   �� 
����  � � Cursor$
 Hand��6^   ��6-   �� *NombreArchivo+6^   5      5      �� 5      $
��Ruta��6%   $	 300��63    �� DisplayMemberBinding 6?   �� *Ruta+5      �� 5      $��Tamaño��6%   $ 50��65    5      �� 5      .R�5   "   �� ��6-   �� *	Tamanno+5      5       5!      5#      �� 5$   
   -   5        $��	StatusBar��5$      $
��Left=�6%   $��21��6@   $��	0,411,0,0q�6L   $	��Top=�6_   $	��559��6w   �� 5%   
   -   5        $��StatusLabel��5%      $��Buscando...��6#   $y�Hidden=�69   $
��Left=�6M   $��
458,53,0,0q�6h   $	��Top=�6|    J� RenderTransformOrigin$ 
0.295,0.41&�6�   �� 5&   
   -   5         ��Name$ TiempoLabel��5&      $��Label��6%   $
��Left=�65   $��
191,57,0,0q�6P   $	��Top=�6d   5(      5)      