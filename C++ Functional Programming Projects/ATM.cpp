/*

	Write a ATM Project for the Bank Using Console.

	requirement:

	Login Screen:
	- Account Number
	- Pin

	Main Menu Screen:
		1- Quick Withdraw (go to the Quick Withdraw Menu)
			- the User Can Pick a Number to Withdraw Money Fast no Need to Write the Number him Self.
			- Has it's Own Menu to Piick from it.
		2- Normal Withdraw
			- the User Pick the Withdraw Valu he Want.
		3- Deposit
			- the User Pick the Deposit Valu he Want.
		4- Check Balances
			- Show the User his Balance
		5- Logout
	
	- the User Should Navigate the Program With Numbers in Keyboard.

	-----------------------------------------------------------
	
	- Assume you Already have Clients Data.

	- Client Stored in Text File in This Format:
		a150#//#1234#//#mohammad#//#87313#//#400
		b150#//#9876#//#ahmad#//#456435798#//#500
		c150#//#5913#//#koko#//#456478435#//#900

	1- Copy the Clients Data into Text File.
	2- Make Sure There is no Spaces Before and After the Data.
	3- Text File Name Should be: ClintsInfoFile.
	4- Set the File Path in the ClientsFile Variable.

*/

#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <iomanip>

using namespace std;

struct StClient {

    string AccountNumber, Name, PhoneNumber, PinCode;
    int AccountBalance;
    bool Update = false, Delete = false;

};

StClient CurrentClient;

// Client Data File Set the Path Here.
const string ClientsFile = "ClintsInfoFile.txt";

enum enMainMenueOption {
    enQuickWithdraw = 1, enNormalWithdraw = 2, enDeposit = 3,
    enCheckBalance = 4, enLogOut = 5, enEndProgram = 6
};

enum enQuickWithdrawMenue {

    enQuickWithdraw20 = 1, enQuickWithdraw50 = 2, enQuickWithdraw100 = 3, enQuickWithdraw200 = 4,
    enQuickWithdraw400 = 5, enQuickWithdraw600 = 6, enQuickWithdraw800 = 7, enQuickWithdraw1000 = 8,
    enQuickWithdrawExit = 9

};

// File Functions.
string AddClientDataInString(StClient ClData, string Sparater = "#//#") {

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
StClient PutStringToStruct(string S1) {

	StClient Client;

	vector <string> vS1;

	vS1 = PutStringToVector(S1);

	Client.AccountNumber = vS1[0];
	Client.PinCode = vS1[1];
	Client.Name = vS1[2];
	Client.PhoneNumber = vS1[3];
	Client.AccountBalance = stoi(vS1[4]);

	return Client;
}
void FillTheClientsFileWithNewInfo(string FileName, vector <StClient>& ClientsVector) {

	string Line;
	fstream MyFile;

	MyFile.open(FileName, ios::out);

	if (MyFile.is_open()) {

		for (StClient& c : ClientsVector) {

			Line = AddClientDataInString(c);
			MyFile << Line << endl;
		}

		MyFile.close();
	}

}
vector <StClient> LoadClientsFromFileToVector(string FileName) {

	vector <StClient> Vclients;
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
//-------------.

// screen Draw. 
void ResetScreen() {

	system("cls");

}
void ScreenHeder(string Massege) {

	cout << "==========================================\n";
	cout << "\t" << Massege << "Screen\n";
	cout << "==========================================\n";

}
void MainMenue() {

	ResetScreen();

	cout << "==========================================\n";
	cout << "\t\tATM Main Menue Screen\n";
	cout << "==========================================\n";
	cout << "\t[1] Quick Withdraw.\n";
	cout << "\t[2] Normal Withdraw.\n";
	cout << "\t[3] Deposit.\n";
	cout << "\t[4] Check Balance.\n";
	cout << "\t[5] Logout.\n";
	cout << "\t[6] End Program.\n";
	cout << "==========================================\n";

}
void EndScreen() {

	ResetScreen();

	cout << "==========================================\n";
	cout << "\tProgram Ends:-)\n";
	cout << "==========================================\n";


}
void QuickWithdrawMenue() {

	cout << "==========================================\n";
	cout << "\t\tQuick Withdraw\n";
	cout << "==========================================\n";
	cout << "\t[1] 20          [2] 50\n";
	cout << "\t[3] 100         [4] 200\n";
	cout << "\t[5] 400         [6] 600\n";
	cout << "\t[7] 800         [8] 1000\n";
	cout << "\t[9] Exit\n";
	cout << "==========================================\n";
	cout << "Your Balance is: " << CurrentClient.AccountBalance << ".\n";

}
//-------------.

// Read Data.
enMainMenueOption ReadMenuePick(short from, short to) {

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
enQuickWithdrawMenue ReadQuickWithdrawMenuePick(short from, short to) {

	int Pick;

	printf("Choose what to Withdraw from [%d] to [%d]?", from, to);
	cin >> Pick;

	while (cin.fail() || Pick <from || Pick > to) {

		cin.clear();
		cin.ignore(numeric_limits<streamsize>::max(), '\n');

		ResetScreen();
		QuickWithdrawMenue();

		cout << "You have entered wrong input(try again).\n";
		printf("Choose what to Withdraw from [%d] to [%d]?", from, to);
		cin >> Pick;

	}

	return enQuickWithdrawMenue(Pick);

}
StClient ReadLogInInfo() {

	StClient Client;

	cout << "Enter Account Number: ";
	cin >> Client.AccountNumber;

	cout << "Enter PinCode: ";
	cin >> Client.PinCode;

	return Client;

}
//-------------.

bool CheckIfClientExist(vector <StClient>& ClientsVector, StClient& Account) {

	for (StClient& c : ClientsVector) {

		if (c.AccountNumber == Account.AccountNumber && c.PinCode == Account.PinCode) {
			CurrentClient = c;
			return true;

		}

	}

	return false;

}
void PauseScreen() {

	cout << "\nPress Any Key to go back to main menue...";
	system("pause>0");

}
void LogIn() {

	ResetScreen();
	ScreenHeder("Login ");

	vector <StClient> ClientVector = LoadClientsFromFileToVector(ClientsFile);

	StClient ClientLogInInfo = ReadLogInInfo();

	while (!CheckIfClientExist(ClientVector, ClientLogInInfo)) {

		ResetScreen();
		ScreenHeder("Login ");

		cout << "invaild Account Number/PinCode!\n";

		ClientLogInInfo = ReadLogInInfo();

	}

}
bool MakeSure() {

	char Answer;

	cout << "are you sure you want to preform this Transaction - Y/N ? \n";
	cin >> Answer;

	if (tolower(Answer) == 'y')
		return true;

	return false;
}
void UpdateClintsVector(vector <StClient>& ClientsVector) {

	for (StClient& c : ClientsVector) {

		if (CurrentClient.AccountNumber == c.AccountNumber) {

			c = CurrentClient;

			return;
		}
	}
}
bool IsHaveEnoughMoney(short MoneyAmount) {

	return CurrentClient.AccountBalance >= MoneyAmount;

}
short ReturnQuickWithdrawMoneyAmount(enQuickWithdrawMenue Pick) {

	switch (Pick)
	{
	case enQuickWithdrawMenue::enQuickWithdraw20:
		return 20;
	case enQuickWithdrawMenue::enQuickWithdraw50:
		return 50;
	case enQuickWithdrawMenue::enQuickWithdraw100:
		return 100;
	case enQuickWithdrawMenue::enQuickWithdraw200:
		return 200;
	case enQuickWithdrawMenue::enQuickWithdraw400:
		return 400;
	case enQuickWithdrawMenue::enQuickWithdraw600:
		return 600;
	case enQuickWithdrawMenue::enQuickWithdraw800:
		return 800;
	case enQuickWithdrawMenue::enQuickWithdraw1000:
		return 1000;
	}
}
void CalculateQuickWithdraw(string FileName, vector <StClient>& ClientsVector, enQuickWithdrawMenue& Pick) {

	while (true) {

		short MoneyAmount = ReturnQuickWithdrawMoneyAmount(Pick);

		if (!IsHaveEnoughMoney(MoneyAmount)) {

			cout << "you dont have engh money.\n";
			cout << "\nPress Any Key to continue\n";
			system("pause>0");

			ResetScreen();
			QuickWithdrawMenue();

			Pick = ReadQuickWithdrawMenuePick(1, 9);

			if (Pick == enQuickWithdrawMenue::enQuickWithdrawExit)
				return;
			else
				continue;

		}

		if (MakeSure()) {

			CurrentClient.AccountBalance -= MoneyAmount;

			cout << "Done Successfully. your New Balance is: " << CurrentClient.AccountBalance << endl;

			UpdateClintsVector(ClientsVector);
			FillTheClientsFileWithNewInfo(FileName, ClientsVector);

		}
		else
			cout << "ok like you want\n";

		return;

	}
}
int ReadDepositAmount() {

	int MoneyAmount;

	cout << "enter a posittive Deposit Amount: ";
	cin >> MoneyAmount;

	while (MoneyAmount <= 0) {

		cout << "\nenter a posittive Deposit Amount: ";
		cin >> MoneyAmount;

	}

	return MoneyAmount;

}
int ReadNormalWithdrawAmount() {

	short MoneyAmount;

	do {

		cout << "\n\nenter an amount multiple of 5's:";
		cin >> MoneyAmount;

	} while (MoneyAmount % 5 != 0);

	return MoneyAmount;

}

// Main Functions.

void QuickWithdraw(string FileName, vector <StClient>& ClientsVector) {

	while (true) {

		ResetScreen();
		QuickWithdrawMenue();

		enQuickWithdrawMenue Pick = ReadQuickWithdrawMenuePick(1, 9);

		if (Pick == enQuickWithdrawMenue::enQuickWithdrawExit)
			return;

		CalculateQuickWithdraw(FileName, ClientsVector, Pick);

		if (Pick == enQuickWithdrawMenue::enQuickWithdrawExit)
			return;

		break;

	}

	PauseScreen();
}

void NormalWithdraw(string FileName, vector <StClient>& ClientsVector) {

	short MoneyAmount;

	while (true) {

		ResetScreen();
		ScreenHeder("Normal Withdraw ");

		MoneyAmount = ReadNormalWithdrawAmount();

		if (!IsHaveEnoughMoney(MoneyAmount)) {

			cout << "\nyou dont have Enough money.\n";

			cout << "\nPress Any Key to continue\n";
			system("pause>0");

			continue;

		}

		if (MakeSure()) {

			CurrentClient.AccountBalance -= MoneyAmount;

			cout << "Done Successfully. your New Balance is: " << CurrentClient.AccountBalance << endl;

			UpdateClintsVector(ClientsVector);
			FillTheClientsFileWithNewInfo(FileName, ClientsVector);

		}
		else
			cout << "ok no problem.\n";

		PauseScreen();
		break;
	}
}

void Deposit(string FileName, vector <StClient>& ClientsVector) {

	ResetScreen();
	ScreenHeder("Deposit ");

	int MoneyAmount = ReadDepositAmount();

	if (MakeSure()) {

		CurrentClient.AccountBalance += MoneyAmount;

		cout << "Done Successfully. your New Balance is: " << CurrentClient.AccountBalance << endl;

		UpdateClintsVector(ClientsVector);
		FillTheClientsFileWithNewInfo(FileName, ClientsVector);

	}
	else
		cout << "ok no problem.\n";

	PauseScreen();

}

void CheckBalance(string FileName, vector <StClient>& ClientsVector) {

	ResetScreen();
	ScreenHeder("Check Balance ");

	cout << "Your Balance is: " << CurrentClient.AccountBalance << ".\n";

	PauseScreen();

}
//-------------.

void StartProject() {

    bool Exit = true;

    while (true) {

        LogIn();

        do {

            MainMenue();

            vector <StClient>  ClientsVector = LoadClientsFromFileToVector(ClientsFile);

            switch (ReadMenuePick(1, 6))
            {
            case enMainMenueOption::enQuickWithdraw:
                QuickWithdraw(ClientsFile, ClientsVector);
                break;
            case enMainMenueOption::enNormalWithdraw:
                NormalWithdraw(ClientsFile, ClientsVector);
                break;
            case enMainMenueOption::enDeposit:
                Deposit(ClientsFile, ClientsVector);
                break;
            case enMainMenueOption::enCheckBalance:
                CheckBalance(ClientsFile, ClientsVector);
                break;
            case enMainMenueOption::enLogOut:
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
