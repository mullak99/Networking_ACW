# Networking ACW

ACW for 'Networking and User Interface Design' (500081).

## Location (LocationClient)

Client for getting and setting someones location on a server using TCP.

### Usage

To take full advantage of the client you will need to use the commandline.  
Once the commandline is open the client can be used like so:

- Get Person Location: `location.exe <person>`
- Set Person Location: `location.exe <person> <location>`

Advanced command line options can also be appended to the above command
examples.

Example: `location.exe <person> <parameter(s)>`

The full list of possible argument are as follows:

- `-h <IP/Address>`: Set the address of the server to connect to (Default: localhost)
- `-p <Port>`: Set the port of the server to connect to (Default: 43)
- `-t <ms>`: Sets the timeout of all requests in milliseconds (Default: 2000)
- `-l <path>`: Path of the log file to save all messages
- `-h9`: Use the HTTP/0.9 protocol for requests
- `-h0`: Use the HTTP/1.0 protocol for requests
- `-h1`: Use the HTTP/1.0 protocol for requests
- `-d`: Enable debug mode (verbosely shows what the client is doing)

P.S: If multiple `-hX` parameters are provided, only the last one will be used.  
P.S.S: By default the client uses the WHOIS protocol.

## LocationServer

Server for LocationClient. Used to manage the locations of users in a database
and respond to get/set requests from the Client.

### Usage

To take full advantage of the client you will need to use the commandline.  
Once the commandline is open the client can be used like so:

- Get Person Location: `location.exe <person>`
- Set Person Location: `location.exe <person> <location>`

Advanced command line options can also be appended to the above command
examples.

Example: `location.exe <person> <parameter(s)>`

The full list of possible argument are as follows:

- `-p <Port>`: Set the port of the server (Default: 43)
- `-l <path>`: Path of the log file to save all messages
- `-f <path>`: Path of the database file to save peoples names and locations
- `-d`: Enable debug mode (verbosely shows what the client is doing)
- `-w`: Opens the server in a WindowsForms window

P.S: If a `-f <path>` isn't provided the locations will only be stores in memory
and will be deleted on server close.  
P.S.S: When a `-f <path>` is specified, it stores the locations in a SQLite
database. Therefore it is recommended to end it will the extension '.db'.

## LCH

LCH (LocationCommandHandler) is a library used by LocationClient (location) and
LocationServer (locationserver) for the purpose of
handling commands used for client-server communication.

It also contains some common functions that are shared between LocationClient
and LocationServer.
