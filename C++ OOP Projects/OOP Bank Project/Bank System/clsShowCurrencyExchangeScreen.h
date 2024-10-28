#pragma once

#include "clsScreen.h"
#include "clsUtil.h"
#include <iomanip>
#include "clsInputValidate.h"
#include "clsListCurrenciesScreen.h"
#include "clsFindCurrencyScreen.h"
#include "clsUpdateCurrencyRateScreen.h"
#include "clsCurrencyCalculatorScreen.h"

class clsShowCurrencyExchangeScreen : protected clsScreen
{

private:

    enum enCurrencyExchangeOptions {
        enListCurrencies = 1, enFindCurrency = 2, enUpdateRate = 3,
        enCurrencyCalculator = 4, eMainMenue = 5
    };

    static short ReadCurrencyExchangeMenueOption()
    {
        cout << setw(37) << left << "" << "Choose what do you want to do? [1 to 5]? ";
        short Choice = clsInputValidate<short>::readNumberInRange(1, 5, "Enter Number between 1 to 5? ");
        return Choice;
    }

    static void _PerformManageUsersMenueOption(enCurrencyExchangeOptions ManageUsersMenueOption)
    {

        switch (ManageUsersMenueOption)
        {
        case enCurrencyExchangeOptions::enListCurrencies:
            clsUtil::ResetScreen();
            _ShowListCurrenciesScreen();
            _GoBackToCurrenciesMenue();
            break;

        case enCurrencyExchangeOptions::enFindCurrency:
            clsUtil::ResetScreen();
            _ShowFindCurrencyScreen();
            _GoBackToCurrenciesMenue();
            break;

        case enCurrencyExchangeOptions::enUpdateRate:
            clsUtil::ResetScreen();
            _ShowUpdateRateScreen();
            _GoBackToCurrenciesMenue();
            break;
        case enCurrencyExchangeOptions::enCurrencyCalculator:
            clsUtil::ResetScreen();
            _ShowCurrencyCalculatorScreen();
            _GoBackToCurrenciesMenue();
            break;
        case enCurrencyExchangeOptions::eMainMenue:
        {
            //do nothing here the main screen will handle it :-) ;
        }
        }

    }

    static void _GoBackToCurrenciesMenue()
    {
        //cout << "\n\nPress any key to go back to Manage Users Menue...";
        clsUtil::PauseScreen();
        ShowCurrenciesMenue();
    }

    static void _ShowListCurrenciesScreen()
    {
       
        clsCurrenciesListScreen::ShowCurrenciesListScreen();

    }
    static void _ShowFindCurrencyScreen()
    {
        
        clsFindCurrencyScreen::ShowFindCurrencyScreen();

    }
    static void _ShowUpdateRateScreen()
    {
        clsUpdateCurrencyRateScreen::ShowUpdateCurrencyRateScreen();
    }
    static void _ShowCurrencyCalculatorScreen()
    {
      
        clsCurrencyCalculatorScreen::ShowCurrencyCalculatorScreen();

    }


public:

	static void ShowCurrenciesMenue() {

		clsUtil::ResetScreen();
		_DrawScreenHeader("\t Manage Users Screen");
	
        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t\t  Currency Exchange Menue\n";
        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t[1] List Currencies.\n";
        cout << setw(37) << left << "" << "\t[2] Find Currency.\n";
        cout << setw(37) << left << "" << "\t[3] Update Rate.\n";
        cout << setw(37) << left << "" << "\t[4] Currency Calculator.\n";
        cout << setw(37) << left << "" << "\t[5] Main Menue.\n";
        cout << setw(37) << left << "" << "===========================================\n";
	
        _PerformManageUsersMenueOption(enCurrencyExchangeOptions(ReadCurrencyExchangeMenueOption()));

	}


};

