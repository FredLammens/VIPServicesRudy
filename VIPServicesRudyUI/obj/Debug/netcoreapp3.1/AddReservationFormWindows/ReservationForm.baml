   M S B A M L   `   `   `  ����L  HVIPServicesRudyUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:VIPServicesRudyUIVIPServicesRudyUI  5   	   '    !VIPServicesRudyUI.ReservationForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:VIPServicesRudyUI     5   	     � Title$  ReservatieFormulier��5   	   $	��500��6%   $	��500��62   $	��500��6>   $	��500��6N   .��5	      �� $
��True��6   $
��Auto=�6+   .��5
   
   � $��10q�6    � RowDefinitions 5      �� 5      $	��10* �6    �� 5      $	��20* �6    �� 5      $	��70* �6    �� 5      $	��10* �6    .+�5      �� $��Klant��6   $��2q�6&   $��0��61   .��5      �� .+�5      � $��6q�6    .+�5      �� $��Bottom=�6   Klant:5      �� 5      -   5         ��Name$ ClientShowBox��5      $��Bottom=�61   $��6,0,0,0q�6L    �� 
IsReadOnly$
 True��6]   .��6o   	KlantNaam5      5      � 5      .+�5      �� -   5         ��Name$ AddExistingCLientBtn��5      $��Voeg bestaande toe��67   $
��Left=�6T   $��Center=�6o   $��6,0,10,0q�6�   6�   �� 5      -   5        $ AddNewClientBtn��5      $��Voeg nieuw toe��62   $
��Left=�6K   $��Center=�6f   6�   5      5       5!      �� 5"      $��
StartAdres��6   $��2q�6+   $��1��66   .��5#      � .+�5$      ��  �� Orientation$ 
Horizontal=�6!   $��5q�6:   .+�5%      �� $��Straat: ��6    �� 5&      -   5        $ StartAdresStreat��5&   "   $	��200��6<   $��Center=�6K   �� 5'      $
��Nr: ��6    �� 5(      -   5        $ StartAdresNr��5(   "   $��30��68   $��Center=�6C   5)      �� 5*      $ 
Horizontal=�6!   $��5q�6:   .+�5+      �� $��
Postcode: ��6    �� 5,      -   5        $ StartAdresPostalCode��5,   "   $��60��6@   $��Center=�6K   �� 5-      $��
Gemeente: ��6    �� 5.      -   5        $ StartAdresTown��5.   "   $	��150��6:   $��Center=�6I   5/      50      51      �� 52      $��Limousine/Arrangement��6   $��2q�66   $��2��6A   .��53      �� .+�54      �� .+�55      �� $ 
Horizontal=�6%   .+�56      �� $��StartLocatie: ��6$   �� 57      -   5         ��Name$ StartLocationComboBox��57   '   $��29,2,2,0q�6F   ��6X   �� *	Locations+ �� SelectedItem 6z   �� *SelectedStartLocation+58      �� 59      $ 
Horizontal=�6%   .+�5:      �� $��AankomstLocatie: ��6$   �� 5;      -	   5        $ ArrivalLocationComboBox��5;   '   $��2q�6H   ��6S   �� *	Locations+ 6u   �� *SelectedArrivalLocation+5<      5=      �� 5>      .+�5?      �� $ 
Horizontal=�6%   .+�5@      �� $��ReservatieStartDatum: ��6$   (  "System.Windows.Controls.DatePicker  5A      -
   5          Name$ ReservationStartDate��5A   )   $��9,0,0,2q�6G   �� 5B      $��
StartUur: ��6$   �� 5C      -   5        $ StartHourTextBox��5C   &   $��40��6@   $��5q�6N   $��Center=�6Y   5D      �� 5E      $ 
Horizontal=�6%   .+�5F      �� $��ReservatieEindDatum: ��6$     5G      -   5        $ ReservationEndDate��5G   )   $��10,2,0,0q�6E   �� 5H      $��	EindUur: ��6$   �� 5I      -   5        $ EndHourTextBox��5I   &   $��40��6>   $��5q�6L   $��Center=�6W   5J      5K      �� 5L      .+�5M      �� $ 
Horizontal=�6%   $��6q�6>   .+�5N      �� $��Bottom=�6)   
Limousine:5P      �� 5Q      -   5        $ LimousineShowBox��5Q   &   $��Bottom=�6@   $��6,0,10,0q�6[   $
 True��6m   .��6   LimousineNaam5S      5T      �� 5U      -   5        $ AddLimousineBtn��5U   !   $��Voeg Limousine toe��6:   $
��Left=�6W   $��Center=�6r   $��6,0,0,0q�6�   6�   5V      �� 5W      $ 
Horizontal=�6!   .+�5X      �� $��Arrangement��6    �� 5Y      -   5        $ ArrangementComboBox��5Y   #   $��Center=�6@   $��2q�6[   ��6f   �� *Arrangements+�� 5Z      $��Price: ��6    �� 5[      -   5        $ 
PriceField��5[   "   $
 True��66   $��30��6H   $��5q�6V   �� 5\      -   5        $ ShowPriceBtn��5\   !   $�� Show Price��67   $��Center=�6M   $��Center=�6h   6�   5]      5^      5_      �� 5`      -   5        $ AddReservationBtn��5`      $��Voeg Reservartie toe��60   $��Center=�6O   $��Center=�6l   $��10q�6�   $��3��6�   5a      5b      5c      