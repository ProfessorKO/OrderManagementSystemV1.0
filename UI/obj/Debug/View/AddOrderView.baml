   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View  5          UI.View.AddOrderView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:UI.View     5        N� Title$  Order Management System��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��440* �6   �� 5      $
��361* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ addOrder��5      $
��Left=�6%   $	��347��6@   $��	0,103,0,0q�6M   $	��Top=�6`   $	��790��6x   $��2��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 SKU��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 63     5      $
 Item��6%   $	 350 65     5      $	 Qty��6%   $ 80 64     5      $ Price��6%   $ 80 66     5      $ Total��6%   $ 80 66   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ * 6)      CellTemplate 5      �� 5      .R�5      �� -   5        $��Delete��5   %   67   5      5      5!      �� 5"   
   $��ORDER��6   $
��Bold"�6    $
��Left=�62   $��	53,24,0,0q�6M   $	��Top=�6`    J� RenderTransformOrigin$ -8.316,-0.462&�6x   $��66��6�   �� 5#   
   $��	DATE/TIME��6   $
��Bold"�6$   $
��Left=�66   $��
280,24,0,0q�6Q   $	��Top=�6e   $ -8.316,-0.462&�6}   $��92��6�   �� 5$   
   $��STATE��6   $
��Bold"�6    $
��Left=�62   $��	60,64,0,0q�6M   $	��Top=�6`   $ -8.316,-0.462&�6x   $��66��6�   �� 5%   
   $��TOTAL��6   $
��Bold"�6    $
��Left=�62   $��
308,64,0,0q�6M   $	��Top=�6a   $ -8.316,-0.462&�6y   $��92��6�   �� 5&   
   -   5        $��orderHeaderId��5&       �� 
IsReadOnly . $
��Left=�6[   $��
103,24,0,0q�6v   $	��Top=�6�   $ -6.921,-2.019&�6�   $��72��6�   $��35��6�   ��6'   �� *Id+	 �� Mode$	 OneWay=�6�   �� 5'   
   -   5        $��
orderState��5'       . $
��Left=�6Z   $��
103,64,0,0q�6u   $	��Top=�6�   $ -6.921,-2.019&�6�   $��72��6�   $��26��6�   ��6$   �� *State+$	 OneWay=�6�   �� 5(   
   -   5        $��
orderTotal��5(       . $
��Left=�6Z   $��
353,64,0,0q�6u   $	��Top=�6�   $ -6.921,-2.019&�6�   $��76��6�   $��26��6�   ��6$   �� *Total+$	 OneWay=�6�   �� 5)   
   -   5        $��orderDateTime��5)       . $��353,22,298,0q�6_   $	��Top=�6u   $ -6.921,-2.019&�6�   $��2��6�   $��28��6�   ��6'   �� *
DateTime+$	 OneWay=�6�   �� 5*   
   -   5        $��Add Item��5*      $��1��6$   $
��Left=�64   $��
172,28,0,0q�6O   $	��Top=�6c   $	��179��6{   6�   �� 5+   
   -   5        $��
BTN_Submit��5+      $��Submit��6#   
 J� Opacity$	
 0.5Q�64   $��1��6B   $
��Left=�6R   $��
172,54,0,0q�6m   $	��Top=�6�   $	��179��6�   6�   �� 5,   
   -	   5        $��Cancel��5,      $��1��6"   $
��Left=�62   $��
172,78,0,0q�6M   $	��Top=�6a   $	��179��6y   6�   5-      5.      