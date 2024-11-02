/*

	Creat a Linked List Class.

*/

#pragma once

#include <iostream>

using namespace std;

template <class T> class clsLinkedList
{
protected:

	int _Size = 0;

public:

	class Node {
	public:

		T val;
		Node* next;

	};

	Node* head = NULL;

	void InsertAtBeginning(T Value) {

		Node* NewNode = new Node();

		NewNode->val = Value;
		NewNode->next = head;

		head = NewNode;

		_Size++;

	}

	void PrintList() {

		cout << "head -> ";

		Node* CurrentNode = head;

		while (CurrentNode != NULL) {

			cout << CurrentNode->val << " -> ";

			CurrentNode = CurrentNode->next;

		}

		cout << "NULL";

	}

	int Size() {

		return _Size;

	}

	Node* Find(T Value) {

		Node* CurrentNode = head;

		while (CurrentNode != NULL){

			if (CurrentNode->val == Value)
				return CurrentNode;

			CurrentNode = CurrentNode->next;

		}

		return NULL;

	}

	void InsertAfter(Node* current, T value) {

		if (current == NULL) {
			return;
		}

		Node* newNode = new Node();
		newNode->val = value;
		newNode->next = current->next;

		current->next = newNode;
		_Size++;

	}

	void InsertAfter(int Index, T Value) {

		Node* Node = GetNode(Index);

		if (Node != NULL)
			InsertAfter(Node, Value);

	}

	void InsertAtEnd(T value) {

		Node* NewNode = new Node();
		NewNode->val = value;
		NewNode->next = NULL;

		if (head == NULL) {
			head = NewNode;
			_Size++;
			return;
		
		}

		Node* LastNode = head;
		
		while(LastNode->next != NULL) {

			LastNode = LastNode->next;

		}

		LastNode->next = NewNode;

		_Size++;

	}

	void DeleteNode(Node*& NodeToDelete) {

		if (head == NULL || NodeToDelete == NULL)
			return;
		
		Node* PrevNode = head;

		while (PrevNode->next->val != NodeToDelete->val) {

			PrevNode = PrevNode->next;

		}

		PrevNode->next = NodeToDelete->next;
		delete NodeToDelete;
		_Size--;
	}

	void DeleteFirstNode()
	{

		if (head == NULL) {
			return;
		}

		Node* temp = head;
		head = head->next;

		
		delete temp;
		_Size--;

	}

	void DeleteLastNode() {

		if (head == NULL) {
			return;
		}

		if (head->next == NULL) {
			delete head;
			head = NULL;
			_Size--;
			return;
		}

		Node* current = head;
		// we need to find the node before last node.
		while (current->next->next != NULL)
		{
			current = current->next;
		}

		Node* temp = current->next;
		current->next = NULL;
		delete temp;
		_Size--;

	}

	bool IsEmpty() {

		//return _Size == 0;
		return head == NULL;

	}

	void Clear() {

		while (head != NULL) {

			DeleteFirstNode();
			DeleteLastNode();
		}

	}

	void ReversList() {

		Node* temp1 = head, *temp2 = NULL;

		while (true) {

			head = head->next;
			temp1->next = temp2;
			temp2 = temp1;
			temp1 = head;

			if (head == NULL) {

				head = temp2;
				return;
			}

		}

	}

	Node* GetNode(int Index) {

		if (head == NULL || _Size <= Index || Index < 0)
			return NULL;

		Node* Current = head;
		int counter = 0;

		while (Current != NULL) {

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

		if (Item == NULL)
			return NULL;

		return Item->value;

	}

	void UpdateItem(int Index, T NewValue) {

		Node* Item = GetNode(Index);

		if (Item == NULL)
			return;

		Item->value = NewValue;

	}
};

