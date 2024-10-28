#pragma once

#include <iostream>

using namespace std;

class clsPerson
{

private:

	string _FirstName, _LastName, _Email, _PhoneNumber;

public:

	clsPerson(string FirstName, string LastName, string Email, string PhoneNumber) {

		_FirstName = FirstName;
		_LastName = LastName;
		_Email = Email;
		_PhoneNumber = PhoneNumber;

	}

	//Set & Get.
	void SetFirstName(string FirstName) {

		_FirstName = FirstName;
	}
	string GetFirstName() {

		return _FirstName;

	}

	void SetLastName(string LastName) {

		_LastName = LastName;
	}
	string GetLastName() {

		return _LastName;

	}

	string GetFullName() {

		return _FirstName + " " + _LastName;

	}

	void SetEmail(string Email) {

		_Email = Email;
	}
	string GetEmail() {

		return _Email;

	}

	void SetPhoneNumber(string PhoneNumber) {

		_PhoneNumber = PhoneNumber;
	}
	string GetPhoneNumber() {

		return _PhoneNumber;

	}

	__declspec(property(get = GetFirstName, put = SetFirstName)) string FirstName;
	__declspec(property(get = GetLastName, put = SetLastName)) string LastName;
	__declspec(property(get = GetEmail, put = SetEmail)) string Email;
	__declspec(property(get = GetPhoneNumber, put = SetPhoneNumber)) string PhoneNumber;
	//_______________.

	void SendEmail(string Title, string Body)
	{

		cout << "Subject: " << Title << endl;
		cout << Body << endl;

		cout << "Email Sent Succfully to:" << this->Email;
	}

	void SendFax(string Title, string Body)
	{

	}

	void SendSMS(string Title, string Body)
	{
		cout << "Subject: " << Title << endl;
		cout << Body << endl;

		cout << "Sms Sent Succfully to:" << this->PhoneNumber;

	}


};
