import { AdditionItem } from './addition_item.model';

export class Addition {
  title: string;
  isMultipleSelect: boolean;
  isRequired: boolean;

  items: AdditionItem[] = [];
}
