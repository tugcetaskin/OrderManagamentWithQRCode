var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7214/SignalRHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    console.log("Mesaj Listeleme İşlemi");
    debugger;
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMin = currentTime.getMinutes();

    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;

    li.appendChild(span);
    li.innerHTML += ` : ${message} - ${currentHour}:${currentMin}`;
    document.getElementById("messageList").appendChild(li);
});

connection.start().then(function () {
    console.log("Bağlantı Başarılı");
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    debugger;
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});