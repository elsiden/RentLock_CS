   M S B A M L   `   `   `  ����?  ;cpv1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:cpv1cpv1  5   	       cpv1.Reviews   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:cpv1     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  Reviews��5	   	   $	��650��6   $
��1500��6&    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�6    � Icon$ images\rentlock.ico��6D    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �� CornerRadius J� SnapsToDevicePixels ��Name��%C  '��       �� 5   
   
review��" ��6!   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $	 border��6!   $
 6��61   #��z��6B   $��3q�6n   #��z��6�    . ._�5      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5      5      5      5      5      .��5      � ���#212121.+�5   
   � .+�5      �� $��Reviews��6   ���#fff$
��Bold"�69   $
��Left=�6K   $��10 15 0 560q�6f   $
��Wrap=�6{   $��Center=�6�   $��40(�6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ReviewsGrid��5   h      CanUserAddRows .     AutoGenerateColumns .  $
��Left=�6}   $	��438��6�   $��	10 70 0 0q�6�   $	��Top=�6�   $	��987��6�      	RowHeight$ 50Q�6�      RowBackground
 �����   AlternatingRowBackground
 �����   HorizontalGridLinesBrush
 �   �   VerticalGridLinesBrush
 �   �   GridLinesVisibility$	 All=�6f  ��6+   �� *
TestData+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6>      FontSize$ 18Q�6L      Width5  /System.Windows.Controls.DataGridLengthConverter$	 240 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *name+6Z     5       $ Review��6@   $	 730 6P   $ 18Q�6\    6%   �� *review+6\   5"      � 5#   
   .+�5$      �� -   5         ��Name$ BackReviews��5$      $
��Back��6*    �� IsCancel . $
��Left=�6I   $��18(�6d   $	��150��6r   $��40��6�   $��
10 500 0 0q�6�   6�   �� 5%      -   5        $ DeleteReviews��5%      $��Delete��6,   $��Right=�6=   $��18(�6Y   $	��150��6g   $��40��6v   $��0 500 500 0q�6�   6�   �� 5&      -   5        $ UpdateReviews��5&      $��Update��6,   $��Right=�6=   $��18(�6Y   $	��150��6g   $��40��6v   $��0 500 670 0q�6�   6�   5)      � 5*   
   -   5         �Name$ AddReviewGrid��5*      .+�5+      �� -   5         ��Name$ textBoxNameReviews��5+      $��18(�62    �� 	MaxLength$ 20��6@   $��Right=�6O   )  #MaterialDesignThemes.Wpf.HintAssist    Hint$  
Enter Name��6k   $��50��6�   $��50��6�   $��0 120 220 0q�6�   ! �� TextWrapping$
! Wrap=�6�   $	��Top=�6�   $	��150��6�   $	��150��6  6  �� 5,      -   5        $ textBoxReview��5,      $��18(�6-   $	 199��6;   $��Right=�6K   $  Enter Review��6g   $	��170��6�   $	��170��6�   $��
0 180 20 0q�6�   $
! Wrap=�6�   $	��Top=�6�   $	��350��6�   $	��350��6  6  �� 5-      $��Right=�6   $��0 133 400 0q�64   $
��Wrap=�6I   $
��Name��6]   $��18(�6i   ���#fff$	��Top=�6�   �� 5.      $��Right=�6   $��0 250 400 0q�64   $
��Wrap=�6I   $��Review��6]   $��18(�6k   ���#fff$	��Top=�6�   �� 5/      $��Right=�6   $��
0 70 150 0q�64   $
��Wrap=�6H   $��Your Review��6\   $��24(�6o   $
��Bold"�6}   ���#fff$	��Top=�6�   �� 50      -	   5        $ 	AddReview��50      " �� 	IsDefault" . $��
Add Review��69   $��Right=�6N   $��18(�6j   $	��150��6x   $��40��6�   $��0 145 130 0q�6�   6�   51      52      53      