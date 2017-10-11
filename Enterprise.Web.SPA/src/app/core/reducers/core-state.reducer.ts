import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromAuth from './../../auth/reducers/auth-state.reducer';
import * as fromNavbar from './../reducers/navbar/navbar.reducer';
import * as fromChat from './../reducers/chat/chat.reducer';

export interface CoreState {
    navbarState: fromNavbar.State;
    chatState: fromChat.State;
}
export interface State extends fromAuth.State {
    coreState: CoreState;
}

export const coreStateReducer = {
    navbarState: fromNavbar.navbarReducer,
    chatState: fromChat.chatReducer
}
export const selectCoreState = createFeatureSelector<CoreState>('core');

export const selectNavbarState = createSelector(
    selectCoreState,
    (state: CoreState) => state.navbarState
)
export const getLoginMenu = createSelector(
    selectNavbarState,
    fromNavbar.getLoginMenu
);
export const getUserMenu = createSelector(
    selectNavbarState,
    fromNavbar.getUserMenu
);
export const getNotifMenu = createSelector(
    selectNavbarState,
    fromNavbar.getNotifMenu
);
export const getCartMenu = createSelector(
    selectNavbarState,
    fromNavbar.getCartMenu
);
export const getLogged = createSelector(
    selectNavbarState,
    fromNavbar.getLogged
);
export const selectChatState = createSelector(
    selectCoreState,
    (state: CoreState) => state.chatState
)

export const getShowChat = createSelector(
    selectChatState,
    fromChat.getShowChat
)
export const getChatToggled = createSelector(
    selectChatState,
    fromChat.getChatToggled
)
export const getChats = createSelector(
    selectChatState,
    fromChat.getChats
)
export const getChatLoading = createSelector(
    selectChatState,
    fromChat.getChatLoading
)
export const getChatError = createSelector(
    selectChatState,
    fromChat.getError
)
export const getConnectionId = createSelector(
    selectChatState,
    fromChat.getConnectionId
)
export const getGroupId = createSelector(
    selectChatState,
    fromChat.getGroupId
)
export const getConnectingChat = createSelector(
    selectChatState,
    fromChat.getConnectingChat
)
export const getConnectedChat = createSelector(
    selectChatState,
    fromChat.getConnectedChat
)
