   M S B A M L   `   `   `  ����?  ;cpv1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:cpv1cpv1  5   	       cpv1.Sedans   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:cpv1     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  SedansWindow��5       � Title$
 Cars��5	   	   $	��650��6   $
��1500��6#    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�6    � Icon$ images\rentlock.ico��6D   .��5      � ���#212121.+�5   
   � .+�5      �� $
��Cars��6   ���#fff$
��Bold"�66   $
��Left=�6H   $��10 15 0 560q�6c   $
��Wrap=�6x   $��Center=�6�   $��40(�6�   �� 5      -   5         ��Name$ 
RentSedans��5      $��Right=�6)   $��0 10 500 561q�6E   $��18(�6[   $	��150��6i   $��40��6x   $
��Rent��6�   $
��Auto��6�   6�   �� 5      -   5         ��Name$ 	SearchBox��5      ���#fff���#fff)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search��6N   $��Right=�6v   $��40��6�   $��40��6�   $��
0 10 675 0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��150��6�   $	��150��6�   $��18(�6  5      &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 
SedansGrid��5   �   
   CanUserAddRows
 .     AutoGenerateColumns .  $
��Left=�6�   $	��438��6  $��	10 70 0 0q�6  $	��Top=�6-  $	��987��6E     	RowHeight$ 50Q�6Q     RowBackground
 �����   AlternatingRowBackground
 �����   HorizontalGridLinesBrush
 �   �   VerticalGridLinesBrush
 �   �   GridLinesVisibility$	 All=�6�     cpv1.DataGridTextSearch   SearchValue 6   ��  �� ElementName$ 	SearchBox�� �� Path$
 Text� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *
TestData+ � 	Resources 5         cpv1.SearchValueConverter   SearchValueConverter*  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value `� 	Converter �� RelativeSource �� Triggers P� Property P� Value��%�  &	        '       7     5      6-   �� 5      "  6   .�5      ��  �@ IsTextMatch 5      `� 5      8   .1�5   "   �� $ Content.Text�6Q    6*   �� *Self+6Q   �� 5   "   $, &(local:DataGridTextSearch.SearchValue)�6Q    6*   �� *Self+6Q   5      5        5!      P� 5"       �@ IsTextMatch . . �5#      ��  � ��
 � ���6;   5$      5&      5'         Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)          FontSize$  18Q�6A   ,  &System.Windows.Controls.DataGridColumn!   Header$! Company��6O   "   Width5  /System.Windows.Controls.DataGridLengthConverter$	" 160 6`   1	  +System.Windows.Controls.DataGridBoundColumn# 	  Binding# 6%   �� *	company+6`     5*      $  18Q�6@   $! Model��6N   $	" 160 6]   # 6%   �� *model+6]     5+      $! Class��6?   $  18Q�6N   $	" 160 6\   # 6%   �� *class+6\     5,      $! Horse power��6@   $  18Q�6U   $	" 110 6c   # 6%   �� *power+6c     5-      $! 	Engine, L��6@   $  18Q�6S   $" 95 6a   # 6%   �� *engine+6a     5.      $! Drive��6?   $  18Q�6N   $" 95 6\   # 6%   �� *drive+6\     5/      $! Places��6A   $  18Q�6Q   $" 95 6_   # 6%   �� *places+6_     50      $! Price, $��6@   $  18Q�6R   $" 95 6`   # 6%   �� *price+6`   52      �� 53   
   -   5        $ ��Name$$ StackAddSedans��53      $	��400��6)   $��0 0 50 0q�68   ���#212121
�������$��Right=�6w   % �� Padding$% 30q�6�   $	��400��6�   $	��300��6�   & �� CornerRadius$& 20��6�   ._�55      �� $	��600��6   .+�56      �� $��Add new car��6   ���#fff$��24(�6A   $��Center=�6O   $
��Bold"�6l   $��0q�6~   �� 57      -   5        $ textBoxCompanySedans��57      ' �� 	MaxLength$' 30��68   ���#fff$��18(�6Z   ���#fff$ Enter company��6z   $��0 0 0 10q�6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   6+  �� 58      -   5        $ textBoxModelSedans��58      $' 30��66   ���#fff$��18(�6X   ���#fff$ Enter model��6x   $��0 0 0 10q�6�   #��[ 6�   6  �� 59      -   5        ( ��Name$( comboBoxClassSedans��59      $ Choose class��69   ���#fff$��18(�6y   ���#fff$��0 10 0 5q�6�     MaterialDesignComboBox#��[ 6�   .@�5:      �� ���#212121) �� Padding$) 5q�65   Sedan6H   �� 5;      ���#212121$) 5q�65   
Sportcar6K   �� 5<      ���#212121$) 5q�65   Lux6F   �� 5=      ���#212121$) 5q�65   Suv6F   5>      �� 5?      -	   5        $ textBoxHorseSedans��5?      $' 4��66   ���#fff$��18(�6W   ���#fff$ Enter horse��6w   $��0 0 0 5q�6�   #��[ 6�   6#  �� 5@      -
   5        $ textBoxEngineSedans��5@      ���#fff$' 3��6J   $��18(�6X   ���#fff$ Enter engine��6x   $��0 0 0 10q�6�   #��[ 6�   6+  �� 5A      -   5        $( comboBoxDriveSedans��5A      $ Choose drive��69   ���#fff$��18(�6y   ���#fff$
��0 10q�6�   #��[ 6�   .@�5B      �� ���#212121$) 5q�65   AWD6F   �� 5C      ���#212121$) 5q�65   RWD6F   �� 5D      ���#212121$) 5q�65   FWD6F   5E      �� 5F      -   5        $( comboBoxPlacesSedans��5F      $ Choose places��6:   ���#fff$��18(�6{   ���#fff$��0 10 0 0q�6�   #��[ 6�   .@�5G      �� ���#212121$) 5q�65   26D   �� 5H      ���#212121$) 5q�65   46D   �� 5I      ���#212121$) 5q�65   56D   5J      �� 5K      -   5        $ textBoxPriceSedans��5K      $' 4��66   ���#fff$��18(�6W   ���#fff$ Enter price��6w   $��0 0 0 25q�6�   #��[ 6�   6U  5O      5P      � 5Q   
   .+�5R      �� -   5        $ 	AddSedans��5R      $	��Add��6)   $��Right=�67   $��Bottom=�6S   $	��150��6n   $��40��6}   $��
0 0 160 40q�6�   * �� 	IsDefault* . $��18(�6�   6�   �� 5S      -   5        $ UpdateSedans��5S      $��Update��6+   $��Right=�6<   $��18(�6X   $	��150��6f   $��40��6u   $��0 500 670 0q�6�   6�   �� 5T      -   5        $ 
BackSedans��5T      + �� IsCancel+ . $
��Back��69   $
��Left=�6H   $��18(�6c   $	��150��6q   $��40��6�   $��
10 500 0 0q�6�   6�   �� 5U      -   5        $ DeleteSedans��5U      $��Delete��6+   $��Right=�6<   $��18(�6X   $	��150��6f   $��40��6u   $��0 500 500 0q�6�   6�   5W      5X      5Y      