/*

    Start the Game Read The Rules and Play.

*/

#include <iostream>
#include <vector>
#include <algorithm>
#include <cstdlib>

using namespace std;

struct roundinfo {

    int min = 1, max = 100, rounds_played = 0, randompick = 0;
    char pick;
    bool answer = false;
};

int RandomNumber(int From, int To) {

    int randNum = rand() % (To - From + 1) + From;
    return randNum;

}

void print_rules() {

    cout << "choce a number is your head between 1-100\n";
    cout << "i will guss the number in less than 7 trys\n";
    cout << "if not you will win\n";
    cout << "(l)arger or (s)maller than the one shown.\n";
    cout << "Enter 'c' (for 'correct') if the number shown is yours.\n";

}

void check_guess(roundinfo& round) {

    switch (round.pick)
    {

    case 'l':
    case 'L':
        round.min = round.randompick;
        break;
    case 'S':
    case 's':
        round.max = round.randompick;
        break;
    case 'c':
    case 'C':
        round.answer = true;
        break;
    }
}

void print_result(roundinfo& round) {

    cout << "the number you picked is: " << round.randompick << endl;
    cout << "i gussed it after: " << round.rounds_played << " trys\n";


}

void play_game() {

    roundinfo round;

    print_rules();

    do {

        round.randompick = RandomNumber(round.min, round.max);

        cout << "the number you picked is: " << round.randompick;
        cout << " Right? " << endl;
        cin >> round.pick;

        check_guess(round);

        round.rounds_played++;

    } while (!round.answer);

    print_result(round);
}

int main()
{
    srand((unsigned)time(NULL));

    play_game();

    return 0;

}