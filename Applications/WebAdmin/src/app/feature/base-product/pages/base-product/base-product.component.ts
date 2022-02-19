import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzModalService } from 'ng-zorro-antd/modal';
import { BaseWizard } from 'src/app/core/common/base-wizard';
import { RoutingKey } from 'src/app/core/const/routing-key';
import { Addition } from 'src/app/core/models/addition.model';
import { Category, CATEGORY_CHILD, CATEGORY_NAME } from 'src/app/core/models/category.model';
import { SubCategory } from 'src/app/core/models/subcategory.model';
import { BaseProductService } from 'src/app/core/services/api/base-product.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { RouterService } from 'src/app/core/services/router.service';
import { WizardService } from 'src/app/core/services/wizard.service';

@Component({
  selector: 'app-base-product',
  templateUrl: './base-product.component.html',
  styleUrls: ['./base-product.component.scss']
})
export class BaseProductComponent extends BaseWizard implements OnInit {
  rootKey: RoutingKey = RoutingKey.BaseProduct;
  category: Category;
  categoryName = CATEGORY_NAME;
  form: FormGroup;

  constructor(
    private baseProductService: BaseProductService,
    public loaderService: LoaderService,
    protected modal: NzModalService,
    private router: Router,
    private routerService: RouterService,
    public wizardService: WizardService,
  ) {
    super(modal, wizardService);
    // this.storageRootRouting();
  }

  initForm(): void {
    this.form = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      imageUrl: new FormControl(''),
      subCategory: new FormControl(SubCategory.Soup),
      category: new FormControl(Category.SoupStarterSalad),
      isAvailable: new FormControl(true),
    });
  }

  deserialize(data: any) {
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
    if (!this.wizardService._isCreate) {
      this.loadData();
    }
  }

  save() {
    this.baseProductService.updateBaseProduct(this.form.value).subscribe(
      () => {
      }
    );
  }

  uploaded(event: any) {
    this.form.controls.imageUrl.setValue(event.uploadedPath);
  }

  create() {
    this.baseProductService.createBaseProduct(this.form.value).subscribe(
      result => {
        this.routerService.navigateToDetail(`/base-product/${result}`);
      }
    );
  }

  loadData() {
    this.baseProductService.getBaseProduct(this.wizardService._id).subscribe(
      result => {
        this.deserialize(result);
      }
    );
  }

  categorySelected(event) {
    this.form.controls.category.setValue(event);
    const subCategories = CATEGORY_CHILD.get(event);
    this.form.controls.subCategory.setValue(subCategories[0]);
  }

  subCategorySelected(event) {
    this.form.controls.subCategory.setValue(event);
  }

  goBack() {
    this.router.navigate(['/base-product'], { queryParams: { category: this.form.value.category } });
  }
}
