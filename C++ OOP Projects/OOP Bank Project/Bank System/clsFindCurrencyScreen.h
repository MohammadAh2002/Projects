#pragma once
#include <iostream>
#include "clsScreen.h"
#include "clsCurrency.h"
#include "clsInputValidate.h"

class clsFindCurrencyScreen :protected clsScreen
{

private:

    enum enFindCurrencyMenue{enCode = 1,enCountry = 2};

    static void _PrintCurrency(clsCurrency Currency)
    {
        cout << "\nCurrency Card:\n";
        cout << "_____________________________\n";
        cout << "\nCountry    : " << Currency.GetCountry();
        cout << "\nCode       : " << Currency.GetCurrencyCode();
        cout << "\nName       : " << Currency.GetCurrencyName();
        cout << "\nRate(1$) = : " << Currency.GetRate();

        cout << "\n_____________________________\n";

    }

    static void _ShowResults(clsCurrency Currency)
    {
        if (Currency.IsEmpty())
        {
            cout << "\nCurrency Was not Found :-(\n";
        }
        else
        {
           
            cout << "\nCurrency Found :-)\n";
            _PrintCurrency(Currency);
        }
    }

public:

    static void ShowFindCurrencyScreen()
    {

        _DrawScreenHeader("\t  Find Currency Screen");

        cout << "\nFind By: [1] Code or [2] Country ? ";
        short Answer = clsInputValidate<short>::readNumberInRange(1,2,"enter a number in range: ");

        if (enFindCurrencyMenue(Answer) == enFindCurrencyMenue::enCode)
        {
            cout << "\nPlease Enter CurrencyCode: ";
            clsCurrency Currency = clsCurrency::FindByCode(clsInputValidate<string>::ReadString());
            _ShowResults(Currency);
        }
        else if(enFindCurrencyMenue(Answer) == enFindCurrencyMenue::enCountry)
        {
            cout << "\nPlease Enter Country Name: ";
            clsCurrency Currency = clsCurrency::FindByCountry(clsInputValidate<string>::ReadString());
            _ShowResults(Currency);
        }






    }

};

