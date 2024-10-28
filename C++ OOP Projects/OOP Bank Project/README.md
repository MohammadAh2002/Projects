# Bank OOP System
This is Bank Project Using C++, OOP, and Text Files as Database

## How to Run the Project
1. Download and install Visual Studio (the purple one).
2. Open the main folder and click on `Bank System.sln`, or open Visual Studio and load the project.
3. Run the project from Visual Studio.

to Enter the System (Login Screen) You Have an User:
- Username: UserAdmin
- Password: 1234

### requirement

	Login Screen:
        - Ask the User 
		    - Username
		    - Password
        - User have only 3 Tries if he False the System Close.

    Main Menu Screen:
        1- List All Clients.
        2- Find Client.
        3- Add Client.
        4- Delete Cleint.
        5- Update Client.
        6- Exit (Close the Program).
        7- Transactions (go to the Transactions Menu).
	8- Logout (go to the Login Screen).
 	9- Manage Users (go to the Manage Users Screen).
        10- Login Register.
        11- Currency Exchange.

    Transactions Menu Screen:
        1- Deposit.
        2- Withdraw.
        3- Total Balances.
        4- Main Menue (Get you Back to Main Menu).

	Manage Users Menu Screen:
		1- List All Users.
		2- Find User.
		3- Add User.
		4- Delete User.
		5- Update User.
		6- Main Menu Scrren (get you Back to Main Menu).

    - the User Should Navigate the Program With Numbers in Keyboard.
    - Use Text File as a Database.

	Permissions:
	- to do any Operation the User Should Have a Permission to do it so Make a Permissions System in Your Program.
	- the User Should not be able to do any Operation he dont have Permission to it.

    Currency Exchange:
        1- List Currencies.
        2- Find Currency.
        3- Update Rate.
        4- Currency Calculator.
        5- Main Menue (get you Back to Main Menu).

    Login Register:
        - When the user enters the system, record when he entered the system.

    Logout:
        - the User Should be Able to Log out From the System.

    Exit The Program:
        - the User Should be Able to Close the Program.
    -------------------------------------------------------------

	Client Data:

    - in the Start You don't have any Client you should add them the do the other Operations.
	- you can Start the Program With no Client and Add them in the Program.
	- You can Creat A file With Client Data and Start the Program With Clients.

	How to Start with Clients:
	
	1- Create A Text File Called: ClintsInfoFile.
	2- Cope the Data below to the File.
	3- Make Sure there is no Spaces Before and After the Data.
	4- Change the ClientsFile Variable Value to the File Path.

	Client Should be Stored in the File in This Format:
        mohammad,ahmad,lexmoh@gmail.com,0543812415,A101,1234,50000.000000
        Khaili,Ahmed,Khalil,8928982,A102,1234,10350.000000
        Adli,Haddad,Adli@Gmail.com,8983883,A103,1234,555.000000

        - Field 1: First Name
        - Field 2: Second Name
        - Field 3: Email
        - Field 4: Phone Number
	- Field 5: Account Number
	- Field 6: Pin Code
	- Field 7: Balance

	User Data:

	- When you run the Program you well See the Login Screen
	  so you Should Already Have Some Users to Enter the System.
	- Follow the Steps to Enter the System and add Users.

	1- Create A Text File Called: UsersInfoFile.
	2- Cope the Data below to the File.
	3- Make Sure there is no Spaces Before and After the Data.
	4- Change the UsersFile Variable Value to the File Path.

	Users Should be Stored in the File in This Format:
        Jamil,Adli,Jamil@gmail.com,23123123,User2,1456,-1
        Lina,Loay,Lina@gmail.com,1456,User3,1456,-1
        Mazem,Kareem,Mazin@gmail.com,898234,User4,1456,-1

        - Field 1: First Name
        - Field 2: Second Name
        - Field 3: Email
        - Field 4: Phone Number
	- Field 5: Username
	- Field 6: Password
	- Field 7: Permissions

    Currencies:
        - Store Currencies in File And Add the Feature of Converting Between them.

    Login Regester:
        - When User Enter the System Store the Time he Entered the System in.

    Transfer:
        - Store Every Money Transfer Between 2 Accounts.

## Feedback and Questions
- Feel free to report any mistakes you find.  
- Feel free to ask any questions you have.
