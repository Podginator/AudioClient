   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      J FAudioClient_Tom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AudioClient_Tom.ViewsAudioClient_Tom.Views 5      G(clr-namespace:AudioClient_Tom.ViewModelsAudioClient_Tom.ViewModels 5      $   AudioClient_Tom.Views.HomeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      5local#clr-namespace:AudioClient_Tom.Views     5      ?
viewModels(clr-namespace:AudioClient_Tom.ViewModels     5        � DataContext  5      . (AudioClient_Tom.ViewModels.HomeViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��140 �6   �� 5      .+�5   
   �� -   5         ��Name$ 	MenuItems��5      $��Stretch=�5      $��Stretch=�5         HeaderStyle#��[  5      
������ $��Stretch=�5   =   $��1��6Y    �� SelectedIndex$ 0��6f   ��5      �� *	MenuItems+��5      Z� ��5!      �� 5"      .R�5#      �� ��6   Z� ��64   Z� .   (System.Windows.Interactivity.Interaction   Triggers 5$      /   )System.Windows.Interactivity.EventTrigger  5%         	EventName$ MouseLeftButtonUp��6-   .   (System.Windows.Interactivity.TriggerBase   Actions. 5&   "   6   0System.Windows.Interactivity.InvokeCommandAction     Command 5'   %   �� *DataContext.updateViewInModel+	 �� RelativeSource	 �� 
 �� AncestorType"
 ��   CommandParameter 5)   %   �� 5*      ._�5,      ��  ��Name$ itemName��6    $��16(�5-       $��Yu Gothic UI Light)�5.       ��5/       �� *Name+��50       �� 	 �� $
 ListBoxItemL� �� Mode$ FindAncestor=� �� Path$ 
Foreground�51      52      55      �� 56   
   -   5        $ label��57      $
��Menu��58      $��0,0,0,0q�59      $��14.667(�5:      ���#6a6a6a$��Yu Gothic UI Light)�5<      �� 5=   
   $��1��5?      $��1��6   $��Stretch=�6*   $��Stretch=�6H   ��5>      �� *UserControl+5?   H   �� 5@   
   -   5        $ 
label_Copy��5A   
   $��0,0,0,0q�5C   
   $��14.667(�5D   
   ���#6a6a6a$��Yu Gothic UI Light)�5F   
   $��1��6*   ��5B   
   �� *CurrentlySelected+5F   *   5H      5I      