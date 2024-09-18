/*

    Write a small game for Stone - Paper - Scissor.

    Requirements:
    • Ask for how many rounds the game will be.
    • Start each round Player vs Computer.
    • Show the results with each round.
    • If computer wins the round ring a bill, and screed red.
    • If player won the round show green screen.
    • After all rounds show game over the print game results, then ask the user if s/he want to play again?

*/

#include <iostream>
#include <cstdlib>

using namespace std;

enum who_win { player = 1, computer = 2, draw = 3 };
enum tiktok { stone = 1, paper = 2, scissor = 3 };

int read_how_many_rounds() {

    int number;

    do {

        cout << "how many rounds you want to play(1-10): ";
        cin >> number;

    } while (number <= 0 || number > 10);

    return number;
}

int read_player_choice() {

    int number;

    do {

        cout << "what is your choice: [1] stone, [2]paper, [3]scissors?: ";
        cin >> number;

    } while (number < 1 || number > 3);

    return number;
}

int RandomNumber(int From, int To) {

    int randNum = rand() % (To - From + 1) + From;
    return randNum;

}

int computer_choice() {

    int choice = RandomNumber(1, 3);

    return choice;

}

who_win check_the_winner(int player_pick, int computer_pick) {

    if (player_pick == tiktok::stone) {

        if (computer_pick == tiktok::stone)
            return who_win::draw;
        else if (computer_pick == tiktok::paper)
            return who_win::computer;
        else
            return who_win::player;

    }
    if (player_pick == tiktok::paper) {

        if (computer_pick == tiktok::stone)
            return who_win::player;
        else if (computer_pick == tiktok::paper)
            return who_win::draw;
        else
            return who_win::computer;

    }
    if (player_pick == tiktok::scissor) {

        if (computer_pick == tiktok::stone)
            return who_win::computer;
        else if (computer_pick == tiktok::paper)
            return who_win::player;
        else
            return who_win::draw;

    }

}

string print_pick(int pick) {

    if (pick == 1)
        return "stone";
    else if (pick == 2)
        return "paper";
    else
        return "scissor";
}

void round_result(who_win round_winner, int player_pick, int computer_pick) {

    cout << "-----------------------------\n";
    cout << "the player pick is: " << print_pick(player_pick) << endl;
    cout << "the computer pick is: " << print_pick(computer_pick) << endl;

    if (round_winner == who_win::player) {

        cout << "the winner is: [player]\n";
        cout << "------------------------------\n";
        system("color 2f");

    }
    if (round_winner == who_win::computer) {

        cout << "the winner is: [computer]\n";
        cout << "------------------------------\n";
        system("color 4f");
        cout << "\a";

    }
    if (round_winner == who_win::draw) {

        cout << "its a [draw]\n";
        cout << "------------------------------\n";
        system("color 6f");

    }
}

void calculate_total_result(who_win winner, int& player_win, int& computer_win, int& draw) {

    if (winner == who_win::player) {
        player_win++;
    }
    if (winner == who_win::computer) {
        computer_win++;
    }
    if (winner == who_win::draw) {
        draw++;
    }
}

string who_won(int player_wins, int computer_wins) {

    if (player_wins > computer_wins)
        return "player win";
    else  if (computer_wins > player_wins)
        return "computer win";
    else
        return "no winner";
}

void result_color(string winner) {

    if (winner == "player win") {
        system("color 2f");
    }
    if (winner == "computer win") {
        system("color 4f");
    }
    if (winner == "no winner") {
        system("color 6f");
    }

}

void final_result(int Rounds, int PlayerWins, int ComputerWins, int Draw) {

    string the_winner = who_won(PlayerWins, ComputerWins);
    result_color(the_winner);

    cout << "                 ------------------------------\n";
    cout << "                        +++ GAME OVER +++\n";
    cout << "                 ------------------------------\n";
    cout << "                 ---------{GAME RESULT}--------\n";
    cout << "                 game rounds = " << Rounds << endl;
    cout << "                 player won time = " << PlayerWins << endl;
    cout << "                 computer won time = " << ComputerWins << endl;
    cout << "                 draw time = " << Draw << endl;
    cout << "                 final winner:  " << the_winner << endl;

}

void play_game() {

    int rounds = read_how_many_rounds();
    int rounde_counter = 1, player_won = 0, computer_won = 0, draw_result = 0, live_rounds = 1;

    do {

        cout << "round [" << live_rounds << "] begins:\n";
        int player_choice = read_player_choice();
        int computer_pick = computer_choice();

        who_win round_winner = check_the_winner(player_choice, computer_pick);

        round_result(round_winner, player_choice, computer_pick);
        calculate_total_result(round_winner, player_won, computer_won, draw_result);

        live_rounds++;
        rounde_counter++;
    } while (rounde_counter <= rounds);

    final_result(rounds, player_won, computer_won, draw_result);

}

bool ask_want_to_continue() {

    cout << "do you want to play again [1]yes,[0]no: ";

    int play;
    cin >> play;

    return play;

}

void start_game() {

    bool play;

    do {

        play_game();
        play = ask_want_to_continue();

        if (play) {

            system("cls");
            system("color 0f");
        }

    } while (play);

}

int main()
{
    srand((unsigned)time(NULL));

    start_game();

    return 0;

}

