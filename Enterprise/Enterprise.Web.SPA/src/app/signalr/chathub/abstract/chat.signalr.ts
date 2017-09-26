import { ChatModel } from './../../../models/chat/chat.model';
export interface ChatSignalR {
    chatHub: ChatProxy
}

export interface ChatProxy {
    client: ChatClient;
    server: ChatServer;
}

export interface ChatClient {
    setConnectionId: (id: string) => void;
    send: (message: ChatModel) => void;
}

export interface ChatServer {
    subscribe(groupName: string): void;
    unsubscribe(groupName: string): void;
}

export enum SignalRConnectionStatus {
    Connected = 1,
    Disconnected = 2,
    Error = 3
}
