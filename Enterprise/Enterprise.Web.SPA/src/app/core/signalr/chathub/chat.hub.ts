import { ChatSignalR, ChatServer, ChatProxy, SignalRConnectionStatus } from './abstract/chat.signalr';
import { OnInit } from '@angular/core';
import { ChatModel } from './../../models/chat/chat.model';
import { chatHubProxy } from './../../../shared/consts/hub-proxy.const';
import { serverUrl } from './../../../shared/consts/server-url.const';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import { Subject } from 'rxjs/Subject';

declare var $: any;
export class ChatHub {
    chatConnection: ChatSignalR;
    chatHub: ChatProxy;
    chatServer: ChatServer;

    currentState: SignalRConnectionStatus;

    connectionState: Observable<SignalRConnectionStatus>;
    addChat: Observable<ChatModel>;
    setConnectionId: Observable<string>;

    connectionStateSubject: Subject<SignalRConnectionStatus>;
    chatSubject: Subject<ChatModel>;
    setConnectionIdSubject: Subject<string>;

    constructor() {
        this.chatSubject = new Subject<ChatModel>();
        this.setConnectionIdSubject = new Subject<string>();
        this.connectionStateSubject = new Subject<SignalRConnectionStatus>();

        this.currentState = SignalRConnectionStatus.Disconnected;

        this.setConnectionId = this.setConnectionIdSubject.asObservable();
        this.connectionState = this.connectionStateSubject.asObservable();
        this.addChat = this.chatSubject.asObservable();
    }
    initSignalRConnection(): Observable<SignalRConnectionStatus> {
        $.connection.hub.logging = true;
        this.chatConnection = <ChatSignalR>$.connection;
        this.chatHub = this.chatConnection.chatHub;
        this.chatServer = this.chatHub.server;
        this.registerEventHandler();
        return this.startConnection();
    }
    registerEventHandler() {
        this.chatHub.client.send = chatModel => this.onAddChat(chatModel);
        this.chatHub.client.setConnectionId = id => this.onSetConnectionId(id);
    }
    startConnection(): Observable<SignalRConnectionStatus> {
        $.connection.hub.start()
            .done(response => this.setConnectionState(SignalRConnectionStatus.Connected))
            .fail(error => this.connectionStateSubject.error(error));
        return this.connectionState;
    }
    setConnectionState(connectionState: SignalRConnectionStatus) {
        console.log('connection state changed to: ' + connectionState);
        this.currentState = connectionState;
        this.connectionStateSubject.next(connectionState);
    }
    onAddChat(chatModel: ChatModel) {
        console.log('come from onAddChat Method' + chatModel);
        this.chatSubject.next(chatModel);
    }
    onSetConnectionId(id: string) {
        console.log('onSetConnectionId Called');
        this.setConnectionIdSubject.next(id);
    }
}
