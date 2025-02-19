import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NavigationEnd, Router, RouterModule } from '@angular/router';
import { filter } from 'rxjs';
import { menuItems } from '../../shared/constants/menuItems';

@Component({
  selector: 'app-header',
  imports: [RouterModule, CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  selectedItemLabel: string = 'Dashboard';

  menuItems = [
    { route: '/admin/dashboard', label: 'Dashboard' },
    { route: '/admin/clients', label: 'Clientes' },
    { route: '/admin/reports', label: 'Reportes' }
  ];

  constructor(private router: Router) {
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => {
        this.updateSelectedMenu();
      });
  }

  updateSelectedMenu() {
    const currentRoute = this.router.url;
    const foundItem = menuItems.find(item => item.route === currentRoute);
    this.selectedItemLabel = foundItem ? foundItem.label : 'Dashboard';
  }

}
