const connection = new signalR.HubConnectionBuilder()
    .withUrl("/carHub")
    .build();

connection.on("UpdateCarCount", function (carCount) {
    document.getElementById("carCount").innerText = carCount;
});

connection.start().catch(function (err) {
    console.error(err.toString());
});