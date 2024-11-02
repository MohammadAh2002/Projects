/*

    Build a Period Class Have in it Methods to manipulate Periods.

    Methods in the Class :

    - SetStartDay(clsDate StartDate)
    - GetStartDate()
    - SetEndDate(clsDate EndDate)
    - GetEndDate()
    - static IsOverlapPeriods(clsPeriod Period1, clsPeriod Period2)
    - IsOverLapPeriods(clsPeriod Period2)
    - static IsDateWithinThePeriod(clsPeriod Period1, clsDate Date)
    - IsDateWithinThePeriod(clsDate Date)
    - static OverlapDaysBetween2Periods(clsPeriod Period1, clsPeriod Period2)
    - OverlapDaysBetween2Periods(clsPeriod Period2)
    - static PeriodLenthInDays(clsPeriod Period, bool IncludEndDay = false)
    - PeriodLenthInDays(bool IncludEndDay = false)
    - Print()

    Note: To Use the Class You Should Include the Date Library in Your Project.

*/

#pragma once

#include <iostream>
#include "clsDate.h"

class clsPeriod
{

private:

    clsDate _StartDate;
    clsDate _EndDate;

public:

    clsPeriod(clsDate StartDate, clsDate EndDate)
    {
        _StartDate = StartDate;
        _EndDate = EndDate;

    }

    void SetStartDay(clsDate StartDate) {

        _StartDate = StartDate;

    }
    clsDate GetStartDate() {

        return  _StartDate;

    }

    void SetEndDate(clsDate EndDate) {

        _EndDate = EndDate;

    }
    clsDate GetEndDate() {

        return  _EndDate;

    }

    static bool IsOverlapPeriods(clsPeriod Period1, clsPeriod Period2)
    {

        if (
            clsDate::Compare2Dates(Period2._EndDate, Period1._StartDate) == clsDate::enDateCompare::Before
            ||
            clsDate::Compare2Dates(Period2._StartDate, Period1._EndDate) == clsDate::enDateCompare::After
            )
            return false;
        else
            return true;

    }
    bool IsOverLapPeriods(clsPeriod Period2)
    {
        return IsOverlapPeriods(*this, Period2);
    }

    static bool IsDateWithinThePeriod(clsPeriod Period1, clsDate Date) {

        return !(clsDate::Compare2Dates(Period1._EndDate, Date) == clsDate::enDateCompare::Before
            ||
            clsDate::Compare2Dates(Period1._StartDate, Date) == clsDate::enDateCompare::After);

    }
    bool IsDateWithinThePeriod(clsDate Date) {

        return IsDateWithinThePeriod(*this, Date);

    }

    static int OverlapDaysBetween2Periods(clsPeriod Period1, clsPeriod Period2) {

        int OverlapDays = 0;

        if (IsOverlapPeriods(Period1, Period2)) {

            return clsDate::DifferenceBetweenToDatesInDays(Period2._StartDate, Period1._EndDate);

        }

        return 0;
    }
    int OverlapDaysBetween2Periods(clsPeriod Period2) {

        return OverlapDaysBetween2Periods(*this, Period2);

    }

    static int PeriodLenthInDays(clsPeriod Period, bool IncludEndDay = false) {

        return clsDate::DifferenceBetweenToDatesInDays(Period._StartDate, Period._EndDate, IncludEndDay);

    }
    int PeriodLenthInDays(bool IncludEndDay = false) {

        return PeriodLenthInDays(*this);

    }

    void Print()
    {
        cout << "Period Start: ";
        _StartDate.PrintDate();

        cout << "Period End: ";
        _EndDate.PrintDate();

    }

};
