/*

	Write a Program To Generate a Math Questions for 1 to 10 Rounds.

*/

#include <iostream>
#include <cstdlib>

using namespace std;

enum enanswer { right = 1, wrong = 2 };

struct strRoundInfo {

	int answer, num1, num2, result;
	enanswer IsAnswerRight;

};

int RandomNumber(int From, int To) {

	int randNum = rand() % (To - From + 1) + From;
	return randNum;

}

int read_ronds_number() {

	int number;

	do {

		cout << "how many rounds you wnat to play(1-10): ";
		cin >> number;

	} while (number <= 0 || number >10);

	return number;
}

int read_number() {

	int answer;

	cout << "answer: ";
	cin >> answer;

	return answer;
}

void print_qoustion(strRoundInfo round){

	cout << round.num1 << " + " << round.num2 << "?\n";

}

enanswer chek_answer(strRoundInfo round) {

	if (round.answer == round.result) {
		system("color 2f");
		return enanswer::right;	
	}
	else {
		system("color 4f");
		return enanswer::wrong;
	}
}

void calculate_total_score(enanswer answer, int& rightanswer, int& wrongnaswer) {

	if (answer == enanswer::right)
		rightanswer++;
	else
		wrongnaswer++;
		
}

void print_final_score(int roundsplayed, int rightanswer, int wrongnaswer) {

	cout << "\n\n";
	cout << "			---------------------------\n";
	cout << "			rounds playes is: " << roundsplayed << endl;
	cout << "			number of right answers is: " << rightanswer <<  endl;
	cout << "			number of  wrong answers is: " << wrongnaswer << endl;
	cout << "			---------------------------\n";
}

void play_game() {

	int rounds = read_ronds_number();
	int rounds_counter = 1, QustionsRights = 0, QustionsWrong = 0;

	strRoundInfo roundinfo;

	do {

		roundinfo.num1 = RandomNumber(1, 100);
		roundinfo.num2 = RandomNumber(1, 100);
		print_qoustion(roundinfo);

		roundinfo.answer = read_number();
		roundinfo.result = roundinfo.num1 + roundinfo.num2;

		roundinfo.IsAnswerRight = chek_answer(roundinfo);

		calculate_total_score(roundinfo.IsAnswerRight, QustionsRights, QustionsWrong);

		rounds_counter++;
	} while (rounds_counter <= rounds);

	print_final_score(rounds,QustionsRights, QustionsWrong);
}

bool wanttoplayagaim() {

	bool answer;

	cout << "do you want to play again? [0]no,[1]yes: ";
	cin >> answer;

	return answer;
}

void start_game() {

	bool play;

	do{
	
		play_game();

		play = wanttoplayagaim();

		if (play) {

			system("cls");
			system("color 0f");

		}
	
	} while(play);
}

int main() {

	srand((unsigned)time(NULL));

	start_game();

	return 0;

}
