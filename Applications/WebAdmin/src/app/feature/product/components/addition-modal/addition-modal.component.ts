import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Addition } from 'src/app/core/models/addition.model';
import { AdditionItem } from 'src/app/core/models/addition_item.model';

@Component({
  selector: 'app-addition-modal',
  templateUrl: './addition-modal.component.html',
  styleUrls: ['./addition-modal.component.scss']
})
export class AdditionModalComponent implements OnInit {
  @Input() addition: Addition;
  @Output() additionChange: EventEmitter<Addition> = new EventEmitter<Addition>();
  newItem: AdditionItem = new AdditionItem();

  storedItem: string;
  itemEdited: number;
  isEditedState = false;
  constructor() { }

  ngOnInit(): void {
  }

  addNewItem() {
    this.newItem.id = this.addition.items.length + 1;
    this.addition.items.push(this.newItem);
    this.newItem = new AdditionItem();
  }

  changeToEditState(id: number) {
    if (this.isEditedState) {
      return;
    }
    this.isEditedState = true;
    this.storedItem = JSON.stringify(this.addition.items.filter(p => p.id === id)[0]);
    this.itemEdited = id;
  }

  remove(item: AdditionItem) {
    const itemIndex: number = this.addition.items.indexOf(item);
    if (itemIndex !== -1) {
      this.addition.items.splice(itemIndex, 1);
    }
    this.addition.items.forEach((element, index) => {
      element.id = index + 1;
    });
  }

  saveItem() {
    this.itemEdited = -1;
    this.isEditedState = false;
  }

  discardItem(id: number) {
    const itemIndex: number = this.addition.items.map(p => p.id).indexOf(id);
    this.addition.items[itemIndex] = JSON.parse(this.storedItem);
    this.itemEdited = -1;
    this.isEditedState = false;
  }
}
