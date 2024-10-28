#pragma once
#include "clsScreen.h"

class clsCurrencyCalculatorScreen : protected clsScreen
{

private:

	static string ReadFromCurrency() {

		string CurrencyFromCode = clsInputValidate<string>::ReadString();

		while (!clsCurrency::IsCurrencyExist(CurrencyFromCode)) {

			cout << "this Currency do not exist enter another Currency code : ";
			CurrencyFromCode = clsInputValidate<string>::ReadString();

		}

		return CurrencyFromCode;
	}

	static string ReadToCurrency(clsCurrency CurrencyFrom) {

		string CurrencyToCode = clsInputValidate<string>::ReadString();

		while ((!clsCurrency::IsCurrencyExist(CurrencyToCode)) || (CurrencyFrom.GetCurrencyCode() == clsString::StringToUpper(CurrencyToCode))) {

			if (CurrencyFrom.GetCurrencyCode() == clsString::StringToUpper(CurrencyToCode)) {

				cout << "You Cant convert to the same Currency enter another Currency: ";
				CurrencyToCode = clsInputValidate<string>::ReadString();
				continue;
			}

			cout << "this Currency do noy exist enter another Currency code : ";
			CurrencyToCode = clsInputValidate<string>::ReadString();

		}

		return CurrencyToCode;

	}

	static void _PrintCurrency(clsCurrency Currency)
	{
		cout << "\nConvert From:\n";
		cout << "_____________________________\n";
		cout << "\nCountry    : " << Currency.GetCountry();
		cout << "\nCode       : " << Currency.GetCurrencyCode();
		cout << "\nName       : " << Currency.GetCurrencyName();
		cout << "\nRate(1$) = : " << Currency.GetRate();

		cout << "\n_____________________________\n";

	}

	static float ReadAmount() {

		float Amount = clsInputValidate<float>::ReadNumber();

		return Amount;
	}

	static void CalculateTheExchange(clsCurrency CurrencyFrom, clsCurrency CurrencyTo, float Amount) {

		if (CurrencyTo.GetCurrencyCode() == "USD") {

			cout << Amount << " " << CurrencyFrom.GetCurrencyCode() << " = " <<
				CurrencyFrom.ConvertToUSD(Amount) << " " << CurrencyTo.GetCurrencyCode();
		}
		else {

			cout << Amount << " " << CurrencyFrom.GetCurrencyCode() << " = "
				 << CurrencyFrom.ConvertToOtherCurrency(Amount, CurrencyTo) <<
				 " " << CurrencyTo.GetCurrencyCode();
		}

		return;

	}

public:

	static void ShowCurrencyCalculatorScreen() {

		char Continue = 'y';

		while (Continue == 'y' || Continue == 'Y')
		{

			clsUtil::ResetScreen();

			_DrawScreenHeader("Currency Calculator Screen");

			cout << "Please enter Currency1 code: ";
			clsCurrency CurrencyFrom = clsCurrency::FindByCode(ReadFromCurrency());

			cout << "Please enter Currency2 code: ";
			clsCurrency CurrencyTo = clsCurrency::FindByCode(ReadToCurrency(CurrencyFrom));

			cout << "Enter Amount to exchange: ";
			float Amount = ReadAmount();

			_PrintCurrency(CurrencyFrom);

			CalculateTheExchange(CurrencyFrom,CurrencyTo,Amount);

			cout << "\n\nDo you want to perform another calculation? y/n ? ";
			cin >> Continue;

		}


	}

};

