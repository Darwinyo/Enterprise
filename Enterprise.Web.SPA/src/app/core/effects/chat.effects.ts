import { Store } from '@ngrx/store';
import { of } from 'rxjs/observable/of';

import { Effect, Actions } from '@ngrx/effects';
import { Injectable } from '@angular/core';
import * as chatActions from './../actions/chat.actions';
import * as fromChat from './../reducers/chat/chat.reducer';

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/map';
import { SignalRConnectionStatus } from './../signalr/chathub/abstract/chat.signalr';
import { Observable } from 'rxjs/Observable';
import { ChatService } from './../services/chat/chat.service';
import { ChatModel } from './../models/chat/chat.model';
import * as fromApp from './../../reducers/app-state.reducer';
@Injectable()
export class ChatEffects {
    @Effect()
    sendChat$ = this.actions$
        .ofType(chatActions.SEND_CHAT)
        .map((action: chatActions.SendChat) => action.payload)
        .mergeMap(chatModel => this.chatService.postChat(chatModel).map(
            x => console.log('Posted')
        ))
        .catch(err => Observable.of(console.log(err)));
    @Effect({ dispatch: false })
    toggleChat$ = this.actions$
        .ofType(chatActions.TOGGLE_CHAT)
        .do(() => console.log('chat toggled'));
    @Effect({ dispatch: false })
    connectingChat$ = this.actions$
        .ofType(chatActions.CONNECTING_CHAT_HUB)
        .do(() => {
            console.log('connecting chat hub....')
            this.chatService.initSignalRConnection().subscribe(
                null,
                error => this.coreStore.dispatch(new chatActions.ConnectionFailureChatHub(error))
            );
        }
        );
    @Effect({ dispatch: false })
    connectedChat$ = this.actions$
        .ofType(chatActions.CONNECTED_CHAT_HUB)
        .do(() =>
            this.coreStore.dispatch(new chatActions.FetchingChat('TestGroup'))
        )
    @Effect({ dispatch: false })
    chatReceived$ = this.actions$
        .ofType(chatActions.CHAT_RECEIVED)
        .map((action: chatActions.ChatReceived) => action.payload)
        .do((message) => console.log('Received New Messages : ' + message.message))
    @Effect({ dispatch: false })
    connectionFailureChat$ = this.actions$
        .ofType(chatActions.CONNECTION_FAILURE_CHAT_HUB)
        .map((action: chatActions.ConnectionFailureChatHub) => action.payload)
        .do((err) => console.log('Error :' + err));
    @Effect()
    fetchingChat$ = this.actions$
        .ofType(chatActions.FETCHING_CHAT)
        .map((action: chatActions.FetchingChat) => action.payload)
        .switchMap((groupId) => {
            return this.chatService.getChatHistoryByGroupId(groupId).map(
                (chatModels: ChatModel[]) => new chatActions.ChatLoaded(chatModels)
            ).catch((err) => of(new chatActions.ConnectionFailureChatHub(err)))
        });
    @Effect({ dispatch: false })
    chatLoaded$ = this.actions$
        .ofType(chatActions.CONNECTION_FAILURE_CHAT_HUB)
        .do(() => console.log('chat loaded'));
    constructor(private actions$: Actions,
        private chatService: ChatService,
        private coreStore: Store<fromApp.State>) { }
}
