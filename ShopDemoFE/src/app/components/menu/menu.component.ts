import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { menuItems } from '../../shared/constants/menuItems';

@Component({
  selector: 'app-menu',
  imports: [CommonModule, RouterModule],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {
  isCollapsed = false;
  selectedItem: string = '';
  menuItemsList = menuItems 
 
  toggleSidebar() {
    this.isCollapsed = !this.isCollapsed;
  }

  selectItem(route: string) {
    this.selectedItem = route;
  }
}
