   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View  5          UI.View.AddOrderItemView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:UI.View     5        N� Title$  Order Management System��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��440* �6   �� 5      $
��361* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
stockItems��5         
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6x   $	��349��6�   $��	0,101,0,0q�6�   $	��Top=�6�   $	��790��6�   $��2��6�    �� SelectedItem 6'   �� *	stockItem+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 SKU��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6I   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 62   �� *Id+6I     5      $
 Item��6%   $	 400 6L   	 63   �� *Name+6L     5      $ Price��6%   $	 100 6N   	 64   �� *Price+6N     5      $ In Stock��6%   $ * 6S   	 67   �� *	InStock+6S   5      �� 5   
   $^��XAdd order line item 
 (please select an item, enter quantity and hit [Add Item] button)��6   $
��Bold"�6{   $
��Left=�6�   $��
207,10,0,0q�6�   $	��Top=�6�   
 J� RenderTransformOrigin$
 -8.316,-0.462&�6�   $	��476��6�   $��47��6  $��2��6  �� 5    
   $��Quantity��6   $
��Bold"�6#   $
��Left=�65   $��
308,62,0,0q�6P   $	��Top=�6d   $
 -8.316,-0.462&�6|   $��92��6�   $��26��6�   �� 5!   
   -   5        $��Add Item��5!      $��1��6$   $
��Left=�64   $��
172,68,0,0q�6O   $	��Top=�6c   $	��179��6{   $��20��6�   �� 5"   
   -   5        $��itemQuantity��5"      $
��Left=�6&   $��23��6A   $��
380,66,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $��1��6u   $	��Top=�6~   $	��120��6�   $��2��6�   5#      5$      