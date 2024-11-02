/*

	Creat a Stack Class.

	Note: Use the Queue Class You Created to Implement the Stack.

*/

#pragma once

#include <iostream>
#include "clsMyQueueArray.h"

using namespace std;

template <class T> class  clsMyStackArr :public clsMyQueueArray <T>
{

public:

	void push(T Item)
	{
		clsMyQueueArray <T>::_MyArray.InsertAtBeginning(Item);
	}

	T Top()
	{
		return clsMyQueueArray <T>::front();

	}

	T Bottom()
	{
		return clsMyQueueArray <T>::back();

	}

};

