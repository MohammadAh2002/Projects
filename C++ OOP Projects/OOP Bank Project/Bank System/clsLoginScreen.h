#pragma once

#include <iostream>
#include "clsScreen.h"
#include "clsUser.h"
#include <iomanip>
#include "clsMainScreen.h"
#include "Global.h"
#include "clsUtil.h"
#include "clsDate.h"

class clsLoginScreen :protected clsScreen
{

private:

    static  void _Login()
    {
        bool LoginFaild = false;
        short Trials = 3;

        string Username, Password;
        do
        {

            if (LoginFaild)
            {
                cout << "\nInvlaid Username/Password!\n";
                Trials--;
                cout << "you have " << Trials << " Trails To Login\n\n";

                if (Trials == 0) {

                    cout << "\nyou are locked after 3 faild trails\n\n";
                    exit(0);
                }

            }

            cout << "Enter Username? ";
            cin >> Username;

            cout << "Enter Password? ";
            cin >> Password;

            CurrentUser = clsUser::FindUser(Username, Password);

            LoginFaild = CurrentUser.IsEmpty();

        } while (LoginFaild);

        CurrentUser.RegisterLogIn();
        clsMainScreen::ShowMainMenue();

    }

public:


    static void ShowLoginScreen()
    {
        clsUtil::ResetScreen();
        _DrawScreenHeader("\t  Login Screen");
        _Login();

    }

};

