import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  sideNavs: { group: string, children: { path: string, title: string, icon: string }[] }[] = [
    {
      group: 'Configuration', children: [
        { path: 'configuration/users', title: 'Users', icon: '' },
        { path: 'configuration/areas', title: 'Areas', icon: '' },
        { path: 'configuration/restaurants', title: 'Restaurants', icon: '' },
        { path: 'configuration/base-products', title: 'Base products', icon: '' },
        { path: 'configuration/menus', title: 'Menus', icon: '' },
        { path: 'configuration/promotions', title: 'Promotions', icon: '' },
      ]
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
