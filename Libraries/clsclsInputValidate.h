
/*

	Build a Input Validation Class Have in it Methods to Validate Input.

	Methods in the Class:

	- IsNumberInRange(int number, int from, int to)
	- IsNumberInRange(float number, float from, float to)
	- IsNumberInRange(double number, double from, double to)
	- readIntNumberInRange(int from, int to, string Massege)
	- readFloatNumberInRange(float from, float to, string Massege)
	- readDoubleNumberInRange(double from, double to, string Massege)
	- ReadIntNumber(string ErrorMessage)
	- ReadFloatNumber(string ErrorMessage)
	- ReadDoubleNumber(string ErrorMessage)
	- readPositiveIntNumber()
	- ReadPositiveFloatNumber()
	- ReadPositiveDoubleNumber()
	- IsDateBetween(clsDate Date, clsDate From, clsDate To)
	- IsValidDate(clsDate Date)

	 Note: To Use the Class You Should Include the Date Library in Your Project.

*/


#pragma once

#include <iostream>
#include "clsDate.h"

using namespace std;

class clsInputValidate
{

public:


	static bool IsNumberInRange(int number, int from, int to)
	{
		return (number >= from && number <= to);
	}
	static bool IsNumberInRange(float number, float from, float to)
	{
		return (number >= from && number <= to);
	}
	static bool IsNumberInRange(double number, double from, double to)
	{
		return (number >= from && number <= to);
	}

	static int readIntNumberInRange(int from, int to, string Massege)
	{
		int number = ReadIntNumber();


		while (!IsNumberInRange(number, from, to)) {

			cout << Massege;
			cin >> number;

		}

		return number;
	}
	static float readFloatNumberInRange(float from, float to, string Massege)
	{
		float number = ReadFloatNumber();


		while (!IsNumberInRange(number, from, to)) {

			cout << Massege;
			cin >> number;

		}

		return number;
	}
	static double readDoubleNumberInRange(double from, double to, string Massege)
	{
		double number = ReadDoubleNumber();

		while (!IsNumberInRange(number, from, to)) {

			cout << Massege;
			cin >> number;

		}

		return number;
	}

	static int ReadIntNumber(string ErrorMessage = "Invalid Input, Enter again\n") {

		int num;
		cin >> num;

		while (cin.fail()) {

			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');

			cout << ErrorMessage << endl;
			cin >> num;

		}

		return num;

	}
	static float ReadFloatNumber(string ErrorMessage = "Invalid Input, Enter again\n") {

		float num;
		cin >> num;

		while (cin.fail()) {

			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');

			cout << ErrorMessage << endl;
			cin >> num;

		}

		return num;

	}
	static double ReadDoubleNumber(string ErrorMessage = "Invalid Input, Enter again\n") {

		double num;
		cin >> num;

		while (cin.fail()) {

			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');

			cout << ErrorMessage << endl;
			cin >> num;

		}

		return num;

	}

	static int readPositiveIntNumber()
	{

		int num;

		do
		{
			num = ReadIntNumber();

		} while (num <= 0);

		return num;
	}
	static float ReadPositiveFloatNumber()
	{
		float num;

		do
		{
			num = ReadFloatNumber();

		} while (num <= 0);

		return num;
	}
	static double ReadPositiveDoubleNumber()
	{
		double num;

		do
		{
			num = ReadDoubleNumber();

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

