'use strict';

var connection = new signalR.HubConnectionBuilder()
    .withUrl('/messenger')
    .withHubProtocol(new signalR.protocols.msgpack.MessagePackHubProtocol())
    .build();

connection.on('ReceiveMessage', function (user, message) {
    var li = document.createElement('li');
    li.innerHTML = '<b>' + user + ' : </b>' + message;
    document.getElementById('messages').appendChild(li);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById('envoie').addEventListener('click', function (event) {
    event.preventDefault();

    var user = document.getElementById('user').value;
    var message = document.getElementById('message').value;

    connection.invoke('SendMessage', user, message).catch(function (err) {
        return console.error(err.toString());
    });
});
