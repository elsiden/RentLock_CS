   M S B A M L   `   `   `  ����?  ;cpv1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:cpv1cpv1  5   	       cpv1.PersonalAccount   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:cpv1     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  PersonalAccount��5	   	   $	��450��6!   $	��800��6.    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�6    � Icon$ images\rentlock.ico��6[   .��5      � ���#212121.+�5   
   � .+�5      �� $��Orders��6   ���#fff$
��Bold"�68   $
��Left=�6J   $��10 15 0 360q�6e   $
��Wrap=�6z   $��Center=�6�   $��40(�6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
OrdersGrid��5   z      CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6�   $	��235��6�   $��	10 70 0 0q�6�   $	��Top=�6�   $	��760��6�      	RowHeight$ 50Q�6�   	   RowBackground
	 �����
   AlternatingRowBackground

 �����   HorizontalGridLinesBrush
 �   �   VerticalGridLinesBrush
 �   �   GridLinesVisibility$	 All=�6w  ��6=   �� *
TestData+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6>      FontSize$ 18Q�6L      Width5  /System.Windows.Controls.DataGridLengthConverter$	 219 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *name+6Z     5      $	 Car��6=   $	 229 6J   $ 18Q�6V    6%   �� *car+6V     5      $
 Date��6>   $ 18Q�6L   $	 120 6Z    6%   �� *date+6Z     5      $ Phone��6?   $	 175 6N   $ 18Q�6Z    6%   �� *phone+6Z   5      �� 5   
   -   5         ��Name$ DeleteAccount��5      $��Delete��6(   $��Right=�69   $��18(�6U   $��	0 0 25 50q�6c   $��Bottom=�6v   $	��150��6�   $��40��6�   6�   �� 5   
   -   5        $ BackAccount��5       �� IsCancel . $
��Left=�66   $	��150��6Q   $��40��6`   $��40��6o   $	��150��6~   $��	15 0 0 50q�6�   $��Bottom=�6�   $��18(�6�   $
��Back��6�   6�   5      5      