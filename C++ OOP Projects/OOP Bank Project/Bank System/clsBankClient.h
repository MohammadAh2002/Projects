#pragma once

#include <iostream>
#include "clsUtil.h"

using namespace std;

const string ClientsFile = "ClintsInfoFile.txt";
const string TransferFile = "TransferFile.txt";

class clsBankClient : public clsPerson
{
private:

	enum enMode {EmptyMode = 0, UpdateMode = 1, AddNewMode = 2};

	enMode _Mode;	

	string _AccountNumber, _PinCode;
	float _AccountBalance;

	static clsBankClient _ConvertStringToClientObject(string Line,string Sprator = ",") {

		vector <string> VClientData = clsString::SplitStringInVector(Line, Sprator);

		return clsBankClient(enMode::UpdateMode, VClientData[0], VClientData[1], VClientData[2],
			VClientData[3], VClientData[4], VClientData[5], stof(VClientData[6]));
	}	
	static string _ConverClientObjectToString(clsBankClient Client, string Seperator = ",")
	{

		string stClientRecord = "";
		stClientRecord += Client.FirstName + Seperator;
		stClientRecord += Client.LastName + Seperator;
		stClientRecord += Client.Email + Seperator;
		stClientRecord += Client.PhoneNumber + Seperator;
		stClientRecord += Client.GetAccountNumber() + Seperator;
		stClientRecord += Client.PinCode + Seperator;
		stClientRecord += to_string(Client.AccountBalance);

		return stClientRecord;

	}
	static void _SaveCleintsDataToFile(vector <clsBankClient>& vClients)
	{

		fstream MyFile;
		MyFile.open(ClientsFile, ios::out);//overwrite

		string DataLine;

		if (MyFile.is_open())
		{

			for (clsBankClient& C : vClients)
			{
				DataLine = _ConverClientObjectToString(C);
				MyFile << DataLine << endl;

			}

			MyFile.close();

		}

	}
	void _Update()
	{
		vector <clsBankClient> _vClients = _LoadClientsDataFromFile();

		for (clsBankClient& C : _vClients)
		{
			if (C.GetAccountNumber() == GetAccountNumber())
			{
				C = *this;
				break;
			}

		}

		_SaveCleintsDataToFile(_vClients);

	}

	static clsBankClient _GetEmptyClientObject() {

		return clsBankClient(enMode::EmptyMode, "", "", "", "", "", "", 0);

	}

	void _AddDataLineToFile(string stDataLine)
	{
		fstream MyFile;
		MyFile.open(ClientsFile, ios::out | ios::app);

		if (MyFile.is_open())
		{

			MyFile << stDataLine << endl;

			MyFile.close();
		}

	}
	
	void _AddNew()
	{

		_AddDataLineToFile(_ConverClientObjectToString(*this));
	}

	static void PrintClientRecordLine(clsBankClient Client)
	{

		cout << "| " << setw(15) << left << Client.GetAccountNumber();
		cout << "| " << setw(20) << left << Client.GetFullName();
		cout << "| " << setw(12) << left << Client.PhoneNumber;
		cout << "| " << setw(20) << left << Client.Email;
		cout << "| " << setw(10) << left << Client.PinCode;
		cout << "| " << setw(12) << left << Client.AccountBalance;

	}

	static void PrintClientRecordBalanceLine(clsBankClient Client)
	{

		cout << "| " << setw(15) << left << Client.GetAccountNumber();
		cout << "| " << setw(40) << left << Client.GetFullName();
		cout << "| " << setw(12) << left << Client.AccountBalance;

	}
	
	static string _PrepareTransferRecord(clsBankClient ClientFrom, clsBankClient ClientTo,
										 float Amount,  string Seperator = ",")
	{
		
		return clsDate::GetSystemDateTimeString() + Seperator +
			ClientFrom.GetAccountNumber() + Seperator +
			ClientTo.GetAccountNumber() + Seperator +
			to_string(Amount) + Seperator +
			to_string(ClientFrom.GetAccountBalance()) + Seperator +
			to_string(ClientTo.GetAccountBalance()) + Seperator +
			CurrentUser.UserName;

	}


	struct stTrnsferLogRecord;

	static stTrnsferLogRecord _ConvertTransferLogLineToRecord(string Line, string Seperator = ",")
	{
		stTrnsferLogRecord TrnsferLogRecord;

		vector <string> vTrnsferLogRecordLine = clsString::SplitStringInVector(Line, Seperator);
		TrnsferLogRecord.DateTime = vTrnsferLogRecordLine[0];
		TrnsferLogRecord.SourceAccountNumber = vTrnsferLogRecordLine[1];
		TrnsferLogRecord.DestinationAccountNumber = vTrnsferLogRecordLine[2];
		TrnsferLogRecord.Amount = stod(vTrnsferLogRecordLine[3]);
		TrnsferLogRecord.srcBalanceAfter = stod(vTrnsferLogRecordLine[4]);
		TrnsferLogRecord.destBalanceAfter = stod(vTrnsferLogRecordLine[5]);
		TrnsferLogRecord.UserName = vTrnsferLogRecordLine[6];

		return TrnsferLogRecord;

	}

public:

	struct stTrnsferLogRecord
	{
		string DateTime;
		string SourceAccountNumber;
		string DestinationAccountNumber;
		float Amount;
		float srcBalanceAfter;
		float destBalanceAfter;
		string UserName;

	};


	clsBankClient(enMode Mode, string FirstName, string LastName, string Email,
		          string PhoneNumber, string AccountNumber,
	        	  string PinCode, float AccountBalance) :
				  clsPerson(FirstName, LastName, Email, PhoneNumber) {

		_Mode = Mode;
		_AccountNumber = AccountNumber;
		_PinCode = PinCode;
		_AccountBalance = AccountBalance;

	}


	bool IsEmpty() {

		return (_Mode == enMode::EmptyMode);

	}

	//Set & Get.
	string GetAccountNumber() {

		return _AccountNumber;

	}

	void SetPinCode(string PinCode) {

		_PinCode = PinCode;
	}
	string GetPinCode() {

		return _PinCode;

	}

	void SetAccountBalance(float AccountBalance) {

		_AccountBalance = AccountBalance;
	}
	float GetAccountBalance() {

		return _AccountBalance;

	}

	__declspec(property(get = GetAccountBalance, put = SetAccountBalance)) float AccountBalance;
	__declspec(property(get = GetPinCode, put = SetPinCode)) string PinCode;
	//_______________.
	static  vector <clsBankClient> _LoadClientsDataFromFile()
	{

		vector <clsBankClient> vClients;

		fstream MyFile;
		MyFile.open(ClientsFile, ios::in);//read Mode

		if (MyFile.is_open())
		{

			string Line;


			while (getline(MyFile, Line))
			{

				clsBankClient Client = _ConvertStringToClientObject(Line);

				vClients.push_back(Client);
			}

			MyFile.close();

		}

		return vClients;

	}

	void Print() {

		cout << "\nClient Card:\n";
		cout << "\n____________________________";
		cout << "\nFirst Name     : " << GetFirstName();
		cout << "\nLast Name      : " << GetLastName();
		cout << "\nFull Name      : " << GetFullName();
		cout << "\nEmail          : " << GetEmail();
		cout << "\nPhone Number   : " << GetPhoneNumber();
		cout << "\nAccount Number : " << GetAccountNumber();
		cout << "\nPassword       : " << GetPinCode();
		cout << "\nAccount Balance: " << GetAccountBalance();
		cout << "\n____________________________" << endl;

	}

	static clsBankClient FindClient(string AccountNumber, string PinCode) {

		clsBankClient Client = FindClient(AccountNumber);

		if (Client._PinCode == PinCode)
			return Client;
		else
			return _GetEmptyClientObject();

	}
	static clsBankClient FindClient(string AccountNumber) {

		fstream MyFile;

		MyFile.open(ClientsFile, ios::in);//read Mode

		if (MyFile.is_open())
		{

			string Line;

			while (getline(MyFile, Line))
			{
				clsBankClient Client = _ConvertStringToClientObject(Line);

				if (Client._AccountNumber == AccountNumber)
				{

					MyFile.close();
					return Client;

				}

			}

			MyFile.close();

		}

		return _GetEmptyClientObject();

	}

	static bool IsClientExist(string AccountNumber) {

		clsBankClient Client = clsBankClient::FindClient(AccountNumber);

		return (!Client.IsEmpty());
	}
	static clsBankClient GetAddNewClientObject(string AccountNumber)
	{
		return clsBankClient(enMode::AddNewMode, "", "", "", "", AccountNumber, "", 0);
	}
	static float GetTotalBalances()
	{
		vector <clsBankClient> vClients = clsBankClient::_LoadClientsDataFromFile();

		float TotalBalances = 0;

		for (clsBankClient& Client : vClients)
		{

			TotalBalances += Client.AccountBalance;
		}

		return TotalBalances;

	}

	enum enSaveResults { svFaildEmptyObject = 0, svSucceeded = 1, svFaildAccountNumberExists = 2 };

	enSaveResults Save()
	{

		switch (_Mode)
		{
		case enMode::EmptyMode:
		{

			return enSaveResults::svFaildEmptyObject;
		}

		case enMode::UpdateMode:
		{


			_Update();

			return enSaveResults::svSucceeded;

		}

		case enMode::AddNewMode:
		{
			//This will add new record to file or database
			if (clsBankClient::IsClientExist(_AccountNumber))
			{
				return enSaveResults::svFaildAccountNumberExists;
			}
			else
			{
				_AddNew();

				//We need to set the mode to update after add new
				_Mode = enMode::UpdateMode;
				return enSaveResults::svSucceeded;
			}

		}
		}
	}

	bool Delete()
	{
		vector <clsBankClient> vClients, vClients2;
		vClients = _LoadClientsDataFromFile();

		for (clsBankClient& C : vClients)
		{
			if (!(C.GetAccountNumber() == _AccountNumber))
			{

				vClients2.push_back(C);

			}

		}

		_SaveCleintsDataToFile(vClients2);

		*this = _GetEmptyClientObject();

		return true;

	}

	void Deposit(double Amount)
	{
		_AccountBalance += Amount;
		Save();
	}

	bool Withdraw(double Amount)
	{

		if (Amount > _AccountBalance)
			return false;

		_AccountBalance -= Amount;
		Save();
	}

	bool Transfer(float Amount, clsBankClient& DestinationClient)
	{
		if (Amount > AccountBalance)
		{
			return false;
		}

		Withdraw(Amount);
		DestinationClient.Deposit(Amount);
		RegisterTransferLog(*this, DestinationClient, Amount);
		return true;
	}

	static void RegisterTransferLog(clsBankClient ClientFrom, clsBankClient ClientTo,float Amount)
	{

		string stDataLine = _PrepareTransferRecord(ClientFrom, ClientTo,Amount);

		fstream MyFile;
		MyFile.open(TransferFile, ios::out | ios::app);

		if (MyFile.is_open())
		{

			MyFile << stDataLine << endl;

			MyFile.close();
		}

	}

	static  vector <stTrnsferLogRecord> GetTransfersLogList()
	{
		vector <stTrnsferLogRecord> vTransferLogRecord;

		fstream MyFile;
		MyFile.open(TransferFile, ios::in);//read Mode

		if (MyFile.is_open())
		{

			string Line;

			stTrnsferLogRecord TransferRecord;

			while (getline(MyFile, Line))
			{

				TransferRecord = _ConvertTransferLogLineToRecord(Line);

				vTransferLogRecord.push_back(TransferRecord);

			}

			MyFile.close();

		}

		return vTransferLogRecord;

	}

};

