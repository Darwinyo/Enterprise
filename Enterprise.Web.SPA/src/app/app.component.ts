import { ChatComponent } from './core/components/chat/chat.component';
import { ChatModel } from './core/models/chat/chat.model';
import { ChatService } from './core/services/chat/chat.service';
import { Router, NavigationEnd } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';
import { SignalRConnectionStatus } from './core/signalr/chathub/abstract/chat.signalr';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  @ViewChild('chat') chat: ChatComponent;
  chatModel: ChatModel[];
  userId: string;
  groupId: string;
  chatItem: ChatModel;
  connectionId: string;
  error: any;
  constructor(private router: Router, private chatService: ChatService) {
  }
  ngOnInit(): void {
    this.userId = prompt('Input UserId Please', 'User');
    this.groupId = 'TestGroup';
    this.chatService.initSignalRConnection().subscribe(
      null,
      error => console.log('Error on init: ' + error)
    )
    this.listenToConnection();
    this.listenToConnectionState();
    this.chatService.addChat.subscribe(
      message => {
        console.log('received..');
        console.log(message);
        this.chatModel.push(message)
      }
    )
  }
  fetchChats(groupId: string) {
    this.chatService.getChatHistoryByGroupId(groupId).subscribe(
      (result) => this.chatModel = result,
      (err) => console.log(err),
      () => this.chat.populateChats(this.chatModel)
    )
  }
  listenToConnection() {
    this.chatService.setConnectionId.subscribe(
      id => {
        console.log(id);
        this.connectionId = id;
      }
    )
  }
  listenToConnectionState() {
    this.chatService.connectionState.subscribe(
      connectionState => {
        if (connectionState === SignalRConnectionStatus.Connected) {
          console.log('Connected');
          this.fetchChats(this.groupId);
        } else {
          console.log(connectionState.toString());
        }
      },
      error => {
        this.error = error;
        console.log(error);
      }
    )
  }
  send(event) {
    this.chatItem = <ChatModel>{
      userId: this.userId,
      groupId: this.groupId,
      message: event,
      messageDatetime: new Date()
    }
    this.chatService.postChat(this.chatItem).subscribe(
      x => console.log('Posted'),
      (err) => console.log(),
      () => console.log('Post Complete')
    )
  }
}
