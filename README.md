C# Basic CRUD
====
This program is Desktop App using C# as programming language. Featured basic Create, Read, Update and Delete (CRUD).
The app using textboxes, buttons, labels, data grid view, photobox etc

Environtment
----
 * IDE : [Visual Studio 2014][1]
 * Database : [Xampp][2]
 * Database Connector : [mysql-connector-odbc-5.3.9-win32.msi][3], [mysql-connector-net-6.10.6.msi][4]

Setup
----
* 1. Setting ODBC Data Source Administrator 32-bit.
	* -- Add DSN at User DSN tab
.	* -- Driver : MYSQL ODBC 5.3 ANSI Driver
Data Source Name :
```
dsn_aplikasi_mobil
```

* 2. Setup database. Import this database 
```
db_pembayaran_kampus.sql
```

Feature
----
 * Insert data admin
 * Update data admin
 * View on Data Grid View
 * Delete data admin
 * Select data from Data Grid and show at textboxes
 * Upload Picture

### TODO
----
 * [x] Create form
 * [x] Create Simpan() Method
 * [x] Create Update() Method
 * [x] Create Delete() Method
 * [x] Create TampilData() and TampilDataById() Method
 * [x] Create selected id from cell click on Data Grid View
 * [x] Create cleardata
 * [x] Create upload picture
 * [ ] Show picture from database	 

 Assets
 ----
 * <div>Icons made by <a href="https://www.flaticon.com/authors/smashicons" title="Smashicons">Smashicons</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a> is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0" target="_blank">CC 3.0 BY</a></div>
 * <div>Icons made by <a href="http://www.freepik.com" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a> is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0" target="_blank">CC 3.0 BY</a></div>


[1]: https://www.visualstudio.com/
[2]: https://www.apachefriends.org/download.html
[3]: https://dev.mysql.com/downloads/connector/odbc/
[4]: https://dev.mysql.com/downloads/connector/net/
