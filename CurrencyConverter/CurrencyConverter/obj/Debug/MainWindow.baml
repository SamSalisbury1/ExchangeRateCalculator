   M S B A M L   `   `   `  ����L  HCurrencyConverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CurrencyConverterCurrencyConverter  5   	   "    CurrencyConverter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:CurrencyConverter     5   	     � Title$  
MainWindow��5   	   $	��350��6   $��545.667��6)   .��5	      � $	��319��6   $��Bottom=�6   .+�5
   
   �� $��Exchange Rate Calculator��6   $��Center=�63   $��183,10,191,283q�6P   �� 5   
   -   5         ��Name$ poundInputBox��5      $
��Left=�6)   $��23��6D   $��	31,88,0,0q�6P    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��120��6�   �� 5   
   -   5         ��Name$ 
errorLabel��5      $�� ��6$   $
��Left=�6/   $��
31,111,0,0q�6J   $	��Top=�6^   $	��189��6v   
���  ��$��40��6�   �� 5   
   -   5         ��Name$ currencyComboBox��5      $��Right=�6-   $��	0,85,10,0q�6I   $	��Top=�6\   $	��120��6t    �� SelectedIndex$ 0��6�   �� 5   
   $��
Convert To��6   $��Center=�6%   $��217,85,225,0q�6B   $	��Top=�6X   $��75��6p   �� 5   
   -   5        $��	Calculate��5      $��Center=�6%   $��217,131,225,0q�6B   $	��Top=�6Y   $��75��6q   6|   �� 5   
   -   5        $ 	resultBox��5      $��Center=�6%   $��23��6B   $��183,191,191,0q�6N   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��143��6�   �� 5   
   $��Result��6   $��Center=�6!   $��234,165,240,0q�6>   $	��Top=�6U   $��43��6m   �� 5   
   -   5        $��	View Logs��5      $��Center=�6%   $��217,271,225,0q�6B   $	��Top=�6Y   $��75��6q   6|   �� 5   
   $��£��6   $
��Left=�6   $��	10,85,0,0q�67   $	��Top=�6J   �� 5   
   $��	e.g. 1.10��6   $
��Left=�6$   $��	31,62,0,0q�6?   $	��Top=�6R   $	��120��6j   
�������6v   5      5      