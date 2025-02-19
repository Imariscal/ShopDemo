import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuComponent } from '../../components/menu/menu.component';
import { HeaderComponent } from '../../components/header/header.component';

@Component({
  selector: 'app-admin-layout',
  imports: [CommonModule, RouterModule, MenuComponent, HeaderComponent],
  templateUrl: './admin-layout.component.html',
  styleUrl: './admin-layout.component.css'
})
export class AdminLayoutComponent {

}
