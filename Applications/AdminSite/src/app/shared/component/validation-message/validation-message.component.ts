import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { ValidationMessageConfig } from './validation-message.config';

@Component({
  selector: 'app-validation-message',
  templateUrl: './validation-message.component.html',
  styleUrls: ['./validation-message.component.scss']
})
export class ValidationMessageComponent implements OnInit {
  @Input() control!: AbstractControl ;
  @Input() controlName!: string;

  config = ValidationMessageConfig;

  constructor() {
  }

  ngOnInit(): void {
  }

}
