import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Select } from 'src/app/core/const/select/select';
import { APIService } from 'src/app/core/services/api.service';

@Component({
  selector: 'app-select-restaurant',
  templateUrl: './select-restaurant.component.html',
  styleUrls: ['./select-restaurant.component.scss']
})
export class SelectRestaurantComponent implements OnInit {
  @Input() form: FormGroup;
  @Input() isView = true;

  restaurants: Select[] = [];

  constructor(
    private apiService: APIService,
  ) { }

  ngOnInit(): void {
    this.apiService.getRestaurantDropdown().subscribe(
      result => {
        this.restaurants = result;
      }
    );
  }

  public get label(): string {
    if (this.form.controls.restaurantId.value) {
      return this.restaurants.find(p => p.value === this.form.controls.restaurantId.value)?.label;
    }
    return '';
  }

}
