import { Observable } from 'rxjs/Rx';
import { Store } from '@ngrx/store';
import { ChatComponent } from './core/components/chat/chat.component';
import { ChatModel } from './core/models/chat/chat.model';
import { ChatService } from './core/services/chat/chat.service';
import { Router, NavigationEnd } from '@angular/router';
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { SignalRConnectionStatus } from './core/signalr/chathub/abstract/chat.signalr';
import * as fromCore from './core/reducers/core-state.reducer';
import * as chatActions from './core/actions/chat.actions';
import * as fromAuth from './auth/reducers/auth-state.reducer';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, AfterViewInit {

  @ViewChild('chat') chat: ChatComponent;
  showChat$: Observable<boolean>;
  chatModel$: Observable<ChatModel[]>;
  groupId$: Observable<string>;
  userLogin$: Observable<string>;
  connectionId: string;
  constructor(private router: Router,
    private chatService: ChatService,
    private coreStore: Store<fromCore.State>) {
    this.groupId$ = this.coreStore.select(fromCore.getGroupId);
    this.showChat$ = this.coreStore.select(fromCore.getShowChat);
    this.chatModel$ = this.coreStore.select(fromCore.getChats);
    this.userLogin$ = this.coreStore.select(fromAuth.getUserLogin);
  }
  ngOnInit(): void {
    this.subscribeConnection();
  }
  ngAfterViewInit(): void {
    this.subscribeChats();
  }
  subscribeChats() {
    this.showChat$.subscribe(
      (show) => {
        if (show) {
          console.log('subscribing chat model');
          this.chatModel$.subscribe(
            (chats) => this.chat.populateChats(chats),
            (error) => this.coreStore.dispatch(new chatActions.ConnectionFailureChatHub(error))
          )
          this.chatService.addChat.subscribe(
            message => {
              this.coreStore.dispatch(new chatActions.ChatReceived(message));
            }
          )
        }
      }
    )
  }
  subscribeConnection() {
    this.chatService.setConnectionId.subscribe(
      id => {
        this.connectionId = id;
        console.log('setConnectionId Called');
      },
      error => this.coreStore.dispatch(new chatActions.ConnectionFailureChatHub(error))
    )
    this.chatService.connectionState.subscribe(
      connectionState => {
        if (connectionState === SignalRConnectionStatus.Connected) {
          console.log('dispatching connected action');
          this.coreStore.dispatch(new chatActions.ConnectedChatHub(this.connectionId));
        } else {
          this.coreStore.dispatch(new chatActions.ConnectionFailureChatHub('Connection Failure'));
        }
      },
      error => this.coreStore.dispatch(new chatActions.ConnectionFailureChatHub(error))
    )
  }
  send(event) {
    this.userLogin$.mergeMap((userlogin) =>
      this.groupId$.map((groupId) => {
        const chatItem = <ChatModel>{
          userId: userlogin,
          groupId: groupId,
          message: event,
          messageDatetime: new Date()
        };
        this.coreStore.dispatch(new chatActions.SendChat(chatItem));
      })
    )
  }
  toggleChat() {
    this.coreStore.dispatch(new chatActions.ToggleChat());
  }
}
