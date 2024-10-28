#pragma once
#pragma warning(disable : 4996)

#include <iostream>
#include <vector>
#include <string>
#include "clsString.h"

using namespace std;

class clsDate {

private:

	short _Day, _Month, _Year;

public:

	enum enDateCompare { Before = -1, equal = 0, After = 1 };

	// Constructor 
	clsDate() {

		GetSystemDate();

	}
	clsDate(string Date) {

		*this = DateFromStringToDate(Date);

	}
	clsDate(short Day, short Month, short Year) {

		_Day = Day;
		_Month = Month;
		_Year = Year;

	}
	clsDate(short DaysNumberInYear, short Year) {

		*this = GetDateFromDayOrderInTheYear(DaysNumberInYear, Year);

	}

	static clsDate DateFromStringToDate(string stringDate) {

		clsDate Date;

		vector<string> V = clsString::SplitStringInVector(stringDate, "/");

		Date._Day = stoi(V[0]);
		Date._Month = stoi(V[1]);
		Date._Year = stoi(V[2]);

		return Date;

	}

	static clsDate GetSystemDate(clsDate Date) {

		time_t t = time(0);
		tm* now = localtime(&t);

		Date._Day = now->tm_mday;
		Date._Month = now->tm_mon + 1;
		Date._Year = now->tm_year + 1900;

		return Date;

	}
	void GetSystemDate() {

		*this = GetSystemDate(*this);

	}

	//----------

	// Set & Get.
	void SetDay(short Day) {

		_Day = Day;

	}
	short GetDay(){

		return _Day;

	}

	void SetMonth(short Month) {

		_Month = Month;

	}
	short GetMonth() {

		return _Month;

	}

	void SetYear(short Year) {

		_Year = Year;

	}
	short GetYear() {

		return _Year;

	}
	//----------

	// Number of XXX In XXX.
	static short NumberOfDaysInMonth(short Month, short Year) {

		if (Month < 1 || Month>12)
			return 0;

		int numberofdays[12] = { 31,28,31,30,31,30,31,31,30,31,30,31 };

		return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : numberofdays[Month - 1];

	}
	short NumberOfDaysInMonth() {

		return NumberOfDaysInMonth(this->_Month, this->_Year);

	}

	static short NumberOfDaysInYear(short Year) {

		return IsLeapYear(Year) ? 366 : 365;

	}
	short NumberOfDaysInYear() {

		return NumberOfDaysInYear(this->_Year);

	}

	static short NumberOfHoursInYear(short Year) {

		return NumberOfDaysInYear(Year) * 24;

	}
	short NumberOfHoursInYear() {

		return NumberOfHoursInYear(this->_Year);

	}

	static int NumberOfMinutesInYear(short Year) {

		return NumberOfHoursInYear(Year) * 60;

	}
	int NumberOfMinutesInYear() {

		return NumberOfMinutesInYear(this->_Year);

	}

	static int NumberOfSecondsInYear(short Year) {

		return NumberOfMinutesInYear(Year) * 60;

	}
	int NumberOfSecondsInYear() {

		return NumberOfSecondsInYear(this->_Year);

	}

	static int NumberOfHoursInMonth(clsDate Date) {

		return NumberOfDaysInMonth(Date._Month, Date._Year) * 24;

	}
	int NumberOfHoursInMonth() {

		return NumberOfHoursInMonth(*this);

	}

	static int NumberOfMinutsInMonth(clsDate Date) {

		return NumberOfHoursInMonth(Date) * 60;

	}
	int NumberOfMinutsInMonth() {

		return NumberOfMinutsInMonth(*this);

	}

	static int NumberOfSecondsInMonth(clsDate Date) {

		return NumberOfMinutsInMonth(Date) * 60;

	}
	int NumberOfSecondsInMonth() {

		return NumberOfSecondsInMonth(*this);

	}
	//----------

	// Is XXX.
	static bool IsLeapYear(short Year)
	{
		return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
	}
	bool IsLeapYear() {

		return IsLeapYear(this->_Year);

	}

	static bool IsDate1BeforeDate2(clsDate Date1, clsDate Date2) {

		return (Date1._Year < Date2._Year || Date1._Month < Date2._Month || Date1._Day < Date2._Day);

	}
	bool IsDate1BeforeDate2(clsDate Date2) {

		return IsDate1BeforeDate2(*this, Date2);

	}

	static bool IsDate1AfterDate2(clsDate Date1, clsDate Date2) {

		return (Date1._Year > Date2._Year) || (Date1._Month > Date2._Month) || (Date1._Day > Date2._Day);

	}
	bool IsDate1AfterDate2(clsDate Date2) {

		return IsDate1AfterDate2(*this, Date2);

	}

	static bool IsDate1EqualDate2(clsDate Date1, clsDate Date2) {

		return (Date1._Year == Date2._Year && Date1._Month == Date2._Month && Date1._Day == Date2._Day);

	}
	bool IsDate1EqualDate2(clsDate Date2) {

		return IsDate1EqualDate2(*this, Date2);

	}

	static bool IsLastDayInMonth(clsDate Date) {

		return Date._Day == NumberOfDaysInMonth(Date._Month, Date._Year);

	}
	bool IsLastDayInMonth() {

		return IsLastDayInMonth(*this);

	}

	static bool IsLastMonthInYear(short Month) {

		return Month == 12;

	}
	bool IsLastMonthInYear() {

		return IsLastMonthInYear(this->_Month);

	}

	static bool IsEndOfTheWeek(clsDate Date) {

		return DayOrderInTheWeek(Date._Day, Date._Month, Date._Year) == 6;

	}
	bool IsEndOfTheWeek() {

		return IsEndOfTheWeek(*this);

	}

	static bool IsWeekEnd(clsDate Date) {

		short DyasIndex = DayOrderInTheWeek(Date._Day, Date._Month, Date._Year);

		return DyasIndex == 5 || DyasIndex == 6;

	}
	bool IsWeekEnd() {

		return IsWeekEnd(*this);

	}

	static bool IsBusinessDay(clsDate Date) {

		return !IsWeekEnd(Date);

	}
	bool IsBusinessDay() {

		return IsBusinessDay(*this);

	}

	static bool IsValidDate(clsDate Date) {

		if (Date.GetMonth() < 1 || Date.GetMonth() > 12)
			return false;

		short MonthDays = Date.NumberOfDaysInMonth();

		if (Date.GetDay() < 1 || Date.GetDay() > MonthDays)
			return false;

		return true;

	}
	bool IsValidDate() {

		return IsValidDate(*this);

	}
	//----------

	// Days & Months Names.
	static string DayName(short DayNum) {

		string Days[7] = { "sunday","monday","tusday", "wensday",
						   "thersday","friday","satarday" };

		return Days[DayNum];
	}
	string DayName() {

		return DayName(this->_Day);

	}

	static string MonthName(short MonthNum) {

		string Months[12] = { "jan","feb","mar","apr","may", "jun",
								"jul","aug","sep","oct","nov","dec" };

		return Months[MonthNum - 1];
	}
	string MonthName() {

		return MonthName(this->_Month);

	}
	//----------

	// Days Until End Of The XXX.
	static short DaysUntilTheEndOfTheWeek(clsDate Date) {

		return 6 - DayOrderInTheWeek(Date._Day, Date._Month, Date._Year);

	}
	short DaysUntilTheEndOfTheWeek() {

		return DaysUntilTheEndOfTheWeek(*this);

	}

	static short DaysUntilTheEndOfTheMonth(clsDate Date, bool IncludeCurrentDay = false) {

		return (IncludeCurrentDay) ? NumberOfDaysInMonth(Date._Month, Date._Year) - Date._Day + 1 : NumberOfDaysInMonth(Date._Month, Date._Year) - Date._Day;

	}
	short DaysUntilTheEndOfTheMonth(bool IncludeCurrentDay = false) {

		return DaysUntilTheEndOfTheMonth(*this, IncludeCurrentDay);

	}

	static short DaysUntilTheEndOfTheYear(clsDate Date, bool IncludeCurrentDay = false) {

		return (IncludeCurrentDay) ? NumberOfDaysInYear(Date._Year) - DaysFromYearStart(Date) + 1 : NumberOfDaysInYear(Date._Year) - DaysFromYearStart(Date);

	}
	short DaysUntilTheEndOfTheYear(bool IncludeCurrentDay = false) {

		return DaysUntilTheEndOfTheYear(*this, IncludeCurrentDay);

	}
	//----------

	// General Functions.
	static int DayOrderInTheWeek(short Day, short Month, short Year) {

		//Start From Sunday With Number 0 end in satarday with number 6.

		int a;

		a = (14 - Month) / 12;

		Year = Year - a;
		Month = Month + (12 * a) - 2;

		return (Day + Year + (Year / 4) - (Year / 100) + (Year / 400) + ((31 * Month) / 12)) % 7;

	}
	int DayOrderInTheWeek() {

		return  DayOrderInTheWeek(this->_Day, this->_Month, this->_Year);

	}

	static short DaysFromYearStart(clsDate Date) {

		short DaysSum = 0;

		for (short i = 1; i < Date._Month; i++) {

			DaysSum += NumberOfDaysInMonth(i, Date._Year);

		}

		return DaysSum + Date._Day;

	}
	short DaysFromYearStart() {

		return DaysFromYearStart(*this);

	}

	static clsDate GetDateFromDayOrderInTheYear(short DayOrderInYear, short Year)
	{
		// take the day order in the year (DaysFromYearStart function) and the year you want
		// and give you the date day/month/year in the struct sDate.

		clsDate Date;

		short RemainingDays = DayOrderInYear, MonthDays = 0;

		Date._Year = Year;
		Date._Month = 1;

		while (true)
		{
			MonthDays = NumberOfDaysInMonth(Date._Month, Date._Year);
			if (RemainingDays > MonthDays)
			{
				RemainingDays -= MonthDays;
				Date._Month++;
			}
			else
			{
				Date._Day = RemainingDays;
				break;
			}
		}
		return Date;
	}

	static int DifferenceBetweenToDatesInDays(clsDate Date1, clsDate Date2, bool IncludEndDay = false) {

		int DaysDiff;

		if (IsDate1BeforeDate2(Date1, Date2)) {

			if (Date1._Year == Date2._Year) {

				if (IncludEndDay)
					return DaysFromYearStart(Date2) - DaysFromYearStart(Date1) + 1;
				else
					return DaysFromYearStart(Date2) - DaysFromYearStart(Date1);

			}
			else {

				DaysDiff = NumberOfDaysInYear(Date1._Year) - DaysFromYearStart(Date1);
				Date1._Year++;

				while (Date1._Year < Date2._Year) {

					DaysDiff += NumberOfDaysInYear(Date1._Year);
					Date1._Year++;
				}

				DaysDiff += DaysFromYearStart(Date2);

				if (IncludEndDay)
					return DaysDiff + 1;
				else
					return DaysDiff;
			}
		}
		else {
			return 0;
		}

	}
	int DifferenceBetweenToDatesInDays(clsDate Date2, bool IncludEndDay = false) {

		return DifferenceBetweenToDatesInDays(*this, Date2, IncludEndDay);

	}

	static enDateCompare Compare2Dates(clsDate Date1, clsDate Date2) {

		if (IsDate1BeforeDate2(Date1, Date2))
			return enDateCompare::Before;
		if (IsDate1AfterDate2(Date1, Date2))
			return enDateCompare::After;

		return enDateCompare::equal;

	}
	enDateCompare Compare2Dates(clsDate Date2) {

		return Compare2Dates(Date2);

	}

	static short CalculateMyAgeInDays(clsDate DateOfBirth)
	{

		clsDate TodayDate = GetSystemDate(TodayDate);

		return DifferenceBetweenToDatesInDays(DateOfBirth, TodayDate, true);
	}

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

	static void PrintDate(clsDate Date) {

		printf("%d/%d/%d\n", Date._Day, Date._Month, Date._Year);

	}
	void PrintDate() {

		printf("%d/%d/%d\n", _Day, _Month, _Year);

	}
	//----------

	//Vacation & Business Functions.
	static short CalculateVacationDays(clsDate VacationStart, clsDate VacationEnd) {

		short VacationDays = 0;

		while (IsDate1BeforeDate2(VacationStart, VacationEnd)) {

			if (IsBusinessDay(VacationStart))
				VacationDays++;

			VacationStart = IncreaseDateByOneDay(VacationStart);


		}

		return VacationDays;

	}
	short CalculateVacationDays(clsDate VacationEnd) {

		return CalculateVacationDays(*this, VacationEnd);

	}

	static clsDate CalculateReturnDateFromVacation(clsDate VacationStart, short VacationDays) {

		for (short i = 1; i <= VacationDays; i++) {

			if (IsWeekEnd(VacationStart))
				i--;

			VacationStart = IncreaseDateByOneDay(VacationStart);

		}

		while (IsWeekEnd(VacationStart))
			VacationStart = IncreaseDateByOneDay(VacationStart);

		return VacationStart;

	}
	clsDate CalculateReturnDateFromVacation(short VacationDays) {

		return CalculateReturnDateFromVacation(*this, VacationDays);

	}

	static short CalculateBusinessDays(clsDate DateFrom, clsDate DateTo)
	{

		short Days = 0;
		while (IsDate1BeforeDate2(DateFrom, DateTo))
		{
			if (IsBusinessDay(DateFrom))
				Days++;

			DateFrom = IncreaseDateByOneDay(DateFrom);
		}

		return Days;

	}

	//----------

	// Calender Functions.
	static void PrintMonthCalendar(short Month, short Year)
	{
		int NumberOfDays;

		// Index of the day from 0 to 6
		int current = DayOrderInTheWeek(1, Month, Year);

		NumberOfDays = NumberOfDaysInMonth(Month, Year);

		// Print the current month name
		printf("\n  _______________%s_______________\n\n",
			MonthName(Month).c_str());

		// Print the columns
		printf("  Sun  Mon  Tue  Wed  Thu  Fri  Sat\n");

		// Print appropriate spaces
		int i;
		for (i = 0; i < current; i++)
			printf("     ");

		for (int j = 1; j <= NumberOfDays; j++)
		{
			printf("%5d", j);


			if (++i == 7)
			{
				i = 0;
				printf("\n");
			}
		}

		printf("\n  _________________________________\n");

	}
	void PrintMonthCalendar()
	{
		PrintMonthCalendar(_Month, _Year);
	}

	static void PrintYearCalnder(short Year) {

		cout << "\t\n_____________________________________________________\n\n";
		cout << "\t\tcalnder - " << Year << endl;
		cout << "\t\n_____________________________________________________\n\n";

		for (short i = 1; i <= 12; i++) {

			PrintMonthCalendar(i, Year);
		}
	}
	void PrintYearCalendar()
	{
		printf("\n  _________________________________\n\n");
		printf("           Calendar - %d\n", _Year);
		printf("  _________________________________\n");


		for (int i = 1; i <= 12; i++)
		{
			PrintMonthCalendar(i, _Year);
		}

		return;
	}
	//----------

	// Increase Date.
	static clsDate IncreaseDateByOneDay(clsDate Date) {

		if (IsLastDayInMonth(Date)) {

			Date._Day = 1;

			if (IsLastMonthInYear(Date._Month)) {

				Date._Month = 1;
				Date._Year++;

			}
			else
				Date._Month++;

		}
		else {
			Date._Day++;
		}

		return Date;

	}
	void IncreaseDateByOneDay() {

		*this = IncreaseDateByOneDay(*this);

	}

	static clsDate IncreaseDateByXDays(int DaysToAdd, clsDate DateInfo) {

		int DaysInYear = NumberOfDaysInYear(DateInfo._Year);
		int DaysInMonth;

		DaysToAdd += DaysFromYearStart(DateInfo);
		DateInfo._Month = 1;

		while (true) {

			int DaysInYear = NumberOfDaysInYear(DateInfo._Year);

			if (DaysToAdd > DaysInYear)
			{
				DaysToAdd -= DaysInYear;
				DateInfo._Year++;
				continue;
			}

			DaysInMonth = NumberOfDaysInMonth(DateInfo._Month, DateInfo._Year);

			if (DaysToAdd > DaysInMonth)
			{
				DaysToAdd -= DaysInMonth;
				DateInfo._Month++;
				continue;
			}
			else
			{
				DateInfo._Day = DaysToAdd;
				break;
			}
		}

		return DateInfo;
	}
	void IncreaseDateByXDays(int DaysToAdd) {

		*this = IncreaseDateByXDays(DaysToAdd, *this);

	}

	static clsDate IncreaseDateByOneWeek(clsDate Date) {

		return IncreaseDateByXDays(7, Date);

	}
	void IncreaseDateByOneWeek() {

		*this = IncreaseDateByOneWeek(*this);

	}

	static clsDate IncreaseDateByXWeeks(int WeeksToAdd, clsDate Date) {

		for (int i = 1; i <= WeeksToAdd; i++) {

			Date = IncreaseDateByOneWeek(Date);

		}

		return Date;

	}
	void IncreaseDateByXWeeks(int WeeksToAdd) {

		*this = IncreaseDateByXWeeks(WeeksToAdd, *this);

	}

	static clsDate IncreaseDateByOneMonth(clsDate Date) {

		int DaysInMonth;

		if (Date._Month == 12) {

			Date._Month = 1;
			Date._Year++;

		}
		else
		{
			Date._Month++;
		}

		DaysInMonth = NumberOfDaysInMonth(Date._Month, Date._Year);

		if (Date._Day > DaysInMonth) {

			Date._Day -= DaysInMonth;

			Date._Month++;

		}

		return Date;

	}
	void IncreaseDateByOneMonth() {

		*this = IncreaseDateByOneMonth(*this);

	}

	static clsDate IncreaseDateByXMonths(int MonthToAdd, clsDate Date) {

		for (int i = 1; i <= MonthToAdd; i++) {

			Date = IncreaseDateByOneMonth(Date);

		}

		return Date;

	}
	void IncreaseDateByXMonths(int MonthToAdd) {

		*this = IncreaseDateByXMonths(MonthToAdd, *this);

	}

	static clsDate IncreaseDateByOneYear(clsDate Date) {

		Date._Year++;

		return Date;

	}
	void IncreaseDateByOneYear() {

		*this = IncreaseDateByOneYear(*this);

	}

	static clsDate IncreaseDateByXYears(int YearsToAdd, clsDate Date) {

		Date._Year += YearsToAdd;

		return Date;

	}
	void IncreaseDateByXYears(int YearsToAdd) {

		*this = IncreaseDateByXYears(YearsToAdd, *this);

	}

	static clsDate IncreaseDateByOneDecade(clsDate Date) {

		Date._Year += 10;

		return Date;

	}
	void IncreaseDateByOneDecade() {

		*this = IncreaseDateByOneDecade(*this);

	}

	static clsDate IncreaseDateByXDecades(int DecadesToAdd, clsDate Date) {

		Date._Year += DecadesToAdd * 10;

		return Date;

	}
	void IncreaseDateByXDecades(int DecadesToAdd) {

		*this = IncreaseDateByXDecades(DecadesToAdd, *this);

	}

	static clsDate IncreaseDateByOneCentury(clsDate Date) {

		Date._Year += 100;

		return Date;

	}
	void IncreaseDateByOneCentury() {

		*this = IncreaseDateByOneCentury(*this);


	}

	static clsDate IncreaseDateByXCenturys(int CenturysToAdd, clsDate Date) {

		Date._Year += CenturysToAdd * 100;

		return Date;

	}
	void IncreaseDateByXCenturys(int CenturysToAdd) {

		*this = IncreaseDateByXCenturys(CenturysToAdd, *this);

	}

	static clsDate IncreaseDateByOneMillennuim(clsDate Date) {

		Date._Year += 1000;

		return Date;

	}
	void ncreaseDateByOneMillennuim() {

		*this = IncreaseDateByOneMillennuim(*this);


	}

	static clsDate IncreaseDateByXMillennuims(int MillennuimsToAdd, clsDate Date) {

		Date._Year += MillennuimsToAdd * 1000;

		return Date;

	}
	clsDate IncreaseDateByXMillennuims(int MillennuimsToAdd) {

		*this = IncreaseDateByXMillennuims(MillennuimsToAdd, *this);


	}
	//----------

	// Decrease Date.
	static clsDate DecreaseDateByOneDay(clsDate Date) {

		if (Date._Day == 1) {

			if (Date._Month == 1) {

				Date._Year--;
				Date._Month = 12;
				Date._Day = 31;

			}
			else {

				Date._Month--;
				Date._Day = NumberOfDaysInMonth(Date._Month, Date._Year);

			}

		}
		else {


			Date._Day--;

		}

		return Date;

	}
	void DecreaseDateByOneDay() {

		*this = DecreaseDateByOneDay(*this);

	}

	static clsDate DecreaseDateByXDays(int DaysToDecrease, clsDate DateInfo) {

		int DaysInYear = NumberOfDaysInYear(DateInfo._Year);

		if (DaysToDecrease > DaysInYear) {

			DaysToDecrease += DaysFromYearStart(DateInfo);
			DateInfo._Year--;

		}

		while (DaysToDecrease > (DaysInYear = DaysFromYearStart(DateInfo))) {

			DaysToDecrease -= DaysInYear;
			DateInfo._Year--;

		}

		int DaysInMonth;

		while (DaysToDecrease > (DaysInMonth = NumberOfDaysInMonth(DateInfo._Month, DateInfo._Year))) {

			DaysToDecrease -= DaysInMonth;

			if (DateInfo._Month == 1) {

				DateInfo._Month = 12;
				DateInfo._Year--;
			}
			else
				DateInfo._Month--;

		}

		for (int i = 1; i <= DaysToDecrease; i++) {

			DateInfo = DecreaseDateByOneDay(DateInfo);

		}

		return DateInfo;

	}
	void DecreaseDateByXDays(int DaysToDecrease) {

		*this = DecreaseDateByXDays(DaysToDecrease, *this);

	}

	static clsDate DecreaseDateByOneWeek(clsDate Date) {

		return DecreaseDateByXDays(7, Date);

	}
	void DecreaseDateByOneWeek() {

		*this = DecreaseDateByOneWeek(*this);


	}

	static clsDate DecreaseDateByXWeeks(int WeeksToDecrease, clsDate Date) {

		for (int i = 1; i <= WeeksToDecrease; i++) {

			Date = DecreaseDateByOneWeek(Date);

		}

		return Date;

	}
	void DecreaseDateByXWeeks(int WeeksToDecrease) {

		*this = DecreaseDateByXWeeks(WeeksToDecrease, *this);


	}

	static clsDate DecreaseDateByOneMonth(clsDate Date) {

		short DaysInMonth;

		if (Date._Month == 1) {

			Date._Month = 12;
			Date._Year--;

		}
		else
		{
			Date._Month--;
		}

		if (Date._Day > (DaysInMonth = NumberOfDaysInMonth(Date._Month, Date._Year))) {

			Date._Day -= DaysInMonth;

			Date._Month--;

		}

		return Date;

	}
	void DecreaseDateByOneMonth() {

		*this = DecreaseDateByOneMonth(*this);


	}

	static clsDate DecreaseDateByXMonths(int MonthToDecrease, clsDate Date) {

		for (int i = 1; i <= MonthToDecrease; i++) {

			Date = DecreaseDateByOneMonth(Date);

		}

		return Date;

	}
	void DecreaseDateByXMonths(int MonthToDecrease) {

		*this = DecreaseDateByXWeeks(MonthToDecrease, *this);

	}

	static clsDate DecreaseDateByOneYear(clsDate Date) {

		Date._Year--;

		return Date;

	}
	void DecreaseDateByOneYear() {

		*this = DecreaseDateByOneYear(*this);


	}

	static clsDate DecreaseDateByXYears(int YearsToDecrease, clsDate Date) {

		Date._Year -= YearsToDecrease;

		return Date;

	}
	void DecreaseDateByXYears(int YearsToDecrease) {

		*this = DecreaseDateByXYears(YearsToDecrease, *this);


	}

	static clsDate DecreaseDateByOneDecade(clsDate Date) {

		Date._Year -= 10;

		return Date;

	}
	void DecreaseDateByOneDecade() {

		*this = DecreaseDateByOneDecade(*this);


	}

	static clsDate DecreaseDateByXDecades(int DecadesToDecrease, clsDate Date) {

		Date._Year -= DecadesToDecrease * 10;

		return Date;

	}
	void DecreaseDateByXDecades(int DecadesToDecrease) {

		*this = DecreaseDateByXDecades(DecadesToDecrease, *this);


	}

	static clsDate DecreaseDateByOneCentury(clsDate Date) {

		Date._Year -= 100;

		return Date;

	}
	void DecreaseDateByOneCentury() {

		*this = DecreaseDateByOneCentury(*this);

	}

	static clsDate DecreaseDateByXCenturys(int CenturysToDecrease, clsDate Date) {

		Date._Year -= CenturysToDecrease * 100;

		return Date;

	}
	void DecreaseDateByXCenturys(int CenturysToDecrease) {

		*this = DecreaseDateByXCenturys(CenturysToDecrease, *this);

	}

	static clsDate DecreaseDateByOneMillennuim(clsDate Date) {

		Date._Year -= 1000;

		return Date;

	}
	void DecreaseDateByOneMillennuim() {

		*this = DecreaseDateByOneMillennuim(*this);


	}

	static clsDate DecreaseDateByXMillennuims(int MillennuimsToDecrease, clsDate Date) {

		Date._Year -= MillennuimsToDecrease * 1000;

		return Date;

	}
	void DecreaseDateByXMillennuims(int MillennuimsToDecrease) {

		*this = DecreaseDateByXMillennuims(MillennuimsToDecrease, *this);

	}
	//----------

	// Date manipulation.
	static string FormateDate(clsDate Date, string DateFormat = "dd/mm/yyyy")
	{
		string FormattedDateString = "";

		FormattedDateString = clsString::ReplaceWordInString(DateFormat, "dd", to_string(Date._Day));
		FormattedDateString = clsString::ReplaceWordInString(FormattedDateString, "mm", to_string(Date._Month));
		FormattedDateString = clsString::ReplaceWordInString(FormattedDateString, "yyyy", to_string(Date._Year));

		return FormattedDateString;
	}
	static string DateToString(clsDate Date) {

		return to_string(Date._Day) + "/" + to_string(Date._Month) +
			"/" + to_string(Date._Year);

	}
	static clsDate StringToDate(string stringDate) {

		clsDate Date;

		vector<string> V = clsString::SplitStringInVector(stringDate, "/");

		Date._Day = stoi(V[0]);
		Date._Month = stoi(V[1]);
		Date._Year = stoi(V[2]);

		return Date;

	}
	//----------

};


