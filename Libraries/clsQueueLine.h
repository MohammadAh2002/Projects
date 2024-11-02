/*

	Creat a Queue Line Class.

*/

#pragma warning (disable : 4996)
#pragma once

#include <iostream>
#include <string>
#include <queue>
#include <stack>

using namespace std;

class clsQueueLine
{
private:

	struct TicketDetails {

		string CardPrefix;
		short TimeToServe;
		string TicketTime;
		short ClientBefore = 0;

	}TicketInfo;

	queue <TicketDetails> QueueLine;

	int _TotalTickets = 0;
	int _AverageServeTime;
	string _CardPrefix;

	static string GetSystemDateTimeString()
	{
		//system datetime string
		time_t t = time(0);
		tm* now = localtime(&t);

		short Day, Month, Year, Hour, Minute, Second;

		Year = now->tm_year + 1900;
		Month = now->tm_mon + 1;
		Day = now->tm_mday;
		Hour = now->tm_hour;
		Minute = now->tm_min;
		Second = now->tm_sec;

		return (to_string(Day) + "/" + to_string(Month) + "/"
			+ to_string(Year) + " - "
			+ to_string(Hour) + ":" + to_string(Minute)
			+ ":" + to_string(Second));

	}

	int WaitingClients() {

		return QueueLine.size();

	}

	short ServedClients() {

		return _TotalTickets - QueueLine.size();

	}

public:

	clsQueueLine(string CardPrefix, short ServeTime) {

		_AverageServeTime = ServeTime;

		_CardPrefix = CardPrefix;

	}

	void IssueTicket() {

		TicketInfo.CardPrefix = _CardPrefix + to_string(_TotalTickets + 1);
		TicketInfo.TicketTime = GetSystemDateTimeString();
		TicketInfo.TimeToServe = WaitingClients() * _AverageServeTime;
		TicketInfo.ClientBefore = WaitingClients();

		QueueLine.push(TicketInfo);

		_TotalTickets++;

	}

	void PrintInfo() {

		cout << "\t\t\t___________________________\n";
		cout << "\n\t\t\t\tQueue Info\n";
		cout << "\n\t\t\t___________________________\n";
		cout << "\n\t\t\t  Prefix: " << _CardPrefix << "\n";
		cout << "\t\t\t  Total Tickets  : " << _TotalTickets << "\n";
		cout << "\t\t\t  Served Clients : " << ServedClients() << "\n";
		cout << "\t\t\t  Waiting Clients: " << WaitingClients() << "\n";
		cout << "\t\t\t___________________________\n";

	}

	void ClientServed() {

		QueueLine.pop();

	}

	TicketDetails ServeClient() {

		return QueueLine.front();

	}

	void PrintTicketsLineRTL() {

		if (QueueLine.empty()) {
			cout << "\n\t\tTickets: No Tickets.";
			return;
		}


		queue <TicketDetails> TempQueue;


		TempQueue =QueueLine;

		stack <TicketDetails> TempStack;


		while (!TempQueue.empty()) {

			TempStack.push(TempQueue.front());

			TempQueue.pop();

		}

		cout << "\t\t\nTickets: ";

		cout << "End -> ";

		while (!TempStack.empty()) {

			cout << TempStack.top().CardPrefix << " -> ";
			TempStack.pop();

			
		}

		

	}

	void PrintTicketsLineLTR() {

		if (QueueLine.empty()) {
			cout << "\n\t\tTickets: No Tickets.";
			return;
		}


		queue <TicketDetails> TempQueue;

		TempQueue = QueueLine;

		cout << "\t\t\nTickets: ";

		while (!TempQueue.empty()) {

			cout << TempQueue.front().CardPrefix << " <- ";
			TempQueue.pop();
		
		}
		
		cout << "End.\n";

	}

	void PrintAllTickets() {

		cout << "\n\t\t\t\t---Tickets---";

		cout << "\n\t\t\t___________________________\n";

		if (QueueLine.empty())
			cout << "\n\n\t\t\t     ---No Tickets---\n";

		queue <TicketDetails> TempQueue;

		TempQueue = QueueLine;

		while (!TempQueue.empty()) {

			cout << "\t\t\t\t     " << TempQueue.front().CardPrefix << '\n';
			cout << "\t\t\t    " << TempQueue.front().TicketTime << '\n';
			cout << "\t\t\t    Waiting Clients = " << TempQueue.front().ClientBefore << '\n';
			cout << "\t\t\t\tServe Time In \n";
			cout <<"\t\t\t\t  " << TempQueue.front().TimeToServe << " Minutes\n";
			cout << "\t\t\t___________________________\n";

			TempQueue.pop();

		}



	}

	string WhoIsNext()
	{
		if (QueueLine.empty())
			return "No Clients Left.";
		else
			return QueueLine.front().CardPrefix;

	}

};

