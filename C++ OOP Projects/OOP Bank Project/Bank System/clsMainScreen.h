#pragma once

#include <iostream>
#include "clsInputValidate.h"
#include <iomanip>
#include "clsClientsListScreen.h"
#include "clsAddNewClientScreen.h"
#include "clsDeleteClientScreen.h"
#include "clsUpdateClientList.h"
#include "clsFindClientScreen.h"
#include "clsTransactionsScreen.h"
#include "clsManageUserScreen.h"
#include "clsShowLoginRegisterScreen.h"
#include "clsShowCurrencyExchangeScreen.h"

using namespace std;

class clsMainScreen : protected clsScreen
{

private:

    enum enMainMenueOptions {
        eListClients = 1, eAddNewClient = 2, eDeleteClient = 3,
        eUpdateClient = 4, eFindClient = 5, eShowTransactionsMenue = 6,
        eManageUsers = 7, enLoginRegister = 8,enCurrencyExchange = 9,
        enLogout = 10 ,eExit = 11
    };

    static short _ReadMainMenueOption()
    {
        cout << setw(37) << left << "" << "Choose what do you want to do? [1 to 11]? ";
         return  clsInputValidate<short>::readNumberInRange(1, 11, "Enter Number between 1 to 11? ");
       
    }

    static  void _GoBackToMainMenue()
    {

        clsUtil::PauseScreen();
        ShowMainMenue();
    }

    static void _PerfromMainMenueOption(enMainMenueOptions MainMenueOption)
    {

        switch (MainMenueOption)
        {
        case enMainMenueOptions::eListClients:
            _ShowAllClientsScreen();
            _GoBackToMainMenue();
            break;
        
        case enMainMenueOptions::eAddNewClient:
             _ShowAddNewClientsScreen();
            _GoBackToMainMenue();
            break;

        case enMainMenueOptions::eDeleteClient:
            _ShowDeleteClientScreen();
            _GoBackToMainMenue();
            break;

        case enMainMenueOptions::eUpdateClient:
            _ShowUpdateClientScreen();
            _GoBackToMainMenue();
            break;

        case enMainMenueOptions::eFindClient:
            _ShowFindClientScreen();
            _GoBackToMainMenue();
            break;

        case enMainMenueOptions::eShowTransactionsMenue:
            _ShowTransactionsMenue();
            ShowMainMenue();
            break;

        case enMainMenueOptions::eManageUsers:
            _ShowManageUsersMenue();
            ShowMainMenue();
            break;

        case enMainMenueOptions::enLoginRegister:
            _ShowLoginRegister();
            _GoBackToMainMenue();
            break;

         case enMainMenueOptions::enCurrencyExchange:
            _ShowCurrencyExchange();
            ShowMainMenue();
            break;

        case enMainMenueOptions::enLogout:
            clsUtil::ResetScreen();
            _Logout();
            break;

        case enMainMenueOptions::eExit:
            clsUtil::ResetScreen();
            _ShowEndScreen();
            exit(0);
            break;
        }

    }

    static void _ShowAllClientsScreen()
    {

        if (!CheckAccessRights(clsUser::enPermissions::pListClients))
        {
            return;// this will exit the function and it will not continue
        }

        clsClientListScreen::ShowClientsList();
    }
    static void _ShowAddNewClientsScreen()
    {
        if (!CheckAccessRights(clsUser::enPermissions::pAddNewClient))
        {
            return;// this will exit the function and it will not continue
        }

        clsAddNewClientScreen::ShowAddNewClientScreen();

    }
    static void _ShowDeleteClientScreen()
    {

        if (!CheckAccessRights(clsUser::enPermissions::pDeleteClient))
        {
            return;// this will exit the function and it will not continue
        }

        clsDeleteClientScreen::ShowDeleteClientScreen();

    }
    static void _ShowUpdateClientScreen()
    {

        if (!CheckAccessRights(clsUser::enPermissions::pUpdateClients))
        {
            return;// this will exit the function and it will not continue
        }

        clsUpdateClientScreen::ShowUpdateClientScreen();

    }
    static void _ShowFindClientScreen()
    {

        if (!CheckAccessRights(clsUser::enPermissions::pFindClient))
        {
            return;// this will exit the function and it will not continue
        }

        clsFindClientScreen::ShowFindClientScreen();

    }
    static void _ShowTransactionsMenue()
    {

        if (!CheckAccessRights(clsUser::enPermissions::pTranactions))
        {
            clsUtil::PauseScreen();
            return;// this will exit the function and it will not continue
        }

        clsTransactionsScreen::ShowTransactionsMenue();
    }
    static void _ShowManageUsersMenue()
    {

        if (!CheckAccessRights(clsUser::enPermissions::pManageUsers))
        {
            clsUtil::PauseScreen();
            return;// this will exit the function and it will not continue
        }

        clsManageUsersScreen::ShowManageUsersMenue();

    }
    static void _ShowLoginRegister() {

        if (!CheckAccessRights(clsUser::enPermissions::pLoginRegister))
        {
            return;// this will exit the function and it will not continue
        }

        clsShowLoginRegister::ShowLoginRegisterScreen();

    }
    static void _ShowCurrencyExchange() {

        if (!CheckAccessRights(clsUser::enPermissions::pCurrencyExchange))
        {
            clsUtil::PauseScreen();
            return;// this will exit the function and it will not continue
        }

        clsShowCurrencyExchangeScreen::ShowCurrenciesMenue();

    }
    static void _Logout()
    {

        CurrentUser = clsUser::GetEmptyUserObject();
        //then it will go back to main function.
    }
    static void _ShowEndScreen()
    {
        cout << "\nProgram Ended :-(\n";

    }

public:


    static void ShowMainMenue()
    {

        clsUtil::ResetScreen();
        _DrawScreenHeader("\t\tMain Screen");

        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t\t\tMain Menue\n";
        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t[1]  Show Client List.\n";
        cout << setw(37) << left << "" << "\t[2]  Add New Client.\n";
        cout << setw(37) << left << "" << "\t[3]  Delete Client.\n";
        cout << setw(37) << left << "" << "\t[4]  Update Client Info.\n";
        cout << setw(37) << left << "" << "\t[5]  Find Client.\n";
        cout << setw(37) << left << "" << "\t[6]  Transactions.\n";
        cout << setw(37) << left << "" << "\t[7]  Manage Users.\n";
        cout << setw(37) << left << "" << "\t[8]  Login Register.\n";
        cout << setw(37) << left << "" << "\t[9]  Currency Exchange.\n";
        cout << setw(37) << left << "" << "\t[10] Logout.\n";
        cout << setw(37) << left << "" << "\t[11] Exit The Program.\n";
        cout << setw(37) << left << "" << "===========================================\n";

        _PerfromMainMenueOption((enMainMenueOptions)_ReadMainMenueOption());
    }




};

