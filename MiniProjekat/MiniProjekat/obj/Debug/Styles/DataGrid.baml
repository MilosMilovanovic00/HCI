   M S B A M L   `   `   `  ����b  ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� 
ResourceId �� TypeInTargetAssembly&    System.Windows.Controls.DataGrid �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �Name	 J� Opacity
 � Points �� Stretch �� Triggers P� Property P� Value �� 
TargetName $   DataGrid.AlternateRow.Background  DataGrid.Static.BorderBrush % !DataGrid.Grid.HorizontalLineBrush �� Padding ��Name � ColumnDefinitions � RowDefinitions    SelectAllCommand7  1System.Windows.Controls.DataGridHeadersVisibility
   All �� ConverterParameter!    HeadersVisibilityConverter �� 	Converter �� RelativeSource �� AncestorTypeG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter  Name   Column ��Name �� CanContentScroll ��Name  �� ScrollableHeight! � Maximum" �� Orientation*# �� #ComputedVerticalScrollBarVisibility$ �� ViewportHeight% �� ViewportSize& � Value' �� Mode( �� ScrollableWidth,) �� %ComputedHorizontalScrollBarVisibility* �� ViewportWidth+ �� Triggers, ]� 
Conditions- �� Property. �� Value  ColumnHeaderGripperStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader % !DataGrid.Column.Header.Background , (DataGrid.Column.Header.Static.Foreground/ �� Orientation0 F�Name 
 SortUp & "DataGrid.Column.Header.Icon.Static  SortDown1 n�Name 	 Sort.Up.Icon.Active*  $System.Windows.Controls.DataGridCell2 �� Mode)  #System.Windows.Controls.DataGridRow3 ��Name?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid?  9System.Windows.Controls.Primitives.DataGridCellsPresenter4   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter5   DetailsVisibility$6   SelectiveScrollingOrientation;	  5System.Windows.Controls.SelectiveScrollingOrientation7 	  Vertical#8    RowDetailsScrollingConverter:
  4System.Windows.Controls.Primitives.DataGridRowHeader
9   Row�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      VThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2  5      %  (��       5      $" DataGridSelectAllButtonStyle��"   )'   �    &	     '  ,    7  7  '  �    '  ]    �� 6   "  ��6{   .�5   
   ��  � �� 5      �� 5      " ��6"   .R�5	      � .+�5
      �� $ Border��6$   #��� ��64    . 6u   � 5      $ Arrow��6"   
���   �$��Right=�6>   $��8,8,3,3q�6Z   $
	 0.15Q�6k   
 �   ��� ��� ��� ��� $ Uniform=�6�   $��Bottom=�6�   5       5      P� 5       �@J�IsMouseOver . . �5      �� $ Border��67   # � ��6K    � ��5      P� 5       � �� . . �5      �� $ Border��65   # � ��6I    � ��5      P� 5       � {� .  . �5      �� $ Arrow��6;    � y�$ 	Collapsed=�6N   5      5      5      5      �� 5      "    6   .�5   
   ��   �@  AlternatingRowBackground# �   65   �� 5   
    � ��# � ��6'   �� 5   
    � ��# � ��6'   �� 5    
    � ��# �  6(   �� 5!   
    �@  GridLinesVisibility$ 
Horizontal=�60   �� 5"   
     �@  HorizontalGridLinesBrush# �  65   �� 5#   
    �@  HeadersVisibility$ Column=�6.   �� 5$   
    � ��$ 0,0,0,1q�6,   �� 5%   
     �@  RowDetailsVisibilityMode$ VisibleWhenSelected=�65   �� 5&   
    � �� . 6:   �� 5'   
    �@  SelectionMode$ Single=�6*   �� 5(   
    �@��PanningMode$
 Both=�65   �� 5)   
    �@��IsFlicksEnabled .  63   �� 5*   
    � �� 5+      �� 5,      "   6"   .R�5-      �� #��z��6   #��z��6I   #��z��6}   # z��6�    . ._�5.      �� $ DG_ScrollViewer��6'   |�.  ��5/      �� 50   "   " ��62   .R�51   &   �  52   *   �� 53   .   $
��Auto �6?   �� 54   .   $��* �6?   �� 55   .   $
��Auto �6?    57   *   �� 58   .   $
��Auto �6<   �� 59   .   $��* �6<   �� 5:   .   $
��Auto �6<   .+�5<   *   �� #��Z 61   |�.  ��6r   C� *�� $" DataGridSelectAllButtonStyle��"   +y�6�   �� *HeadersVisibility+# Z # Z  �� "   ��6�  �� *CellsPanelHorizontalOffset+ �� "     5=   *   $! PART_ColumnHeadersPresenter��6I   $��1��6n   y�6~   �� *HeadersVisibility+# Z # Z  �� "   �� 5>   *   $! PART_ScrollContentPresenter��6A   # z��6f   $��2��6�   $��1��6�   �� 5?   *   $ PART_VerticalScrollBar��64   $��2��6T   #! z  6d   $" Vertical=�6�   $��1��6�   #y�z# 6�   #% z$ 6W  & 6�   �� *VerticalOffset+$' OneWay=� �� *TemplatedParent+6W  � 5@   *   $��1��6/   $��2��6?    5A   .   �� 5B   2   ��6C   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� "   �� 5C   2   $��* �6C   .+�5E   .   �� $ PART_HorizontalScrollBar��68   $��1��6Z   #! z( 6j   $" 
Horizontal=�6�   #y�z) 6�   #% z* 6U  & 6�   �� *HorizontalOffset+$' OneWay=� �� *TemplatedParent+6U  5F   +   5G   '   5H   #   .��5J      �� # z 6-   5K      5L      5M      5O      + 5P   
   ]� 5Q      , 5R      �� 5S      - �@��
IsGrouping. . 66   �� 5T      "- �@%�IsVirtualizingWhenGrouping. .  6X   ./�5V      ��  � �� .  6B   5W      5Y      �� 5Z      "  n�6-   .�5[   
   ��  � ��$ 8��6"   �� 5\   
    � ��
 ���� 6'   �� 5]   
    �@�Cursor$ SizeWE��6#   �� 5^   
    � �� 5_      �� 5`      " n�6"   .R�5a      �� #��z��6   # z��6G   5b      5d      5e      �� 5f      "   6   .�5g   
   ��  � ��$ Center=�65   �� 5h   
    � ��# �  6'   �� 5i   
    � ��# �  6'   �� 5j   
    � ��$ SemiBold"�6'   �� 5k   
    � ��$	 5,0q�6$   �� 5l   
    � ��$ 32��6#   �� 5m   
    � �� 5n      �� 5o      "  6"   .R�5p      � .+�5q      �� #��z��6!   #��z��5r   !   #��z��5s   !   # z��5t   !   ._�5u      � #��z��6#    5v   "   �� 5w   &   �� 5x   &   $
��Auto �67   .+�5z   "   �� #��z��63   ��. # z 5|   3   #��z��5}   3   �� 5~   "   $��1��6-   $/ 
Horizontal=�5   %   $��5 0 0 0q�5�   %   .+�5�   &   F� $0 
SortUpIcon��5�   )   #���  5�   )   #��z��5�   )   #���  5�   )   $ Uniform=�5�   )   $��10��5�   )   5�   '   F� 5�   &   $0 SortDownIcon��5�   )   #���  5�   )   #��z��5�   )   #���  5�   )   $ Uniform=�5�   )   $��10��5�   )   5�   '   5�   #   5�      5�      n� 5�      $1 PART_LeftHeaderGripper��6    $
��Left=�6@   8��  6[   n� 5�      $1 PART_RightHeaderGripper��6    $��Right=�6A   8�� 6]   5�       5�      P� 5�       �@ SortDirection$ 	AscendingX�6;   . �5�      �� $ SortDownIcon��6%   # � 	 6O    � ��6   5�      P� 5�       �@ SortDirection$ 
DescendingX�6;   . �5�      �� $ 
SortUpIcon��6%   # � 	 6M    � ��6}   5�      5�      5�      5�      �� 5�      "   6   .�5�   
   ��  � �� 6'   �� *
Foreground+ �� $2 FindAncestor=�$ DataGridL��� 5�   
    � ��$	 5,0q�6#   62   �� 5�   
    � ��$ Center=�65   6G   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �� #��z��5�      #��z��5�      #��z��5�      ._�5�      �� #��z��6+   #��z��5�   +   #��z��5�   +   5�      5�      5�      5�      5�      �� 5�      "   6   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    � ��$ 30��6#   �� 5�   
    �@=�ErrorTemplate 65   Z� �� 5�   
    �@ ValidationErrorTemplate 5�      �� 5�      .R�5�      �� 
���  ��$��2,0,0,0q�61   $��!��6B   $��Center=�6K   5�      5�      �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �� $3 
DGR_Border��6   #��z��61   #��z��6]   #��z��6�    . ._�5�         5�      �� 5�   "   $
��Auto �63   �� 5�   "   $��* �63    5�      �� 5�   "   $��* �60   �� 5�   "   $
��Auto �60   .+�5�        $��1��65   #��z4 6E   # z 6o     5�      $��1��67   $��1��6G   #y�z5 6k  6 6T   �� *AreRowDetailsFrozen+# Z7 # Z8  �� "   6k  
  5�      $��2��60   $6 Vertical=�6A   y�6�   �� *HeadersVisibility+# Z9 # Z  �� "   5�      5�      5�      5�      + 5�   
   P� 5�       �@ 	IsNewItem . . �5�      ��  � �� 6+   �� *NewItemMargin+ �� "   5�      5�      5�      