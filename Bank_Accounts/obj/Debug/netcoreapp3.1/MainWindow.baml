   M S B A M L   `   `   `  ����H  DBank_Accounts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Bank_AccountsBank_Accounts  5   	       Bank_Accounts.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Bank_Accounts     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5   
   �� $��Manage Bank Accounts��6   $��0,0,10,0q�6/   �� 5   
   $��Choose Account:��6   $��	0,30,10,0q�6*   �� 5   
   -   5        $��	AccountIn��5      $
��Left=�6#   $��
100,35,0,0q�6>   $�� ��6R    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6n   $	��120��6�   �� 5   
   $��Make Deposit:��6   $��	0,60,10,0q�6(   �� 5   
   -   5        $��	DepositIn��5      $
��Left=�6#   $��
100,65,0,0q�6>   $�� ��6R   $
 Wrap=�6Z   $	��Top=�6n   $	��120��6�   �� 5   
   -   5        $��GetDepositIn��5      $��Deposit��6%   $
��Left=�67   $��
230,63,0,0q�6R   $	��Top=�6f   6~   �� 5   
   $��Make Withdrawal:��6   $��	0,90,10,0q�6+   �� 5   
   -   5        $��WithdrawalIn��5      $
��Left=�6&   $��
100,95,0,0q�6A   $�� ��6U   $
 Wrap=�6]   $	��Top=�6q   $	��120��6�   �� 5   
   -   5        $��GetWithdrawalIn��5      $��Withdraw��6(   $
��Left=�6;   $��
230,93,0,0q�6V   $	��Top=�6j   6�   �� 5   
   $!��Calculate Monthly Interest:��6   $��
0,120,10,0q�66   �� 5   
   -   5        $��CalculateMonthlyInterest��5      $��	Calculate��61   $
��Left=�6E   $��230,123,0,0q�6`   $	��Top=�6u   6�   �� 5    
   -   5        $��Result��5       $
��test��6   $��
0,150,10,0q�6-   �� 5#   
   -   5         ��Name$ accList��5#      $	��200��6#   $��
536,0,64,0q�6/   5%      5&      5'      