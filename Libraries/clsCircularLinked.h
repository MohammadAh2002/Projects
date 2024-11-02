/*

	Creat a Circular Linked List Class.

*/

#pragma once

#include <iostream>

using namespace std;

template <class T> class clsCircularLinked
{
protected:

	int _Size = 0;

public:

	class Node {
	public:
		T  Value;
		Node* next;
	};

	Node* head = NULL;

	void InsertAtBeginning(T Val) {

		Node* NewNode = new Node();

		NewNode->Value = Val;
		NewNode->next = head;

		if (head == NULL) {

			NewNode->next = NewNode;

			head = NewNode;

			_Size++;

			return;

		}

		Node* LastNode = head;

		while(LastNode->next != head) 
			LastNode = LastNode->next;

		head = NewNode;
		LastNode->next = head;

		_Size++;
	}

	void PrintList() {

		if (head == NULL) {
			cout << "\nThe circular linked list is empty.\n" << endl;
			return;
		}

		cout << "head -> ";

		Node* CurrentNode = head;

		while (true) {

			cout << CurrentNode->Value << " -> ";

			CurrentNode = CurrentNode->next;

			if (CurrentNode == head)
				break;

		}

		cout << "NULL";


	}

	int Size() {

		return _Size;

	}

	bool IsEmpty() {

		return head == NULL;

	}

	Node* Find(T Value) {

		if (head == NULL) {
			cout << "\nThe circular linked list is empty.\n";
			return NULL;
		}

		Node* Current = head;

		while (true) {

			if (Current->Value == Value)
				return Current;

			Current = Current->next;

			if (Current == head)
				break;

		}

		return NULL;

	}

	void InsertAfterByNode(Node* current, T value) {

		if (current == NULL) {

			cout << "\nThe Node you Want to Add After Is Not Exist\n";
			return;

		}

		Node* NewNode = new Node();
		NewNode->Value = value;
		NewNode->next = current->next;

		current->next = NewNode;

		_Size++;
	}

	void InsertAfterByIndex(int Index, T Value) {

		Node* Node = GetNode(Index);

		if (Node != NULL)
			InsertAfterByNode(Node, Value);

	}

	void InsertAtEnd(T value) {

		Node* NewNode = new Node();
		NewNode->Value = value;
		NewNode->next = head;

		if (head == NULL) {

			NewNode->next = NewNode;

			head = NewNode;
			_Size++;
			return;

		}

		Node* LastNode = head;

		while (LastNode->next != head) {

			LastNode = LastNode->next;

		}

		LastNode->next = NewNode;

		_Size++;

	}

	void DeleteNode(Node*& NodeToDelete) {

		if (head == NULL || NodeToDelete == NULL)
			return;
		
		Node* PrevNode = head;

		while (PrevNode->next->Value != NodeToDelete->Value) {

			PrevNode = PrevNode->next;

		}

		if (NodeToDelete == head)
			head = head->next;

		PrevNode->next = NodeToDelete->next;
		delete NodeToDelete;
		_Size--;
	}

	void DeleteFirstNode()
	{

		if (head == NULL) {
			return;
		}

		if (head->next == head)
		{
			
			delete head;

			head = NULL;

			_Size--;

			return;
		}

		Node* temp = head;


		Node* LastNode = head;

		while (LastNode->next != head) {

			LastNode = LastNode->next;

		}

		head = head->next;
		LastNode->next = head;

		delete temp;
		_Size--;

	}

	void DeleteLastNode() {

		if (head == NULL) {
			return;
		}

		if (head->next == head) {

			DeleteFirstNode();
			return;
		}

		Node* LastNode = head;

		// we need to find the node before last node.
		while (LastNode->next->next != head)
		{
			LastNode = LastNode->next;
		}

		Node* temp = LastNode->next;
		LastNode->next = head;
		delete temp;
		_Size--;

	}

	void Clear() {

		while (head != NULL) {

			DeleteFirstNode();
			DeleteLastNode();
		}

	}

	Node* GetNode(int Index) {

		if (head == NULL || _Size <= Index || Index < 0)
			return NULL;

		Node* Current = head;
		short counter = 0;

		while (counter < _Size) {

			if (counter == Index) {
				return Current;
			}

			Current = Current->next;
			counter++;
		}

		return NULL;

	}

	int GetItem(int Index) {

		Node* Item = GetNode(Index);

		if (Item != NULL)
			return Item->value;

		return NULL;
	}

	void UpdateItemByIndex(int Index, T NewValue) {

		Node* Item = GetNode(Index);

		if (Item != NULL)
			Item->value = NewValue;

	}

	void ReversList() {

		if (head == NULL) {

			cout << "\nThe Linked List Is Empty\n";
			return;

		}

		Node* Current = head->next, * Prev = head, * Next = Current->next;

		while (Current != head) {

			Current->next = Prev;

			Prev = Current;
			Current = Next;
			Next = Next->next;

		}

		Current->next = Prev;

		head = Prev;

	}



};

