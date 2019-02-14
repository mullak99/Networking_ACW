# Networking ACW

ACW1 for 'Networking and User Interface Design' (500081).

## Location/LocationClient

Client for getting and setting someones location on a server using TCP.

## LocationServer

Server for LocationClient. Used to manage the locations of users in a database
and respond to get/set requests from the Client.

## LCH

LCH (LocationCommandHandler) is a library used by LocationClient (location) and
LocationServer (locationserver) for the purpose of
handling commands used for client-server communication.

It also contains some common functions that are shared between LocationClient
and LocationServer.
