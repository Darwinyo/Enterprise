import { serverUrl } from './../../consts/server-url.const';
import { ChatControllerUrl } from './../../consts/api-url.const';
import { ChatHub } from './../../signalr/chathub/chat.hub';
import { ChatModel } from './../../models/chat/chat.model';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class ChatService extends ChatHub {
    urlChatController = serverUrl + ChatControllerUrl;
    constructor(private http: Http) {
        super();
    }
    getChatHistoryByGroupId(groupId: string): Observable<ChatModel[]> {
        return this.http.get(this.urlChatController + '/' + groupId).map(
            (result) => result.json()
        )
    }
    postChat(chatModel: ChatModel) {
        const headers: Headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(this.urlChatController, chatModel, { headers: headers }).map(
            (result) => null
        )
    }
}
