   M S B A M L   `   `   `  ����J  FAudioClient_Tom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AudioClient_Tom.ViewsAudioClient_Tom.Views  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      G(clr-namespace:AudioClient_Tom.ViewModelsAudioClient_Tom.ViewModels  5	      b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5
      $    AudioClient_Tom.Views.SongView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:AudioClient_Tom.Views     5      4s&clr-namespace:System;assembly=mscorlib     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      ?
viewModels(clr-namespace:AudioClient_Tom.ViewModels     5	      ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5
      $��Stretch=�5   7   $��Stretch=�6U     � 	Resources  5         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  ComboBox.Static.Background �� Color �� Opacity  ComboBox.Static.Border ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background * &ComboBox.Static.Editable.Button.Border  ComboBox.MouseOver.Glyph ! ComboBox.MouseOver.Background 	 ComboBox.MouseOver.Border *
 &ComboBox.MouseOver.Editable.Background & "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background �� EndPoint �� 
StartPoint	 � Color
 � Offset - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Glyph  ComboBox.Pressed.Background  ComboBox.Pressed.Border ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border  ComboBox.Disabled.Glyph   ComboBox.Disabled.Background  ComboBox.Disabled.Border ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBox.Static.Glyph  ComboBoxToggleButton �� 
TargetType �� 
TargetType ��Name F�Name �� Triggers ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value �� 
TargetName P� Property P� Value  ComboBoxTemplate �Name � ColumnDefinitions �Name � AllowsTransparency �� Mode5  /Microsoft.Windows.Themes.SystemDropShadowChrome  Name   Color �� MaxDropDownHeight  �� ElementName! J� Opacity" ��Name# �� ClearTypeHint$ ��Name% ��Name& ��Name-  'System.Windows.Input.KeyboardNavigation'   DirectionalNavigation( d�Name) d� 	IsChecked* ��Name+ �� SelectionBoxItemTemplate, �� SelectionBoxItem#- �� SelectionBoxItemStringFormat. �� ContentStringFormat/ J� IsHitTestVisible0 P� 
SourceName1 ]� 
Conditions2 �� Property  TextBox.Static.Background   ComboBoxEditableTextBox ! ComboBoxEditableTemplate3 ��Name4 �� 
IsReadOnly " ComboBoxStyle15 �� Triggers��%(+  &	        &	 �     &	 �     &	 �     &	 *    &	 O    &	 t    &	 �    &	 �    &		 �    &	
     &	 2    &	 U    &	 �    &	     &	 7    &	 �    &	 �    &	     &	 >    &	 �    &	 �    &	      &	 C    &	 f    &	 �    &	 �    &	 �    &	 �    &	     7  7  7  7  7  7  7  7  7  7 	 7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 W    7  &	 �    &	      &	! 0    7  7  7   &	" �&    7   7  7  7  7 ! �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ White��6=   $ 0Q�6K   �� 5   
   $ Transparent��69   �� 5   
   $ White��6F   $
 0.75Q�6T   �� 5   
   $ Transparent��6B   �� 5   
   $ Transparent��6M   �� 5   
   $ Transparent��6I   �� 5   
   $ 	#FF000000��6;   �� 5   
   $ White��6@   $	 0.5Q�6N   �� 5    
   $ Transparent��6<   �� 5!   
   $ 	#FFFFFFFF��6I   �� 5"   
   $ 	#FF7EB4EA��6E   �� 5#   
   $	 0,1&�6T   $	 0,0&�6c   .��5$      � $	 	#FFEBF4FC��6   $	
 0.0Q�6-   � 5%      $	 	#FFDCECFC��6   $	
 1.0Q�6-   5&      �� 5'   
   $ 	#FF7EB4EA��6L   �� 5(   
   $ 	#FF000000��69   �� 5)   
   $	 0,1&�6B   $	 0,0&�6Q   .��5*      � $	 	#FFDAECFC��6   $	
 0.0Q�6-   � 5+      $	 	#FFC4E0FC��6   $	
 1.0Q�6-   5,      �� 5-   
   $ Transparent��6:   �� 5.   
   $ 	#FFFFFFFF��6G   �� 5/   
   $ 	#FF569DE5��6C   �� 50   
   $	 0,1&�6R   $	 0,0&�6a   .��51      � $	 	#FFDAEBFC��6   $	
 0.0Q�6-   � 52      $	 	#FFC4E0FC��6   $	
 1.0Q�6-   53      �� 54   
   $ 	#FF569DE5��6J   �� 55   
   $ 	#FFBFBFBF��6:   �� 56   
   $ 	#FFF0F0F0��6?   �� 57   
   $ 	#FFD9D9D9��6;   �� 58   
   $ 	#FFFFFFFF��6H   �� 59   
   $ 	#FFBFBFBF��6D   �� 5:   
   $ Transparent��6O   �� 5;   
   $ Transparent��6K   �� 5<   
   $ 	#FF606060��68   �� 5=   
   " d�6-   .�5>      ��  �@�OverridesDefaultStyle . 66   �� 5?       � �� .  6*   �� 5@       � |� .  6*   �� 5A       �@��	ClickMode$ Press=�6*   �� 5B       � �� 5C      �� 5D      " d�6&   .R�5E      �� $ templateRoot��6!   8��  $��0q�6m   8��  . ._�5F      �� $ splitBorder��6%   
������ $��1q�6T   $��Right=�6h   $��0q�6�    . #��� r�6�   ._�5G   "   F� $ arrow��6'   F����        ���( ��( јaQ     јaQ P����̰( � �    P����        8�� $��Center=�6�   $��0q�6�   $��Center=�6�   5H      5I       5J      ^� 5K       5L   "   �� 5M   &    60   �� *
IsEditable+ �� " �� true6�   �� 5N   &    60   �� *IsMouseOver+ �� *Self+	 false6v   �� 5O   &    60   �� *	IsPressed+ �� *Self+	 false6t   �� 5P   &    60   �� *	IsEnabled+ �� *Self+ true6t   .0�5R   "   �� $ templateRoot��6?   8   � ��6Y   �� 5S   "   $ templateRoot��6@   8   � ��6Z   �� 5T   "   $ splitBorder��6?   8   � ��6X   �� 5U   "   $ splitBorder��6@   8   � ��6Y   5V      P� 5W       �@J�IsMouseOver . . �5X   "   �� $ arrow��69   8   � ��6L   5Y      ^� 5Z       5[   "   �� 5\   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5]   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5_   "   �� $ templateRoot��6?   8   � ��6Y   �� 5`   "   $ templateRoot��6@   8 	  � ��6Z   5a      ^� 5b       5c   "   �� 5d   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5e   &    60   �� *
IsEditable+ �� " �� true6�   .0�5g   "   �� $ templateRoot��6?   8 
  � ��6Y   �� 5h   "   $ templateRoot��6@   8   � ��6Z   �� 5i   "   $ splitBorder��6?   8   � ��6X   �� 5j   "   $ splitBorder��6@   8   � ��6Y   5k      P� 5l       � �� . . �5m   "   �� $ arrow��69   8   � ��6L   �� 5n   "   $ templateRoot��6?   8   � ��6Y   �� 5o   "   $ templateRoot��6@   8   � ��6Z   �� 5p   "   $ splitBorder��6?   8   � ��6X   �� 5q   "   $ splitBorder��6@   8   � ��6Y   5r      P� 5s       � {� .  . �5t   "   �� $ arrow��69   8   � ��6L   5u      ^� 5v       5w   "   �� 5x   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5y   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5{   "   �� $ templateRoot��6?   8   � ��6Y   �� 5|   "   $ templateRoot��6@   8   � ��6Z   5}      ^� 5~       5   "   �� 5�   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5�   &    60   �� *
IsEditable+ �� " �� true6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   �� 5�   "   $ splitBorder��6?   8   � ��6X   �� 5�   "   $ splitBorder��6@   8   � ��6Y   5�      5�      5�      5�      �� 5�   
   " ��63   .R�5�      � $ templateRoot��6    .  5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   $��1q�6�   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5�        $ shadow��64   $ Transparent��6D   #��z 6X   ��6�   �� *ActualWidth+$  templateRoot��._�5�      �� $ dropDownBorder��6!   #��� ��69   $��0q�6�   
�������$	! 0.5Q�6�   ._�5�      �� $" DropDownScrollViewer��6+   
���   �.��5�   "   � $
 grid��6'   $# Enabled=�65   .+�5�   &   �� $$ canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $% 
opaqueRect��64   ��6H   �� *
Background+$  dropDownBorder����6�   �� *ActualHeight+$  dropDownBorder����6�   �� *ActualWidth+$  dropDownBorder��5�   '   �� 5�   &   $& ItemsPresenter��65   $' 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $( toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  ) 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+66  �� 5�      $* contentPresenter��6#   #��z+ 6=   #��z��6z   #��z, 6�   #. z- 6�   #��z��6-  / .  #��z��6�  # z 6�  #��z��6�  5�       5�      P� 5�      $0 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $ shadow��6/    � ��$ 0,0,5,5q�6C   �� 5�      $ shadow��6.    �@ Color$ 	#71000000��6B   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6/    � ��$ 95��6K   5�      ]� 5�      1 5�      �� 5�      2 �@��
IsGrouping . 6:   �� 5�      "2 �@%�IsVirtualizingWhenGrouping .  6\   ./�5�      ��  � �� .  6F   5�      P� 5�      $0 DropDownScrollViewer��6C    � �� .  . �5�      �� $ 
opaqueRect��63    6K   �� *VerticalOffset+$  DropDownScrollViewer�� �@��Top�� 5�      $ 
opaqueRect��64    6L   �� *HorizontalOffset+$  DropDownScrollViewer�� �@��Left5�      5�      �� 5�   
   $ 	#FFFFFFFF��6<   �� 5�   
   " ��60   .�5�      ��  �@�OverridesDefaultStyle . 66   �� 5�       �@J�	AllowDrop . 6*   �� 5�       � ��$ 0��6)   �� 5�       � ��$ 0��6*   �� 5�       �@�FocusVisualStyle 61   Z� �� 5�       �@��PanningMode$ VerticalFirst=�69   �� 5�       �@��IsFlicksEnabled .  67   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $" PART_ContentHost��6'   
������ |�.  $��Hidden=�6l   $��Hidden=�6�   5�      5�      5�      �� 5�   
   " ��6;   .R�5�      � $ templateRoot��6    .  5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+ �� *TemplatedParent+.��5�        $ shadow��64   $ Transparent��6D   #��z 6X   ��6�   �� *ActualWidth+$  templateRoot��._�5�      �� $ dropDownBorder��6!   #��� ��69   $��1q�6�   #��� ��6�   ._�5�      �� $" DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $# Enabled=�65   .+�5�   &   �� $$ canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $% 
opaqueRect��64   ��6H   �� *
Background+$  dropDownBorder����6�   �� *ActualHeight+$  dropDownBorder����6�   �� *ActualWidth+$  dropDownBorder��5�   '   �� 5�   &   $& ItemsPresenter��65   $' 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $( toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  ) 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+66  �� 5�      $ border��6   8�� #��z��6a   ._�5�      �� $3 PART_EditableTextBox��6   #��z��6<   #��z��6�   8�� #��z��6-  4 6�   �� *
IsReadOnly+ �� *TemplatedParent+6-  5�      5�       5�      P� 5�       � {� .  . �5�      �� $ border��60    �@J�Opacity$
 0.56Q�6D   5�      P� 5�       �@J�IsKeyboardFocusWithin . . �5�      ��  � ��
 �   �63   5�      P� 5�      $0 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $ shadow��6/    � ��$ 0,0,5,5q�6C   �� 5�      $ shadow��6.    �@ Color$ 	#71000000��6B   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6/    � ��$ 95��6K   5�      ]� 5�      1 5�      �� 5�      2 �@��
IsGrouping . 6:   �� 5�      "2 �@%�IsVirtualizingWhenGrouping .  6\   ./�5�      ��  � �� .  6F   5�      P� 5�      $0 DropDownScrollViewer��6C    � �� .  . �5�      �� $ 
opaqueRect��63    6K   �� *VerticalOffset+$  DropDownScrollViewer�� �@��Top�� 5�      $ 
opaqueRect��64    6L   �� *HorizontalOffset+$  DropDownScrollViewer�� �@��Left5�      5�      �� 5�   
   " ��6'   .�5�      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5      � ��8  6,   �� 5      � ��# � ��6+   �� 5      � ��$ 1q�60   �� 5      � ��$
 Auto=�6K   �� 5      � ��$
 Auto=�6I   �� 5      � ��$ 6,3,5,3q�6(   �� 5      � �� . 6>   �� 5      �@��PanningMode$
 Both=�69   �� 5	      �@��IsFlicksEnabled .  67   �� 5
      � ��8  6)   5 5     P� 5      �@��
IsEditable . . �5     ��  � �� .  62   �� 5      � ��$ 2q�60   �� 5      � ��8  61   5     5     5     6 � DataContext6 5     8  2AudioClient_Tom.ViewModels.SongCollectionViewModel  5  
   .��5     � -   5        ���	#FF1E1E1E$��Stretch=�5  "   $��Stretch=�6@   .+�5  
   �� -   5        7 ��Name$7 	SongItems��5     $��Stretch=�5     $��Stretch=�5     $��20,68,20,30q�5!     
�������$��Yu Gothic UI Light)�5#      # MusicCollectionStyle#��[# 5$      $ MusicItemStyle#��[$ 5%     ��5     �� *FilteredCollection+��5      Z� ��6   Z� 8 �� SelectedIndex8 5%  E   �� *SelectedIndex+.  (System.Windows.Interactivity.Interaction9   Triggers9 5&     /  )System.Windows.Interactivity.EventTrigger  5'     :   	EventName$: MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase;   Actions.; 5(     6  0System.Windows.Interactivity.InvokeCommandAction  <   Command< 5)  %   �� *DataContext.SendSongEvent+ �� " ��=   CommandParameter= 5+  %   �� $  	SongItems��> �� Path$> SelectedItem�5-     ? �� View? 50     �� 51     .P�52     �� -   5        SongTitleHeader��@ �� Width$	@ 250��52  >   $��
Song Title��6J   A �� DisplayMemberBindingA 6_   �� *	SongTitle+�� 53     -   5        ArtistTitleHeader��$	@ 150��53  @   $��Artist Name��6L   A 6a   �� *
ArtistName+�� 54     -   5        LengthHeader��$	@ 150��54  ;   $��Length��6G   A 6W   �� *Length+55     57     � 5:  
   $��22��6   $��
20,32,20,0q�6   $	��Top=�6/   .+�5<     �� $��0, 3, 180, 0q�6   $��50��6.   $��  Filter...��6<   
�������$��Yu Gothic UI Light)�5=     $	! 0.5Q�6�   y�68   �� *Text.IsEmpty+ % MyBoolToVisibilityConverterB �� 	Converter#B [% $  textBox��6�   �� 5>     -   5        $3 textBox��5?     $��	0,0,192,0q�5>     $��22��5@     C �� TextWrapping$
C Wrap=�5A     $	��Top=�5C     $	! 0.5Q�5D     ��5B     �� *FilteredString+D �� UpdateSourceTrigger$D PropertyChanged=�.��5D  %   ��5H     �� 5I     " ��6   .�5J     ��  � ��
 ���� 67   �� 5K      � ��
 ���� 68   �� 5L      � ��
 �����67   �� 5M      � ��$ Yu Gothic UI Light)�67   5 5N     P� 5O      �@J�	IsFocused . . �5P  "   ��  � ��
 �   �6?   �� 5Q  "    � ��
 �����6?   5R     P� 5T      �@J�IsMouseOver . . �5U  "   ��  � ��
 �   �6?   �� 5V  "    � ��
 �����6?   5W     5Z     .��5[  !   5\     �� 5]     -   5        E ��Name$E ConvertersCombo��5]     $��0,0,97.674,0q�5`     
������ $��Right=�5b     $��90��5c     $	! 0.5Q�5d     
�������#��� " 5f     $8 0��5g     $��Yu Gothic UI Light)�5h     ��5^     �� *SongConverters.Keys+F �� SelectedItemF 5_     �� *ConverterKey+5h     �� 5i     -   5        $E 	filterBox��5i     $��0,0,4,0q�5j     $��Right=�5k     $��90��5l     $	! 0.5Q�5m     
�������#��� " 5o     $��Yu Gothic UI Light)�5p     G �� DisplayMemberPath$	G Key��5r     H �� SelectedValuePath$H Value��5s     $8 0��5u     ��5q     �� *SongRankers+F 5t     �� *CurrentFilters+$ TwoWay=�5u     5v     5w     5x     