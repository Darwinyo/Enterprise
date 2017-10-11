import { ChatModel } from './../../models/chat/chat.model';
import * as ChatActions from './../../actions/chat.actions';

export interface State {
    showChat: boolean;
    chats: ChatModel[];
    connectionId: string;
    groupId: string;
    connectingChatHub: boolean;
    connectedChatHub: boolean;
    loadingChat: boolean;
    chatToggled: boolean;
    error: boolean;
}
export const INITIAL_STATE = {
    showChat: false,
    chats: [],
    connectionId: '',
    groupId: '',
    connectingChatHub: false,
    connectedChatHub: false,
    loadingChat: false,
    chatToggled: false,
    error: false
}
export function chatReducer(state = INITIAL_STATE, action: ChatActions.Actions): State {
    switch (action.type) {
        case ChatActions.TOGGLE_CHAT: {
            return {
                ...state,
                chatToggled: !state.chatToggled
            };
        }
        case ChatActions.FETCHING_CHAT: {
            return {
                ...state,
                groupId: (<ChatActions.FetchingChat>action).payload,
                loadingChat: true,
                chats: []
            };
        }
        case ChatActions.CHAT_LOADED: {
            return {
                ...state,
                loadingChat: false,
                chats: (<ChatActions.ChatLoaded>action).payload
            };
        }
        case ChatActions.CHAT_RECEIVED: {
            state.chats.push((<ChatActions.ChatReceived>action).payload);
            return {
                ...state,
                chats: state.chats
            };
        }
        case ChatActions.CONNECTION_FAILURE_CHAT_HUB: {
            return {
                ...state,
                showChat: false,
                loadingChat: false,
                connectedChatHub: false,
                connectingChatHub: false,
                error: true
            };
        }
        case ChatActions.CONNECTED_CHAT_HUB: {
            return {
                ...state,
                connectionId: (<ChatActions.ConnectedChatHub>action).payload,
                showChat: true,
                loadingChat: false,
                connectedChatHub: true,
                connectingChatHub: false,
                error: false
            };
        }
        case ChatActions.CONNECTING_CHAT_HUB: {
            return {
                ...state,
                loadingChat: true,
                connectingChatHub: true
            };
        }
        default:
            return state;
    }
}

export const getShowChat = (state: State) => state.showChat;
export const getChatToggled = (state: State) => state.chatToggled;
export const getChats = (state: State) => state.chats;
export const getChatLoading = (state: State) => state.loadingChat;
export const getError = (state: State) => state.error;
export const getConnectionId = (state: State) => state.connectionId;
export const getGroupId = (state: State) => state.groupId;
export const getConnectingChat = (state: State) => state.connectingChatHub;
export const getConnectedChat = (state: State) => state.connectedChatHub;
