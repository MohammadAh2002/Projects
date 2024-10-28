#pragma once
#include <string>
#include "clsBankClient.h"

class clsTransferLogScreen : public clsScreen
{

private:

    static void PrintTransferRecordLine(clsBankClient::stTrnsferLogRecord TransferLogRecord)
    {

        cout << setw(8) << left << "" << "| " << setw(23) << left << TransferLogRecord.DateTime;
        cout << "| " << setw(8) << left << TransferLogRecord.SourceAccountNumber;
        cout << "| " << setw(8) << left << TransferLogRecord.DestinationAccountNumber;
        cout << "| " << setw(8) << left << TransferLogRecord.Amount;
        cout << "| " << setw(10) << left << TransferLogRecord.srcBalanceAfter;
        cout << "| " << setw(10) << left << TransferLogRecord.destBalanceAfter;
        cout << "| " << setw(8) << left << TransferLogRecord.UserName;


    }

public:

	static void ShowTransferList() {

        vector <clsBankClient::stTrnsferLogRecord> vTransferLog = clsBankClient::GetTransfersLogList();

        clsUtil::ResetScreen();

        _DrawScreenHeader("\t  Transfer List Screen");

        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "_________________________________________\n" << endl;

        cout << setw(8) << left << "" << "| " << left << setw(23) << "Date/Time";
        cout << "| " << left << setw(8) << "F.Acct";
        cout << "| " << left << setw(8) << "T.Acct";
        cout << "| " << left << setw(8) << "Amount";
        cout << "| " << left << setw(10) << "F.Balance";
        cout << "| " << left << setw(10) << "T.Balance";
        cout << "| " << left << setw(8) << "User";
        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "_________________________________________\n" << endl;

        if (vTransferLog.size() == 0)
            cout << "\t\t\t\tNo Register Info Available In the System!";

        else
        {
            
            for (clsBankClient::stTrnsferLogRecord& LogLine : vTransferLog)
            {

                PrintTransferRecordLine(LogLine);
                cout << endl;
            }


        }

        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "_________________________________________\n" << endl;
	}

};

