/*

    Write a small Math Game.

    Requirements:
    • Ask for how many qustions do you want to answer.
    • enter the level you want:
        [1]Easy [2]Med [3]Hard [4]Mix 
    • enter the Opration you want:
        [1]add [2]sub [3]mul [4]div [5]mix

    • Generate Quostion According to the User Picks.
    • Give the Result for each quostion the User Answer.
        - if the Answer is Right Green Screen
        - if the Answer is Wrong Red Screen and Write the Right Answer
    • Give a Final Result

    • After all rounds show game over the print game results, then ask the user if s/he want to play again?

*/

#include <iostream>
#include <cstdlib>

using namespace std;

enum enlevel {easylv = 1, medlv = 2, hardlv = 3, mixlv = 4};
enum enoprationtupe {addop = 1, subop = 2, mulop = 3, divop = 4, mixop = 5};
enum enanswer {right = 1, wrong = 2};

struct strRoundInfo {

    enlevel level;
    enoprationtupe opration;
    int how_many_rounds;
};
struct strqustioninfo {

    int num1, num2, result, answer;
    string stringopration;
    enanswer is_answer_right;
};
struct strtotalresylt {

    int rightqoustions, wrongqoustions;

};
 
int RandomNumber(int From, int To) {

	int randNum = rand() % (To - From + 1) + From;
	return randNum;

}

int read_number(string massege) {

    cout << massege;

    int number;
    cin >> number;

    return number;

}

void print_qoustion_number(int number, int from) {

    cout << "\nthis is qustion [" << number << "/" << from << "]\n";

}

int give_number_vale(strRoundInfo roundinfo){

     switch(roundinfo.level){

     case enlevel::easylv:
        return RandomNumber(1,10);
     case enlevel::medlv:
         return RandomNumber(10, 50);
     case enlevel::hardlv:
         return RandomNumber(50, 100);
     default:
         return RandomNumber(1, 100);
    }
}

string rnadom_opration(strRoundInfo roundinfo) {

    int opratinnumber = RandomNumber(1, 4);

    switch (opratinnumber) {

    case 1:
        return "+";
    case 2:
        return "-";
    case 3:
        return "*";
    case 4: 
        return "/";
    }
}

string what_is_the_op(strRoundInfo roundinfo) {

    switch (roundinfo.opration) {

    case enoprationtupe::addop:
        return "+";
    case enoprationtupe::subop:
        return "-";
    case enoprationtupe::mulop:
        return "*";
    case enoprationtupe::divop:
        return "/";
    default:
        return rnadom_opration(roundinfo);

    }
}

void print_qoustion(strqustioninfo qustioninfo) {

    cout << qustioninfo.num1 << " " << qustioninfo.stringopration << " " << qustioninfo.num2 << "?\n";

}

int calculate_result(strqustioninfo qustioninfo) {

    switch (qustioninfo.stringopration[0]) {

    case '+':
        return qustioninfo.num1 + qustioninfo.num2;
    case '-':
        return qustioninfo.num1 - qustioninfo.num2;
    case '*':
        return qustioninfo.num1 * qustioninfo.num2;
    case '/':
        return qustioninfo.num1 / qustioninfo.num2;
    }
}

enanswer check_answer(strqustioninfo qustioninfo) {

    if (qustioninfo.answer == qustioninfo.result)
        return enanswer::right;
    else
        return enanswer::wrong;

}

void change_color(strqustioninfo qustioninfo) {

    if (qustioninfo.is_answer_right == enanswer::right) {
        system("color 2f");

    }
    else {

        system("color 4f");
        cout << "\a";
    }
}

void print_qoustion_result(strqustioninfo qustioninfo){

    change_color(qustioninfo);

    cout << "______________\n";

    if (qustioninfo.is_answer_right == enanswer::right) {
    
        cout << "your answer is right :-)\n";

    }
    else {

        cout << "your answer is wrong :-(\n";
        cout << "the right answer is: " << qustioninfo.result << endl;

    }
}

void reset_total_result(strtotalresylt& finalresult) {

    finalresult.rightqoustions = 0;
    finalresult.wrongqoustions = 0;

}

void clculate_final_result(strtotalresylt& finalresult, strqustioninfo qustioninfo) {

    if (qustioninfo.is_answer_right == enanswer::right)
        finalresult.rightqoustions++;
    else
        finalresult.wrongqoustions++;

}

string passedorno(strtotalresylt finalresult){

    if (finalresult.rightqoustions > finalresult.wrongqoustions) {

        system("color 2f");
        return "passed :-)";

    }
    else {

        system("color 4f");
        return "failed :-(";
    }
}

string print_opration(strRoundInfo roundinfo) {

    switch (roundinfo.opration) {

    case enoprationtupe::addop:
        return "+";
    case enoprationtupe::subop:
        return "-";
    case enoprationtupe::mulop:
        return "*";
    case enoprationtupe::divop:
        return "/";
    default:
        return "mixed oprations";
    }
}

string print_level(strRoundInfo roundinfo) {

    switch (roundinfo.level) {

    case enlevel::easylv:
        return "easy";
    case enlevel::medlv:
        return "med";
    case enlevel::hardlv:
        return "hard";
    default:
        return "mixed level";
    }
}

void print_final_result(strtotalresylt finalresult, strRoundInfo roundinfo) {

    cout << "               _________________________\n";
    cout << "               final result is " << passedorno(finalresult) << endl;
    cout << "               _________________________\n";
    cout << "               number of qoustions is: " << roundinfo.how_many_rounds << endl;
    cout << "               qoustions level is: " << print_level(roundinfo) << endl;
    cout << "               the optration is: " << print_opration(roundinfo) << endl;
    cout << "               number of right answers is: " << finalresult.rightqoustions << endl;
    cout << "               number of wrong answers is: " << finalresult.wrongqoustions << endl;
    cout << "               _________________________\n";
}

void playgame() {

    strRoundInfo roundinfo;
    strqustioninfo qustioninfo;
    strtotalresylt finalresult;

    roundinfo.how_many_rounds = read_number("how many qustions do you want to answer: ");
    roundinfo.level = enlevel(read_number("enter the level you want [1]easy [2]med [3]hard [4]mix: "));
    roundinfo.opration = enoprationtupe(read_number("enter the opration you want [1]add [2]sub [3]mul [4]div [5]mix: "));

    int qustions_counter = 1;
    reset_total_result(finalresult);

    do {

        print_qoustion_number(qustions_counter, roundinfo.how_many_rounds);
        qustioninfo.num1 = give_number_vale(roundinfo);
        qustioninfo.num2 = give_number_vale(roundinfo);
        qustioninfo.stringopration = what_is_the_op(roundinfo);

        print_qoustion(qustioninfo);
        qustioninfo.result = calculate_result(qustioninfo);
        qustioninfo.answer = read_number("what is your answer: ");
        qustioninfo.is_answer_right = check_answer(qustioninfo);

        print_qoustion_result(qustioninfo);
        clculate_final_result(finalresult, qustioninfo);

        qustions_counter++;
    } while (qustions_counter <= roundinfo.how_many_rounds);

    print_final_result(finalresult, roundinfo);

}

void resetthesecreen() {
    system("cls");
    system("color 0f");
}

bool askwanttoplay() {

    bool play;

    cout << "do you want to play again?[0]no [1]yes";
    cin >> play;

    return play;
}

void startgame() {

    bool wanttoplay;

    do {

        playgame();

     wanttoplay = askwanttoplay();
     if (wanttoplay)
         resetthesecreen();

    } while (wanttoplay);
}

int main()
{
	srand((unsigned)time(NULL));

    startgame();

    return 0;
}
