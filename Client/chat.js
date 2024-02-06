$(function () {
    // Opret forbindelse til chatHub, som defineret på serveren
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    // Deaktiver send knappen indtil forbindelsen er etableret
    $("#sendButton").disabled = true;

    // Modtag besked fra serveren og tilføj den til listen
    connection.on("ReceiveMessage", function (user, message) {
        var msg = document.createElement("div");
        msg.textContent = `${user}: ${message}`;
        document.getElementById("messagesList").appendChild(msg);
    });

    // Start forbindelsen og aktiver send knappen når forbindelsen er etableret
    connection.start().then(function () {
        document.getElementById("sendButton").disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });

    // Send en besked når send knappen klikkes
    document.getElementById("sendButton").addEventListener("click", function (event) {
        var user = document.getElementById("userInput").value;
        var message = document.getElementById("messageInput").value;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
});
