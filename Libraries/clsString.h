/*

    Build a String Class Have in it Methods to manipulate string.

    Methods in the Class:

    - SetValue(string Value)
    - GetValue()
    - static Length(string S1)
    - Length()
    - static CountWords(string S1)
    - CountWords()
    - static UpperFirstLetterOfEachWord(string S1)
    - UpperFirstLetterOfEachWord()
    - static LowerFirstLetterOfEachWord(string S1)
    - LowerFirstLetterOfEachWord()
    - static StringToUpper(string S1)
    - StringToUpper()
    - static StringToLower(string S1)
    - StringToLower()
    - PrintEachWordInString()
    - static PrintEachWordInString(string S1)
    - static InvertStringCharaters(string S1)
    - InvertStringCharaters()
    - static TrimLeft(string S1)
    - TrimLeft()
    - static TrimRight(string S1)
    - TrimRight()
    - static Trim(string S1)
    - Trim()
    - static CountVowels(string S1)
    - CountVowels()
    - static RemovePunctuations(string S1)
    - RemovePunctuations()
    - static encryptionText(string text, short encryptionKey)
    - encryptionText(short encryptionKey)
    - static dncryptionText(string text, short encryptionKey)
    - dncryptionText(short encryptionKey)
    - static CountLetters(string S1, enWhatToCount WhatToCount)
    - CountLetters(enWhatToCount WhatToCount)
    - static CountCapitalLetters(string S1)
    - CountCapitalLetters()
    - static CountSmallLetters(string S1)
    - CountSmallLetters()
    - static CountSpecificLetter(string S1, char Letter, bool MatchCase)
    - CountSpecificLetter(char Letter, bool MatchCase)
    - static ReplaceWord(string S1, string StringToReplace, string sRepalceTo)
    - ReplaceWord(string StringToReplace, string sRepalceTo)
    - static ReverseWordsInString(string S1)
    - ReverseWordsInString()
    - static SplitStringInVector(string S1, string Delim)
    - SplitStringInVector(string Delim)
    - static PutVectorInString(vector<string>& vstring, string spareter)
    - static PutArrayInString(string arrString[], short Length, string Delim)

*/

#pragma once

#include <iostream>
#include <vector>

using namespace std;

class clsString
{

private:

	string _Value;

    static char InvertChar(char c1) {

        return isupper(c1) ? tolower(c1) : toupper(c1);

    }

    static bool IsVowel(char Ch1)
    {
        Ch1 = tolower(Ch1);

        return ((Ch1 == 'a') || (Ch1 == 'e') || (Ch1 == 'i') || (Ch1 == 'o') || (Ch1 == 'u'));

    }

    enum enWhatToCount { SmallLetters = 0, CapitalLetters = 1, All = 3 };

public:

    clsString() {

		_Value = "";

	}
	clsString(string Value) {

		_Value = Value;

	}

	void SetValue(string Value) {

		_Value = Value;

	}
	string GetValue() {

		return _Value;

	}

	__declspec(property(get = GetValue, put = SetValue)) string Value;

    static short Length(string S1)
    {
        return S1.length();
    };
    short Length()
    {
        return _Value.length();
    };

    static short CountWords(string S1)
    {

        string delim = " "; // delimiter  
        short Counter = 0;
        short pos = 0;
        string sWord; // define a string variable  

        // use find() function to get the position of the delimiters  
        while ((pos = S1.find(delim)) != std::string::npos)
        {
            sWord = S1.substr(0, pos); // store the word   
            if (sWord != "")
            {
                Counter++;
            }

            //erase() until positon and move to next word.
            S1.erase(0, pos + delim.length());
        }

        if (S1 != "")
        {
            Counter++; // it counts the last word of the string.
        }

        return Counter;

    }
    short CountWords()
    {
        return CountWords(_Value);
    };

    static string  UpperFirstLetterOfEachWord(string S1)
    {

        bool isFirstLetter = true;

        for (short i = 0; i < S1.length(); i++)
        {

            if (S1[i] != ' ' && isFirstLetter)
            {
                S1[i] = toupper(S1[i]);

            }

            isFirstLetter = (S1[i] == ' ' ? true : false);

        }

        return S1;
    }
    void  UpperFirstLetterOfEachWord()
    {
        // no need to return value , this function will directly update the object value  
        _Value = UpperFirstLetterOfEachWord(_Value);
    }

    static string  LowerFirstLetterOfEachWord(string S1)
    {

        bool isFirstLetter = true;

        for (short i = 0; i < S1.length(); i++)
        {

            if (S1[i] != ' ' && isFirstLetter)
            {
                S1[i] = tolower(S1[i]);

            }

            isFirstLetter = (S1[i] == ' ' ? true : false);

        }

        return S1;
    }
    void  LowerFirstLetterOfEachWord()
    {
        // no need to return value , this function will directly update the object value  
        _Value = LowerFirstLetterOfEachWord(_Value);
    }

    static string StringToUpper(string S1) {

        for (int i = 0; i < S1.length(); i++) {

            S1[i] = toupper(S1[i]);

        }

        return S1;

    }
    void  StringToUpper() {

        _Value = StringToUpper(_Value);

    }

    static string StringToLower(string S1) {

        for (int i = 0; i < S1.length(); i++) {

            S1[i] = tolower(S1[i]);

        }

        return S1;

    }
    void StringToLower() {

        _Value = StringToLower(_Value);

    }

    void PrintEachWordInString(string S1)
    {
        string delim = " "; // delimiter
        cout << "\nYour string wrords are: \n\n";
        short pos = 0;
        string sWord; // define a string variable
        // use find() function to get the position of the delimiters
        while ((pos = S1.find(delim)) != std::string::npos)
        {
            sWord = S1.substr(0, pos); // store the word
            if (sWord != "")
            {
                cout << sWord << endl;
            }
            S1.erase(0, pos + delim.length()); /* erase() until
           positon and move to next word. */
        }
        if (S1 != "")
        {
            cout << S1 << endl; // it print last word of the string.
        }
    }
    void PrintEachWordInString() {

        PrintEachWordInString(_Value);

    }

    static string InvertStringCharaters(string S1) {

        for (int i = 0; i < S1.length(); i++) {

            S1[i] = InvertChar(S1[i]);

        }

        return S1;

    }
    string InvertStringCharaters() {
    
        _Value = InvertStringCharaters(_Value);
    }

    static string TrimLeft(string S1)
    {


        for (short i = 0; i < S1.length(); i++)
        {
            if (S1[i] != ' ')
            {
                return S1.substr(i, S1.length() - i);
            }
        }
        return "";
    }
    void TrimLeft()
    {
        _Value = TrimLeft(_Value);
    }

    static string TrimRight(string S1)
    {


        for (short i = S1.length() - 1; i >= 0; i--)
        {
            if (S1[i] != ' ')
            {
                return S1.substr(0, i + 1);
            }
        }
        return "";
    }
    void TrimRight()
    {
        _Value = TrimRight(_Value);
    }

    static string Trim(string S1)
    {
        return (TrimLeft(TrimRight(S1)));

    }
    void Trim()
    {
        _Value = Trim(_Value);
    }

    static short  CountVowels(string S1)
    {

        short Counter = 0;

        for (short i = 0; i < S1.length(); i++)
        {

            if (IsVowel(S1[i]))
                Counter++;

        }

        return Counter;
    }
    short  CountVowels()
    {
        return CountVowels(_Value);
    }

    static string RemovePunctuations(string S1)
    {

        string S2 = "";

        for (short i = 0; i < S1.length(); i++)
        {
            if (!ispunct(S1[i]))
            {
                S2 += S1[i];
            }
        }

        return S2;

    }
    void RemovePunctuations()
    {
        _Value = RemovePunctuations(_Value);
    }

    static string encryptionText(string text, short encryptionKey)
    {
        for (int i = 1; i <= text.length(); i++)
        {
            text[i] = char((int)text[i] + encryptionKey);
        }
        return text;
    }
    string encryptionText(short encryptionKey) {

        return encryptionText(_Value, encryptionKey);

    }
    
    static string dncryptionText(string text, short encryptionKey)
    {
        for (int i = 1; i <= text.length(); i++)
        {
            text[i] = char((int)text[i] - encryptionKey);
        }
        return text;
    }
    string dncryptionText(short encryptionKey) {

        return dncryptionText(_Value, encryptionKey);

    }

    static short CountLetters(string S1, enWhatToCount WhatToCount = enWhatToCount::All)
    {


        if (WhatToCount == enWhatToCount::All)
        {
            return S1.length();
        }

        short Counter = 0;

        for (short i = 0; i < S1.length(); i++)
        {

            if (WhatToCount == enWhatToCount::CapitalLetters && isupper(S1[i]))
                Counter++;


            if (WhatToCount == enWhatToCount::SmallLetters && islower(S1[i]))
                Counter++;


        }

        return Counter;

    }
    short CountLetters(enWhatToCount WhatToCount = enWhatToCount::All) {

        return CountLetters(_Value, WhatToCount);
            
    }

    static short  CountCapitalLetters(string S1)
    {

        short Counter = 0;

        for (short i = 0; i < S1.length(); i++)
        {

            if (isupper(S1[i]))
                Counter++;

        }

        return Counter;
    }
    short  CountCapitalLetters()
    {
        return CountCapitalLetters(_Value);
    }

    static short  CountSmallLetters(string S1)
    {

        short Counter = 0;

        for (short i = 0; i < S1.length(); i++)
        {

            if (islower(S1[i]))
                Counter++;

        }

        return Counter;
    }
    short  CountSmallLetters()
    {
        return CountSmallLetters(_Value);
    }

    static short  CountSpecificLetter(string S1, char Letter, bool MatchCase = true)
    {

        short Counter = 0;

        for (short i = 0; i < S1.length(); i++)
        {

            if (MatchCase)
            {
                if (S1[i] == Letter)
                    Counter++;
            }
            else
            {
                if (tolower(S1[i]) == tolower(Letter))
                    Counter++;
            }

        }

        return Counter;
    }
    short  CountSpecificLetter(char Letter, bool MatchCase = true)
    {
        return CountSpecificLetter(_Value, Letter, MatchCase);
    }

    static string ReplaceWord(string S1, string StringToReplace, string sRepalceTo, bool MatchCase = true)
    {

        vector<string> vString = SplitStringInVector(S1, " ");

        for (string& s : vString)
        {

            if (MatchCase)
            {
                if (s == StringToReplace)
                {
                    s = sRepalceTo;
                }

            }
            else
            {
                if (StringToLower(s) == StringToLower(StringToReplace))
                {
                    s = sRepalceTo;
                }

            }

        }

        return PutVectorInString(vString, " ");
    }
    void ReplaceWord(string StringToReplace, string sRepalceTo)
    {
        _Value = ReplaceWord(_Value, StringToReplace, sRepalceTo);
    }

    static string ReverseWordsInString(string S1)
    {

        vector<string> vString;
        string S2 = "";

        vString = SplitStringInVector(S1, " ");

        // declare iterator
        vector<string>::iterator iter = vString.end();

        while (iter != vString.begin())
        {

            --iter;

            S2 += *iter + " ";

        }

        S2 = S2.substr(0, S2.length() - 1); //remove last space.

        return S2;
    }
    void ReverseWordsInString()
    {
        _Value = ReverseWordsInString(_Value);
    }

    static vector <string> SplitStringInVector(string S1, string Delim)
    {
        vector<string> vString;
        short pos = 0;
        string sWord; // define a string variable
        // use find() function to get the position of the delimiters
        while ((pos = S1.find(Delim)) != std::string::npos)
        {
            sWord = S1.substr(0, pos); // store the word
            if (sWord != "")
            {
                vString.push_back(sWord);
            }
            S1.erase(0, pos + Delim.length()); /* erase() until
           positon and move to next word. */
        }
        if (S1 != "")
        {
            vString.push_back(S1); // it adds last word of the string.
        }
        return vString;
    }
    vector <string> SplitStringInVector(string Delim) {

        return SplitStringInVector(_Value, Delim);

    }

    static string PutVectorInString(vector <string>& vstring, string spareter) {

        string word = "";

        for (string& s : vstring) {

            word += s + spareter;
        }

        return word.substr(0, word.length() - spareter.length());

    }
    static string PutArrayInString(string arrString[], short Length, string Delim)
    {

        string S1 = "";

        for (short i = 0; i < Length; i++)
        {
            S1 = S1 + arrString[i] + Delim;
        }

        return S1.substr(0, S1.length() - Delim.length());

    }

};

