import { Store } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import { NgForm } from '@angular/forms';
import { ChatModel } from './../../models/chat/chat.model';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import * as ChatActions from './../../actions/chat.actions';
import * as fromCore from './../../reducers/core-state.reducer';
@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  chatModel: ChatModel[];
  toggleChat$: Observable<boolean>;
  @Output() sendEvent: EventEmitter<string>;
  constructor(private coreStore: Store<fromCore.State>) {
    this.sendEvent = new EventEmitter();
    this.toggleChat$ = this.coreStore.select(fromCore.getChatToggled);
    console.log(this.toggleChat$);
  }

  ngOnInit() {
  }
  populateChats(chatModel: ChatModel[]) {
    this.chatModel = chatModel;
    console.log(this.chatModel);
  }
  send(form: NgForm) {
    const message = form.value['message'];
    this.sendEvent.emit(message);
  }
}
