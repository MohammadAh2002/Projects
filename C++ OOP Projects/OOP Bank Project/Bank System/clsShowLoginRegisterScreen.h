#pragma once
#include "clsUser.h"
#include "clsString.h"

class clsShowLoginRegister : protected clsScreen
{
	
private:

   static void PrintLoginRecordLine(string LogInfo)
    {

      vector <string> v = clsString::SplitStringInVector(LogInfo);

        cout << setw(8) << left << "" << "| " << setw(30) << left << v[0];
        cout << "| " << setw(20) << left << v[1];
        cout << "| " << setw(20) << left << clsString::DcryptText(v[2]);
        cout << "| " << setw(10) << left << v[3];

   }

public:

	static void ShowLoginRegisterScreen() {

        clsUtil::ResetScreen();
        _DrawScreenHeader("\t  Register List Screen");

        vector <string> vLoginRegester = clsUser::LoadRegisterDataFromFile();

        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "_________________________________________\n" << endl;

        cout << setw(8) << left << "" << "| " << left << setw(30) << "Date/Time";
        cout << "| " << left << setw(20) << "Username";
        cout << "| " << left << setw(20) << "Password";
        cout << "| " << left << setw(10) << "Permissions";
        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "_________________________________________\n" << endl;

        if (vLoginRegester.size() == 0)
            cout << "\t\t\t\tNo Register Info Available In the System!";

        else
        {
        
            for (string& LogLine : vLoginRegester)
            {

                PrintLoginRecordLine(LogLine);
                cout << endl;
            }

        
        }

        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "_________________________________________\n" << endl;

	}


};

