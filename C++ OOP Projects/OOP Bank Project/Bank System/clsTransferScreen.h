#pragma once
#include "clsBankClient.h"
#include "clsInputValidate.h"

class clsTransferScreen : public clsScreen
{

private:

    static void _PrintClient(clsBankClient Client)
    {
        cout << "\nClient Card:";
        cout << "\n___________________";
        cout << "\nFull Name   : " << Client.GetFullName();    
        cout << "\nAcc. Number : " << Client.GetAccountNumber();
        cout << "\nBalance     : " << Client.AccountBalance;
        cout << "\n___________________\n";

    }

    static string ReadFromAccountNumber() {

        string AccountFrom;

        cout << "\nplease enter account number to transfer from: ";
        AccountFrom = clsInputValidate<string>::ReadString();

        while (!clsBankClient::IsClientExist(AccountFrom)) {

            cout << "\nAccount do not exist enter Another Account number:";
            AccountFrom = clsInputValidate<string>::ReadString();

        }

        return AccountFrom;

    }

    static string ReadToAccountNumber(string AccountFrom) {


        string AccountTo;

        cout << "please enter account number to transfer to: ";
        AccountTo = clsInputValidate<string>::ReadString();

        while (!clsBankClient::IsClientExist(AccountTo) || AccountTo == AccountFrom) {

            if (AccountTo == AccountFrom) {

                cout << "\nyou cant tranfer to the same account enter Another Account number:";
                AccountTo = clsInputValidate<string>::ReadString();
                continue;
            }

            cout << "\nAccount do not exist enter Another Account number:";
            AccountTo = clsInputValidate<string>::ReadString();

        }

        return AccountTo;

    }

    static float ReadAmount(clsBankClient& ClientFrom){

        float Amount;

        cout << "enter transfer amount: ";
        cin >> Amount;

        while (ClientFrom.AccountBalance < Amount) {

            cout << "\nCannot withdraw, Insuffecient Balance!\n";
            cout << "enter another amount: ";
            cin >> Amount;
        }

        return Amount;

    }

public:

	static void ShowTotalBalances() {

        clsUtil::ResetScreen();

        clsScreen::_DrawScreenHeader("Tranfer Screen");

        string AccountFrom = ReadFromAccountNumber();
        clsBankClient ClientFrom = clsBankClient::FindClient(AccountFrom);
        _PrintClient(ClientFrom);

        string AccountTo = ReadToAccountNumber(AccountFrom);
        clsBankClient ClientTo = clsBankClient::FindClient(AccountTo);
        _PrintClient(ClientTo);

        float Amount = ReadAmount(ClientFrom);
       
        cout << "\nAre you sure you want to perform this transaction? ";
        char Answer = 'n';
        cin >> Answer;

        if (Answer == 'Y' || Answer == 'y')
        {
            ClientFrom.Withdraw(Amount);
            ClientTo.Deposit(Amount);
            clsBankClient::RegisterTransferLog(ClientFrom, ClientTo, Amount);
            cout << "Transfer Done Succfully\n";
        }

        _PrintClient(ClientFrom);
        _PrintClient(ClientTo);
    }

};

