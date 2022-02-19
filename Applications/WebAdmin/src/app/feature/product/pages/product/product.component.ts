import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NzModalService } from 'ng-zorro-antd/modal';
import { BaseWizard } from 'src/app/core/common/base-wizard';
import { Addition } from 'src/app/core/models/addition.model';
import { Category, CATEGORY_CHILD, CATEGORY_NAME } from 'src/app/core/models/category.model';
import { COUNTRY_NAME } from 'src/app/core/models/country.model';
import { MenuItem } from 'src/app/core/models/menu_item.model';
import { SubCategory } from 'src/app/core/models/subcategory.model';
import { APIService } from 'src/app/core/services/api.service';
import { MenuService } from 'src/app/core/services/api/menu.api.service';
import { ProductService } from 'src/app/core/services/api/product.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { SystemErrorModalService } from 'src/app/core/services/system-error-modal.service';
import { WizardService } from 'src/app/core/services/wizard.service';
import { AdditionModalComponent } from '../../components/addition-modal/addition-modal.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent extends BaseWizard implements OnInit {
  isCreate: boolean;
  state: string;

  category: Category;
  categoryName = CATEGORY_NAME;
  countryName = COUNTRY_NAME;

  form: FormGroup;
  menu: MenuItem = new MenuItem();
  additionPanels: Addition[] = [];

  constructor(
    private productService: ProductService,
    public loaderService: LoaderService,
    protected modal: NzModalService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    public wizardService: WizardService,
    private systemErrorModalService: SystemErrorModalService,
    private menuService: MenuService,
  ) {
    super(modal, wizardService);
  }

  initForm(): void {
    this.form = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      price: new FormControl(0, [Validators.required]),
      imageUrl: new FormControl(''),
      subCategory: new FormControl(SubCategory.Soup),
      category: new FormControl(Category.SoupStarterSalad),
      additions: new FormControl([]),
      isAvailable: new FormControl(true),
      priority: new FormControl(1),
      menuId: new FormControl(0),
    });
  }

  deserialize(data: any) {
    if (data) {
      this.form.controls.id.setValue(data.id);
      this.form.controls.name.setValue(data.name);
      this.form.controls.description.setValue(data.description);
      this.form.controls.price.setValue(data.price);
      this.form.controls.imageUrl.setValue(data.imageUrl);
      this.form.controls.subCategory.setValue(data.subCategory);
      this.form.controls.category.setValue(data.category);
      this.form.controls.isAvailable.setValue(data.isAvailable);
      this.form.controls.priority.setValue(data.priority);
      this.form.controls.menuId.setValue(data.menuId);
      this.additionPanels = data.additions;
    }
  }

  ngOnInit(): void {
    if (!this.wizardService._isCreate) {
      this.loadData();
    } else {
      this.activatedRoute.queryParams.subscribe(
        result => {
          if (result.menu) {
            this.menuService.get(result.menu).subscribe(
              rs => {
                this.menu = rs;
                this.form.controls.menuId.setValue(this.menu.id);
              }
            );
          } else {
            this.systemErrorModalService.showError();
          }
        }
      );
    }
  }

  save() {
    this.form.controls.additions.setValue(this.additionPanels);
    this.productService.update(this.form.value).subscribe(
      () => {
      }
    );
  }

  uploaded(event: any) {
    this.form.controls.imageUrl.setValue(event.uploadedPath);
  }

  create() {
    this.form.controls.additions.setValue(this.additionPanels);
    this.productService.create(this.form.value).subscribe(
      result => {
        this.router.navigate(['/menu/', this.menu.id], { queryParams: { tab: this.form.value.category } });
      }
    );
  }

  loadData() {
    this.productService.get(this.wizardService._id).subscribe(
      result => {
        if (result) {
          this.deserialize(result);
          console.log(result);
          this.menu = result.menu;
        }
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

  addAddition() {
    const newItem = new Addition();
    this.modal.create({
      nzTitle: 'New addition',
      nzContent: AdditionModalComponent,
      nzComponentParams: { addition: newItem },
      nzClosable: false,
      nzMaskClosable: false,
      nzOnOk: () => {
        this.additionPanels.push(newItem);
      }
    });
  }

  editItem(event: MouseEvent) {
    event.stopPropagation();
    const paths = event.composedPath();
    let indexItem: number;
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < paths.length; i++) {
      if ((paths[i] as HTMLElement).nodeName === 'NZ-COLLAPSE-PANEL') {
        // tslint:disable-next-line: radix
        indexItem = Number.parseInt((paths[i] as HTMLElement).id);
        break;
      }
    }
    const storedItem = JSON.stringify(this.additionPanels[indexItem]);

    this.modal.create({
      nzTitle: 'Update addition',
      nzContent: AdditionModalComponent,
      nzComponentParams: { addition: this.additionPanels[indexItem] },
      nzClosable: false,
      nzMaskClosable: false,
      nzOnCancel: () => {
        this.additionPanels[indexItem] = JSON.parse(storedItem);
      },
    });
  }

  goBack() {
    this.router.navigate(['/menu'], { queryParams: { category: this.form.value.category } });
  }
}
