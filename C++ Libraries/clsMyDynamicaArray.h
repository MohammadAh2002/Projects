/*

	Creat a Dynamic Array Class.

*/

#pragma once

#include <iostream>

using namespace std;

template <class T> class clsMyDynamicArray
{
protected:

	int _Size = 0;

	T* _TempArray, * OriginalArray;


public:


	clsMyDynamicArray(int Size = 0) {

		if (Size < 0)
			Size = 0;

		_Size = Size;

		OriginalArray = new T[_Size];

	}
	
	~clsMyDynamicArray() {

		delete[] OriginalArray;

	}

	void SetItem(int Index, T Value) {

		if (Index < 0 || Index >= _Size)
			return;

		OriginalArray[Index] = Value;

	}

	void PrintList() {

		for (int i = 0; i < _Size; i++) {

			cout << OriginalArray[i] << " ";

		}

		cout << '\n';

	}

	bool IsEmpty() {

		return _Size == 0;

	}

	int Size() {

		return _Size;

	}

	void Resize(int NewSize) {

		if (NewSize < 0)
			NewSize = 0;

		_TempArray = new T[NewSize];

		//copy all data from original array until the size
		for (int i = 0; i < NewSize; i++)
		{
			_TempArray[i] = OriginalArray[i];
		}

		delete[] OriginalArray;

		_Size = NewSize;

		OriginalArray = _TempArray;


	}

	T GetItem(int Index){
	
		// Return The Value;

		if (Index >= _Size || Index < 0)
			return -1;

		return OriginalArray[Index];
	
	}

	void Reverse() {

		_TempArray = new T[_Size];

		for (int i = _Size - 1; i >= 0; i--) {


			_TempArray[_Size - i - 1] = OriginalArray[i];

		}

		delete[] OriginalArray;
		OriginalArray = _TempArray;

	}

	void Clear()
	{
		_TempArray = new T[0];
		delete[] OriginalArray;
		_Size = 0;
		OriginalArray = _TempArray;
	}

	void DeleteItemByIndex(int Index) {

		if (Index < 0 || Index >= _Size)
			return;

		_TempArray = new T[_Size - 1];

		short counter = 0;

		for (int i = 0; i < _Size; i++) {

			if (i == Index)
				continue;

			_TempArray[counter] = OriginalArray[i];
			counter++;
		
		}
				
		delete[]OriginalArray;

		_Size -= 1;

		OriginalArray = _TempArray;

	}
	void DeleteItemByValue(T Value) {

		int Index = Find(Value);

		if (Index == -1)
			return;

		DeleteItemByIndex(Index);
	}

	void DeleteFirstItem() {

		DeleteItemByIndex(0);

	}

	void DeleteLastItem() {

		DeleteItemByIndex(_Size - 1);

	}

	int Find(T Value) {

		// Return The Index Of The Value;

		for (int i = 0; i < _Size; i++) {

			if (OriginalArray[i] == Value)
				return i;

		}

		return -1;

	}

	void InsertAt(int index, T value) {

		if (index > _Size || index < 0)
		{
			return;
		}

		_Size++;

		_TempArray = new T[_Size];

		//copy all before index
		for (int i = 0; i < index; i++)
		{
			_TempArray[i] = OriginalArray[i];
		}

		_TempArray[index] = value;

		//copy all after index
		for (int i = index; i < _Size - 1; i++)
		{
			_TempArray[i + 1] = OriginalArray[i];
		}

		delete[] OriginalArray;
		OriginalArray = _TempArray;

	}

	void InsertAtBeginning(T Value) {

		InsertAt(0, Value);

	}

	void InsertBefore(int Index, T Value) {

		if (Index < 1) {
			InsertAt(0, Value);
			return;
		}

		InsertAt(Index- 1, Value);

	}

	void InsertAfter(int Index, T Value) {

		if (Index >= _Size) {

			InsertAt(_Size - 1, Value);

		}

		InsertAt(Index + 1, Value);

	}

	void InsertAtEnd(T Value) {

		InsertAt(_Size, Value);

	}

};

