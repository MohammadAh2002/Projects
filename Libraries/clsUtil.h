/*

	Build a Util Class.

	Methods in the Class:

	- void Swap(int& a, int& b)
	- void Swap(float& a, float& b)
	- void Swap(string& a, string& b)
	- void Swap(double& A, double& B)
	- void Swap(bool& A, bool& B)
	- void Swap(char& A, char& B)
	- void Swap(clsDate& Date1, clsDate& Date2)
	- int factorial(int n)
	- float getFrectionPart(float number)
	- bool IsPrimeNumber(int number)
	- bool IsPerfectNumber(int number)
	- int NumberInRevers(int number)
	- int sumOfDigits(int number)
	- int countDigitsRpeatedINnUMBER(int number, short digitsNumber)
	- int RandomNumberInRange(int from, int to)
	- void printArray(int arr[], int ArrLenth)
	- int maxNumberInArray(int arr[], int arrLength)
	- int minNumberInArray(int arr[], int arrLength)
	- int sumOfArrayElements(int arr[], int arrLength)
	- void copyOfArrayToAnotherArray(int arr[], int arr2[], int arrLength)
	- void copyArrayToAnotherArrayInReverseOrder(int arr[], int arr2[], int arrLength)
	- short FindElementIndexInArray(int Number, int arr[], int arrLength)
	- bool IsElementInArray(int arr[], int arrlenth, int check_number)
	- void copyOnlyPrimeNumberOfArray(int arr[], int arr2[], int arrLength, int& arrLength2)
	- void ShuffleArray(int arr[], int arrLength)
	- void ShuffleArray(string arr[100], int arrLength)
	- void fillArrayWithRandomNumbers(int arr[], int number, int from, int to)
	- void addElementToArray(int number, int arr[], int& arrLength)
	- void addElementsToArray(int arr[], int& arrLength)
	- char GetRandomCharacter(enCharType CharType)
	- string GenerateWord(enCharType CharType, short WordLength)
	- string GenerateKey(enCharType CharType, short WordLength)
	- void GenerateKeys(short NumberOfKeys, enCharType CharType, short WordLength)
	- void FillArrayWithRandomWords(string arr[], int arrLength, enCharType CharType, short Wordlength)
	- void FillArrayWithRandomKeys(string arr[100], int arrLength, enCharType CharType, short Wordlength)
	- string Tabs(short NumberOfTabs)

	 Note: To Use the Class You Should Include the Date Library & Input Validation Library 
	 in Your Project.

*/


#pragma once

#include <iostream>
#include <cstdlib>
#include "clsDate.h"
#include "clsclsInputValidate.h"

using namespace std;

class clsUtil
{

private:

	enum enCharType {
		SamallLetter = 1, CapitalLetter = 2,
		Digit = 3, Mix = 4
	};

public:

	static void Swap(int& a, int& b) {

		int tmp;

		tmp = a;
		a = b;
		b = tmp;
	}
	static void Swap(float& a, float& b) {

		float tmp;

		tmp = a;
		a = b;
		b = tmp;
	}
	static void Swap(string& a, string& b) {

		string tmp;

		tmp = a;
		a = b;
		b = tmp;
	}
	static void Swap(double& A, double& B)
	{
		double Temp;

		Temp = A;
		A = B;
		B = Temp;
	}
	static void Swap(bool& A, bool& B)
	{
		bool Temp;

		Temp = A;
		A = B;
		B = Temp;
	}
	static void Swap(char& A, char& B)
	{
		char Temp;

		Temp = A;
		A = B;
		B = Temp;
	}
	static void Swap(clsDate& Date1, clsDate& Date2) {

		clsDate Date3;

		Date3 = Date1;
		Date1 = Date2;
		Date2 = Date3;

	}

	static int factorial(int n)
	{
		int f = 1;

		for (int i = 1; i <= n; i++)
		{
			f = f * i;
		}
		return f;
	}
	static float  getFrectionPart(float number)
	{
		return number - (int)number;
	}

	static bool IsPrimeNumber(int number)
	{
		int m = round(number / 2);

		for (int counter = 2; counter <= m; counter++)
		{
			if (number % counter == 0)
				return false;
		}
		return true;

	}
	static bool IsPerfectNumber(int number)
	{
		int sum = 0;

		for (int i = 1; i < number; i++)
		{
			if (number % i == 0)
				sum += i;

		}
		return (sum == number);
	}

	static int NumberInRevers(int number)
	{
		int remainder = 0, numberInRevers = 0;

		while (number > 0)
		{
			remainder = number % 10;
			number /= 10;
			numberInRevers = numberInRevers * 10 + remainder;
		}
		return numberInRevers;
	}
	static int sumOfDigits(int number)
	{
		int remainder = 0, sum = 0;
		while (number > 0)
		{
			remainder = number % 10;
			number /= 10;
			sum += remainder;
		}
		return sum;
	}
	static int countDigitsRpeatedINnUMBER(int number, short digitsNumber)
	{
		int remainder = 0, sum = 0;
		while (number > 0)
		{
			remainder = number % 10;
			number /= 10;
			if (digitsNumber == remainder)
				sum++;
		}
		return sum;
	}

	static int RandomNumberInRange(int from, int to)
	{

		static bool randcheck = true;

		if (randcheck) {

			srand((unsigned)time(NULL));

			randcheck = false;

		}

		int random = rand() % (to - from + 1) + from;
		return random;
	}

	static void printArray(int arr[], int ArrLenth)
	{

		for (int i = 0; i < ArrLenth; i++)
		{
			cout << arr[i] << " ";
		}

	}

	static int maxNumberInArray(int arr[], int arrLength)
	{
		int max = arr[0];
		for (int i = 0; i < arrLength; i++)
		{
			if (max < arr[i])
				max = arr[i];
		}
		return max;
	}
	static int minNumberInArray(int arr[], int arrLength)
	{
		int min = arr[0];
		for (int i = 0; i < arrLength; i++)
		{
			if (min > arr[i])
				min = arr[i];
		}
		return min;
	}

	static int sumOfArrayElements(int arr[], int arrLength)
	{
		int sum = 0;
		for (int i = 0; i < arrLength; i++)
		{
			sum += arr[i];
		}
		return sum;
	}
	static void copyOfArrayToAnotherArray(int arr[], int arr2[], int arrLength)
	{
		int sum = 0;
		for (int i = 0; i < arrLength; i++)
		{
			arr2[i] = arr[i];
		}
	}
	static void copyArrayToAnotherArrayInReverseOrder(int arr[], int arr2[], int arrLength)
	{
		for (int i = 0; i < arrLength; i++)
		{
			arr2[i] = arr[arrLength - 1 - i];
		}
	}

	static short FindElementIndexInArray(int Number, int arr[], int arrLength)
	{
		for (int i = 0; i < arrLength; i++) {
			if (arr[i] == Number)
				return i;
		}
		return -1;
	}
	static bool IsElementInArray(int arr[], int arrlenth, int check_number) {

		for (int i = 0; i <= arrlenth; i++) {

			if (arr[i] == check_number) {

				return true;
			}
		}

		return false;

	}

	static void copyOnlyPrimeNumberOfArray(int arr[], int arr2[], int arrLength, int& arrLength2)
	{
		int counter = 0;
		for (int i = 0; i < arrLength; i++)
		{
			if (IsPrimeNumber(arr[i]) == true)
			{
				arr2[counter] = arr[i];
				counter++;
			}

		}
		arrLength2 = counter;
	}

	static void ShuffleArray(int arr[], int arrLength)
	{

		for (int i = 0; i < arrLength; i++)
		{
			Swap(arr[RandomNumberInRange(1, arrLength) - 1], arr[RandomNumberInRange(1, arrLength) - 1]);
		}

	}
	static void ShuffleArray(string arr[100], int arrLength)
	{

		for (int i = 0; i < arrLength; i++)
		{
			Swap(arr[RandomNumberInRange(1, arrLength) - 1], arr[RandomNumberInRange(1, arrLength) - 1]);
		}

	}
	static void fillArrayWithRandomNumbers(int arr[], int number, int from, int to)
	{

		for (int i = 0; i < number; i++)
		{
			arr[i] = RandomNumberInRange(from, to);
		}
	}

	static void addElementToArray(int number, int arr[], int& arrLength)
	{
		arrLength++;
		arr[arrLength - 1] = number;
	}
	static void addElementsToArray(int arr[], int& arrLength)
	{
		int addMore = true;
		do
		{
			addElementToArray(clsInputValidate::ReadIntNumber(), arr, arrLength);
			cout << "do you want to add more numbers? [0]:no , [1] yes" << endl;
			cin >> addMore;
		} while (addMore);

	}

	static char GetRandomCharacter(enCharType CharType) {

		switch (CharType) {

		case enCharType::SamallLetter:
			return char(RandomNumberInRange(97, 122));
		case enCharType::CapitalLetter:
			return char(RandomNumberInRange(65, 90));
		case enCharType::Digit:
			return char(RandomNumberInRange(48, 57));
		case enCharType::Mix:
			return char(RandomNumberInRange(48, 122));
		}
	}
	static string GenerateWord(enCharType CharType, short WordLength = 4)

	{
		string Word;

		for (int i = 1; i <= WordLength; i++)

		{

			Word = Word + GetRandomCharacter(CharType);

		}
		return Word;
	}
	static string  GenerateKey(enCharType CharType = CapitalLetter, short WordLength = 4)
	{

		string Key = "";


		Key = GenerateWord(CharType, WordLength) + "-";
		Key = Key + GenerateWord(CharType, WordLength) + "-";
		Key = Key + GenerateWord(CharType, WordLength) + "-";
		Key = Key + GenerateWord(CharType, WordLength);


		return Key;
	}
	static void GenerateKeys(short NumberOfKeys, enCharType CharType = CapitalLetter, short WordLength = 4)
	{

		for (int i = 1; i <= NumberOfKeys; i++)
		{
			cout << "Key [" << i << "] : ";
			cout << GenerateKey(CharType, WordLength) << endl;
		}

	}

	static void FillArrayWithRandomWords(string arr[], int arrLength, enCharType CharType = CapitalLetter, short Wordlength = 4)
	{
		for (int i = 0; i < arrLength; i++)
			arr[i] = GenerateWord(CharType, Wordlength);

	}
	static void FillArrayWithRandomKeys(string arr[100], int arrLength, enCharType CharType = CapitalLetter, short Wordlength = 4)
	{
		for (int i = 0; i < arrLength; i++)
			arr[i] = GenerateKey(CharType, Wordlength);
	}

	static string Tabs(short NumberOfTabs)
	{
		string t = "";

		for (int i = 1; i < NumberOfTabs; i++)
		{
			t = t + "\t";
			cout << t;
		}
		return t;

	}

};
