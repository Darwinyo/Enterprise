import { NgForm } from '@angular/forms';
import { ChatModel } from './../../models/chat/chat.model';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  chatModel: ChatModel[];
  chatItem: string;
  @Output() sendEvent: EventEmitter<string>;
  constructor() {
    this.sendEvent = new EventEmitter();
  }

  ngOnInit() {
  }
  populateChats(chatModel: ChatModel[]) {
    this.chatModel = chatModel;
  }
  send(form: NgForm) {
    const message = form.value['message'];
    this.sendEvent.emit(message);
  }
}
