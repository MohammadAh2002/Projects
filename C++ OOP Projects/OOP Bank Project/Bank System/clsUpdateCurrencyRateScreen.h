#pragma once

#include "clsCurrency.h"

class clsUpdateCurrencyRateScreen : protected clsScreen 
{



private:

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

    static float _ReadRate() {

        float NewRate = clsInputValidate<float>::ReadNumber();

        return NewRate;
    }

public:

	static void ShowUpdateCurrencyRateScreen() {

		_DrawScreenHeader("Update Currency Rate Screen");

		cout << "what is the Currency Code: ";
		string Code = clsInputValidate<string>::ReadString();

		clsCurrency Currency = clsCurrency::FindByCode(Code);

        if (Currency.IsEmpty())
        {
            cout << "\nCurrency Was not Found :-(\n";
            return;
        }

        cout << "\nCurrency Found :-)\n";
        _PrintCurrency(Currency);
            
        cout << "Are you Sure you want to update the Rate of this Currency y/n?";
        char Answer;
        cin >> Answer;

        if (Answer == 'y' || Answer == 'Y') {

             cout << "\nUpdate Currency Rate:\n";
             cout << "___________________\n";
             cout << "enter the new rate: ";

             Currency.clsCurrency::UpdateRate(_ReadRate());

             cout << "Currency Updated Succfully\n";
             _PrintCurrency(Currency);
        }

	}


};

