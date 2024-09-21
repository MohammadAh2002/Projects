/*

	Write a Small Bank Project Using Console.
	
	requirement:
	
	Main Menu Screen:
		1- List All Clients
		2- Find Client
		3- Add Client
		4- Delete Cleint
		5- Update Client
		6- Exit
		7- Transactions (go to the Transactions Menu)

	Transactions Menu Screen:
		1- Deposit
		2- Withdraw
		3- Total Balances
		4- Main Menue (Get you Back to main Menu)

	- the User Should Navigate the Program With Numbers in Keyboard.
	- Use Text File as a Database.

	Client Should be Stored in the File in This Format:
		a150#//#1234#//#mohammad#//#87313#//#400
		b150#//#9876#//#ahmad#//#456435798#//#500
		c150#//#5913#//#koko#//#456478435#//#900

*/

#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <iomanip>

using namespace std;

const string ClientsFile = "ClintsInfoFile.text";

struct StClientData {

	string AccountNumber, Name, PhoneNumber, PinCode;
	int AccountBalance;
	bool Update = false, Delete = false;

};

enum enMainMenueOption {
	enShowClints = 1, enAddClint = 2, enDeleteClint = 3,
	enUpdateClient = 4, enFindClient = 5,
	enTransactions = 6, enExit = 7
};

enum enTransactionsOptins {
	enDeposit = 1, enWithdraw = 2,
	enTotalBalances = 3, enMainMenue = 4
};

void ResetScreen() {

	system("cls");

}

void PrintMainMenue() {

	ResetScreen();

	cout << "==========================================\n";
	cout << "\t\tMain Menue Screen\n";
	cout << "==========================================\n";
	cout << "\t[1] Show Clients List.\n";
	cout << "\t[2] Add New Client.\n";
	cout << "\t[3] Delete Client.\n";
	cout << "\t[4] Update Client.\n";
	cout << "\t[5] Find Client.\n";
	cout << "\t[6] Transactions.\n";
	cout << "\t[7] Exit.\n";
	cout << "==========================================\n";

}

enMainMenueOption ReadMenuePickInRange(int from, int to) {

	int Pick;

	printf("Choose what do you want to do?[%d-%d]?", from, to);
	cin >> Pick;

	while (cin.fail() || Pick <from || Pick > to) {

		cin.clear();
		cin.ignore(numeric_limits<streamsize>::max(), '\n');

		cout << "You have entered wrong input(try again).\n";
		printf("Choose what do you want to do?[%d-%d]?", from, to);
		cin >> Pick;

	}

	return enMainMenueOption(Pick);

}

void ClientsDetialsHeder(vector <StClientData>& Vclients) {

	cout << "\t\t\t\tclients list (" << Vclients.size() << ") clients(s)\n";
	cout << "_______________________________________________________________________________________________\n";
	cout << setw(20) << left << "| account number";
	cout << setw(20) << left << "| pin code";
	cout << setw(20) << left << "| name";
	cout << setw(20) << left << "| phone";
	cout << setw(20) << left << "| balance" << endl;
	cout << "_______________________________________________________________________________________________\n";

}

void ClientsDetails(StClientData& c) {

	cout << "|" << setw(19) << left << c.AccountNumber;
	cout << "|" << setw(19) << left << c.PinCode;
	cout << "|" << setw(19) << left << c.Name;
	cout << "|" << setw(19) << left << c.PhoneNumber;
	cout << "|" << setw(19) << left << c.AccountBalance;
	cout << endl;

}

void PrintClientDetails(StClientData& c) {

	cout << "\nthe folowing is the clint details:\n";
	cout << "------------------------------------------\n";
	cout << "account number : " << c.AccountNumber << endl;
	cout << "pin code       : " << c.PinCode << endl;
	cout << "name           : " << c.Name << endl;
	cout << "phone number   : " << c.PhoneNumber << endl;
	cout << "account balance: " << c.AccountBalance << endl;
	cout << "------------------------------------------\n\n";

}

string AddClientDataInString(StClientData ClData, string Sparater = "#//#") {

	string word;

	word += ClData.AccountNumber + Sparater;
	word += ClData.PinCode + Sparater;
	word += ClData.Name + Sparater;
	word += ClData.PhoneNumber + Sparater;
	word += to_string(ClData.AccountBalance);

	return word;

}

void PutClientStringDataInFile(string FileName, string s) {

	fstream ClientFile;

	ClientFile.open(FileName, ios::out | ios::app);

	if (ClientFile.is_open()) {

		ClientFile << s << endl;

	}

	ClientFile.close();
}

vector<string> PutStringToVector(string S1, string Sparator = "#//#") {

	vector<string> vString;
	short pos = 0;
	string sWord; // define a string variable

	// use find() function to get the position of the delimiters
	while ((pos = S1.find(Sparator)) != std::string::npos)
	{
		sWord = S1.substr(0, pos); // store the word
		if (sWord != "")
		{
			vString.push_back(sWord);
		}
		S1.erase(0, pos + Sparator.length());
	}
	if (S1 != "")
	{
		vString.push_back(S1); // it adds last word of the string.
	}

	return vString;

}

StClientData PutStringToStruct(string S1) {

	StClientData Client;

	vector <string> vS1;

	vS1 = PutStringToVector(S1);

	Client.AccountNumber = vS1[0];
	Client.PinCode = vS1[1];
	Client.Name = vS1[2];
	Client.PhoneNumber = vS1[3];
	Client.AccountBalance = stoi(vS1[4]);

	return Client;
}

vector <StClientData> LoadClientsFromFileToVector(string FileName) {

	vector <StClientData> Vclients;
	fstream MyFile;
	string line;

	MyFile.open(FileName, ios::in);

	if (MyFile.is_open()) {

		while (getline(MyFile, line)) {

			Vclients.push_back(PutStringToStruct(line));

		}

		MyFile.close();

	}

	return Vclients;

}

bool CheckIfAccountExist(vector <StClientData>& v, StClientData& AccountNumCheck) {

	for (StClientData& c : v) {

		if (c.AccountNumber == AccountNumCheck.AccountNumber) {

			return true;

		}
	}

	return false;
}

void MarkClient(vector <StClientData>& V1, string AccountNum, char DorU) {

	for (StClientData& c : V1) {

		if (c.AccountNumber == AccountNum) {

				switch (DorU)
				{
				case 'D':
				case 'd':
					c.Delete = true;
					return;
				case 'U':
				case 'u':
					c.Update = true;
					return;
				}

			}
	}
}

StClientData ReadClientData(vector <StClientData>& V1) {

	StClientData ClData;

	do {

		cout << "what is the account number: ";
		getline(cin >> ws, ClData.AccountNumber);

		if (CheckIfAccountExist(V1, ClData)) {
			cout << "we already have this account number try another one\n" << endl;

		}
		else {
			break;
		}

	} while (true);

	cout << "what is the pin pincode: ";
	cin >> ClData.PinCode;
	cin.ignore(100, '\n');

	cout << "what is the name: ";
	getline(cin, ClData.Name);

	cout << "what is the phone number: ";
	getline(cin, ClData.PhoneNumber);

	cout << "what is the account balance: ";
	cin >> ClData.AccountBalance;

	return ClData;

}

string ReadAccountNumber() {

	string AcoountNumberSearch;

	cout << "what is the number of the account:";
	getline(cin >> ws, AcoountNumberSearch);

	return AcoountNumberSearch;

}

bool FindClientInFile(string AcoountNumberSearch, StClientData& c1, vector <StClientData>& V1) {

	for (StClientData& c : V1) {

		if (AcoountNumberSearch == c.AccountNumber) {
				c1 = c;
				return true;
			}
	}

	return false;
}

void FillTheFileWithNewInfo(string FileName, vector <StClientData>& V1) {

	string Line;
	fstream MyFile;

	MyFile.open(FileName, ios::out);

	if (MyFile.is_open()) {

		for (StClientData& c : V1) {

			Line = AddClientDataInString(c);
			MyFile << Line << endl;
		}

		MyFile.close();
	}

}

void ReadUpdatedClientData(StClientData& ClData, string accountnum) {

	ClData.AccountNumber = accountnum;

	cout << "what is the new pin pincode: ";
	getline(cin >> ws, ClData.PinCode);

	cout << "what is the new name: ";
	getline(cin, ClData.Name);

	cout << "what is the new phone number: ";
	getline(cin, ClData.PhoneNumber);

	cout << "what is the new account balance: ";
	cin >> ClData.AccountBalance;

	ClData.Update = false;

}

void PauseScreen() {

	cout << "\nPress Any to go back to main menue...";
	system("pause>0");

}

bool MakeSure(string maseege) {

	char Answer;

	cout << "are you sure you want to " << maseege << " - Y/N ? \n";
	cin >> Answer;

	if (tolower(Answer) == 'y')
		return true;

	return false;
}

void ScreenHeder(string Massege) {

	cout << "---------------------------------------\n";
	cout << "\t" << Massege << " Client Screen\n";
	cout << "---------------------------------------\n";

}

void UpdateVector(vector <StClientData>& V1, string Accountnum) {

	for (StClientData& c : V1) {

		if (c.Update) {

			ReadUpdatedClientData(c, Accountnum);
			return;
		}
	}
}

void DeletClientFromVector(vector <StClientData>& v, string AccountNum) {

	vector <StClientData> v2;

	for (StClientData& c : v) {

		if (c.AccountNumber != AccountNum) {

			v2.push_back(c);
		}

	}
	v = v2;
}

void EndScreen() {

	ResetScreen();

	cout << "---------------------------------------\n";
	cout << "\tProgram Ends:-)\n";
	cout << "---------------------------------------\n";


}

void PrintTransactionsMenueScreen() {

	cout << "==========================================\n";
	cout << "\tTransactions Menue Screen\n";
	cout << "==========================================\n";
	cout << "\t[1] Deposit.\n";
	cout << "\t[2] Withdraw.\n";
	cout << "\t[3] Total Balances.\n";
	cout << "\t[4] Main Menue.\n";
	cout << "==========================================\n";

}

void AddMoneyToAccount(vector <StClientData>& V1, string AccNum) {

	int num;

	for (StClientData& c : V1) {

		if (c.AccountNumber == AccNum) {

			cout << "how much you want to Deposit: ";
			cin >> num;
			c.AccountBalance += num;
			return;
		}
	}
}

void TakeMoneyFromAccount(vector <StClientData>& V1, string AccNum) {

	int num;

	for (StClientData& c : V1) {

		if (c.AccountNumber == AccNum) {

			cout << "how much you want to Withdraw : ";
			cin >> num;

			while (num > c.AccountBalance) {

				cout << "Amount Exceeds the balance, you can withdraw up to:" << c.AccountBalance << ".\n";
				cout << "how much you want to Withdraw : ";
				cin >> num;
			}

			c.AccountBalance -= num;
			return;
		}
	}
}

void TotalBalanceClientsHeader(vector <StClientData>& Vclients) {

	cout << "\t\t\t\tclients list (" << Vclients.size() << ") clients(s)\n";
	cout << "_______________________________________________________________________________________________\n";
	cout << setw(20) << left << "| account number";
	cout << setw(20) << left << "| name";
	cout << setw(20) << left << "| balance" << endl;
	cout << "_______________________________________________________________________________________________\n";

}

void TotalBalanceClientsDetails(StClientData& c) {

	cout << "|" << setw(19) << left << c.AccountNumber;
	cout << "|" << setw(19) << left << c.Name;
	cout << "|" << setw(19) << left << c.AccountBalance;
	cout << endl;


}

// Main Functions.

void PrintClients(string FileName, vector <StClientData>& V1) {

	ResetScreen();

	if (V1.size() == 0) {

		cout << "you dont have any clints :-(\n";
		return;
	}

	ClientsDetialsHeder(V1);

	for (StClientData& c : V1) {

		ClientsDetails(c);

	}

	cout << "_______________________________________________________________________________________________\n";

}

void AddClient(string FileName, vector <StClientData>& V1) {

	ResetScreen();

	char more;

	do {

		ScreenHeder("Add");
		cout << "Adding New Client:\n\n";

		PutClientStringDataInFile(FileName, AddClientDataInString(ReadClientData(V1)));
		cout << "client added successfully.\n";

		cout << "do you want to add more clients?Y/N\n";
		cin >> more;

		if (tolower(more) == 'y')
			system("cls");

	} while (tolower(more) == 'y');

}

void DeleteClient(string FileName, vector <StClientData>& V1) {

	ResetScreen();

	ScreenHeder("Delete");

	string AccountNum;
	StClientData c;

	AccountNum = ReadAccountNumber();

	if (FindClientInFile(AccountNum, c, V1)) {

		PrintClientDetails(c);

		if (MakeSure("Delete")) {

			MarkClient(V1, AccountNum, 'D');

			DeletClientFromVector(V1, AccountNum);

			FillTheFileWithNewInfo(FileName, V1);

			cout << "Clint deleted Scssfuly.\n";

		}
		else {

			cout << "ok as you want\n";

		}
	}
	else {

		cout << "Client Not Found!.\n";

	}

	PauseScreen();

}

void UpdateClient(string FileName, vector <StClientData>& V1) {

	ResetScreen();
	ScreenHeder("Update");

	string AccountNum;
	StClientData c;

	AccountNum = ReadAccountNumber();

	if (FindClientInFile(AccountNum, c, V1)) {

		PrintClientDetails(c);

		MarkClient(V1, AccountNum, 'U');

		UpdateVector(V1, AccountNum);

		if (MakeSure("Update")) {

			FillTheFileWithNewInfo(FileName, V1);

			cout << "Clint Updated succfuly.\n";
		}
		else {

			cout << "ok as you want\n";

		}
	}
	else {

		cout << "Client Not Found!.\n";

	}

	PauseScreen();

}

void FindClient(string FileName, vector <StClientData>& V1) {

	ResetScreen();

	StClientData StClients;

	ScreenHeder("Find");

	if (FindClientInFile(ReadAccountNumber(), StClients, V1)) {

		PrintClientDetails(StClients);

	}
	else {

		cout << "client not found!\n";
	}

	PauseScreen();
}

void Deposit(string FileName, vector <StClientData>& V) {

	ResetScreen();
	ScreenHeder("Deposit");

	string AccountNum;
	StClientData c;

	AccountNum = ReadAccountNumber();

	if (FindClientInFile(AccountNum, c, V)) {

		PrintClientDetails(c);

		AddMoneyToAccount(V, AccountNum);

		if (MakeSure("Deposit")) {

			FillTheFileWithNewInfo(FileName, V);

			cout << "Deposit succfuly..\n";

		}
		else {

			cout << "ok as you want\n";

		}
	}
	else {

		cout << "Client Not Found!.\n";

	}

	PauseScreen();

}

void Withdraw(string FileName, vector <StClientData>& V) {

	ResetScreen();
	ScreenHeder("Withdraw");

	string AccountNum;
	StClientData c;

	AccountNum = ReadAccountNumber();

	if (FindClientInFile(AccountNum, c, V)) {

		PrintClientDetails(c);

		TakeMoneyFromAccount(V, AccountNum);


		if (MakeSure("Withdraw")) {

			FillTheFileWithNewInfo(FileName, V);

			cout << "Withdraw succfuly..\n";

		}
		else {

			cout << "ok as you want\n";

		}
	}
	else {

		cout << "Client Not Found!.\n";

	}

	PauseScreen();

}

void TotalBalances(string FileName, vector <StClientData>& V) {

	ResetScreen();

	if (V.size() == 0) {

		cout << "you dont have any clints :-(\n";
		return;

	}

	TotalBalanceClientsHeader(V);

	double BalnceCount = 0;

	for (StClientData& c : V) {

		TotalBalanceClientsDetails(c);

		BalnceCount += c.AccountBalance;
	}

	cout << "_______________________________________________________________________________________________\n";

	cout << "\t\ttotal balances = " << BalnceCount << endl;

	PauseScreen();

}

void Transactions(string FileName, vector <StClientData>& V1) {

	bool BackToMainMenue = true;

	do {

		ResetScreen();
		PrintTransactionsMenueScreen();

		switch (ReadMenuePickInRange(1, 4)) {

		case enTransactionsOptins::enDeposit:
			Deposit(FileName, V1);
			break;
		case enTransactionsOptins::enWithdraw:
			Withdraw(FileName, V1);
			break;
		case enTransactionsOptins::enTotalBalances:
			TotalBalances(FileName, V1);
			break;
		case enTransactionsOptins::enMainMenue:
			BackToMainMenue = false;
			break;
		}

	} while (BackToMainMenue);
}

void StartProject() {

    bool exit = true;

    do {

        PrintMainMenue();

        vector <StClientData> V1 = LoadClientsFromFileToVector(ClientsFile);

        switch (ReadMenuePickInRange(1, 7)) {

			case enMainMenueOption::enShowClints:
			    PrintClients(ClientsFile, V1);
				PauseScreen();
			    break;
			case enMainMenueOption::enAddClint:
			    AddClient(ClientsFile, V1);
			    break;
			case enMainMenueOption::enDeleteClint:
			    DeleteClient(ClientsFile, V1);
			    break;

			case enMainMenueOption::enUpdateClient:
			    UpdateClient(ClientsFile, V1);
			    break;

			case enMainMenueOption::enFindClient:
			    FindClient(ClientsFile, V1);
			    break;
			case enMainMenueOption::enTransactions:
			    Transactions(ClientsFile, V1);
			    break;
			case enMainMenueOption::enExit:
			    EndScreen();
			    exit = false;
			    break;

        }

    } while (exit);

}

int main()
{
    
    StartProject();

    return 0;
}
