#pragma once

#include <iostream>
#include "clsDate.h"

using namespace std;

template <class T> class clsInputValidate
{

public:

	 static bool IsNumberInRange(T number, T from, T to)
	{
		return (number >= from && number <= to);
	}

	 static T readNumberInRange(T from, T to, string ErrorMessage)
	{
		T number = ReadNumber();


		while (!IsNumberInRange(number, from, to)) {

			cout << ErrorMessage;
			cin >> number;

		}

		return number;
	}
	
	 static T ReadNumber(string ErrorMessage = "Invalid Input, Enter again: ") {

		T num;
		cin >> num;

		while (cin.fail()) {

			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');

			cout << ErrorMessage;
			cin >> num;

		}

		return num;

	}
	 static T ReadString()
	{
		T  S1;
		// Usage of std::ws will extract allthe whitespace character
		getline(cin >> ws, S1);
		return S1;
	}

	 static T readPositiveNumber()
	{

		T num;

		do
		{
			num = ReadNumber();

		} while (num <= 0);

		return num;
	}
	
	static bool IsDateBetween(clsDate Date, clsDate From, clsDate To)
	{
		//Date>=From && Date<=To
		if ((clsDate::IsDate1AfterDate2(Date, From) || clsDate::IsDate1EqualDate2(Date, From))
			&&
			(clsDate::IsDate1BeforeDate2(Date, To) || clsDate::IsDate1EqualDate2(Date, To))
			)
		{
			return true;
		}

		//Date>=To && Date<=From
		if ((clsDate::IsDate1AfterDate2(Date, To) || clsDate::IsDate1EqualDate2(Date, To))
			&&
			(clsDate::IsDate1BeforeDate2(Date, From) || clsDate::IsDate1EqualDate2(Date, From))
			)
		{
			return true;
		}

		return false;
	}

	static bool IsValidDate(clsDate Date) {

		return clsDate::IsValidDate(Date);
	}


};

