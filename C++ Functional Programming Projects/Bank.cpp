/*

    Write a Small Bank Project Using Console.

    requirement:

	Login Screen:
		- Username
		- Password

    Main Menu Screen:
        1- List All Clients
        2- Find Client
        3- Add Client
        4- Delete Cleint
        5- Update Client
        6- Exit (Close the Program)
        7- Transactions (go to the Transactions Menu)
		8- Logout (go to the Login Screen)
		9- Manage Users (go to the Manage Users Screen)

    Transactions Menu Screen:
        1- Deposit
        2- Withdraw
        3- Total Balances
        4- Main Menue (Get you Back to Main Menu)

	Manage Users Menu Screen:
		1- List All Users
		2- Find User
		3- Add User
		4- Delete User
		5- Update User
		6- Main Menu Scrren (get you Back to Main Menu)

    - the User Should Navigate the Program With Numbers in Keyboard.
    - Use Text File as a Database.

	Permissions:
	- to do any Operation the User Should Have a Permission to do it so Make a Permissions System in Your Program.
	- the User Should not be able to do any Operation he dont have Permission to it.

    -------------------------------------------------------------

	Client Data:

    - in the Start You don't have any Client you should add them the do the other Operations
	- you can Start the Program With no Client and Add them in the Program.
	- You can Creat A file With Client Data and Start the Program With Clients.

	How to Start with Clients:
	
	1- Create A Text File Called: ClintsInfoFile.
	2- Cope the Data below to the File.
	3- Make Sure there is no Spaces Before and After the Data.
	4- Change the ClientsFile Variable Value to the File Path.

	Client Should be Stored in the File in This Format:
		a150#//#1234#//#mohammad#//#87313#//#400
		b150#//#9876#//#ahmad#//#456435798#//#500
		c150#//#5913#//#koko#//#456478435#//#900

		- Field 1: Account Number
		- Field 2: Pin Code
		- Field 3: Name
		- Field 4: Phone Number
		- Field 5: Balance

	User Data:

	- When you run the Program you well See the Login Screen
	  so you Should Already Have Some Users to Enter the System.
	- Follow the Steps to Enter the System and add Users.

	1- Create A Text File Called: UsersInfoFile.
	2- Cope the Data below to the File.
	3- Make Sure there is no Spaces Before and After the Data.
	4- Change the UsersFile Variable Value to the File Path.

	Users Should be Stored in the File in This Format:
		Admin#//#1234#//#-1#//#
		user1#//#5678#//#17#//#
		user2#//#1234#//#-1#//#
		user3#//#9876#//#49#//#

		- Field 1: Username
		- Field 2: Password
		- Field 3: Permissions

*/

#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <iomanip>

using namespace std;

struct StClientData {

    string AccountNumber, Name, PhoneNumber, PinCode;
    int AccountBalance;
    bool Update = false, Delete = false;

};

enum enMainMenueOption {
    enShowClints = 1, enAddClint = 2, enDeleteClint = 3,
    enUpdateClient = 4, enFindClient = 5,
    enTransactions = 6, enManageUsers = 7, enLogout = 8, enEndProgram = 9
};
enum enTransactionsOptins {
    enDeposit = 1, enWithdraw = 2,
    enTotalBalances = 3, enTransactionsToMainMenue = 4
};

const string ClientsFile = "ClintsInfoFile.text";

struct stUser {

	string UserName, Password;
	short Permissions;

};
stUser CurrentUser;

enum enUserMenueOptions {

	enShowUsers = 1, enAddUsers = 2, enDeleteUsers = 3,
	enUpdateUsers = 4, enFindUsers = 5,
	enUserToMainMenue = 6

};
enum enPermissions {
	enAll = -1, enPShowClints = 1, enPAddClint = 2, enPDeleteClint = 4,
	enPUpdateClient = 8, enPFindClient = 16,
	enPTransactions = 32, enPManageUsers = 64
};

const string UsersFile = "UsersInfoFile.txt";

//Part 1.

void ResetScreen() {

	system("cls");

}

void MainMenue() {

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
	cout << "\t[7] Manage Users\n";
	cout << "\t[8] Logut.\n";
	cout << "\t[9] End Program.\n";
	cout << "==========================================\n";

}

enMainMenueOption ReadMenuePick(int from, int to) {

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

void ShowOneClientDetails(StClientData& c) {

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

StClientData PutClientStringToStruct(string S1) {

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

			Vclients.push_back(PutClientStringToStruct(line));

		}

		MyFile.close();

	}

	return Vclients;

}

bool CheckIfClientExist(vector <StClientData>& v, StClientData& AccountNumCheck) {

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

		if (CheckIfClientExist(V1, ClData)) {
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

void FillTheClientsFileWithNewInfo(string FileName, vector <StClientData>& V1) {

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
	cout << "\t" << Massege << "Screen\n";
	cout << "---------------------------------------\n";

}

void UpdateClientsVector(vector <StClientData>& V1, string Accountnum) {

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

// Main Functions.

void PrintClients(string FileName, vector <StClientData>& V1) {

	ResetScreen();

	if (V1.size() == 0) {

		cout << "you dont have any clints :-(\n";
		return;
	}


	ClientsDetialsHeder(V1);

	for (StClientData& c : V1)
		ClientsDetails(c);

	cout << "_______________________________________________________________________________________________\n";

	PauseScreen();

}

void AddClient(string FileName, vector <StClientData>& V1) {

	ResetScreen();

	char more;

	do {

		ScreenHeder("Add Client ");
		cout << "Adding New Client:\n\n";

		PutClientStringDataInFile(FileName, AddClientDataInString(ReadClientData(V1)));
		cout << "\nclient added successfully.\n";

		cout << "\ndo you want to add more clients?Y/N?\n";
		cin >> more;

		if (tolower(more) == 'y')
			ResetScreen();

	} while (tolower(more) == 'y');

}

void DeleteClient(string FileName, vector <StClientData>& V1) {

	ResetScreen();

	ScreenHeder("Delete Client ");

	string AccountNum;
	StClientData c;

	AccountNum = ReadAccountNumber();

	if (FindClientInFile(AccountNum, c, V1)) {

		ShowOneClientDetails(c);

		if (MakeSure("Delete")) {

			MarkClient(V1, AccountNum, 'D');

			DeletClientFromVector(V1, AccountNum);

			FillTheClientsFileWithNewInfo(FileName, V1);

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
	ScreenHeder("Update Client ");

	string AccountNum;
	StClientData c;

	AccountNum = ReadAccountNumber();

	if (FindClientInFile(AccountNum, c, V1)) {

		ShowOneClientDetails(c);

		MarkClient(V1, AccountNum, 'U');

		UpdateClientsVector(V1, AccountNum);

		if (MakeSure("Update")) {

			FillTheClientsFileWithNewInfo(FileName, V1);

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

	ScreenHeder("Find Client ");

	if (FindClientInFile(ReadAccountNumber(), StClients, V1)) {

		ShowOneClientDetails(StClients);

	}
	else {

		cout << "client not found!\n";
	}

	PauseScreen();
}

void EndScreen() {

	ResetScreen();

	cout << "---------------------------------------\n";
	cout << "\tProgram Ends:-)\n";
	cout << "---------------------------------------\n";


}

// Part 2.

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
void Deposit(string FileName, vector <StClientData>& V) {

	ResetScreen();
	ScreenHeder("Deposit ");

	string AccountNum;
	StClientData c;

	AccountNum = ReadAccountNumber();

	if (FindClientInFile(AccountNum, c, V)) {

		ShowOneClientDetails(c);

		AddMoneyToAccount(V, AccountNum);

		if (MakeSure("Deposit")) {

			FillTheClientsFileWithNewInfo(FileName, V);

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
	ScreenHeder("Withdraw ");

	string AccountNum;
	StClientData c;

	AccountNum = ReadAccountNumber();

	if (FindClientInFile(AccountNum, c, V)) {

		ShowOneClientDetails(c);

		TakeMoneyFromAccount(V, AccountNum);


		if (MakeSure("Withdraw")) {

			FillTheClientsFileWithNewInfo(FileName, V);

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

		switch (ReadMenuePick(1, 4)) {

		case enTransactionsOptins::enDeposit:
			Deposit(FileName, V1);
			break;
		case enTransactionsOptins::enWithdraw:
			Withdraw(FileName, V1);
			break;
		case enTransactionsOptins::enTotalBalances:
			TotalBalances(FileName, V1);
			break;
		case enTransactionsOptins::enTransactionsToMainMenue:
			BackToMainMenue = false;
			break;
		}

	} while (BackToMainMenue);
}


// File Functions.
string AddUserDataInString(stUser UserData, string Sparater = "#//#") {

	string word;

	word += UserData.UserName + Sparater;
	word += UserData.Password + Sparater;
	word += to_string(UserData.Permissions) + Sparater;

	return word;

}
void PutUserStringDataInFile(string FileName, string s) {

	fstream UserFile;

	UserFile.open(FileName, ios::out | ios::app);

	if (UserFile.is_open()) {

		UserFile << s << endl;

	}
	UserFile.close();
}
stUser PutUserStringToStruct(string S1) {

	stUser User;

	vector <string> vS1;

	vS1 = PutStringToVector(S1);

	User.UserName = vS1[0];
	User.Password = vS1[1];
	User.Permissions = stoi(vS1[2]);

	return User;
}
void FillTheUsersFileWithNewInfo(string FileName, vector <stUser>& V1) {

	string Line;
	fstream MyFile;

	MyFile.open(FileName, ios::out);

	if (MyFile.is_open()) {

		for (stUser& c : V1) {

			Line = AddUserDataInString(c);
			MyFile << Line << endl;
		}

		MyFile.close();
	}

}
vector <stUser> LoadUsersFromFileToVector(string FileName) {

	vector <stUser> Vusers;
	fstream MyFile;
	string line;

	MyFile.open(FileName, ios::in);

	if (MyFile.is_open()) {

		while (getline(MyFile, line)) {

			Vusers.push_back(PutUserStringToStruct(line));

		}

		MyFile.close();

	}

	return Vusers;

}
//-------------.

// Check Functions.
bool CheckIfUserExist(vector <stUser>& v, stUser& Account) {

	for (stUser& u : v) {

		if ((u.UserName == Account.UserName) && (u.Password == Account.Password)) {
			Account = u;
			return true;

		}

	}

	return false;

}
bool CheckIfUsernameExist(vector <stUser>& v, stUser username) {

	for (stUser& u : v) {

		if (u.UserName == username.UserName) {

			return true;
		}

	}

	return false;

}
//-------------.

// Random Functions.
string StringToLower(string S1) {

	for (int i = 0; i < S1.length(); i++) {

		S1[i] = tolower(S1[i]);

	}

	return S1;

}
//-------------.

// Print Functions.
void UsersMainMenue() {

	ResetScreen();

	cout << "==========================================\n";
	cout << "\tManage Users Screen\n";
	cout << "==========================================\n";
	cout << "\t[1] List Users.\n";
	cout << "\t[2] Add New User.\n";
	cout << "\t[3] Delete User.\n";
	cout << "\t[4] Update User.\n";
	cout << "\t[5] Find User.\n";
	cout << "\t[6] Main Menue.\n";
	cout << "==========================================\n";

}
void UserDetialsHeder(vector <stUser>& Vusers) {

	cout << "\t\t\t\tUsers list (" << Vusers.size() << ") User(s)\n";
	cout << "_______________________________________________________________________________________________\n";
	cout << setw(20) << left << "| Username";
	cout << setw(20) << left << "| Password";
	cout << setw(20) << left << "| Permissions";
	cout << "\n_______________________________________________________________________________________________\n";

}
void UserDetails(stUser& u) {

	cout << "|" << setw(19) << left << u.UserName;
	cout << "|" << setw(19) << left << u.Password;
	cout << "|" << setw(19) << left << u.Permissions;
	cout << endl;

}
void ShowOneUserDetails(stUser& u) {

	cout << "\nthe folowing is the user details:\n";
	cout << "------------------------------------------\n";
	cout << "username       : " << u.UserName << endl;
	cout << "password       : " << u.Password << endl;
	cout << "Permissions    : " << u.Permissions << endl;
	cout << "------------------------------------------\n\n";

}
//-------------.

// Read Data.
stUser ReadLogInInfo() {

	stUser user;

	cout << "Enter Username: ";
	cin >> user.UserName;

	cout << "Enter Password: ";
	cin >> user.Password;

	return user;

}
int ReadPermissions() {

	char Answer;

	cout << "\ndo you want to give full acces? Y/N? ";
	cin >> Answer;

	if (tolower(Answer) == 'y')
		return enPermissions::enAll;

	short Permissionsnum = 0;

	cout << "\ndo you want to give acces to:\n";

	cout << "\nshow client list? Y/N? ";
	cin >> Answer;

	if (tolower(Answer) == 'y')
		Permissionsnum += enPermissions::enPShowClints;

	cout << "\nadd new client? Y/N? ";
	cin >> Answer;

	if (tolower(Answer) == 'y')
		Permissionsnum += enPermissions::enPAddClint;

	cout << "\ndelete client? Y/N? ";
	cin >> Answer;

	if (tolower(Answer) == 'y')
		Permissionsnum += enPermissions::enPDeleteClint;

	cout << "\nupdate client? Y/N? ";
	cin >> Answer;

	if (tolower(Answer) == 'y')
		Permissionsnum += enPermissions::enPUpdateClient;

	cout << "\nfind client? Y/N? ";
	cin >> Answer;

	if (tolower(Answer) == 'y')
		Permissionsnum += enPermissions::enPFindClient;

	cout << "\nTransactions? Y/N? ";
	cin >> Answer;

	if (tolower(Answer) == 'y')
		Permissionsnum += enPermissions::enPTransactions;

	cout << "\nManage Users? Y/N? ";
	cin >> Answer;

	if (tolower(Answer) == 'y')
		Permissionsnum += enPermissions::enPManageUsers;

	return Permissionsnum;

}
stUser ReadUserData(vector <stUser>& V1) {

	stUser UData;

	do {

		cout << "what is the Username: ";
		getline(cin >> ws, UData.UserName);

		if (CheckIfUsernameExist(V1, UData)) {
			cout << "we already have this Username try another one\n" << endl;
			continue;
		}
		else {
			break;
		}

	} while (true);

	cout << "what is the Password: ";
	cin >> UData.Password;
	cin.ignore(100, '\n');

	UData.Permissions = ReadPermissions();

	return UData;

}
stUser ReadUserNewData(string username) {

	stUser UData;

	UData.UserName = username;

	cout << "what is the new Password: ";
	cin >> UData.Password;
	cin.ignore(100, '\n');

	UData.Permissions = ReadPermissions();

	return UData;

}
enUserMenueOptions ReadUsersMenuePick(int from, int to) {

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

	return enUserMenueOptions(Pick);
}
//-------------.

// Oprations On User Fuunctions.
void DeletUserFromVector(vector <stUser>& v, string UserName) {

	vector <stUser> v2;

	for (stUser& c : v) {

		if (c.UserName != UserName) {

			v2.push_back(c);
		}

	}
	v = v2;
}
void UpdateUsersVector(vector <stUser>& V1, string username) {

	for (stUser& u : V1) {

		if (u.UserName == username) {

			u = ReadUserNewData(u.UserName);
			return;
		}
	}
}
bool FindUserInFile(string UserName, stUser& u1, vector <stUser>& u) {

	for (stUser& user : u) {

		if (UserName == user.UserName) {
			u1 = user;
			return true;

		}
	}

	return false;
}
//-------------.

// Access Functions.
enPermissions PickInBinary(enMainMenueOption Pick) {

	switch (Pick)
	{
	case enShowClints:
		return enPermissions::enPShowClints;
	case enAddClint:
		return enPermissions::enPAddClint;
	case enDeleteClint:
		return enPermissions::enPDeleteClint;
	case enUpdateClient:
		return enPermissions::enPUpdateClient;
	case enFindClient:
		return enPermissions::enPFindClient;
	case enTransactions:
		return enPermissions::enPTransactions;
	case enManageUsers:
		return enPermissions::enPManageUsers;
	}

}
bool CheckIfAccessDenid(enMainMenueOption Pick) {

	if (CurrentUser.Permissions == enPermissions::enAll || Pick == 9 || Pick == 8)
		return true;

	if ((PickInBinary(Pick) & CurrentUser.Permissions) == PickInBinary(Pick))
		return true;

	return false;

}
void AccessDenidScreen() {

	ResetScreen();

	cout << "---------------------------------------\n";
	cout << "AccessDenid,\n";
	cout << "you dont have the Permission to do this,\n";
	cout << "Please conact your admin\n";
	cout << "---------------------------------------\n";

	PauseScreen();

}
//--------------.

// Log In Functions.
void LogIn() {

	ResetScreen();
	ScreenHeder("Login ");

	vector <stUser> UsersVector = LoadUsersFromFileToVector(UsersFile);

	stUser UserInfo = ReadLogInInfo();

	while (!CheckIfUserExist(UsersVector, UserInfo)) {

		ResetScreen();
		ScreenHeder("Login ");

		cout << "invaild username/password!\n";

		UserInfo = ReadLogInInfo();

	}

	CurrentUser = UserInfo;

}
//-------------.

// Main Functions.

void ShowUsersList(vector <stUser>& Vusers) {

	ResetScreen();

	if (Vusers.size() == 0) {

		cout << "you dont have any users :-(\n";
		return;
	}

	UserDetialsHeder(Vusers);

	for (stUser& u : Vusers)
		UserDetails(u);

	cout << "_______________________________________________________________________________________________\n";

	PauseScreen();

}

void AddUser(string FileName, vector <stUser>& Vusers) {

	ResetScreen();

	char more;

	do {

		ScreenHeder("Add User ");
		cout << "Adding New User:\n\n";

		PutUserStringDataInFile(UsersFile, AddUserDataInString(ReadUserData(Vusers)));

		cout << "\nUser added successfully.\n";

		cout << "\ndo you want to add more clients?Y/N?\n";
		cin >> more;

		if (tolower(more) == 'y')
			ResetScreen();

	} while (tolower(more) == 'y');


}

void DeleteUser(string FileName, vector <stUser>& Vusers) {

	ResetScreen();

	ScreenHeder("Delete ");

	string UserName;
	stUser user;

	cout << "what is the username: ";
	cin >> UserName;

	if (FindUserInFile(UserName, user, Vusers)) {

		if (StringToLower(user.UserName) == "admin") {

			cout << "you cant delete this user\n";
			PauseScreen();
			return;
		}

		ShowOneUserDetails(user);

		if (MakeSure("Delete")) {

			DeletUserFromVector(Vusers, user.UserName);

			FillTheUsersFileWithNewInfo(FileName, Vusers);

			cout << "User deleted Scssfuly.\n";

		}
		else {

			cout << "ok as you want\n";

		}
	}
	else {

		cout << "User Not Found!.\n";

	}

	PauseScreen();

}

void UpdateUser(string FileName, vector <stUser>& Vusers) {

	ResetScreen();
	ScreenHeder("Update User ");

	string UserName;
	stUser user;

	cout << "what is the username: ";
	cin >> UserName;

	if (FindUserInFile(UserName, user, Vusers)) {

		ShowOneUserDetails(user);

		if (MakeSure("Update")) {

			UpdateUsersVector(Vusers, UserName);

			FillTheUsersFileWithNewInfo(FileName, Vusers);

			cout << "user Updated succfuly.\n";

		}
		else {

			cout << "ok as you want\n";

		}
	}
	else {

		cout << "user Not Found!.\n";

	}

	PauseScreen();
}

void FindUser(string FileName, vector <stUser>& Vusers) {

	ResetScreen();
	ScreenHeder("Find user: ");

	string username;
	stUser user;

	cout << "what is the username";
	cin >> username;

	if (FindUserInFile(username, user, Vusers)) {

		ShowOneUserDetails(user);

	}
	else {

		cout << "user not found!\n";
	}

	PauseScreen();

}

void ManageUsers(string FileName) {

	bool BackToMainMenue = true;

	do {

		vector <stUser> UsersVector = LoadUsersFromFileToVector(FileName);

		UsersMainMenue();

		switch (ReadUsersMenuePick(1, 6))
		{

		case enUserMenueOptions::enShowUsers:
			ShowUsersList(UsersVector);
			break;
		case enUserMenueOptions::enAddUsers:
			AddUser(FileName, UsersVector);
			break;
		case enUserMenueOptions::enDeleteUsers:
			DeleteUser(FileName, UsersVector);
			break;
		case enUserMenueOptions::enUpdateUsers:
			UpdateUser(FileName, UsersVector);
			break;
		case enUserMenueOptions::enFindUsers:
			FindUser(FileName, UsersVector);
			break;
		case enUserMenueOptions::enUserToMainMenue:
			BackToMainMenue = false;

		}

	} while (BackToMainMenue);

}
//--------------.

void StartProject() {

    while (true) {

        LogIn();

        bool Exit = true;

        do {

            MainMenue();

            enMainMenueOption MenuePick = ReadMenuePick(1, 9);

            if (!CheckIfAccessDenid(MenuePick)) {

                AccessDenidScreen();
                continue;

            }

            vector <StClientData> ClientsVector;
            vector <stUser> UsersVector;

            switch (MenuePick){

            case enMainMenueOption::enShowClints:
                ClientsVector = LoadClientsFromFileToVector(ClientsFile);
                PrintClients(ClientsFile, ClientsVector);
                break;
            case enMainMenueOption::enAddClint:
                ClientsVector = LoadClientsFromFileToVector(ClientsFile);
                AddClient(ClientsFile, ClientsVector);
                break;
            case enMainMenueOption::enDeleteClint:
                ClientsVector = LoadClientsFromFileToVector(ClientsFile);
                DeleteClient(ClientsFile, ClientsVector);
                break;
            case enMainMenueOption::enUpdateClient:
                ClientsVector = LoadClientsFromFileToVector(ClientsFile);
                UpdateClient(ClientsFile, ClientsVector);
                break;
            case enMainMenueOption::enFindClient:
                ClientsVector = LoadClientsFromFileToVector(ClientsFile);
                FindClient(ClientsFile, ClientsVector);
                break;
            case enMainMenueOption::enTransactions:
                ClientsVector = LoadClientsFromFileToVector(ClientsFile);
                Transactions(ClientsFile, ClientsVector);
                break;
            case enMainMenueOption::enManageUsers:
                ManageUsers(UsersFile);
                break;
            case enMainMenueOption::enLogout:
                Exit = false;
                break;
            case enMainMenueOption::enEndProgram:
                EndScreen();
                return;
            }

        } while (Exit);

    }

}

int main()
{
    
    StartProject();

    return 0;
}
