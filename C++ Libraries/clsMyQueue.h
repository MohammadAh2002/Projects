/*

	Creat a Queue Class.

	Note: Use the Doubly Linked List Class You Created to Implement the Queue.

*/

#pragma once

#include <iostream>
#include "clsMyLinkedList.h"

using namespace std;

template <class T> class clsMyQueue
{

protected:
	clsDblLinkedList <T> _MyList;

public:

	void push(T Item)
	{
		_MyList.InsertAtEnd(Item);
	}

	void pop()
	{
		_MyList.DeleteFirstNode();
	}

	void Print()
	{
		_MyList.PrintList();
	}

	int Size()
	{
		return _MyList.Size();
	}

	bool IsEmpty()
	{
		return _MyList.IsEmpty();
	}

	T front()
	{
		return _MyList.GetItem(0);
	}

	T back()
	{
		return _MyList.GetItem(Size() - 1);
	}

	T GetItem(int Index) {

		return _MyList.GetItem(Index);


	}

	void Revers() {

		_MyList.ReversList();

	}

	void UpdateItem(int Index, T Value) {

		_MyList.UpdateItem(Index,Value);

	}

	void InsertAfter(int Index, T Value) {

		_MyList.InsertAfter(Index, Value);


	}

	void InsertAtFront(T Value) {

		_MyList.InsertAtBeginning(Value);

	}

	void InsertAtBack(T Value) {

		push(Value);

	}

	void Clear() {

		_MyList.Clear();

	}


};


