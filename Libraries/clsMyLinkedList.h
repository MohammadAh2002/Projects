/*

    Creat a Doubly Linked List Class.

*/

#pragma once

#include <iostream>

using namespace std;

template <class T> class clsDblLinkedList
{

protected:

    int _Size = 0;

public:

    class Node
    {

    public:
        T value;
        Node* next;
        Node* prev;
    };

    Node* head = NULL;

    void InsertAtBeginning(T value)
    {

        /*
            1-Create a new node with the desired value.
            2-Set the next pointer of the new node to the current head of the list.
            3-Set the previous pointer of the current head to the new node.
            4-Set the new node as the new head of the list.
        */

        Node* newNode = new Node();
        newNode->value = value;
        newNode->next = head;
        newNode->prev = NULL;

        if (head != NULL) {
            head->prev = newNode;
        }
        head = newNode;

        _Size++;
    }

    void PrintList()
    {
        Node* Current = head;

        if (Current == NULL) {

            cout << "Ther is no elemnts in the linked list :-(\n";
            return;

        }

        cout << "head -> ";

        while (Current != NULL) {
            cout << Current->value << " -> ";
            Current = Current->next;
        }

        cout << "NULL\n";

    }

    Node* Find(T Value)
    {
        Node* Current = head;
        while (Current != NULL) {

            if (Current->value == Value)
                return Current;

            Current = Current->next;
        }

        return NULL;

    }

    void InsertAfter(Node* current, T value) {


        /*  1 - Create a new node with the desired value.
             2-Set the next pointer of the new node to the next node of the current node.
             3-Set the previous pointer of the new node to the current node.
             4-Set the next pointer of the current node to the new node.
             5-Set the previous pointer of the next node to the new node(if it exists).
        */

        if (current == NULL) {
            return;
        }

        Node* newNode = new Node();
        newNode->value = value;
        newNode->next = current->next;
        newNode->prev = current;

        if (current->next != NULL) {
            current->next->prev = newNode;
        }
        current->next = newNode;
        _Size++;

    }

    void InsertAfter(int Index, T Value) {

        Node* Node = GetNode(Index);

        if (Node != NULL)
            InsertAfter(Node, Value);

    }

    void InsertAtEnd(T value) {

        /*
            1-Create a new node with the desired value.
            2-Traverse the list to find the last node.
            3-Set the next pointer of the last node to the new node.
            4-Set the previous pointer of the new node to the last node.
        */


        Node* newNode = new Node();
        newNode->value = value;
        newNode->next = NULL;
        if (head == NULL) {
            newNode->prev = NULL;
            head = newNode;
        }
        else {
            Node* current = head;
            while (current->next != NULL) {
                current = current->next;
            }
            current->next = newNode;
            newNode->prev = current;
        }

        _Size++;

    }

    void DeleteNode(Node*& NodeToDelete) {

        /*
            1-Set the next pointer of the previous node to the next pointer of the current node.
            2-Set the previous pointer of the next node to the previous pointer of the current node.
            3-Delete the current node.
        */
        if (head == NULL || NodeToDelete == NULL) {
            return;
        }
        if (head == NodeToDelete) {
            head = NodeToDelete->next;
        }
        if (NodeToDelete->next != NULL) {
            NodeToDelete->next->prev = NodeToDelete->prev;
        }
        if (NodeToDelete->prev != NULL) {
            NodeToDelete->prev->next = NodeToDelete->next;
        }
        delete NodeToDelete;
        _Size--;

    }

    void DeleteFirstNode()
    {

        /*
            1-Store a reference to the head node in a temporary variable.
            2-Update the head pointer to point to the next node in the list.
            3-Set the previous pointer of the new head to NULL.
            4-Delete the temporary reference to the old head node.
        */

        if (head == NULL) {
            return;
        }
        Node* temp = head;
        head = head->next;
        if (head != NULL) {
            head->prev = NULL;
        }
        delete temp;
        _Size--;

    }

    void DeleteLastNode() {

        /*
            1-Traverse the list to find the last node.
            2-Set the next pointer of the second-to-last node to NULL.
            3-Delete the last node.
        */

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

    int Size() {

        return _Size;

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

        Node* temp = head;

        while (head != NULL)
        {
            temp = head->next;
            head->next = head->prev;
            head->prev = temp;

            if (head->prev == NULL)	break;

            head = head->prev;
        }



    }

    Node* GetNode(int Index) {

        if (head == NULL || _Size < Index || Index < 0)
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

    void SpliteLinkedListIntoTwoHalfs() {

        short LinkedListLenth = Size();

        Node* Current = head;

        if (LinkedListLenth == 0) {
            cout << "you dont have any elemnts in you linked list :-(\n";
            return;
        }
        if (LinkedListLenth == 1) {

            cout << "ther is only one elemnts: " << Current->value << '\n';
            return;
        }

        cout << "\nthe first half:\n";
        for (short i = 1; i <= LinkedListLenth / 2; i++) {

            cout << Current->value << " ";
            Current = Current->next;
        }

        cout << "\nthe second half:\n";

        while (Current != NULL) {

            cout << Current->value << " ";
            Current = Current->next;

        }

    }

    clsDblLinkedList <T> Clone() {

        Node* Current = head;

        clsDblLinkedList <int> ClonedList;

        while (Current != NULL) {

            ClonedList.InsertAtEnd(Current->value);

            Current = Current->next;

        }

        return ClonedList;

    }

    void PrintLinkedListMemeoryAdresse() {

        short i = 1;

        Node* Current = head;

        if (Current == NULL) {

            cout << "you dont have any elemnt in the linked list :-(\n";
            return;
        }

        while (Current != NULL) {

            printf("elemnts %d memery adress:%p\n", i, Current);

            Current = Current->next;

            i++;
        }


    }

    void RemoveduplicatesFromSortedLinkedList() {

        Node* Current = head, * NodeToDelete;

        if (Current == NULL)
            return;

        while (Current->next != NULL) {

            if (Current->value == Current->next->value) {

                NodeToDelete = Current->next;

                Current->next = Current->next->next;

                if (Current->next != NULL) {
                    Current->next->prev = Current;
                }

                delete NodeToDelete;

            }
            else {

                Current = Current->next;
            }

        }

    }

    static Node* MergeTwoLists(Node* Node1Head, Node* Node2Head) {

        if (Node1Head == NULL && Node2Head == NULL)
            return NULL;

        if (Node1Head == NULL)
            return Node2Head;

        if (Node2Head == NULL)
            return Node1Head;

        clsDblLinkedList MergedNodeHead;

        while (true) {

            if (Node1Head != NULL) {

                MergedNodeHead.InsertAtEnd(Node1Head->value);

                Node1Head = Node1Head->next;
            }

            if (Node2Head != NULL) {

                MergedNodeHead.InsertAtEnd(Node2Head->value);

                Node2Head = Node2Head->next;
            }

            if (Node1Head == NULL && Node2Head == NULL)
                break;

        }

        return MergedNodeHead.head;

    }

    bool IsElementExistInList(T Val) {

        Node* Current = head;

        while (Current != NULL) {

            if (Current->value == Val)
                return true;

            Current = Current->next;

        }

        return false;

    }

    void MyReversList() {


        if (head == NULL || head->next == NULL)
            return;

        Node* prev = NULL, * Current = head->next;
        head->next = NULL;

        while (Current != NULL) {

            prev = head;
            head = Current;
            Current = Current->next;
            head->next = prev;
        }

    }

    void DeleteNEveryM(short N, short M) {

        Node* Current = head, *NodeToDelte = NULL;

        short DeleteCounter = 0, SkipCounter = 1;

        while (Current != NULL) {

            while (SkipCounter <= M && Current != NULL) {

                Current = Current->next;
                SkipCounter++;

            }

            if (Current == NULL) {

                break;
            }

            while (DeleteCounter < N && Current != NULL) {

                NodeToDelte = Current;
                Current = Current->next;

                DeleteNode(NodeToDelte);

                DeleteCounter++;

            }

            SkipCounter = 1;
            DeleteCounter = 0;
        }

    }

    void DeleteAllNodesHaveX(T Value) {

        Node* Current = head, * NodeToDelete = NULL;

        while (Current != NULL) {

            if (Value == Current->value) {

                NodeToDelete = Current;
                Current = Current->next;

                DeleteNode(NodeToDelete);

                continue;
            }

            Current = Current->next;

        }


    }

};

