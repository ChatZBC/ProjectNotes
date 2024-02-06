![Discord](https://img.shields.io/discord/1118896540640100352?style=for-the-badge&label=%E2%AD%90%20ZBC's%20Finest%20%E2%AD%90&color=FFA500)


# Instant Messaging App

Created as a part of Unit-Testing excersises in class.

The multi-step plan is as follows:
| Step | Server                  | Client   | 
|------|-------------------------|----------|
| 1    | ASP.Net Core MVC        | Angular  | 
| 2    | Entity Framework, T-SQL |          | 
| 3    | Direct Message          |          |



# Architecture

Intended to be a simple client/server architecture, with minimal fuzz.
We mainly use SignalR and HTTP connections.

## Step 1 - Technology Stack

* ASP.NET Core MVC
* SignalR

## Step 1 - Topology

```mermaid
graph TD
    client1(Client 1) -.-> server[Server]
    server -.-> client1
    client1 --> server
    server --> client1

    client2(Client 2) -.-> server
    server -.-> client2
    client2 --> server
    server --> client2

    client3(Client 3) -.-> server
    server -.-> client3
    client3 --> server
    server --> client3

    client4(Client 4) -.-> server
    server -.-> client4
    client4 --> server
    server --> client4

    %% Legend

    L2[ ] -. "SignalR" .-> L3[ ]
    L4[ ] -->|"HTTP"| L5[ ]

    %% Styling
    classDef legendStyle fill:#f9f9f9,stroke:#333,stroke-width:0px,color:black;
    classDef client fill:#FFA500,stroke:#000000,stroke-width:2px,color:#FFFFFF;
    classDef server fill:#000000,stroke:#1E90FF,stroke-width:4px,color:#FFFFFF;

    class L1,L2,L3,L4,L5 legendStyle;
    class client1,client2,client3,client4 client;
    class server server;


```

## Step 1 - Technology Stack

* ASP.NET Core MVC
* SignalR
* T-SQL
* Entity Framework

## Step 2 - Topology

```mermaid
graph TD
    client1(Client 1) --- server[Server]
    client2(Client 2) --- server
    client3(Client 3) --- server
    client4(Client 4) --- server
    server --- db[(Database)]

    %% Styling
    classDef client fill:#FFA500,stroke:#000000,stroke-width:2px,color:#FFFFFF;
    classDef server fill:#000000,stroke:#1E90FF,stroke-width:4px,color:#FFFFFF;
    classDef database fill:#FFFFFF,stroke:#333,stroke-width:2px;

    class client1,client2,client3,client4 client;
    class server server;
    class db database;

```

 
# Plan for testing 

## Unit tests

| Test Function         | Description                             | 
|-----------------------|-----------------------------------------|
| `SendMessages(str)`   | Tests the sending of messages function. | 
| `CheckProfanity(str)` | Tests for profanity filtering.          | 
| `CheckSecurity(str)`  | Tests the security measures.            | 
| `LogMessage(str)`     | Tests message logging.                  | 
| `OfferXLineState(x)`  | Tests the offering of line states.      | 


## Integration Tests


## Usability Tests
