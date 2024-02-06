# Instant Messaging App

Created as a part of Unit-Testing excersises in class.

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



# Technology Stack

* ASP.NET Core MVC
* SignalR

  
 
