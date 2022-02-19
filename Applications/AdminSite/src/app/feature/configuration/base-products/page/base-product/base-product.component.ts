import { Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Category } from 'src/app/core/model/category.model';
import { SubCategory } from 'src/app/core/model/subcategory.model';
import { BaseProductService } from 'src/app/core/service/api/configuration/base-product.api.service';
import { UserService } from 'src/app/core/service/api/configuration/user.api.service';
import { BaseConfiguration } from '../../../base-configuration';

@Component({
  selector: 'app-base-product',
  templateUrl: './base-product.component.html',
  styleUrls: ['./base-product.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class BaseProductComponent extends BaseConfiguration implements OnInit {
  form = new FormGroup({
    id: new FormControl(0),
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    imageUrl: new FormControl(''),
    subCategory: new FormControl(SubCategory.Soup),
    category: new FormControl(Category.SoupStarterSalad),
    isAvailable: new FormControl(true),
  });

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private baseProductService: BaseProductService,
    public dialog: MatDialog,
  ) {
    super();
  }


  deserialize(data: any): void {
    if (data) {
      this.form.controls.id.setValue(data.id);
      this.form.controls.name.setValue(data.name);
      this.form.controls.description.setValue(data.description);
      this.form.controls.imageUrl.setValue(data.imageUrl);
      this.form.controls.subCategory.setValue(data.subCategory);
      this.form.controls.category.setValue(data.category);
      this.form.controls.isAvailable.setValue(data.isAvailable);
    }
  }

  ngOnInit(): void {
    this.deserialize(this.data);
  }

  create(): void {
    this.baseProductService.create(this.form.value).subscribe(
      result => {
        console.log(result);
      }
    );
  }

  save(): void {
    this.baseProductService.save(this.form.value).subscribe(
      result => {
        console.log(result);
      }
    );
  }

  categoryOnChange(event: any): void {
    this.form.controls.category.setValue(event);
  }

  subCategoryOnChange(event: any): void {
    this.form.controls.subCategory.setValue(event);
  }

  uploaded(event: string): void {
    this.form.controls.imageUrl.setValue(event);
  }
}
