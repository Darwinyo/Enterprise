import { ChatModel } from './../models/chat/chat.model';
import { Action } from '@ngrx/store';

export const TOGGLE_CHAT = '[CHAT] TOGGLE_CHAT';

export const CHAT_RECEIVED = '[CHAT] CHAT_RECEIVED';
export const SEND_CHAT = '[CHAT] SEND_CHAT';

export const FETCHING_CHAT = '[CHAT] FETCHING_CHAT';
export const CHAT_LOADED = '[CHAT] CHAT_LOADED';

export const CONNECTING_CHAT_HUB = '[CHAT] CONNECTING_CHAT_HUB';
export const CONNECTED_CHAT_HUB = '[CHAT] CONNECTED_CHAT_HUB';
export const CONNECTION_FAILURE_CHAT_HUB = '[CHAT] CONNECTION_FAILURE_CHAT_HUB';

export class ToggleChat implements Action {
    readonly type: string = TOGGLE_CHAT;
}
export class SendChat implements Action {
    readonly type: string = SEND_CHAT;
    constructor(public payload: ChatModel) { }
}
export class ChatReceived implements Action {
    readonly type: string = CHAT_RECEIVED;
    constructor(public payload: ChatModel) { }
}
export class FetchingChat implements Action {
    readonly type: string = FETCHING_CHAT;
    constructor(public payload: string) { }
}
export class ChatLoaded implements Action {
    readonly type: string = CHAT_LOADED;
    constructor(public payload: ChatModel[]) { }
}
export class ConnectingChatHub implements Action {
    readonly type: string = CONNECTING_CHAT_HUB;
}
export class ConnectedChatHub implements Action {
    readonly type: string = CONNECTED_CHAT_HUB;
    constructor(public payload: string) { }
}
export class ConnectionFailureChatHub implements Action {
    readonly type: string = CONNECTION_FAILURE_CHAT_HUB;
    constructor(public payload: string) { }
}
export type Actions =
    | ToggleChat
    | SendChat
    | ChatReceived
    | ChatLoaded
    | FetchingChat
    | ConnectedChatHub
    | ConnectingChatHub
    | ConnectionFailureChatHub;
